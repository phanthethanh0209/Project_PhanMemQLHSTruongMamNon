using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DiemDanhDAL
    {

        string conn = null;
        SqlConnection con;

        public DiemDanhDAL()
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
            string sql = "select * from DiemDanh";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layThongTinDiemDanhTheoNgay(string maLop, string ngayDiemDanh, string timKiem)
        {
            string sql = "SELECT pl.MaHS, d.MaDiemDanh, d.NgayDiemDanh, d.GhiChu, d.VangKPhep FROM PhanLop AS pl " +
                "LEFT JOIN DiemDanh AS d ON d.MaHS = pl.MaHS AND d.NgayDiemDanh = '" + ngayDiemDanh + "'" +
                "LEFT JOIN HocSinh AS s ON pl.MaHS = s.MaHS " +
                " WHERE pl.MaLop = '" + maLop + "' ";

            if (timKiem != null)
                if (timKiem.StartsWith("HS"))
                {
                    sql += "and d.MaHS Like '" + timKiem + "%'";
                }
                else
                {
                    sql += "and HoTen Like N'%" + timKiem + "%'";
                }

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layTatCaHSVangTheoNgay(string maLop, string ngayDiemDanh)
        {
            string sql = "SELECT * FROM DiemDanh where MaLop = '" + maLop + "' and ngayDiemDanh = '" + ngayDiemDanh + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable timKiemHocSinhTheoMaTenNgay(string maLop, string ngayDiemDanh, string timKiem)
        {
            string sql = "SELECT * FROM PhanLop AS pl " +
                "LEFT JOIN DiemDanh AS d ON d.MaHS = pl.MaHS AND d.NgayDiemDanh = '" + ngayDiemDanh + "' " +
                "LEFT JOIN HocSinh AS s ON pl.MaHS = s.MaHS " +
                "WHERE pl.MaLop = '" + maLop + "' ";

            if (timKiem != string.Empty)
                if (timKiem.StartsWith("HS"))
                {
                    sql += "and d.MaHS Like '" + timKiem + "%'";
                }
                else
                {
                    sql += "and HoTen Like N'%" + timKiem + "%'";
                }

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable timKiemHocSinhTheoMaTen(string maLop, string timKiem)
        {
            string sql = "SELECT pl.MaHS, d.MaDiemDanh, d.NgayDiemDanh, d.GhiChu, d.VangKPhep FROM PhanLop AS pl " +
                "LEFT JOIN DiemDanh AS d ON d.MaHS = pl.MaHS " +
                " WHERE pl.MaLop = '" + maLop + "' ";

            if (timKiem != string.Empty)
                if (timKiem.StartsWith("HS"))
                {
                    sql += "and d.MaHS Like '" + timKiem + "%'";
                }
                else
                {
                    sql += "and HoTen Like N'%" + timKiem + "%'";
                }

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int demSoNgayVangCua1HS(string malop, string maHS, int thang)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM DiemDanh WHERE MaHS = '" + maHS + "'      AND MaLop = '" + malop + "' AND MONTH(NgayDiemDanh)= '" + thang + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }


        public int demSoHSVangTheoNgay(string malop, string ngayDiemDanh)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM DiemDanh WHERE NgayDiemDanh = '" + ngayDiemDanh + "' and MaLop = '" + malop + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }

        public DataTable LayThongTinHocSinh(string maGV)
        {
            string sql = @"
            SELECT hs.MaHS, hs.HoTen, hs.GioiTinh
            FROM GiaoVien gv
            JOIN PhanCong pc ON gv.MaGV = pc.MaGV
            JOIN LopHoc lh ON pc.MaLop = lh.MaLop
            JOIN PhanLop pl ON lh.MaLop = pl.MaLop
            JOIN HocSinh hs ON pl.MaHS = hs.MaHS
            WHERE gv.MaGV = @MaGV AND lh.MaNamHoc = 'NH2425';";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaGV", maGV);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string GetNamHoc()
        {
            return DateTime.Now.Year.ToString();
        }
        public DataTable GetKhoiLopAndLopHoc(string maGV)
        {
            string sql = @"
            SELECT kl.TenKhoi AS TenKhoiLop, lh.TenLop AS TenLopHoc 
            FROM GiaoVien gv
            JOIN PhanCong pc ON gv.MaGV = pc.MaGV
            JOIN LopHoc lh ON pc.MaLop = lh.MaLop
            JOIN KhoiLop kl ON lh.MaKhoi = kl.MaKhoi
            WHERE gv.MaGV = @MaGV";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaGV", maGV);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LayThongTinDiemDanh()
        {
            string sql = @"
    SELECT 
        dd.MaLop, 
        dd.MaHS, 
        dd.NgayDiemDanh, 
        dd.VangKPhep, 
        dd.GhiChu 
    FROM DiemDanh dd"; // Điều chỉnh nếu cần

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string GetGVPhuTrach(string maGV)
        {
            string sql = "SELECT TenGV FROM GiaoVien WHERE MaGV = @MaGV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaGV", maGV);
            Open();
            string gvPhuTrach = cmd.ExecuteScalar()?.ToString();
            Close();
            return gvPhuTrach;
        }

        public bool ExcuteNonQuery(string pQuery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(pQuery, con);
            int so = cmd.ExecuteNonQuery();

            Close();
            return so > 0;
        }



        public bool InsertDiemDanh(DiemDanhDTO dd)
        {
            string ngayDiemDanh = dd.NgayDiemDanh?.ToString("yyyy-MM-dd");
            string sql = "insert into DiemDanh values( '" + dd.MaDiemDanh + "', '" + dd.MaLop + "', '" + dd.MaHS + "', '" + ngayDiemDanh + "', '" + dd.VangKPhep + "', N'" + dd.GhiChu + "')";
            return ExcuteNonQuery(sql);
        }

        public bool capNhatDiemDanh(DiemDanhDTO dd)
        {
            string sql = "Update DiemDanh set VangKPhep = " + dd.VangKPhep + " , GhiChu = N'" + dd.GhiChu + "' Where MaDiemDanh = '" + dd.MaDiemDanh + "'";
            return ExcuteNonQuery(sql);
        }

        public bool xoaDiemDanh(DiemDanhDTO dd)
        {
            string sql = "Delete From DiemDanh where MaDiemDanh = '" + dd.MaDiemDanh + "'";
            return ExcuteNonQuery(sql);
        }
    }
}
