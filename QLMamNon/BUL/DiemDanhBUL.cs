using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class DiemDanhBUL
    {
        DiemDanhDAL diemdanhDAL = new DiemDanhDAL();

        public List<DiemDanhDTO> getAll()
        {
            List<DiemDanhDTO> lst = new List<DiemDanhDTO>();
            DataTable table = diemdanhDAL.getAll();
            foreach (DataRow row in table.Rows)
            {
                DiemDanhDTO dto;
                string maDiemDanh = row["MaDiemDanh"].ToString();
                string maLop = row["MaLop"].ToString();
                string maHS = row["MAHS"].ToString();
                DateTime ngayDiemDanh = DateTime.Parse(row["NgayDiemDanh"].ToString());
                int vangKPhep = int.Parse(row["VangKPhep"].ToString());
                string ghiChu = row["GhiChu"].ToString();

                dto = new DiemDanhDTO(maDiemDanh, maLop, maHS, ngayDiemDanh, vangKPhep, ghiChu);
                lst.Add(dto);
            }
            return lst;
        }

        public int demSoNgayVangCua1HS(string maLop, string maHS, int thang)
        {
            return diemdanhDAL.demSoNgayVangCua1HS(maLop, maHS, thang);
        }

        public bool InsertDiemDanh(DiemDanhDTO nguoidung)
        {
            return diemdanhDAL.InsertDiemDanh(nguoidung);
        }

        public bool capNhatDiemDanh(DiemDanhDTO nguoidung)
        {
            return diemdanhDAL.capNhatDiemDanh(nguoidung);
        }

        public bool xoaDiemDanh(DiemDanhDTO nguoidung)
        {
            return diemdanhDAL.xoaDiemDanh(nguoidung);
        }

        public DataTable LayThongTinHocSinh(string maGV)
        {
            return diemdanhDAL.LayThongTinHocSinh(maGV);
        }

        public string TaoMaDiemDanh(string maLop, string ngayThangNam, string maHS)
        {
            string key = "DD" + maLop + ngayThangNam + "_" + maHS.Trim();

            return key;
        }

        public DataTable LayThongTinDiemDanh()
        {
            return diemdanhDAL.LayThongTinDiemDanh();
        }

        public List<DiemDanhDTO> layThongTinDiemDanhTheoNgay(string maLop, string ngayDiemDanh, string timKiem)
        {
            List<DiemDanhDTO> lst = new List<DiemDanhDTO>();
            DataTable table = diemdanhDAL.layThongTinDiemDanhTheoNgay(maLop, ngayDiemDanh, timKiem);
            foreach (DataRow row in table.Rows)
            {
                DiemDanhDTO dto;
                string maDiemDanh = row["MaDiemDanh"].ToString();
                string maHS = row["MAHS"].ToString();
                DateTime? ngayDD = row["NgayDiemDanh"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayDiemDanh"].ToString());
                int? vangKPhep = row["VangKPhep"] == DBNull.Value ? 2 : int.Parse(row["VangKPhep"].ToString());
                string ghiChu = row["GhiChu"].ToString();

                dto = new DiemDanhDTO(maDiemDanh, maLop, maHS, ngayDD, vangKPhep, ghiChu);
                lst.Add(dto);
            }
            return lst;
        }

        public List<DiemDanhDTO> timKiemHocSinhTheoMaTenNgay(string maLop, string ngayDiemDanh, string timKiem)
        {
            List<DiemDanhDTO> lst = new List<DiemDanhDTO>();
            DataTable table = diemdanhDAL.timKiemHocSinhTheoMaTenNgay(maLop, ngayDiemDanh, timKiem);
            foreach (DataRow row in table.Rows)
            {
                DiemDanhDTO dto;
                string maDiemDanh = row["MaDiemDanh"].ToString();
                string maHS = row["MAHS"].ToString();
                DateTime? ngayDD = row["NgayDiemDanh"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayDiemDanh"].ToString());
                int? vangKPhep = row["VangKPhep"] == DBNull.Value ? 2 : int.Parse(row["VangKPhep"].ToString());
                string ghiChu = row["GhiChu"].ToString();

                dto = new DiemDanhDTO(maDiemDanh, maLop, maHS, ngayDD, vangKPhep, ghiChu);
                lst.Add(dto);
            }
            return lst;
        }

        public List<DiemDanhDTO> timKiemHocSinhTheoMaTen(string maLop, string timKiem)
        {
            List<DiemDanhDTO> lst = new List<DiemDanhDTO>();
            DataTable table = diemdanhDAL.timKiemHocSinhTheoMaTen(maLop, timKiem);
            foreach (DataRow row in table.Rows)
            {
                DiemDanhDTO dto;
                string maDiemDanh = row["MaDiemDanh"].ToString();
                string maHS = row["MAHS"].ToString();
                DateTime? ngayDD = row["NgayDiemDanh"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayDiemDanh"].ToString());
                int? vangKPhep = row["VangKPhep"] == DBNull.Value ? 2 : int.Parse(row["VangKPhep"].ToString());
                string ghiChu = row["GhiChu"].ToString();

                dto = new DiemDanhDTO(maDiemDanh, maLop, maHS, ngayDD, vangKPhep, ghiChu);
                lst.Add(dto);
            }
            return lst;
        }

        public List<DiemDanhDTO> layTatCaHSVangTheoNgay(string maLop, string ngayDiemDanh)
        {
            List<DiemDanhDTO> lst = new List<DiemDanhDTO>();
            DataTable table = diemdanhDAL.layTatCaHSVangTheoNgay(maLop, ngayDiemDanh);
            foreach (DataRow row in table.Rows)
            {
                DiemDanhDTO dto;
                string maDiemDanh = row["MaDiemDanh"].ToString();
                string maHS = row["MAHS"].ToString();
                DateTime? ngayDD = row["NgayDiemDanh"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayDiemDanh"].ToString());
                int? vangKPhep = row["VangKPhep"] == DBNull.Value ? 2 : int.Parse(row["VangKPhep"].ToString());
                string ghiChu = row["GhiChu"].ToString();

                dto = new DiemDanhDTO(maDiemDanh, maLop, maHS, ngayDD, vangKPhep, ghiChu);
                lst.Add(dto);
            }
            return lst;
        }

        public int demSoHSVangTheoNgay(string maLop, string ngayDiemDanh)
        {
            return diemdanhDAL.demSoHSVangTheoNgay(maLop, ngayDiemDanh);
        }

        public string GetNamHoc()
        {
            return diemdanhDAL.GetNamHoc();
        }

        public DiemDanhDTO GetKhoiLopAndLopHoc(string maGV)
        {
            DiemDanhDTO dto = new DiemDanhDTO();
            //DataTable dt = diemdanhDAL.GetKhoiLopAndLopHoc(maGV);
            //if (dt.Rows.Count > 0)
            //{

            //    string dt.Rows[0]["TenKhoiLop"].ToString(), dt.Rows[0]["TenLopHoc"].ToString());
            //}
            //return (null, null);
            return dto;
        }

        public string GetGVPhuTrach(string maGV)
        {
            return diemdanhDAL.GetGVPhuTrach(maGV);
        }
    }
}

