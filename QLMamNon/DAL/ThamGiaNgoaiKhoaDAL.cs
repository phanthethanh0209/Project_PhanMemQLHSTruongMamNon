using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ThamGiaNgoaiKhoaDAL
    {
        string conn = null;
        SqlConnection con;

        public ThamGiaNgoaiKhoaDAL()
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

        public int demSoHSThamGiaToanTruong(string maHD)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM ThamGiaNgoaiKhoa WHERE MaHD = '" + maHD + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }



        public DataTable timKiemHocSinhTheoMaHoacTen(string search, string maHD, string maLop)
        {
            string sql = "SELECT* FROM HocSinh hs " +
                "INNER JOIN PhanLop pl ON pl.MaHS = hs.MaHS AND pl.MaLop = '" + maLop + "' " +
                "LEFT JOIN ThamGiaNgoaiKhoa tg ON hs.MaHS = tg.MaHS AND tg.MaHD = '" + maHD + "' " +
                "WHERE hs.MaHS = '" + search + "' OR hs.HoTen LIKE N'%" + search + "%' OR hs.HoTen LIKE N'" + search + "%' OR hs.HoTen LIKE N'%" + search + "'";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layDSHSThamGiaNgoaiKhoaTheoTrangThaiDK(string trangThai, string maHD, string maLop)
        {
            string sql = "";
            if (trangThai == "Tất cả")
            {
                sql = "SELECT* FROM HocSinh hs INNER JOIN PhanLop pl ON pl.MaHS = hs.MaHS AND pl.MaLop = '" + maLop + "' " +
                "LEFT JOIN ThamGiaNgoaiKhoa tg ON hs.MaHS = tg.MaHS AND tg.MaHD = '" + maHD + "'";
            }
            else if (trangThai == "Đã đăng ký")
            {
                sql = "SELECT* FROM HocSinh hs " +
                "INNER JOIN PhanLop pl ON pl.MaHS = hs.MaHS AND pl.MaLop = '" + maLop + "' " +
                "LEFT JOIN ThamGiaNgoaiKhoa tg ON hs.MaHS = tg.MaHS AND tg.MaHD = '" + maHD + "' " +
                "WHERE tg.MaHD IS NOT NULL";
            }
            else
            {
                sql = "SELECT* FROM HocSinh hs " +
                "INNER JOIN PhanLop pl ON pl.MaHS = hs.MaHS AND pl.MaLop = '" + maLop + "' " +
                "LEFT JOIN ThamGiaNgoaiKhoa tg ON hs.MaHS = tg.MaHS AND tg.MaHD = '" + maHD + "' " +
                "WHERE tg.MaHD IS NULL";
            }


            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int demSoHSThamGiaHD(string maLop, string maHD)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM HocSinh hs " +
                "INNER JOIN PhanLop pl ON pl.MaHS = hs.MaHS AND pl.MaLop = '" + maLop + "' " +
                "LEFT JOIN ThamGiaNgoaiKhoa tg ON hs.MaHS = tg.MaHS AND tg.MaHD = '" + maHD + "' " +
                "WHERE tg.MaHD IS NOT NULL";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }


        public DataTable layThongTinThamGiaHoatDongCua1HS(string maHD, string maHS)
        {
            string sql = "select * from ThamGiaNgoaiKhoa where MaHD = '" + maHD + "' and MaHS = '" + maHS + "'";
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

        public bool Insert(ThamGiaNgoaiKhoaDTO gv)
        {
            try
            {
                string date = gv.NgayDK.ToString("yyyy-MM-dd");
                string sql = "insert into ThamGiaNgoaiKhoa values( '" + gv.MaTTHD + "', '" + date + "', '" + gv.MaHD + "', '" + gv.MaHS + "', '" + gv.TienNhan + "', '" + gv.MaND + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool Delete(ThamGiaNgoaiKhoaDTO pc)
        {
            try
            {
                string sql = "Delete from ThamGiaNgoaiKhoa where MaTTHD= '" + pc.MaTTHD + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public int ktraDaThanhToan(string maHD, string maHS)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM ThamGiaNgoaiKhoa WHERE MaHS = '" + maHS + "'      AND MaHD = '" + maHD + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }
    }
}
