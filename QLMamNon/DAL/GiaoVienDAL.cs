using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class GiaoVienDAL
    {
        string conn = null;
        SqlConnection con;

        public GiaoVienDAL()
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
            string sql = "select * from GiaoVien";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layTatCaGVTheoMalop(string maLop)
        {
            string sql = "SELECT gv.*, pc.VaiTro, nd.* FROM GiaoVien gv, PhanCong pc, NguoiDung nd WHERE nd.MaND = gv.MaGV AND gv.MaGV = pc.MaGV AND  pc.MaLop= '" + maLop + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int demSoGV(string maND)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM GiaoVien WHERE MaGV = '" + maND + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }

        public List<GiaoVienDTO> LayGiaoVienChuaPhanCongChoLop(string maLop)
        {
            List<GiaoVienDTO> danhSachGiaoVien = new List<GiaoVienDTO>();
            string sql = "SELECT * FROM GiaoVien gv WHERE gv.MaGV NOT IN (SELECT MaGV FROM PhanCong)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@maLop", maLop);

            // Mở kết nối
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // Giả sử bạn có hàm tạo GiaoVienDTO từ SqlDataReader
                GiaoVienDTO gv = new GiaoVienDTO
                {
                    MaGV = reader["MaGV"].ToString(),
                    TenGV = reader["TenGV"].ToString(),
                    GioiTinh = reader["GioiTinh"].ToString(),
                };
                danhSachGiaoVien.Add(gv);
            }

            // Đóng reader và kết nối
            reader.Close();
            con.Close();

            return danhSachGiaoVien;
        }

        public DataTable layThongTinMotGV(string maGV)
        {
            string sql = "select * from GiaoVien gv , NguoiDung nd where gv.MaGV = nd.MaND and gv.MaGV = '" + maGV + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layGVPhuTrachTheoLop(string maLop)
        {
            string vaiTro = "Giáo viên phụ trách";
            string sql = "select * from PhanCong p, GiaoVien gv, NguoiDung nd " +
                "where p.MaGV = gv.MaGV And gv.MaGV = nd.MaND And MaLop = '" + maLop + "' And VaiTro = N'" + vaiTro + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable kiemTraNDLaGV(string magv)
        {
            string sql = "select* from GiaoVien where MaGV = '" + magv + "'";
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

        public bool InsertUser(GiaoVienDTO gv)
        {

            string ngaySinh = gv.NgaySinh.ToString("yyyy-MM-dd");
            string sql = "insert into GiaoVien values( '" + gv.MaGV + "', N'" + gv.TrinhDo + "', N'" + gv.ChuyenMon + "', N'" + gv.NoiDaoTao + "')";
            return ExcuteNonQuery(sql);
        }

        public bool DeleteUser(GiaoVienDTO gv)
        {
            string sql = "delete from GiaoVien where MaNV= '" + gv.MaGV + "'";
            return ExcuteNonQuery(sql);
        }

        public bool UpdateUser(GiaoVienDTO gv)
        {
            string sql = "update GiaoVien set TrinhDo='" + gv.TrinhDo + "',ChuyenMon='" + gv.ChuyenMon + "',NoiDaoTao='" + gv.NoiDaoTao + "' where MaGV= '" + gv.MaGV + "'";
            return ExcuteNonQuery(sql);
        }
    }
}
