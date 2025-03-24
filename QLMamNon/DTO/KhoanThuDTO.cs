using System;

namespace DTO
{
    public class KhoanThuDTO
    {
        public KhoanThuDTO( string maKhoanThu, string maNamHoc, string tenKhoanThu, double soTien)
        {
            MaKhoanThu = maKhoanThu;
            MaNamHoc = maNamHoc;
            TenKhoanThu = tenKhoanThu;
            SoTien = soTien;
        }

        public KhoanThuDTO()
        {

        }

        public string MaKhoanThu { get; set; }
        public string MaNamHoc { get; set; }
        public string TenKhoanThu { get; set; }
        public double SoTien { get; set; }
        
    }
}
