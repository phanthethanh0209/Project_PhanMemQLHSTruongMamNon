using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ChiTietKeHoachDAL
    {
        string conn = null;
        SqlConnection con;

        public ChiTietKeHoachDAL()
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
            string sql = "select * from ChiTietKeHoach";
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

        public bool InsertKeHoach(ChiTietKeHoachDTO kh)
        {
            string sql = "insert into ChiTietKeHoach values( '" + kh.MaCTKeHoach + "', '" + kh.TenKhoi + "', '" + kh.SoLuongLop + "', '" + kh.SoLuongHS + "', '" + kh.HocPhi + "', '" + kh.TienAn + "')";
            return ExcuteNonQuery(sql);
        }

        //public bool DeleteKeHoach(KeHoachDTO gv)
        //{
        //    string sql = "delete from GiaoVien where MaNV= '" + gv.Ma + "'";
        //    return ExcuteNonQuery(sql);
        //}

        public bool UpdateKeHoach(ChiTietKeHoachDTO kh)
        {
            string sql = "update ChiTietKeHoach set MaCTKeHoach='" + kh.MaCTKeHoach + "', TenKhoi='" + kh.TenKhoi + "', SoLuongLop='" + kh.SoLuongLop + "', SoLuongHS='" + kh.SoLuongHS + "', HocPhi='" + kh.HocPhi + "', TienAn='" + kh.TienAn + "'";
            return ExcuteNonQuery(sql);
        }
    }
}
