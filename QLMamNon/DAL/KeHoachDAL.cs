using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class KeHoachDAL
    {

        string conn = null;
        SqlConnection con;

        public KeHoachDAL()
        {
            conn = Settings1.Default.ChuoiKN;
            con = new SqlConnection(conn);
        }

        public void Open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public DataTable getAll()
        {
            string sql = "select * from KeHoach";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool ExcuteNonQuery(string pQuery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(pQuery, con);
            int so = cmd.ExecuteNonQuery();

            Close();
            return so > 0;
        }

        public DataTable layTTKeHoach(string maNamHoc, string maKhoi)
        {
            string sql = "select * from KeHoach where MaNamHoc = '" + maNamHoc + "' and MaKhoi = '" + maKhoi + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layDSKhoiLopTrongNamHoc(string maNamHoc)
        {
            string sql = "select * from KeHoach where MaNamHoc = '" + maNamHoc + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public bool themKeHoach(KeHoachDTO k)
        {
            try
            {
                string sql = "insert into KeHoach values( '" + k.MaNamHoc + "', '" + k.MaKhoi + "', '" + k.SoLopMo + "', '" + k.TongHS + "', '" + k.SiSoToiThieu + "', '" + k.SiSoToiDa + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool suaKeHoach(KeHoachDTO k)
        {
            try
            {
                string sql = "update KeHoach set SoLopMo= '"+k.SoLopMo+ "', TongHS= '" + k.TongHS + "', SiSoToiThieu= '" + k.SiSoToiThieu + "', SiSoToiDa= '" + k.SiSoToiDa + "' where MaNamHoc = '"+k.MaNamHoc+"' and MaKhoi = '"+k.MaKhoi+"'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}
