using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class NamHocBUL
    {
        NamHocDAL namHocDAL = new NamHocDAL();

        public List<NamHocDTO> layTatCaNamHoc()
        {
            List<NamHocDTO> lst = new List<NamHocDTO>();
            DataTable table = namHocDAL.getAll();
            foreach (DataRow row in table.Rows)
            {
                NamHocDTO dto;
                string maNH = row["MaNamHoc"].ToString();
                string tenNH = row["TenNamHoc"].ToString();
                DateTime ngayBD = DateTime.Parse(row["NgayDB"].ToString());
                DateTime ngayKT = DateTime.Parse(row["NgayKT"].ToString());
                dto = new NamHocDTO(maNH, tenNH, ngayBD, ngayKT);
                lst.Add(dto);
            }
            return lst;
        }


        public NamHocDTO layThongTinCua1NamHoc(string maNamhoc)
        {
            DataTable table = namHocDAL.layThongTinCua1NamHoc(maNamhoc);
            NamHocDTO dto = null;

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string maNH = row["MaNamHoc"].ToString();
                string tenNH = row["TenNamHoc"].ToString();                                
                DateTime ngayDB = DateTime.Parse(row["NgayDB"].ToString());
                DateTime ngayKT = DateTime.Parse(row["NgayKT"].ToString());

                dto = new NamHocDTO(maNH, tenNH, ngayDB, ngayKT);
            }

            return dto;
        }


        public NamHocDTO layNamHocTruoc(string namHoc)
        {
            DataTable table = namHocDAL.layNamHocTruoc(namHoc);
            NamHocDTO dto = new NamHocDTO();
            foreach (DataRow row in table.Rows)
            {
                string maNH = row["MaNamHoc"].ToString();
                string tenNH = row["TenNamHoc"].ToString();
                DateTime ngayBD = DateTime.Parse(row["NgayDB"].ToString());
                DateTime ngayKT = DateTime.Parse(row["NgayKT"].ToString());

                dto = new NamHocDTO(maNH, tenNH, ngayBD, ngayKT);
            }
            return dto;
        }

        public NamHocDTO layNamHocMoi()
        {
            DataTable table = namHocDAL.layNamHocMoi();
            NamHocDTO dto = new NamHocDTO();
            foreach (DataRow row in table.Rows)
            {
                string maNH = row["MaNamHoc"].ToString();
                string tenNH = row["TenNamHoc"].ToString();
                DateTime ngayBD = DateTime.Parse(row["NgayDB"].ToString());
                DateTime ngayKT = DateTime.Parse(row["NgayKT"].ToString());

                dto = new NamHocDTO(maNH, tenNH, ngayBD, ngayKT);
            }
            return dto;
        }

        public List<NamHocDTO> layTatCaNamHocCu(string namHocHienTai)
        {
            List<NamHocDTO> lst = new List<NamHocDTO>();
            DataTable table = namHocDAL.getAll();
            foreach (DataRow row in table.Rows)
            {
                NamHocDTO dto;
                string maNH = row["MaNamHoc"].ToString();
                string tenNH = row["TenNamHoc"].ToString();
                DateTime ngayBD = DateTime.Parse(row["NgayDB"].ToString());
                DateTime ngayKT = DateTime.Parse(row["NgayKT"].ToString());
                dto = new NamHocDTO(maNH, tenNH, ngayBD, ngayKT);
                lst.Add(dto);
            }
            return lst;
        }

        public string TaoMaNH()
        {
            string key = "NH";

            int currentYear = DateTime.Now.Year % 100; // Lấy 2 chữ số cuối của năm hiện tại
            int nextYear = (currentYear + 1) % 100;    // Tính năm kế tiếp

            key += currentYear.ToString("D2") + nextYear.ToString("D2"); // Ghép thành mã

            return key;
        }

        public string TaoTenNH()
        {
            string key = "";

            int currentYear = DateTime.Now.Year;
            int nextYear = (currentYear + 1);

            key += currentYear.ToString() + "-" + nextYear.ToString();

            return key;
        }

        // Thêm năm học
        public bool themNamHoc(NamHocDTO n)
        {
            return namHocDAL.themNamHoc(n);
        }

        public bool suaNamHoc(NamHocDTO n)
        {
            return namHocDAL.suaNamHoc(n);
        }
    }
}
