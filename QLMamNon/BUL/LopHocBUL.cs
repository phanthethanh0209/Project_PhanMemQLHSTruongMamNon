using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class LopHocBUL
    {
        LopHocDAL lopHocDAL = new LopHocDAL();

        public List<LopHocDTO> getAll()
        {
            List<LopHocDTO> lst = new List<LopHocDTO>();
            DataTable table = lopHocDAL.getAll();
            foreach (DataRow row in table.Rows)
            {
                LopHocDTO dto;
                string maLop = row["MaLop"].ToString();
                string makhoi = row["MaKhoi"].ToString();
                string tenLop = row["TenLop"].ToString();
                int siSo = int.Parse(row["SiSo"].ToString());
                dto = new LopHocDTO(maLop, tenLop, siSo, makhoi);
                lst.Add(dto);
            }
            return lst;
        }

        public List<LopHocDTO> getLopHocTheoNam(string maNamHoc)
        {
            DataTable table = lopHocDAL.getLopHocTheoNam(maNamHoc);
            List<LopHocDTO> list = new List<LopHocDTO>();

            foreach (DataRow row in table.Rows)
            {
                string tenLop = row["TenLop"].ToString();
                string maLop = row["MaLop"].ToString();
                string maKhoi = row["MaKhoi"].ToString();
                LopHocDTO dto = new LopHocDTO(tenLop, maLop, maNamHoc, maKhoi);
                list.Add(dto);
            }

            return list;
        }

        public LopHocDTO getLopHocTheoMa(string malop)
        {
            DataTable table = lopHocDAL.getLopHocTheoMa(malop);
            LopHocDTO dto = new LopHocDTO();
            foreach (DataRow row in table.Rows)
            {
                string maLop = row["MaLop"].ToString();
                string makhoi = row["MaKhoi"].ToString();
                string tenLop = row["TenLop"].ToString();
                int siSo = int.Parse(row["SiSo"].ToString());
                dto = new LopHocDTO(maLop, tenLop, siSo, makhoi);
            }
            return dto;
        }

        public List<LopHocDTO> layLopHocTheoKeHoach(string maKhoi, string maNamHoc)
        {
            List<LopHocDTO> lst = new List<LopHocDTO>();
            DataTable table = lopHocDAL.layLopHocTheoKeHoach(maKhoi, maNamHoc);
            foreach (DataRow row in table.Rows)
            {
                LopHocDTO dto;
                string maLop = row["MaLop"].ToString();
                string makhoi = row["MaKhoi"].ToString();
                string maNH = row["MaNamHoc"].ToString();
                string tenLop = row["TenLop"].ToString();
                string maPhong = row["MaPhong"].ToString();
                int siSo = int.Parse(row["SiSo"].ToString());
                dto = new LopHocDTO(maLop, tenLop, siSo, makhoi, maNH, maPhong);
                lst.Add(dto);
            }
            return lst;
        }
        public bool themLopHoc(LopHocDTO l)
        {
            return lopHocDAL.themLopHoc(l);
        }

        
        public bool capNhatLopHoc(LopHocDTO l)
        {
            return lopHocDAL.capNhatLopHoc(l);
        }

        public bool suaLopHoc(LopHocDTO l)
        {
            return lopHocDAL.suaLopHoc(l);
        }

        public bool xoaLopHoc(string maLop)
        {
            return lopHocDAL.xoaLopHoc(maLop);
        }
    }
}
