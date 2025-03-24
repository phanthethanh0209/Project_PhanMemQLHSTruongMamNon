using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongKeDoanhThuDTO
    {
        public ThongKeDoanhThuDTO(string maNamHoc, string khoiLop, string thang, string lopHoc, double hocPhi, double tienDaThu, double tienChuaThu)
        {
            MaNamHoc = maNamHoc;
            TenKhoi = khoiLop;
            Thang = thang;
            TenLop = lopHoc;
            TienHP = hocPhi;
            TienDaThu = tienDaThu;
            TienChuaThu = tienChuaThu;
        }
        public ThongKeDoanhThuDTO(string maNamHoc, string khoiLop, string lopHoc, double hocPhi, double tienDaThu, double tienChuaThu)
        {
            MaNamHoc = maNamHoc;
            TenKhoi = khoiLop;
            TenLop = lopHoc;
            TienHP = hocPhi;
            TienDaThu = tienDaThu;
            TienChuaThu = tienChuaThu;
        }

        public ThongKeDoanhThuDTO(string maNamHoc, string tenHoatDong, DateTime ngayToChuc, double doanhThuHoatDong, double tongDoanhThu)
        {
            MaNamHoc = maNamHoc;
            TenHoatDong = tenHoatDong;
            NgayToChuc = ngayToChuc;
            DoanhThuHoatDong = doanhThuHoatDong;
            TongDoanhThu = tongDoanhThu;
        }

        public ThongKeDoanhThuDTO()
        {

        }

        public string TenHoatDong { get; set; }
        public DateTime NgayToChuc { get; set; }
        public double DoanhThuHoatDong { get; set; }
        public double TongDoanhThu { get; set; }
        public string MaNamHoc { get; set; }
        public string TenKhoi { get; set; }
        public string TenLop { get; set; }
        public double TienHP { get; set; }
        public double TienDaThu { get; set; }
        public double TienChuaThu { get; set; }
        public string Thang { get; set; }
    }
}