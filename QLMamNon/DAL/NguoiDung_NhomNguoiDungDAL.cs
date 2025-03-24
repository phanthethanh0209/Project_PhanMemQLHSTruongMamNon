using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NguoiDung_NhomNguoiDungDAL
    {
        string conn = null;
        SqlConnection con;

        public NguoiDung_NhomNguoiDungDAL()
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

        public bool ExcuteNonQuery(string pQuery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(pQuery, con);
            int so = cmd.ExecuteNonQuery();

            Close();
            return so > 0;
        }

        //Load lên dgv theo combobox trong frmND_NhomND
        public DataTable layNguoiDungTheoMaNhom(string maNhom)
        {
            string sql = "select * from NguoiDung_NhomNguoiDung ndn, NguoiDung nd where ndn.MaND = nd.MaND and MaNhomNguoiDung= '" + maNhom + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool themND_NhomND(NguoiDung_NhomNguoiDungDTO dto)
        {
            try
            {
                string sql = "insert into NguoiDung_NhomNguoiDung values( '" + dto.MaND + "', '" + dto.MaNhomNguoiDung + "', '" + dto.GhiChu + "')";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool xoaND_NhomND(NguoiDung_NhomNguoiDungDTO dto)
        {
            try
            {
                string sql = "delete from NguoiDung_NhomNguoiDung where MaND= '" + dto.MaND + "' and MaNhomNguoiDung= '" + dto.MaNhomNguoiDung + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public DataTable layDSMaNhomTuTenTK(string maND)
        {
            string sql = "select * from NguoiDung_NhomNguoiDung ndn, NguoiDung nd " +
                "where ndn.MaND = nd.MaND and nd.MaND= '" + maND + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
