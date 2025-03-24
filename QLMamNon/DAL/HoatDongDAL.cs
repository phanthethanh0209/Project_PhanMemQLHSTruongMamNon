using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HoatDongDAL
    {
        string conn = null;
        SqlConnection con;

        public HoatDongDAL()
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

        public DataTable layTatCaHoatDongTrongNam(string maNamHoc)
        {
            string sql = "select * from HoatDongNgoaiKhoa where MaNamHoc = '" + maNamHoc + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layTatCaHoatDongSapDienRaTrongNam(string maNamHoc)
        {
            string sql = "select * from HoatDongNgoaiKhoa where MaNamHoc = '" + maNamHoc + "' and TrangThaiDK = N'Đang diễn ra'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        
        //public DataTable layTatCaGVTheoMalop(string maLop)
        //{
        //    string sql = "SELECT gv.*, pc.VaiTro FROM GiaoVien gv, PhanCong pc WHERE gv.MaGV = pc.MaGV AND  pc.MaLop= '" + maLop + "'";
        //    SqlDataAdapter da = new SqlDataAdapter(sql, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}

        //public List<GiaoVienDTO> LayGiaoVienChuaPhanCongChoLop(string maLop)
        //{
        //    List<GiaoVienDTO> danhSachGiaoVien = new List<GiaoVienDTO>();
        //    string sql = "SELECT * FROM GiaoVien gv WHERE gv.MaGV NOT IN (SELECT MaGV FROM PhanCong)";

        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@maLop", maLop);

        //    // Mở kết nối
        //    con.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        // Giả sử bạn có hàm tạo GiaoVienDTO từ SqlDataReader
        //        GiaoVienDTO gv = new GiaoVienDTO
        //        {
        //            MaGV = reader["MaGV"].ToString(),
        //            TenGV = reader["TenGV"].ToString(),
        //            GioiTinh = reader["GioiTinh"].ToString(),
        //        };
        //        danhSachGiaoVien.Add(gv);
        //    }

        //    // Đóng reader và kết nối
        //    reader.Close();
        //    con.Close();

        //    return danhSachGiaoVien;
        //}

        public DataTable layThongTinMotHoatDong(string maHD)
        {
            string sql = "select * from HoatDongNgoaiKhoa where MaHD = '" + maHD + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layMaHDCuoiCung(string maHD)
        {
            string sql = "SELECT TOP 1 MaHD FROM HoatDongNgoaiKhoa WHERE MaHD LIKE '" + maHD + "%' ORDER BY MaHD DESC";
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

        public bool themHoatDong(HoatDongDTO hd)
        {

            string ngayThamGia = hd.NgayTG.ToString("yyyy-MM-dd");
            string sql = "insert into HoatDongNgoaiKhoa values( '" + hd.MaHD + "', N'" + hd.TenHDNK + "', '" + ngayThamGia + "', '" + hd.SoTien + "', '" + hd.MaNamHoc + "', N'" + hd.TrangThaiDK + "')";
            return ExcuteNonQuery(sql);
        }

        public bool xoaHoatDong(HoatDongDTO hd)
        {
            string sql = "delete from HoatDongNgoaiKhoa where MaHD= '" + hd.MaHD + "'";
            return ExcuteNonQuery(sql);
        }

        public bool suaHoatDong(HoatDongDTO hd)
        {
            string ngayThamGia = hd.NgayTG.ToString("yyyy-MM-dd");
            string sql = "update HoatDongNgoaiKhoa set TenHDNK = N'" + hd.TenHDNK + "', ngayTG = '" + ngayThamGia + "',SoTien = " + hd.SoTien + ", MaNamHoc = '" + hd.MaNamHoc + "', TrangThaiDK = N'" + hd.TrangThaiDK + "' where MaHD = '" + hd.MaHD + "' ";
            return ExcuteNonQuery(sql);
        }
    }
}
