using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhongHocDAL
    {
        string conn = null;
        SqlConnection con;

        public PhongHocDAL()
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

        public DataTable layTatCaPhongHoc()
        {
            string sql = "select * from PhongHoc";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layThongTin1PhongHoc(string maPhong)
        {
            string sql = "select * from PhongHoc where MaPhong= '" + maPhong + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layThongTin1PhongHocTheoTenPhong(string tenPhong)
        {
            string sql = "select * from PhongHoc where TenPhong= '" + tenPhong + "'";
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


        public string LayMaPhongLonNhat()
        {
            string sql = "SELECT MAX(MaPhong) FROM PhongHoc";
            SqlCommand cmd = new SqlCommand(sql, con);
            Open();

            string maPhong = cmd.ExecuteScalar()?.ToString();
            Close();

            if (maPhong != null)
            {
                string soCuoi = maPhong.Substring(2);
                int soPhong = int.Parse(soCuoi);
                soPhong++;

                return "PH" + soPhong.ToString("D3");
            }

            return "PH001";
        }


        public int demSoPhong()
        {
            Open();

            string sql = "SELECT COUNT(*) FROM PhongHoc";
            SqlCommand cmd = new SqlCommand(sql, con);

            int count = (int)cmd.ExecuteScalar();

            Close();
            return count;
        }

        public bool themPhongHoc(PhongHocDTO ph)
        {
            try
            {
                string sql = "insert into PhongHoc values( '" + ph.MaPhong + "', N'" + ph.TenPhong + "', '" + ph.SucChua + "', N'" + ph.ViTri + "', N'" + ph.TinhTrang + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool xoaPhongHoc(PhongHocDTO ph)
        {
            try
            {
                string sql = "delete from PhongHoc where MaPhong= '" + ph.MaPhong + "'";
                return ExcuteNonQuery(sql);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool suaPhongHoc(PhongHocDTO ph)
        {
            try
            {
                string sql = "update PhongHoc set TenPhong= N'" + ph.TenPhong + "', SucChua=" + ph.SucChua + ", ViTri= N'" + ph.ViTri + "', TinhTrang= N'" + ph.TinhTrang + "' where MaPhong = '" + ph.MaPhong + "'";
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
