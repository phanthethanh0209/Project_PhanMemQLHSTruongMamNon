using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhieuHocPhiDAL
    {
        string conn = null;
        SqlConnection con;

        public PhieuHocPhiDAL()
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
            string sql = "select * from PhieuHocPhi";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layPhieuHocPhiCua1HS(string maHS, string maLop, int thang)
        {
            string sql = "select * from PhieuHocPhi where MaLop= '" + maLop + "' and MaHS= '" + maHS + "' and Thang= '" + thang + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layPhieuHocPhiVaTTCuaTatCaHS(string maLop, int thang)
        {
            string sql = "select * from PhieuHocPhi p, HocSinh h where MaLop= '" + maLop + "' and Thang= '" + thang + "' and p.MaHS = h.MaHS";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int demSoPhieuHocPhi(int thang, string maNH)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM PhieuHocPhi php, LopHoc lh WHERE php.MaLop = lh.MaLop AND php.Thang= '" + thang + "' AND lh.MaNamHoc = '" + maNH + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }

        //Thanh toán
        //Xử lý biên lai thanh toán
        public DataTable timKiemHocSinhTheoMaHoacTen(string search, int thang, string maLop)
        {
            string sql = "SELECT * FROM HocSinh hs, PhieuHocPhi php WHERE hs.MaHS = php.MaHS " +
                "AND php.MaLop = '" + maLop + "' AND php.Thang = '" + thang + "' " +
                "AND (hs.MaHS = '" + search + "' OR hs.HoTen LIKE N'% " + search + " %' OR hs.HoTen LIKE N'" + search + " %' OR hs.HoTen LIKE N'% " + search + "')";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layDSHSThanhToanTheoTrangThai(string trangThai, int thang, string maLop)
        {
            string sql = "SELECT * FROM HocSinh hs, PhieuHocPhi php WHERE hs.MaHS = php.MaHS " +
                "AND php.MaLop = '" + maLop + "' AND php.Thang = '" + thang + "'";

            if (trangThai == "Chưa thanh toán")
            {
                sql += " AND php.TrangThaiThanhToan= 0";
            }
            else if (trangThai == "Đã thanh toán")
            {
                sql += " AND php.TrangThaiThanhToan= 1";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int demSoHSChuaThanhToanHocPhi(string maLop, int thang)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM PhieuHocPhi php " +
                "WHERE php.MaLop = '" + maLop + "' AND php.Thang = '" + thang + "'AND php.TrangThaiThanhToan = 0";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }


        public int laySoBuoiHocCuaThang(string maNamHoc, int thang)
        {
            Open();

            string sql = "SELECT DISTINCT SoBuoiHocTrongThang FROM PhieuHocPhi php, LopHoc lh WHERE php.MaLop = lh.MaLop " +
                         "AND lh.MaNamHoc = '" + maNamHoc + "' AND php.Thang = '" + thang + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            object result = cmd.ExecuteScalar();

            Close();

            return result != DBNull.Value ? Convert.ToInt32(result) : -1;
        }




        public bool Insert(PhieuHocPhiDTO pc)
        {
            try
            {
                //Trạng thái tt = 0, ngayTT và tienNhan = null
                string date = pc.NgayLapPhieu.ToString("yyyy-MM-dd HH:mm:ss");
                string sql = "insert into PhieuHocPhi values( '" + pc.MaPhieuHP + "', '" + pc.MaHS + "', '" + pc.MaLop + "', " +
                    "'" + pc.MaNV + "', '" + date + "', 0 , '" + pc.Thang + "', '" + pc.SoNgayHSVang + "', " +
                    "'" + pc.SoNgayHSHoc + "', '" + pc.TongTien + "',  null , null, '" + pc.SoBuoiHocTrongThang + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

        }

        public bool Update(double tienNhan, string maPHP)
        {
            try
            {
                string ngayThanhToan = DateTime.Now.ToString("yyyy-MM-dd");

                string sql = "update PhieuHocPhi set TienNhan ='" + tienNhan + "', NgayThanhToan='" + ngayThanhToan + "', TrangThaiThanhToan= '1'" +
                    " where MaPhieuHP= '" + maPHP + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


        public bool Delete(string maPhieuHP)
        {
            try
            {
                string sql = "Delete from PhieuHocPhi where MaPhieuHP= '" + maPhieuHP + "' ";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

        }

        public bool ExcuteNonQuery(string pQuery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(pQuery, con);
            int so = cmd.ExecuteNonQuery();

            Close();
            return so > 0;
        }


        public DataTable inPhieuHPTheoThang(string maLop, int thang)
        {
            Open();

            string sql = "SELECT hs.MaHS, hs.HoTen, l.TenLop, php.SoBuoiHocTrongThang, php.Thang, php.SoNgayHSHoc, php.TongTien, TenKhoanThu, SoTien, TenNamHoc, php.NgayLapPhieu, nd.HoTen AS TenNguoiLap " +
                " FROM PhieuHocPhi php, HocSinh hs, LopHoc l, KhoanThu kt, CTPhieuHocPhi ct, NamHoc nh, NguoiDung nd" +
                " WHERE php.MaHS = hs.MaHS AND php.MaLop = l.MaLop AND ct.MaPhieuHP = php.MaPhieuHP And kt.MaNamHoc = nh.MaNamHoc" +
                " And nd.MaND = php.MaND" +
                " And ct.MaKhoanThu = kt.MaKhoanThu And php.Thang = @Thang And php.MaLop = @MaLop"; // Thêm điều kiện WHERE
            SqlCommand lenh = new SqlCommand(sql, con);
            lenh.Parameters.AddWithValue("@MaLop", maLop);
            lenh.Parameters.AddWithValue("@Thang", thang);

            SqlDataAdapter da = new SqlDataAdapter(lenh); // Gắn SqlCommand vào SqlDataAdapter
            DataTable dt = new DataTable("PhieuHP");
            da.Fill(dt);

            // Duyệt qua từng dòng và gán giá trị cho cột "Nam"
            foreach (DataRow row in dt.Rows)
            {
                //if ()
                //row["ThangThu"] = ""; // Gán giá trị cho cột "Nam"
            }


            Close();

            return dt;
        }

        public DataTable inPhieuHPTheoHS(string maPhieu, string tongTienBangChu, double tienThua)
        {
            Open();

            string sql = "SELECT hs.MaHS, hs.HoTen, l.TenLop, php.SoBuoiHocTrongThang, php.Thang, php.SoNgayHSHoc, php.TongTien," +
                " TenKhoanThu, SoTien, TenNamHoc, php.NgayLapPhieu, nd.HoTen AS TenNguoiLap, NgayThanhToan, TienNhan " +
                " FROM PhieuHocPhi php, HocSinh hs, LopHoc l, KhoanThu kt, CTPhieuHocPhi ct, NamHoc nh, NguoiDung nd" +
                " WHERE php.MaHS = hs.MaHS AND php.MaLop = l.MaLop AND ct.MaPhieuHP = php.MaPhieuHP And kt.MaNamHoc = nh.MaNamHoc" +
                " And nd.MaND = php.MaND" +
                " And ct.MaKhoanThu = kt.MaKhoanThu And php.MaPhieuHP = @MaPhieu"; // Thêm điều kiện WHERE
            SqlCommand lenh = new SqlCommand(sql, con);
            lenh.Parameters.AddWithValue("@MaPhieu", maPhieu);


            SqlDataAdapter da = new SqlDataAdapter(lenh); // Gắn SqlCommand vào SqlDataAdapter
            DataTable dt = new DataTable("PhieuThanhToanHP");

            da.Fill(dt);

            dt.Columns.Add("TongTienBangChu", typeof(string)); // Thêm cột "Nam" kiểu string
            dt.Columns.Add("TienThua", typeof(double)); // Thêm cột "Nam" kiểu string

            // Duyệt qua từng dòng và gán giá trị cho cột "Nam"
            foreach (DataRow row in dt.Rows)
            {
                row["TongTienBangChu"] = tongTienBangChu;
                row["TienThua"] = tienThua;
            }

            Close();

            return dt;
        }
    }

}
