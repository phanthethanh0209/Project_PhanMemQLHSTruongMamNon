using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CTPhieuHocPhiDAL
    {
        string conn = null;
        SqlConnection con;

        public CTPhieuHocPhiDAL()
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

        public DataTable layCTHocPhiTheoMaPhieuHP(string maPhieuHP)
        {
            string sql = "select * from CTPhieuHocPhi where MaPhieuHP= '"+maPhieuHP+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool Insert(CTPhieuHocPhiDTO pc)
        {
            try
            {
                string sql = "insert into CTPhieuHocPhi values( '" + pc.MaPhieuHP + "', '" + pc.MaKhoanThu + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

        }

        public bool Delete(CTPhieuHocPhiDTO ct)
        {
            try
            {
                string sql = "Delete from CTPhieuHocPhi where MaPhieuHP= '" + ct.MaPhieuHP + "' AND MaKhoanThu= '"+ct.MaKhoanThu+"' ";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

        }

        public bool ExcuteNonQuery(string pQuery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(pQuery, con);
            int so = cmd.ExecuteNonQuery();

            Close();
            return so > 0;
        }
    }
}
