using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class PhieuHocPhiBUL
    {
        PhieuHocPhiDAL phieuHocPhiDAL = new PhieuHocPhiDAL();
        public PhieuHocPhiDTO layPhieuHocPhiCua1HS(string maLop, string maHS, int Thang)
        {
            DataTable table = phieuHocPhiDAL.layPhieuHocPhiCua1HS(maHS, maLop, Thang);
            PhieuHocPhiDTO dto = new PhieuHocPhiDTO();
            foreach (DataRow row in table.Rows)
            {
                string maPHP = row["MaPhieuHP"].ToString();
                string maHocSinh = row["MaHS"].ToString();
                string maLopHoc = row["MaLop"].ToString();
                string maNV = row["MaND"].ToString();
                DateTime ngayLap = DateTime.Parse(row["NgayLapPhieu"].ToString());
                DateTime? ngayThanhToan = row["NgayThanhToan"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayThanhToan"].ToString());
                int trangThaiTT = int.Parse(row["TrangThaiThanhToan"].ToString());
                int thang = int.Parse(row["Thang"].ToString());
                int soNgayVang = int.Parse(row["SoNgayHSVang"].ToString());
                int soNgayHoc = int.Parse(row["SoNgayHSHoc"].ToString());
                double tongTien = double.Parse(row["TongTien"].ToString());
                double? tienNhan = row["TienNhan"] == DBNull.Value ? (double?)null : double.Parse(row["TienNhan"].ToString());
                int soBuoiHocTrongThang = int.Parse(row["SoBuoiHocTrongThang"].ToString());

                dto = new PhieuHocPhiDTO(maPHP, maHocSinh, maLopHoc, maNV, ngayLap, ngayThanhToan, trangThaiTT, thang, soNgayVang, tongTien, soNgayHoc, tienNhan, soBuoiHocTrongThang);
            }
            return dto;
        }

        public List<PhieuHocPhiDTO> layPhieuHocPhiVaTTCuaTatCaHS(string maLop, int Thang)
        {
            DataTable table = phieuHocPhiDAL.layPhieuHocPhiVaTTCuaTatCaHS(maLop, Thang);
            List<PhieuHocPhiDTO> lst = new List<PhieuHocPhiDTO>();
            foreach (DataRow row in table.Rows)
            {
                PhieuHocPhiDTO dto = new PhieuHocPhiDTO();
                string maPHP = row["MaPhieuHP"].ToString();
                string maHocSinh = row["MaHS"].ToString();
                string maLopHoc = row["MaLop"].ToString();
                string maNV = row["MaND"].ToString();
                DateTime ngayLap = DateTime.Parse(row["NgayLapPhieu"].ToString());
                int trangThaiTT = int.Parse(row["TrangThaiThanhToan"].ToString());
                int thang = int.Parse(row["Thang"].ToString());
                int soNgayVang = int.Parse(row["SoNgayHSVang"].ToString());
                int soNgayHoc = int.Parse(row["SoNgayHSHoc"].ToString());
                double tongTien = double.Parse(row["TongTien"].ToString());

                string tenHS = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                int soBuoiHocTrongThang = int.Parse(row["SoBuoiHocTrongThang"].ToString());

                dto = new PhieuHocPhiDTO(maPHP, maHocSinh, maLopHoc, maNV, ngayLap, trangThaiTT, thang, soNgayVang, tongTien, soNgayHoc, tenHS, ngaySinh, gioiTinh, soBuoiHocTrongThang);
                lst.Add(dto);
            }
            return lst;
        }



        //Thanh toán
        //Thanh toán
        public List<PhieuHocPhiDTO> timKiemHocSinhTheoMaHoacTen(string serach, string maLop, int Thang)
        {
            DataTable table = phieuHocPhiDAL.timKiemHocSinhTheoMaHoacTen(serach, Thang, maLop);
            List<PhieuHocPhiDTO> lst = new List<PhieuHocPhiDTO>();
            PhieuHocPhiDTO dto;
            foreach (DataRow row in table.Rows)
            {
                string maPHP = row["MaPhieuHP"].ToString();
                string maHocSinh = row["MaHS"].ToString();
                string tenHS = row["HoTen"].ToString();
                string maLopHoc = row["MaLop"].ToString();
                string maNV = row["MaND"].ToString();
                DateTime ngayLapPhieu = DateTime.Parse(row["NgayLapPhieu"].ToString());
                DateTime? ngayThanhToan = row["NgayThanhToan"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayThanhToan"].ToString());
                int trangThaiTT = int.Parse(row["TrangThaiThanhToan"].ToString());
                int thang = int.Parse(row["Thang"].ToString());
                int soNgayHSVang = int.Parse(row["SoNgayHSVang"].ToString());
                int soNgayHSHoc = int.Parse(row["SoNgayHSHoc"].ToString());
                double tongTien = double.Parse(row["TongTien"].ToString());
                double? tienNhan = row["TienNhan"] == DBNull.Value ? (double?)null : double.Parse(row["TienNhan"].ToString());
                int soBuoiHocTrongThang = int.Parse(row["SoBuoiHocTrongThang"].ToString());

                dto = new PhieuHocPhiDTO(maPHP, maHocSinh, tenHS, maLopHoc, maNV, ngayLapPhieu, ngayThanhToan, trangThaiTT, thang, soNgayHSVang, tongTien, soNgayHSHoc, tienNhan, soBuoiHocTrongThang);
                lst.Add(dto);
            }
            return lst;
        }

        public List<PhieuHocPhiDTO> layDSHSThanhToanTheoTrangThai(string trangThai, string maLop, int Thang)
        {
            DataTable table = phieuHocPhiDAL.layDSHSThanhToanTheoTrangThai(trangThai, Thang, maLop);
            List<PhieuHocPhiDTO> lst = new List<PhieuHocPhiDTO>();
            PhieuHocPhiDTO dto;
            foreach (DataRow row in table.Rows)
            {
                string maPHP = row["MaPhieuHP"].ToString();
                string maHocSinh = row["MaHS"].ToString();
                string tenHS = row["HoTen"].ToString();
                string maLopHoc = row["MaLop"].ToString();
                string maNV = row["MaND"].ToString();
                DateTime ngayLapPhieu = DateTime.Parse(row["NgayLapPhieu"].ToString());
                DateTime? ngayThanhToan = row["NgayThanhToan"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayThanhToan"].ToString());
                int trangThaiTT = int.Parse(row["TrangThaiThanhToan"].ToString());
                int thang = int.Parse(row["Thang"].ToString());
                int soNgayHSVang = int.Parse(row["SoNgayHSVang"].ToString());
                int soNgayHSHoc = int.Parse(row["SoNgayHSHoc"].ToString());
                double tongTien = double.Parse(row["TongTien"].ToString());
                double? tienNhan = row["TienNhan"] == DBNull.Value ? (double?)null : double.Parse(row["TienNhan"].ToString());
                int soBuoiHocTrongThang = int.Parse(row["SoBuoiHocTrongThang"].ToString());


                dto = new PhieuHocPhiDTO(maPHP, maHocSinh, tenHS, maLopHoc, maNV, ngayLapPhieu, ngayThanhToan, trangThaiTT, thang, soNgayHSVang, tongTien, soNgayHSHoc, tienNhan, soBuoiHocTrongThang);
                lst.Add(dto);
            }
            return lst;
        }


        public int demSoHSChuaThanhToanHocPhi(string maLop, int thang)
        {
            return phieuHocPhiDAL.demSoHSChuaThanhToanHocPhi(maLop, thang);
        }


        public int laySoBuoiHocCuaThang(string maNH, int thang)
        {
            return phieuHocPhiDAL.laySoBuoiHocCuaThang(maNH, thang);
        }

        public string taoMaPhieuHocPhi(int thang, string maNam, string maHS)
        {
            string key = "HP";
            key += maNam.Trim().Substring(2) + "T" + thang + "_" + maHS;

            return key;
        }

        public bool kiemTraTonTaiPhieuHocPhi(int thang, string maNH)
        {
            return phieuHocPhiDAL.demSoPhieuHocPhi(thang, maNH) > 0;
        }

        public bool Insert(PhieuHocPhiDTO p)
        {
            return phieuHocPhiDAL.Insert(p);
        }

        public bool Delete(string maPhieuHP)
        {
            return phieuHocPhiDAL.Delete(maPhieuHP);
        }
        public bool Update(string maPhieuHP, double tienNhan)
        {
            return phieuHocPhiDAL.Update(tienNhan, maPhieuHP);
        }

        public DataTable inPhieuHPTheoThang(string maLop, int thang)
        {
            DataTable dt = phieuHocPhiDAL.inPhieuHPTheoThang(maLop, thang);
            return dt;
        }

        public DataTable inPhieuHPTheoHS(string maPhieu, string tienNhanBangChu, double tienThua)
        {
            DataTable dt = phieuHocPhiDAL.inPhieuHPTheoHS(maPhieu, tienNhanBangChu, tienThua);
            return dt;
        }
    }
}
