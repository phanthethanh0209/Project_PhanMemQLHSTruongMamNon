using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DanhGiaThangDAL
    {
        string conn = null;
        SqlConnection con;

        public DanhGiaThangDAL()
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

        public DataTable layThongTinDanhGiaThangCua1HS(string malop, string maHS, int thang)
        {
            string sql = "select * from DanhGiaThang where MaHS = '" + maHS + "' and MaLop = '" + malop + "' and Thang= '" + thang + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layDSHSDaDanhGia(string malop, int thang)
        {
            string sql = "Select * from DanhGiaThang where Thang = '" + thang + "' and MaLop = '" + malop + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable layDSHSDatPhieu(string malop, int thang)
        {
            string sql = "Select * from DanhGiaThang where Thang = '" + thang + "' and MaLop = '" + malop + "' and DatPhieuChauNgoanBH=1";
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

        public bool Insert(DanhGiaThangDTO gv)
        {
            string sql = "insert into DanhGiaThang values( '" + gv.MaDanhGiaThang + "', '" + gv.MaHS + "', '" + gv.MaLop + "', '" + gv.Thang + "', '" + gv.DatPhieuChauNgoanBH + "', N'" + gv.NoiDung + "')";
            return ExcuteNonQuery(sql);
        }


        public DataTable layTongSoPhieuBacHoCuaNam(string maHS, string maLop)
        {
            string sql = "Select Count(*) As TongSoPhieu from DanhGiaThang where maHS = '" + maHS + "' and MaLop = '" + maLop + "'" +
                " And DatPhieuChauNgoanBH = 1";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable demSoLanDanhGia(string maHS, string maLop)
        {
            string sql = "Select Count(*) As SoLanDanhGia from DanhGiaThang where MaHS = '" + maHS + "' and MaLop = '" + maLop + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
