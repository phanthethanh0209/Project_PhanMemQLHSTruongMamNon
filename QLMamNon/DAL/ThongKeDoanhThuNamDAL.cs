using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace DAL
{
    public class ThongKeDoanhThuNamDAL
    {
        string conn = null;
        SqlConnection con;

        public ThongKeDoanhThuNamDAL()
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

        public DataTable ThongKeDoanhThuHPTheoNam(string maNH)
        {
            string sql = "SELECT NH.MaNamHoc AS MaNamHoc, KL.TenKhoi AS TenKhoi, LH.TenLop AS TenLop, " +
                 "SUM(PHP.TongTien) AS TienHP," +
                 "SUM(CASE WHEN PHP.TrangThaiThanhToan = 1 THEN PHP.TongTien ELSE 0 END) AS TienDaThu, " +
                 "SUM(CASE WHEN PHP.TrangThaiThanhToan = 0 THEN PHP.TongTien ELSE 0 END) AS TienChuaThu " +
                 "FROM [dbo].[PhieuHocPhi] PHP " +
                 "JOIN [dbo].[LopHoc] LH ON PHP.MaLop = LH.MaLop " +
                 "JOIN [dbo].[KhoiLop] KL ON LH.MaKhoi = KL.MaKhoi " +
                 "JOIN [dbo].[NamHoc] NH ON LH.MaNamHoc = NH.MaNamHoc " +
                 "WHERE NH.MaNamHoc = '" + maNH + "' " +
                 "GROUP BY NH.MaNamHoc, KL.TenKhoi, LH.TenLop " +
                 "ORDER BY NH.MaNamHoc, KL.TenKhoi, LH.TenLop";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable InThongKeDoanhThuHPTheoNam(string maNH, string tenNamHoc)
        {
            string sql = "SELECT NH.MaNamHoc AS MaNamHoc, KL.TenKhoi AS TenKhoi, LH.TenLop AS TenLop, " +
                 "SUM(PHP.TongTien) AS TienHP," +
                 "SUM(CASE WHEN PHP.TrangThaiThanhToan = 1 THEN PHP.TongTien ELSE 0 END) AS TienDaThu, " +
                 "SUM(CASE WHEN PHP.TrangThaiThanhToan = 0 THEN PHP.TongTien ELSE 0 END) AS TienChuaThu " +
                 "FROM [dbo].[PhieuHocPhi] PHP " +
                 "JOIN [dbo].[LopHoc] LH ON PHP.MaLop = LH.MaLop " +
                 "JOIN [dbo].[KhoiLop] KL ON LH.MaKhoi = KL.MaKhoi " +
                 "JOIN [dbo].[NamHoc] NH ON LH.MaNamHoc = NH.MaNamHoc " +
                 "WHERE NH.MaNamHoc = '" + maNH + "' " +
                 "GROUP BY NH.MaNamHoc, KL.TenKhoi, LH.TenLop " +
                 "ORDER BY NH.MaNamHoc, KL.TenKhoi, LH.TenLop";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add("Nam", typeof(string)); // Thêm cột "Nam" kiểu string
            // Duyệt qua từng dòng và gán giá trị cho cột "Nam"
            foreach (DataRow row in dt.Rows)
            {
                row["Nam"] = tenNamHoc;
            }
            return dt;
        }
        public DataTable ThongKeDoanhThuHDTheoNam(string maNH)
        {
            string sql = "SELECT HDNK.MaNamHoc, " +
                         "HDNK.TenHDNK AS TenHoatDong, " +
                         "HDNK.NgayTG AS NgayToChuc, " +
                         "COALESCE(SUM(TGNK.TienNhan), 0) AS DoanhThuHoatDong, " +
                         "(SELECT COALESCE(SUM(TGNK1.TienNhan), 0) " +
                         " FROM [dbo].[ThamGiaNgoaiKhoa] TGNK1 " +
                         " JOIN [dbo].[HoatDongNgoaiKhoa] HDNK1 ON TGNK1.MaHD = HDNK1.MaHD " +
                         " WHERE HDNK1.MaNamHoc = HDNK.MaNamHoc) AS TongDoanhThu " +
                         "FROM [dbo].[HoatDongNgoaiKhoa] HDNK " +
                         "LEFT JOIN [dbo].[ThamGiaNgoaiKhoa] TGNK ON HDNK.MaHD = TGNK.MaHD " +
                         "WHERE HDNK.MaNamHoc = '" + maNH + "' " +
                         "GROUP BY HDNK.MaNamHoc, HDNK.TenHDNK, HDNK.NgayTG " +
                         "ORDER BY HDNK.MaNamHoc, HDNK.NgayTG;";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable InThongKeDoanhThuHDTheoNam(string maNH, string tongTienBangChu, string tenNamHoc)
        {
            string sql = "SELECT HDNK.MaNamHoc, " +
                         "HDNK.TenHDNK AS TenHoatDong, " +
                         "HDNK.NgayTG AS NgayToChuc, " +
                         "COALESCE(SUM(TGNK.TienNhan), 0) AS DoanhThuHoatDong, " +
                         "(SELECT COALESCE(SUM(TGNK1.TienNhan), 0) " +
                         " FROM [dbo].[ThamGiaNgoaiKhoa] TGNK1 " +
                         " JOIN [dbo].[HoatDongNgoaiKhoa] HDNK1 ON TGNK1.MaHD = HDNK1.MaHD " +
                         " WHERE HDNK1.MaNamHoc = HDNK.MaNamHoc) AS TongDoanhThu " +
                         "FROM [dbo].[HoatDongNgoaiKhoa] HDNK " +
                         "LEFT JOIN [dbo].[ThamGiaNgoaiKhoa] TGNK ON HDNK.MaHD = TGNK.MaHD " +
                         "WHERE HDNK.MaNamHoc = '" + maNH + "' " +
                         "GROUP BY HDNK.MaNamHoc, HDNK.TenHDNK, HDNK.NgayTG " +
                         "ORDER BY HDNK.MaNamHoc, HDNK.NgayTG;";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add("TongTienBangChu", typeof(string));
            // Duyệt qua từng dòng và gán giá trị cho cột "Nam"
            dt.Columns.Add("Nam", typeof(string)); // Thêm cột "Nam" kiểu string
            // Duyệt qua từng dòng và gán giá trị cho cột "Nam"
            foreach (DataRow row in dt.Rows)
            {
                row["TongTienBangChu"] = tongTienBangChu;
                row["Nam"] = tenNamHoc;
            }
            return dt;
        }

        public DataTable ThongKeDoanhThuHPTheoThang(string maNH, string thang)
        {
            string sql =
                "SELECT NH.MaNamHoc AS MaNamHoc, " +
                "KL.TenKhoi AS TenKhoi, " +
                "LH.TenLop AS TenLop, " +
                "PHP.Thang AS Thang, " +
                "SUM(PHP.TongTien) AS TienHP, " +
                "SUM(CASE WHEN PHP.TrangThaiThanhToan = 1 THEN PHP.TongTien ELSE 0 END) AS TienDaThu, " +
                "SUM(CASE WHEN PHP.TrangThaiThanhToan = 0 THEN PHP.TongTien ELSE 0 END) AS TienChuaThu " +
                "FROM [dbo].[PhieuHocPhi] PHP " +
                "JOIN [dbo].[LopHoc] LH ON PHP.MaLop = LH.MaLop " +
                "JOIN [dbo].[KhoiLop] KL ON LH.MaKhoi = KL.MaKhoi " +
                "JOIN [dbo].[NamHoc] NH ON LH.MaNamHoc = NH.MaNamHoc " +
                "WHERE NH.MaNamHoc = '" + maNH + "' AND PHP.Thang = '" + thang + "' " +
                "GROUP BY NH.MaNamHoc, KL.TenKhoi, LH.TenLop, PHP.Thang " +
                "ORDER BY NH.MaNamHoc, KL.TenKhoi, LH.TenLop, PHP.Thang";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable InThongKeDoanhThuHPTheoThang(string maNH, string tenNamHoc, string thang)
        {
            string sql = "SELECT NH.MaNamHoc AS MaNamHoc, " +
                "KL.TenKhoi AS TenKhoi, " +
                "LH.TenLop AS TenLop, " +
                "PHP.Thang AS Thang, " +
                "SUM(PHP.TongTien) AS TienHP, " +
                "SUM(CASE WHEN PHP.TrangThaiThanhToan = 1 THEN PHP.TongTien ELSE 0 END) AS TienDaThu, " +
                "SUM(CASE WHEN PHP.TrangThaiThanhToan = 0 THEN PHP.TongTien ELSE 0 END) AS TienChuaThu " +
                "FROM [dbo].[PhieuHocPhi] PHP " +
                "JOIN [dbo].[LopHoc] LH ON PHP.MaLop = LH.MaLop " +
                "JOIN [dbo].[KhoiLop] KL ON LH.MaKhoi = KL.MaKhoi " +
                "JOIN [dbo].[NamHoc] NH ON LH.MaNamHoc = NH.MaNamHoc " +
                "WHERE NH.MaNamHoc = '" + maNH + "' AND PHP.Thang = '" + thang + "' " +
                "GROUP BY NH.MaNamHoc, KL.TenKhoi, LH.TenLop, PHP.Thang " +
                "ORDER BY NH.MaNamHoc, KL.TenKhoi, LH.TenLop, PHP.Thang";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //dt.Columns.Add("TongTienBangChu", typeof(string));
            // Duyệt qua từng dòng và gán giá trị cho cột "Nam"
            dt.Columns.Add("Nam", typeof(string)); // Thêm cột "Nam" kiểu string
            foreach (DataRow row in dt.Rows)
            {
                //row["TongTienBangChu"] = tongTienBangChu;
                row["Nam"] = tenNamHoc;
            }
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
    }
}
