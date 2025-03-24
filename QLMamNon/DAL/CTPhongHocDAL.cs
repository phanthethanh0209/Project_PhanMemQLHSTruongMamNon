using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CTPhongHocDAL
    {
        string conn = null;
        SqlConnection con;

        public CTPhongHocDAL()
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


        public bool themCTPhong(CTPhongHocDTO ph)
        {
            string sql = "insert into CTPhongHoc values( '" + ph.MaPhong + "', '" + ph.MaLop + "')";
            return ExcuteNonQuery(sql);
        }
    }
}
