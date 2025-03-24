using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NamHocDAL
    {
        string conn = null;
        SqlConnection con;

        public NamHocDAL()
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
            string sql = "select * from NamHoc";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layThongTinCua1NamHoc(string maNamHoc)
        {
            string sql = "select * from NamHoc where MaNamHoc = '"+maNamHoc+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layNamHocTruoc(string namhoc)
        {
            string sql = "select * from NamHoc where TenNamHoc Like '%" + namhoc + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable layNamHocMoi()
        {
            string ngayHienTai = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "select * from NamHoc where '"+ngayHienTai+"' BETWEEN NgayDB AND NgayKT";
            //string sql = "select * from NamHoc where MaNamHoc = 'NH2324'";
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

        public bool themNamHoc(NamHocDTO namHoc)
        {
            try
            {
                string ngayBD = namHoc.NgayDB.ToString("yyyy-MM-dd");
                string ngayKT = namHoc.NgayKT.ToString("yyyy-MM-dd");
                string sql = "insert into NamHoc values( '" + namHoc.MaNamHoc + "', '" + namHoc.TenNamHoc + "', '" + ngayBD + "', '" + ngayKT + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


        public bool suaNamHoc(NamHocDTO namHoc)
        {
            try
            {
                string ngayBD = namHoc.NgayDB.ToString("yyyy-MM-dd");
                string ngayKT = namHoc.NgayKT.ToString("yyyy-MM-dd");
               
                string sql = "update NamHoc set TenNamHoc = '"+ namHoc.TenNamHoc+"', NgayDB= '" +ngayBD+"', NgayKT= '"+ngayKT+"' where MaNamHoc= '" + namHoc.MaNamHoc + "'";
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
