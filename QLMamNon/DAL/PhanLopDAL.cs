using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhanLopDAL
    {
        string conn = null;
        SqlConnection con;

        public PhanLopDAL()
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

        public DataTable layDSHSChuaPhanLop(string malop, string namHoc)
        {
            //string sql = "select * from PhanLop p, HocSinh h, LopHoc l where p.MaHS = h.MaHS and l.MaLop = '" + malop + "'" +
            //    "and l.MaNamHoc = '" + namHoc + "' and h.MaHS NOT IN (SELECT p.MaHS FROM PHANLOP p)";
            string sql = "select * from PhanLop p, HocSinh h where p.MaHS = h.MaHS and p.MaLop = '" + malop + "'" +
                " and h.MaHS NOT IN (SELECT p.MaHS FROM PHANLOP p, LopHoc l where l.MaLop = p.MaLop and l.MaNamHoc = '" + namHoc + "')";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layTatCaHocSinhTheoMaLop(string maLop)
        {
            string sql = " SELECT *  FROM PhanLop pl" +
                " WHERE pl.MaLop= '" + maLop + "' ";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int demSoHSTrong1Khoi(string maNamHoc, string tenKhoi)
        {
            Open();

            string sql = "SELECT COUNT(*) FROM LopHoc l, PhanLop p, KhoiLop k " +
                "WHERE l.MaLop = p.MaLop and l.MaKhoi = k.MaKhoi " +
                "and l.MaNamHoc = '" + maNamHoc + "' and k.TenKhoi = N'" + tenKhoi + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

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

        public bool Insert(PhanLopDTO gv)
        {
            string sql = "insert into PhanLop values( '" + gv.MaHS + "', '" + gv.MaLop + "', NULL, NULL)";
            return ExcuteNonQuery(sql);
        }

        public bool CapNhatTTCuoiNam(PhanLopDTO pl)
        {
            string sql = "update PhanLop set DanhGia = N'" + pl.DanhGia + "', XepLoai = N'" + pl.XepLoai + "' Where MaHS = '" + pl.MaHS + "' and MaLop = '" + pl.MaLop + "'";
            return ExcuteNonQuery(sql);
        }


        public DataTable layThongTinDanhGia(string maHS, string maLop)
        {
            string sql = "Select * from PhanLop where MaHS = '" + maHS + "' and MaLop = '" + maLop + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool Delete(PhanLopDTO pc)
        {
            try
            {
                string sql = "Delete from PhanLop where MaLop= '" + pc.MaLop + "' AND MaHS= '" + pc.MaHS + "'";
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
