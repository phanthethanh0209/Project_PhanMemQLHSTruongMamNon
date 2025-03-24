using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ThongKeHSDAL
    {
        string conn = null;
        SqlConnection con;

        public ThongKeHSDAL()
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

        public DataTable ThongKeHSDatKhenThuong(string maLop)
        {
            string sql = "SELECT " +
                         "lh.TenLop, " +
                         "hs.MaHS, " +
                         "hs.HoTen, " +
                         "pl.XepLoai " +
                         "FROM PhanLop pl " +
                         "JOIN HocSinh hs ON pl.MaHS = hs.MaHS " +
                         "JOIN LopHoc lh ON pl.MaLop = lh.MaLop " +
                         "WHERE (pl.XepLoai = N'Bé ngoan' OR pl.XepLoai = N'Bé ngoan xuất sắc') " +
                         "AND lh.MaLop = '"+ maLop + "'" +
                         "GROUP BY lh.TenLop, hs.MaHS, hs.HoTen, pl.XepLoai;";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable InThongKeHSDatKhenThuong(string maNamHoc, string tenNamHoc, string maLop)
        {
            string sql = "SELECT " +
                         "lh.TenLop, " +
                         "hs.MaHS, " +
                         "hs.HoTen, " +
                         "pl.XepLoai " +
                         "FROM PhanLop pl " +
                         "JOIN HocSinh hs ON pl.MaHS = hs.MaHS " +
                         "JOIN LopHoc lh ON pl.MaLop = lh.MaLop " +
                         "WHERE (pl.XepLoai = N'Bé ngoan' OR pl.XepLoai = N'Bé ngoan xuất sắc') " +
                         "AND lh.MaLop = '" + maLop + "'" +
                         "GROUP BY lh.TenLop, hs.MaHS, hs.HoTen, pl.XepLoai;";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add("Nam", typeof(string)); // Thêm cột "Nam" kiểu string
            // Duyệt qua từng dòng và gán giá trị cho cột "Nam"
            foreach (DataRow row in dt.Rows)
            {
                row["Nam"] = tenNamHoc;
            }
            return dt;
        }
        public DataTable ThongKeTongSoHSDuocKhenThuong(string maNamHoc)
        {
            string sql = "SELECT " +
                         "lh.TenLop, " +
                         "COUNT(pl.MaHS) AS TongSoHsDatKhenThuong " +
                         "FROM PhanLop pl " +
                         "JOIN LopHoc lh ON pl.MaLop = lh.MaLop " +
                         "WHERE pl.XepLoai = N'Bé ngoan' " +
                         "AND lh.MaNamHoc = '" + maNamHoc + "' " +
                         "GROUP BY lh.TenLop;";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ThongKeHSQueQuan(string maNamHoc)
        {
            string sql = "SELECT " +
                         "hs.QueQuan, " +
                         "hs.NoiSinh, " +
                         "COUNT(hs.MaHS) AS SoHocSinh " +
                         "FROM HoSoHocSinh hs " +
                         "JOIN PhanLop pl ON hs.MaHS = pl.MaHS " +
                         "JOIN LopHoc lh ON pl.MaLop = lh.MaLop " +
                         "WHERE lh.MaNamHoc = '" + maNamHoc + "' " +
                         "GROUP BY hs.QueQuan, hs.NoiSinh;";
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
    }
}
