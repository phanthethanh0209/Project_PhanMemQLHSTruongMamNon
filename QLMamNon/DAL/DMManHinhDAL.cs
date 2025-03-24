using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DMManHinhDAL
    {
        string conn = null;
        SqlConnection con;

        public DMManHinhDAL()
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


        //public bool IsValid(DMManHinhDTO manHinh)
        //{

        //    Open();
        //    string sql = "select count(*) from DMManHinh where MaMH= '" + manHinh.MaMH + "'";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    int so = (int)cmd.ExecuteScalar();

        //    Close();

        //    if (so == 0)
        //        return false;
        //    return true;

        //}

        public DataTable getAll()
        {
            string sql = "select * from DMManHinh";
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


        public bool InsertScreen(DMManHinhDTO manHinh)
        {
            try
            {
                string sql = "insert into DMManHinh values( '" + manHinh.MaMH + "', N'" + manHinh.TenMH + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            
        }

        public bool DeleteScreen(string maMH)
        {
            try
            {
                string sql = "delete from DMManHinh where MaMH= '" + maMH + "'";
            return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            
        }

        public bool UpdateScreen(DMManHinhDTO manHinh)
        {
            try
            {
                string sql = "update DMManHinh set TenMH= '" + manHinh.TenMH + "' where MaMH='" + manHinh.MaMH + "'";
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
