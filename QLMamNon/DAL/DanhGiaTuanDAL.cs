using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DanhGiaTuanDAL
    {
        string conn = null;
        SqlConnection con;

        public DanhGiaTuanDAL()
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

        public DataTable layThongTinDanhGiaTuanCua1HS(string malop, string maHS, int tuan, int thang)
        {

            string sql = "select * from DanhGiaTuan where MaHS = '" + maHS + "' and MaLop = '" + malop + "' and Tuan= '" + tuan + "' and Thang= '" + thang + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layTuanDanhGiaMoi(string malop, int thang)
        {

            string sql = "Select max(Tuan) as Tuan from DanhGiaTuan where Thang = '" + thang + "' and MaLop = '" + malop + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int demSoTuanDanhGia(string malop, string maHS, int thang)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM DanhGiaTuan WHERE MaHS = '" + maHS + "'      AND MaLop = '" + malop + "' AND Thang= '" + thang + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }

        public DataTable layDSHSDaDanhGia(string malop, int thang, int tuan)
        {

            string sql = "Select * from DanhGiaTuan where Thang = '" + thang + "' and MaLop = '" + malop + "' and Tuan = '" + tuan + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Đếm phiếu bé ngoan đã đạt được trong 1 tháng
        public int demDatPhieuBeNgoan(string malop, string maHS, int thang)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM DanhGiaTuan WHERE MaHS = '" + maHS + "' AND MaLop = '" + malop + "' AND Thang = '" + thang + "' AND DatPhieuBeNgoan=1";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }

        //Cho phép sửa đánh giá trong vòng 3 ngày
        public int kiemTraDanhGia3Ngay(string malop, string maHS, int thang, int tuan)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM DanhGiaTuan " +
                "WHERE MaHS = '" + maHS + "' " +
                "AND MaLop = '" + malop + "' " +
                "AND Thang = '" + thang + "' AND Tuan = '" + tuan + "' " +
                "AND DATEDIFF(day, NgayDG, GETDATE()) <= 3";

            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }

        //Lấy tuần đánh giá gần nhất của tháng đó
        public int layTuanDGGanNhatCuaThang(string malop, int thang)
        {
            Open();

            string sql = "SELECT Max(Tuan) FROM DanhGiaTuan " +
                "WHERE MaLop = '" + malop + "' " +
                "AND Thang = '" + thang + "' ";

            SqlCommand cmd = new SqlCommand(sql, con);

            object result = cmd.ExecuteScalar();
            int count = result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);

            Close();
            return count;
        }

        public bool ExcuteNonQuery(string pQuery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(pQuery, con);
            int so = cmd.ExecuteNonQuery();

            Close();
            return so > 0;
        }

        public bool Insert(DanhGiaTuanDTO gv)
        {
            try
            {
                string ngayDG = gv.NgayDG.ToString("yyyy-MM-dd");
                string sql = "insert into DanhGiaTuan values( '" + gv.MaDanhGiaTuan + "', '" + gv.MaHS + "', '" + gv.MaLop + "', '" + gv.Tuan + "', '" + gv.DatPhieuBeNgoan + "', N'" + gv.NoiDung + "', '" + gv.Thang + "', '" + ngayDG + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool Update(DanhGiaTuanDTO dg)
        {
            try
            {
                string ngayDG = dg.NgayDG.ToString("yyyy-MM-dd");

                string sql = "update DanhGiaTuan set MaHS='" + dg.MaHS + "', MaLop='" + dg.MaLop + "', " +
                    "Tuan='" + dg.Tuan + "', DatPhieuBeNgoan='" + dg.DatPhieuBeNgoan + "', NoiDung=N'" + dg.NoiDung + "', Thang= '" + dg.Thang + "', " +
                    "NgayDG= '" + ngayDG + "' WHERE MaDanhGiaTuan ='" + dg.MaDanhGiaTuan + "'";
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
