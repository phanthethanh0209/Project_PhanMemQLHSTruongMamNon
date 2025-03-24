using System;

namespace DTO
{
    public class PhieuHocPhiDTO
    {
        public string MaPhieuHP { get; set; }
        public string MaHS { get; set; }
        public string MaLop { get; set; }
        public string MaNV { get; set; }
        public int TrangThaiThanhToan { get; set; }
        public int Thang { get; set; }
        public double TongTien { get; set; }
        public DateTime NgayLapPhieu { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public int SoNgayHSVang { get; set; }
        public int SoNgayHSHoc { get; set; }
        public int SoBuoiHocTrongThang { get; set; }
        public double? TienNhan { get; set; }

        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }


        public PhieuHocPhiDTO()
        {
        }

        public PhieuHocPhiDTO(string maPhieuHP, string maHS, string maLop, string maNV, DateTime ngayLap, 
            int trangThaiThanhToan, int thang, int soNgayVang, double tongTien, int soNgayHoc, 
            string tenHocSinh, DateTime ngaySinh, string gioiTinh, int soBuoiHocTrongThang)
        {
            MaPhieuHP = maPhieuHP;
            MaHS = maHS;
            MaLop = maLop;
            MaNV = maNV;
            NgayLapPhieu = ngayLap;
            TrangThaiThanhToan = trangThaiThanhToan;
            Thang = thang;
            SoNgayHSVang = soNgayVang;
            SoNgayHSHoc = soNgayHoc;
            TongTien = tongTien;
            HoTen = tenHocSinh;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            SoBuoiHocTrongThang = soBuoiHocTrongThang;
        }


        //Thanh toán
        public PhieuHocPhiDTO(string maPhieuHP, string maHS, string maLop, string maNV, DateTime ngayLapPhieu, DateTime? ngayThanhToan,
            int trangThaiThanhToan, int thang, int soNgayHSVang, double tongTien, int soNgayHSHoc, double? tienNhan, int soBuoiHocTrongThang)
        {
            MaPhieuHP = maPhieuHP;
            MaHS = maHS;
            MaLop = maLop;
            MaNV = maNV;
            NgayLapPhieu = ngayLapPhieu;
            NgayThanhToan = ngayThanhToan;
            TrangThaiThanhToan = trangThaiThanhToan;
            Thang = thang;
            SoNgayHSVang = soNgayHSVang;
            SoNgayHSHoc = soNgayHSHoc;
            TongTien = tongTien;
            TienNhan = tienNhan;
            SoBuoiHocTrongThang = soBuoiHocTrongThang;
        }


        public PhieuHocPhiDTO(string maPhieuHP, string maHS, string hoTen, string maLop, string maNV, DateTime ngayLapPhieu, DateTime? ngayThanhToan,
            int trangThaiThanhToan, int thang, int soNgayHSVang, double tongTien, int soNgayHSHoc, double? tienNhan, int soBuoiHocTrongThang)
        {
            MaPhieuHP = maPhieuHP;
            MaHS = maHS;
            HoTen = hoTen;
            MaLop = maLop;
            MaNV = maNV;
            NgayLapPhieu = ngayLapPhieu;
            NgayThanhToan = ngayThanhToan;
            TrangThaiThanhToan = trangThaiThanhToan;
            Thang = thang;
            SoNgayHSVang = soNgayHSVang;
            SoNgayHSHoc = soNgayHSHoc;
            TongTien = tongTien;
            TienNhan = tienNhan;
            SoBuoiHocTrongThang = soBuoiHocTrongThang;
        }

        

 

    }
}
