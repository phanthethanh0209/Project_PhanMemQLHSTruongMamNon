using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LopHocDAL
    {
        string conn = null;
        SqlConnection con;

        public LopHocDAL()
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
            string sql = "select * from LopHoc";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable getLopHocTheoNam(string maNamHoc)
        {
            string sql = "select TenLop, MaLop, MaKhoi from LopHoc where MaNamHoc = '" + maNamHoc + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable getLopHocTheoMa(string maLop)
        {
            string sql = "select * from LopHoc where MaLop = '" + maLop + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable layLopHocTheoKeHoach(string maKhoi, string maNamHoc)
        {
            string sql = "select * from LopHoc where MaKhoi = '" + maKhoi + "' and MaNamHoc = '" + maNamHoc + "'";
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
        public bool themLopHoc(LopHocDTO lh)
        {
            string sql = "insert into LopHoc values( '" + lh.MaLop + "', '" + lh.MaKhoi + "', '" + lh.MaNamHoc + "', N'" + lh.TenLop + "', '" + lh.SiSo + "', '" + lh.MaPhong + "')";
            return ExcuteNonQuery(sql);
        }

        public bool capNhatLopHoc(LopHocDTO lh)
        {
            string sql = "update LopHoc set Siso = " + lh.SiSo + " where MaLop = '" + lh.MaLop + "' and MaKhoi = '" + lh.MaKhoi + "'";
            return ExcuteNonQuery(sql);
        }


        public bool suaLopHoc(LopHocDTO lh)
        {
            string sql = "update LopHoc set MaKhoi = '" + lh.MaKhoi + "', MaNamHoc = '" + lh.MaNamHoc + "', TenLop= N'"+lh.TenLop+"', Siso = " + lh.SiSo + ", MaPhong= '"+lh.MaPhong+"' where MaLop = '" + lh.MaLop + "'";
            return ExcuteNonQuery(sql);
        }

        public bool xoaLopHoc(string maLop)
        {
            string sql = "delete from LopHoc where MaLop= '" + maLop + "'";
            return ExcuteNonQuery(sql);
        }

    }

    //public bool InsertLopHoc(LopHocDTO lh)
    //{
    //    string ngaykhaigiang = lh.NgayKhaiGiang.ToString("yyyy-MM-dd");
    //    string ngayketthuc = lh.NgayKetThuc.ToString("yyyy-MM-dd");
    //    string sql = "insert into LopHoc values( '" + lh.MaLop + "', '" + lh.MaKhoi + "', '" + lh.TenLop + "', '" + lh.SiSo + "', '" + ngaykhaigiang + "', '" + ngayketthuc + "')";
    //    return ExcuteNonQuery(sql);
    //}



    //public bool UpdateLopHoc(LopHocDTO lophoc)
    //{
    //    throw new NotImplementedException();
    //}
}
