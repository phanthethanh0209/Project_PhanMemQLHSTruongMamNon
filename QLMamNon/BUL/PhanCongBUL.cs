using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class PhanCongBUL
    {
        PhanCongDAL phanCongDAL = new PhanCongDAL();
        public List<PhanCongDTO> layGVChuaPhanCongTrongNam(string maNamHoc)
        {
            DataTable table = phanCongDAL.layGVChuaPhanCongTrongNam(maNamHoc);
            List<PhanCongDTO> lst = new List<PhanCongDTO>();
            PhanCongDTO dto = new PhanCongDTO();
            foreach (DataRow row in table.Rows)
            {
                string maGV = row["MaGV"].ToString();
                string HoTen = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();

                dto = new PhanCongDTO(maGV, HoTen, gioiTinh);
                lst.Add(dto);
            }

            return lst;
        }


        public List<PhanCongDTO> layGVDaPhanCongTheoLop(string maLopp)
        {
            DataTable table = phanCongDAL.layGVDaPhanCongTheoLop(maLopp);
            List<PhanCongDTO> lst = new List<PhanCongDTO>();
            PhanCongDTO dto = new PhanCongDTO();
            foreach (DataRow row in table.Rows)
            {
                string maGV = row["MaGV"].ToString();
                string HoTen = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                //string maLop = row["MaLop"].ToString();
                string vaiTro = row["VaiTro"].ToString();

                dto = new PhanCongDTO(maGV, HoTen, gioiTinh, maLopp, vaiTro);
                lst.Add(dto);
            }
            return lst;
        }


        public PhanCongDTO layGVHoTroTheoLop(string maLop)
        {
            DataTable table = phanCongDAL.layGVHoTroTheoLop(maLop);
            PhanCongDTO dto = new PhanCongDTO();
            foreach (DataRow row in table.Rows)
            {
                string maGV = row["MaGV"].ToString();

                dto = new PhanCongDTO(maGV);
            }
            return dto;
        }


        public PhanCongDTO layGVPhuTrachTheoLop(string maLop)
        {
            DataTable table = phanCongDAL.layGVPhuTrachTheoLop(maLop);
            PhanCongDTO dto = new PhanCongDTO();
            foreach (DataRow row in table.Rows)
            {
                string maGV = row["MaGV"].ToString();

                dto = new PhanCongDTO(maGV);
            }
            return dto;
        }

        public PhanCongDTO layLopGVDayTrongNamHT(string maGV, string namHocHT)
        {
            DataTable table = phanCongDAL.layLopGVDayTrongNamHT(maGV, namHocHT);
            PhanCongDTO dto = new PhanCongDTO();
            foreach (DataRow row in table.Rows)
            {
                string maLop = row["MaLop"].ToString();

                dto = new PhanCongDTO(maLop, maGV);
            }
            return dto;
        }


        public bool ktraGVChuaPhanCong(string maLop, string maGV)
        {
            return phanCongDAL.ktraGVPhanCongChua(maLop, maGV) <= 0;
        }



        public bool Insert(PhanCongDTO phanCong)
        {
            return phanCongDAL.Insert(phanCong);
        }

        public bool Delete(PhanCongDTO phanCong)
        {
            return phanCongDAL.Delete(phanCong);
        }
    }
}
