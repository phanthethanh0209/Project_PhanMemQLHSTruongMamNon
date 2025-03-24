using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class PhuHuynhBUL
    {
        PhuHuynhDAL dal = new PhuHuynhDAL();

        public List<PhuHuynhDTO> getAll()
        {
            List<PhuHuynhDTO> lst = new List<PhuHuynhDTO>();
            DataTable table = dal.layTatCaPhuHuynh();
            foreach (DataRow row in table.Rows)
            {
                PhuHuynhDTO dto;
                string maPH = row["MaPH"].ToString();
                string hoTen = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                int namSinh = int.Parse(row["NamSinh"].ToString());
                string diaChiCQ = row["DiaChiCQ"].ToString();
                string ngheNghiep = row["NgheNghiep"].ToString();
                string dienThoai = row["DienThoai"].ToString().Trim();
                string email = row["Email"].ToString();
                string quanHe = row["QuanHe"].ToString();

                dto = new PhuHuynhDTO(maPH, hoTen, gioiTinh, namSinh, diaChiCQ, ngheNghiep, dienThoai, email, quanHe);
                lst.Add(dto);
            }
            return lst;
        }

        public PhuHuynhDTO layThongTinMotPhuHuynh(string maPHMoi)
        {
            DataTable table = dal.layThongTinMotPhuHuynh(maPHMoi);
            PhuHuynhDTO dto = null;

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];

                string maPH = row["MaPH"].ToString();
                string hoTen = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                int namSinh = int.Parse(row["NamSinh"].ToString());
                string diaChiCQ = row["DiaChiCQ"].ToString();
                string ngheNghiep = row["NgheNghiep"].ToString();
                string dienThoai = row["DienThoai"].ToString().Trim();
                string email = row["Email"].ToString();
                string quanHe = row["QuanHe"].ToString();

                dto = new PhuHuynhDTO(maPH, hoTen, gioiTinh, namSinh, diaChiCQ, ngheNghiep, dienThoai, email, quanHe);
            }

            return dto;
        }

        public string TaoMaPH1(string maHS)
        {
            string key = "PH" + maHS + "1";
            return key;

        }

        public string TaoMaPH2(string maHS)
        {
            string key = "PH" + maHS + "2";
            return key;

        }


        public bool themPhuHuynh(PhuHuynhDTO hs)
        {
            return dal.themPhuHuynh(hs);
        }

        public bool suaPhuHuynh(PhuHuynhDTO hs)
        {
            return dal.suaPhuHuynh(hs);
        }

        public bool xoaPhuHuynh(string maHS)
        {
            return dal.xoaPhuHuynh(maHS);
        }
    }
}
