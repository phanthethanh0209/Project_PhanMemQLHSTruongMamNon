using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NguoiDungDAL
    {
        string conn = null;
        SqlConnection con;

        public NguoiDungDAL()
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
            string sql = "select * from NguoiDung";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layMaNDTOP()
        {
            string sql = "SELECT MAX(MaND) FROM NguoiDung";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layThongTinMotND()
        {
            string sql = "select MaND, TenTK, HoTen, ChucVu from NguoiDung";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layThongTinTheoMa(string MaND)
        {
            string sql = "select * from NguoiDung where MaND= '" + MaND + "'";
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

        public DataTable dangNhap(string tenTK, string password)
        {
            string sql = "SELECT MaND, TenTK, HoTen, MatKhau, TrangThai, GioiTinh FROM NguoiDung WHERE (TenTK = '" + tenTK + "') AND (MatKhau = '" + password + "')";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layTatCaNguoiDung()
        {
            string sql = " SELECT *  FROM NguoiDung";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layNDConHoatDongVaKoCoTrongNhom(string maNhom)
        {
            string sql = " SELECT MaND, TenTK, HoTen FROM NguoiDung WHERE (TrangThai = 1) AND (MaND NOT IN (SELECT MaND FROM NguoiDung_NhomNguoiDung WHERE MaNhomNguoiDung = '" + maNhom + "')) ";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layMotNguoiDung(string maND)
        {
            string sql = " SELECT *  FROM NguoiDung" +
                " WHERE MaND= '" + maND + "' ";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool InsertUser(NguoiDungDTO nv)
        {
            try
            {
                string ngaySinh = nv.NgaySinh.ToString("yyyy-MM-dd");
                string sql = "insert into NguoiDung values( '" + nv.MaND + "', '" + nv.TenTK + "', " +
                                     "CONVERT(VARCHAR(32), HashBytes('MD5', '" + nv.MatKhau + "'), 2), '" +
                                     nv.TrangThai + "', N'" + nv.HoTen + "',  '" + nv.DienThoai + "', N'" +
                                     nv.DiaChi + "', N'" + nv.GioiTinh + "', '" + ngaySinh + "', N'" +
                                     nv.ChucVu + "', '" + nv.Email + "')";

                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


        public bool DeleteUser(string maNV)
        {
            try
            {
                string sql = "delete from NguoiDung where MaND= '" + maNV + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }


        }

        public bool UpdateUser(NguoiDungDTO nv)
        {
            try
            {
                string ngaySinh = nv.NgaySinh.ToString("yyyy-MM-dd");

                string sql = "update NguoiDung set TenTK='" + nv.TenTK + "', MatKhau='" + nv.MatKhau + "', TrangThai='" + nv.TrangThai + "', HoTen='" + nv.HoTen + "', DienThoai= '" + nv.DienThoai + "' " +
                    " DiaChi='" + nv.DiaChi + "', GioiTinh = '" + nv.GioiTinh + "', NgaySinh= '" + ngaySinh + "',  ChucVu='" + nv.ChucVu + "', Email= '" + nv.Email + "' where MaND= '" + nv.MaND + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

        }


        public bool doiMatKhau(string tentk, string mkCu, string mkMoi)
        {
            try
            {
                string sql = "update NguoiDung set MatKhau=CONVERT(VARCHAR(32), HashBytes('MD5', '" + mkMoi + "'), 2) where TenTK='" + tentk + "' and MatKhau = '" + mkCu + "'";
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
