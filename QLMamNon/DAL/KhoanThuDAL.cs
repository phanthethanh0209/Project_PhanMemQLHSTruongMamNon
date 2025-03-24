using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class KhoanThuDAL
    {
        string conn = null;
        SqlConnection con;

        public KhoanThuDAL()
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

        public DataTable layTatCaKhoanThuTrongNamHoc(string maNH)
        {
            string sql = "select * from KhoanThu where MaNamHoc= '"+maNH+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable lay1KhoanThu(string maKT)
        {
            string sql = "select * from KhoanThu where MaKhoanThu= '" + maKT + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layMaKTCuoiCung(string maNH)
        {
            string ma ="KT" + maNH.Trim().Substring(2);
            string sql = "SELECT TOP 1 MaKhoanThu FROM KhoanThu WHERE MaKhoanThu LIKE '"+ma+"%' ORDER BY MaKhoanThu DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool Insert(KhoanThuDTO pc)
        {
            try
            {
                string sql = "insert into KhoanThu values( '" + pc.MaKhoanThu + "', '" + pc.MaNamHoc + "', N'" + pc.TenKhoanThu + "', '"+pc.SoTien+"')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

        }

        public bool Update(KhoanThuDTO kthu)
        {
            try
            {
                string sql = "Update KhoanThu set MaNamHoc= '"+kthu.MaNamHoc+"', TenKhoanThu= N'"+kthu.TenKhoanThu+"', SoTien= '"+kthu.SoTien+"' where MaKhoanThu= '" + kthu.MaKhoanThu + "' ";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

        }

        public bool Delete(string maKhoanThu)
        {
            try
            {
                string sql = "Delete from KhoanThu where MaKhoanThu= '" + maKhoanThu + "' ";
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
