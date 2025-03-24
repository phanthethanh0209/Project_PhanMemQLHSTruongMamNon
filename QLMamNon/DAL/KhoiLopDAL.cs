using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class KhoiLopDAL
    {
        string conn = null;
        SqlConnection con;

        public KhoiLopDAL()
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
            string sql = "select * from KhoiLop";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layKhoiLopTrongNam(string namhoc)
        {
            string sql = "select * from KhoiLop l, KeHoach k where l.MaKhoi = k.MaKhoi and MaNamHoc = '" + namhoc + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layKhoiLopTrongNamTheoDoTuoi(string tuoi, string namhoc)
        {
            string sql = "select * from KhoiLop l, KeHoach k where l.MaKhoi = k.MaKhoi and MaNamHoc = '" + namhoc + "' and DoTuoi = '" + tuoi + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layTenKhoiTheoMa(string maKhoi)
        {
            string sql = "select * from KhoiLop where MaKhoi = '" + maKhoi + "'";
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

        public DataTable layMaKhoiTheoTenKhoi(string tenKhoi)
        {
            string sql = "select * from KhoiLop where TenKhoi like N'%" + tenKhoi + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
