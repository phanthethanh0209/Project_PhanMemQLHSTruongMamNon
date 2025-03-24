using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NhomNguoiDungDAL
    {
        string conn = null;
        SqlConnection con;

        public NhomNguoiDungDAL()
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


        public bool IsValid(NhomNguoiDungDTO nhomND)
        {

            Open();
            string sql = "select count(*) from NhomNguoiDung where MaNhom= '" + nhomND.MaNhom + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int so = (int)cmd.ExecuteScalar();

            Close();

            if (so == 0)
                return false;
            return true;

        }

        public DataTable getAll()
        {
            string sql = "select * from NhomNguoiDung";
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


        public bool InsertRole(NhomNguoiDungDTO nhomND)
        {
            string sql = "insert into NhomNguoiDung values( '" + nhomND.MaNhom + "', '" + nhomND.TenNhom + "', '" + nhomND.GhiChu + "')";
            return ExcuteNonQuery(sql);
        }

        public bool DeleteRole(string maNhom)
        {
            string sql = "delete from NhomNguoiDung where MaNhom= '" + maNhom + "'";
            return ExcuteNonQuery(sql);
        }

        public bool UpdateRole(NhomNguoiDungDTO nhomND)
        {
            string sql = "update NhomNguoiDung set TenNhom='" + nhomND.TenNhom + "', GhiChu= '" + nhomND.GhiChu + "' where MaNhom= '" + nhomND.MaNhom + "'";
            return ExcuteNonQuery(sql);
        }
    }
}
