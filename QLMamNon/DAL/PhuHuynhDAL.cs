using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhuHuynhDAL
    {
        string conn = null;
        SqlConnection con;

        public PhuHuynhDAL()
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

        public DataTable layTatCaPhuHuynh()
        {
            string sql = "select * from PhuHuynh";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layThongTinMotPhuHuynh(string maPH)
        {
            string sql = " SELECT * FROM PhuHuynh h" +
                " WHERE h.MaPH = '" + maPH + "'";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layMaPHCuoiCung(string maHS)
        {
            string sql = "SELECT TOP 1 MaPH FROM PhuHuynh WHERE MaPH LIKE 'PH" + maHS + "%' ORDER BY MaPH DESC";
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


        public bool themPhuHuynh(PhuHuynhDTO ph)
        {
            try
            {
                string sql = "insert into PhuHuynh values( '" + ph.MaPH + "', N'" + ph.HoTen + "', N'" + ph.GioiTinh + "', " +
                    "'" + ph.NamSinh + "', N'" + ph.DiaChiCQ + "', N'" + ph.NgheNghiep + "', '" + ph.DienThoai + "', '" + ph.Email + "', N'" + ph.QuanHe + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool xoaPhuHuynh(string maPH)
        {
            try
            {
                string sql = "delete from PhuHuynh where MaPH= '" + maPH + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }


        }

        public bool suaPhuHuynh(PhuHuynhDTO hs)
        {
            try
            {
                string sql = "update PhuHuynh set HoTen=N'" + hs.HoTen + "', GioiTinh=N'" + hs.GioiTinh + "', NamSinh=N'" + hs.NamSinh + "', " +
                    "DiaChiCQ=N'" + hs.DiaChiCQ + "', NgheNghiep= N'" + hs.NgheNghiep + "', " +
                    "DienThoai= '" + hs.DienThoai + "', Email= '" + hs.Email + "', QuanHe= N'" + hs.QuanHe + "' Where MaPH = '" + hs.MaPH + "'";
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
