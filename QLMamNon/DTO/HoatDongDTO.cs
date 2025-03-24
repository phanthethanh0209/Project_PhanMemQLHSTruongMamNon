using System;

namespace DTO
{
    public class HoatDongDTO
    {
        public HoatDongDTO(string maHD, string tenHDNK, DateTime ngayTG, double soTien, string maNamHoc, string trangThaiDK)
        {
            MaHD = maHD;
            TenHDNK = tenHDNK;
            NgayTG = ngayTG;
            SoTien = soTien;
            MaNamHoc = maNamHoc;
            TrangThaiDK = trangThaiDK;
        }

        public HoatDongDTO()
        {
        }

        public string MaHD { get; set; }
        public string TenHDNK { get; set; }
        public DateTime NgayTG { get; set; }
        public double SoTien { get; set; }
        public string MaNamHoc { get; set; }
        public string TrangThaiDK { get; set; }

    }
}
