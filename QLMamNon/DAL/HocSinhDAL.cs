using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HocSinhDAL
    {
        string conn = null;
        SqlConnection con;

        public HocSinhDAL()
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

        public DataTable layTatCaHocSinh()
        {
            string sql = "select * from HocSinh";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layTatCaHocSinhTheoMaLop(string maLop)
        {
            string sql = " SELECT *  FROM HocSinh hs, PhanLop pl" +
                " WHERE hs.MaHS = pl.MaHS AND pl.MaLop= '" + maLop + "' ";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layTatCaHocSinhTheoMaLopCoQuocTich(string maLop)
        {
            string sql = " SELECT *  FROM HocSinh hs, HoSoHocSinh hoS, PhanLop pl" +
                " WHERE hs.MaHS = pl.MaHS AND hs.MaHS = hoS.MaHS AND pl.MaLop= '" + maLop + "' ";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layTatCaHocSinhChuaPhanLop()
        {
            string sql = " SELECT *  FROM HocSinh h" +
                " WHERE h.NgayKetThuc is null AND h.MaHS NOT IN (SELECT p.MaHS FROM PHANLOP p)"; // Lấy học sinh không có lớp

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layThongTinMotHocSinh(string maHS)
        {
            string sql = " SELECT * FROM HocSinh h" +
                " WHERE h.MaHS = '" + maHS + "'";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layMaHSCuoiCung(string maNH)
        {
            string sql = "SELECT TOP 1 MaHS FROM HocSinh WHERE MaHS LIKE 'HS" + maNH + "%' ORDER BY MaHS DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Học sinh còn đi học- theo độ tuổi- chưa phân lớp
        public DataTable layTatCaHocSinhTheoDoTuoi(int tuoiMin, int tuoiMax)
        {
            string sql = "SELECT * FROM HocSinh h " +
                         "WHERE ( h.NgayKetThuc is null OR NgayKetThuc = '1900-01-01')  " +
                         "AND DATEDIFF(YEAR, h.NgaySinh, GETDATE()) >= '" + tuoiMin + "' " +
                         "AND DATEDIFF(YEAR, h.NgaySinh, GETDATE()) <= '" + tuoiMax + "' " +
                         "AND h.MaHS NOT IN (SELECT p.MaHS FROM PHANLOP p) ";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable timKiemHocSinhTheoMaTenLop(string search, string maLop)
        {
            string sql = "SELECT * FROM HocSinh hs, PhanLop pl " +
                "WHERE hs.MaHS = pl.MaHS And pl.MaLop = '" + maLop + "' " +
                "AND (hs.MaHS = '" + search + "' OR hs.HoTen LIKE N'%" + search + "%' OR hs.HoTen LIKE N'" + search + " %' OR hs.HoTen LIKE N'% " + search + "' )";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        //Xử lý biên lai thanh toán
        public DataTable timKiemHocSinhTheoMaHoacTen(string search)
        {
            string sql = "SELECT * FROM HocSinh " +
                "WHERE (MaHS = '" + search + "' OR HoTen LIKE N'%" + search + "%' OR HoTen LIKE N'" + search + " %' OR HoTen LIKE N'% " + search + "' )";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        //Học sinh toàn trường - còn đi học - theo độ tuổi
        public DataTable layHocSihToanTruongTheoDoTuoi(int tuoiMin, int tuoiMax)
        {
            string sql = "SELECT * FROM HocSinh h " +
                         "WHERE (h.NgayKetThuc is null OR NgayKetThuc = '1900-01-01') " +
                         "AND DATEDIFF(YEAR, h.NgaySinh, GETDATE()) >= '" + tuoiMin + "' " +
                         "AND DATEDIFF(YEAR, h.NgaySinh, GETDATE()) <= '" + tuoiMax + "' ";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Học sinh toàn trường - còn đi học
        public DataTable layHocSinhToanTruong()
        {
            string sql = "SELECT * FROM HocSinh h WHERE NgayKetThuc is null OR NgayKetThuc = '1900-01-01'";

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


        public bool themHocSinh(HocSinhDTO hs)
        {
            try
            {
                string ngaySinh = hs.NgaySinh.ToString("yyyy-MM-dd");
                string ngayNhapHoc = hs.NgayNhapHoc.ToString("yyyy-MM-dd");
                string sql = "insert into HocSinh values( '" + hs.MaHS + "', '" + hs.MaPH1 + "', '" + hs.MaPH2 + "', N" +
                    "'" + hs.HoTen + "', N'" + hs.GioiTinh + "', '" + ngaySinh + "', N'" + hs.DiaChi + "', '" + hs.ChieuCao + "'," +
                    "'" + hs.HinhAnh + "', '" + hs.CanNang + "', '" + ngayNhapHoc + "', N'" + hs.GhiChu + "', N'" + hs.TinhTrang + "', '" + hs.NgayKetThuc + "')"; //ngày kết thúc khi thêm luôn là null
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool xoaHocSinh(string maHS)
        {
            try
            {
                string sql = "delete from HocSinh where MaHS= '" + maHS + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool CapNhatTrangThai(HocSinhDTO hs)
        {
            string sql = "update HocSinh set TinhTrang = N'" + hs.TinhTrang + "' Where MaHS = '" + hs.MaHS + "'";
            return ExcuteNonQuery(sql);
        }

        public bool suaHocSinh(HocSinhDTO hs)
        {
            try
            {
                string ngaySinh = hs.NgaySinh.ToString("yyyy-MM-dd");
                string ngayNhapHoc = hs.NgayNhapHoc.ToString("yyyy-MM-dd");
                if (hs.NgayKetThuc != null)
                {
                    string ngayKetThuc = hs.NgayKetThuc?.ToString("yyyy-MM-dd");
                }

                string sql = "update HocSinh set MaPH1 ='" + hs.MaPH1 + "', MaPH2='" + hs.MaPH2 + "', HoTen=N'" + hs.HoTen + "', " +
                    "GioiTinh=N'" + hs.GioiTinh + "', NgaySinh='" + ngaySinh + "', DiaChi=N'" + hs.DiaChi + "', ChieuCao= '" + hs.ChieuCao + "', " +
                    "HinhAnh= '" + hs.HinhAnh + "', CanNang= '" + hs.CanNang + "', NgayNhapHoc= '" + ngayNhapHoc + "', GhiChu= N'" + hs.GhiChu + "', " +
                    "TinhTrang= N'" + hs.TinhTrang + "', NgayKetThuc= N'" + hs.NgayKetThuc + "' where MaHS= '" + hs.MaHS + "'";
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
