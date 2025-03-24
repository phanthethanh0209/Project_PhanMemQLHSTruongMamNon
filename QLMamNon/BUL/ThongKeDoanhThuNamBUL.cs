using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class ThongKeDoanhThuNamBUL
    {
        ThongKeDoanhThuNamDAL doanhThuDAL = new ThongKeDoanhThuNamDAL();

        //Học phí theo năm
        public List<ThongKeDoanhThuDTO> layTatCaKhoanThuTrongNamHoc(string maNamHoc)
        {
            List<ThongKeDoanhThuDTO> lst = new List<ThongKeDoanhThuDTO>();
            DataTable table = doanhThuDAL.ThongKeDoanhThuHPTheoNam(maNamHoc);
            foreach (DataRow row in table.Rows)
            {
                ThongKeDoanhThuDTO dto;
                string khoiLop = row["TenKhoi"].ToString();
                string lopHoc = row["TenLop"].ToString();
                double hocPhi = double.Parse(row["TienHP"].ToString());
                double tienDaThu = double.Parse(row["TienDaThu"].ToString());
                double tienChuaThu = double.Parse(row["TienChuaThu"].ToString());
                dto = new ThongKeDoanhThuDTO(maNamHoc, khoiLop, lopHoc, hocPhi, tienDaThu, tienChuaThu);
                lst.Add(dto);
            }
            return lst;
        }

        public DataTable InDoanhThuHDTrongNam(string maNamHoc, string tenNamHoc)
        {
            DataTable table = doanhThuDAL.InThongKeDoanhThuHPTheoNam(maNamHoc, tenNamHoc);
            return table;
        }

        //Hoc phi theo tháng
        public List<ThongKeDoanhThuDTO> layTatCaKhoanThuTrongThang(string maNamHoc, string thang)
        {
            List<ThongKeDoanhThuDTO> lst = new List<ThongKeDoanhThuDTO>();
            DataTable table = doanhThuDAL.ThongKeDoanhThuHPTheoThang(maNamHoc, thang);
            foreach (DataRow row in table.Rows)
            {
                ThongKeDoanhThuDTO dto;
                string khoiLop = row["TenKhoi"].ToString();
                string lopHoc = row["TenLop"].ToString();
                //string thang = row["Thang"].ToString();
                double hocPhi = double.Parse(row["TienHP"].ToString());
                double tienDaThu = double.Parse(row["TienDaThu"].ToString());
                double tienChuaThu = double.Parse(row["TienChuaThu"].ToString());
                dto = new ThongKeDoanhThuDTO(maNamHoc, khoiLop, thang, lopHoc, hocPhi, tienDaThu, tienChuaThu);
                lst.Add(dto);
            }
            return lst;
        }

        public DataTable InDoanhThuHPTrongThang(string maNamHoc, string tenNamHoc, string thang)
        {
            DataTable table = doanhThuDAL.InThongKeDoanhThuHPTheoThang(maNamHoc, tenNamHoc, thang);
            return table;
        }

        //Hoạt động theo năm
        public List<ThongKeDoanhThuDTO> DoanhThuHDTrongNam(string maNamHoc)
        {
            List<ThongKeDoanhThuDTO> lst = new List<ThongKeDoanhThuDTO>();
            DataTable table = doanhThuDAL.ThongKeDoanhThuHDTheoNam(maNamHoc);
            foreach (DataRow row in table.Rows)
            {
                ThongKeDoanhThuDTO dto;
                string tenHoatDong = row["TenHoatDong"].ToString();
                DateTime ngayToChuc = DateTime.Parse(row["NgayToChuc"].ToString());
                double doanhThuHoatDong = double.Parse(row["DoanhThuHoatDong"].ToString());
                double tongDoanhThu = double.Parse(row["TongDoanhThu"].ToString());
                dto = new ThongKeDoanhThuDTO(maNamHoc, tenHoatDong, ngayToChuc, doanhThuHoatDong, tongDoanhThu);
                lst.Add(dto);
            }
            return lst;
        }

        public DataTable InThongKeDoanhThuHDTheoNam(string maNamHoc, string tongTienBangChu, string tenNamHoc)
        {
            DataTable table = doanhThuDAL.InThongKeDoanhThuHDTheoNam(maNamHoc, tongTienBangChu, tenNamHoc);
            return table;
        }

    }
}
