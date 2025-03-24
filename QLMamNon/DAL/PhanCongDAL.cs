using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhanCongDAL
    {
        string conn = null;
        SqlConnection con;

        public PhanCongDAL()
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
            string sql = "select * from PhanCong";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layGVChuaPhanCongTrongNam(string maNamHoc)
        {
            string sql = "SELECT * FROM GiaoVien gv, NguoiDung nd WHERE gv.MaGV= nd.MaND And ChucVu like N'Giáo viên%' " +
                "AND gv.MaGV NOT IN (SELECT MaGV FROM PhanCong p, LopHoc l where p.MaLop = l.MaLop and l.MaNamHoc = '" + maNamHoc + "')";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public int ktraGVPhanCongChua(string malop, string maGV)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM PhanCong WHERE MaLop = '" + malop + "'      AND MaGV = '" + maGV + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }




        public DataTable layGVDaPhanCongTheoLop(string maLop)
        {
            string sql = "SELECT * FROM GiaoVien gv, NguoiDung nd, PhanCong p WHERE gv.MaGV= nd.MaND " +
                "AND gv.MaGV = p.MaGV And MaLop = '" + maLop + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layGVHoTroTheoLop(string maLop)
        {
            string vaiTro = "Giáo viên hỗ trợ";
            string sql = "select * from PhanCong p, GiaoVien gv where p.MaGV = gv.MaGV " +
                "and MaLop = '" + maLop + "' and VaiTro Like N'" + vaiTro + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layGVPhuTrachTheoLop(string maLop)
        {
            string vaiTro = "Giáo viên phụ trách";
            string sql = "select * from PhanCong p, GiaoVien gv where p.MaGV = gv.MaGV " +
                "and MaLop = '" + maLop + "' and VaiTro Like N'" + vaiTro + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layLopGVDayTrongNamHT(string magv, string namHocHT)
        {
            string sql = "select * from PhanCong p, LopHoc l, KeHoach k" +
                " where p.MaLop = l.MaLop and l.MaKhoi = k.MaKhoi and l.MaNamHoc = k.MaNamHoc" +
                " and l.MaNamHoc = '" + namHocHT + "' and MaGV = '" + magv + "' ";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //public DataTable lay(string magv, string maNamHoc)
        //{
        //    string sql = "select * from PhanCong p, LopHoc l, NamHoc n " +
        //        "where l.MaLop = p.MaLop and n.MaNamHoc = l.MaNamHoc " +
        //        "and MaGV = '" + magv + "' and n.MaNamHoc = '" + maNamHoc + '";
        //    SqlDataAdapter da = new SqlDataAdapter(sql, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}

        public bool Insert(PhanCongDTO pc)
        {
            try
            {
                string sql = "insert into PhanCong values( '" + pc.MaLop + "', '" + pc.MaGV + "', N'" + pc.VaiTro + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool Delete(PhanCongDTO pc)
        {
            try
            {
                string sql = "Delete from PhanCong where MaLop= '" + pc.MaLop + "' AND MaGV= '" + pc.MaGV + "'";
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
    }
}
