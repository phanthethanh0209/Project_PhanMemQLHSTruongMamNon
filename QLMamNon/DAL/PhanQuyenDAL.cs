using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhanQuyenDAL
    {
        string conn = null;
        SqlConnection con;

        public PhanQuyenDAL()
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


        //public bool IsValid(PhanQuyenDTO dto)
        //{

        //    Open();
        //    string sql = "select count(*) from PhanQuyen where MaNhom= '" + dto.MaNhom + "' and MaMH= '" + dto.MaMH + "'";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    int so = (int)cmd.ExecuteScalar();

        //    Close();

        //    if (so == 0)
        //        return false;
        //    return true;

        //}

        public DataTable getAll()
        {
            string sql = "select * from PhanQuyen";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        
        public DataTable layDSTenMH(string maNhom)
        {
            string sql = "SELECT * FROM PhanQuyen INNER JOIN DMManHinh ON PhanQuyen.MaMH = DMManHinh.MaMH WHERE (PhanQuyen.MaNhom = '"+ maNhom+"')";
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


        public bool Insert(PhanQuyenDTO dto)
        {
            try
            {
                string sql = "insert into PhanQuyen values( '" + dto.MaNhom + "', '" + dto.MaMH + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            
        }

        public bool Delete(PhanQuyenDTO dto)
        {
            try
            {
                string sql = "delete from PhanQuyen where MaNhom= '" + dto.MaNhom + "' and MaMH= '" + dto.MaMH + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            
        }

        //public bool Update(PhanQuyenDTO dto)
        //{
        //    try
        //    {
        //        string sql = "update PhanQuyen set CoQuyen='" + dto.CoQuyen + "' where MaNhom= '" + dto.MaNhom + "' and MaMH= '" + dto.MaMH + "'";
        //        return ExcuteNonQuery(sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //        return false;
        //    }
        //}



        public DataTable getManHinh(string maNhomND)
        {
            string sql = "select TenMH from PhanQuyen, DMManHinh where PhanQuyen.MaMH= DMManHinh.MaMH and MaNhom= '" + maNhomND + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

           
            return dt;
        }


        public DataTable LayNhomNguoiDungChuaCoManHinh(string maMH)
        {
            string sql = "SELECT MaNhom, TenNhom FROM NhomNguoiDung AS nnd WHERE (MaNhom NOT IN (SELECT MaNhom FROM PhanQuyen AS pq WHERE (MaMH = '"+maMH+"')))";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);


            return dt;
        }

        public DataTable LayNhomNguoiDungCoManHinh(string maMH)
        {
            string sql = "SELECT NhomNguoiDung.MaNhom, NhomNguoiDung.TenNhom, DMManHinh.TenMH FROM NhomNguoiDung INNER JOIN PhanQuyen ON NhomNguoiDung.MaNhom = PhanQuyen.MaNhom INNER JOIN DMManHinh ON PhanQuyen.MaMH = DMManHinh.MaMH WHERE(PhanQuyen.MaMH = '"+maMH+"')";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);


            return dt;
           
        }
    }
}
