using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CauHinhDAL
    {
        public void Save(CauHinhDTO config)
        {
            Settings1.Default.ChuoiKN = "Data Source ='" + config.ServerName + "';Initial Catalog='" + config.DatabaseName + "'; User ID= '" + config.User + "'; Pwd= " + config.Password;
            Settings1.Default.Save();
        }

        public DataTable GetDatabase(CauHinhDTO config)
        {
            try
            {
                DataTable dt = new DataTable();
                string conn = "Data Source ='" + config.ServerName + "';Initial Catalog=master; User ID= '" + config.User + "'; Pwd=" + config.Password;
                string sql = "select name from sys.Databases";
                SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
                adap.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
