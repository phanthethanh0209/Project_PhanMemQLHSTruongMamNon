using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HoSoHocSinhDAL
    {
        string conn = null;
        SqlConnection con;

        public HoSoHocSinhDAL()
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


        public DataTable layHoSoMotHocSinh(string maHS)
        {
            string sql = " SELECT * FROM HoSoHocSinh h" +
                " WHERE h.MaHS = '" + maHS + "'";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable layTatCaHoSoHS()
        {
            string sql = "select * from HoSoHocSinh";
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


        public bool themHoSoHocSinh(HoSoHocSinhDTO hs)
        {
            try
            {
                string sql = "insert into HoSoHocSinh values( '" + hs.MaHS + "', '" + hs.MaDinhDanh + "', N'" + hs.QuocTich + "', N'" + hs.DanToc + "', N'" + hs.TonGiao + "', N'" + hs.QueQuan + "', N'" + hs.NoiSinh + "', N'" + hs.TinhTrangSucKhoe + "', '" + hs.DonXinNhapHoc + "' , '" + hs.GiayKhaiSinh + "' )";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool xoaHoSoHocSinh(string maNV)
        {
            try
            {
                string sql = "delete from HoSoHocSinh where MaHS= '" + maNV + "'";
                return ExcuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }


        }

        public bool suaHoSoHocSinh(HoSoHocSinhDTO hs)
        {
            try
            {
                string sql = "update HoSoHocSinh set MaDinhDanh ='" + hs.MaDinhDanh + "', QuocTich=N'" + hs.QuocTich + "', DanToc=N'" + hs.DanToc + "', TonGiao=N'" + hs.TonGiao + "', QueQuan=N'" + hs.QueQuan + "', NoiSinh=N'" + hs.NoiSinh + "', TinhTrangSucKhoe=N'" + hs.TinhTrangSucKhoe + "', DonXinNhapHoc=N'" + hs.DonXinNhapHoc + "', GiayKhaiSinh=N'" + hs.GiayKhaiSinh + "' where MaHS= '" + hs.MaHS + "'";
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
