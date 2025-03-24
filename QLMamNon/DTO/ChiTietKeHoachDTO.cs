using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietKeHoachDTO
    {
        public ChiTietKeHoachDTO(string maKeHoach, string maCTKeHoach, string tenKhoi, int soLuongLop, int soLuongHS, int hocPhi, int tienAn)
        {
            MaKeHoach = maKeHoach;
            MaCTKeHoach = maCTKeHoach;
            TenKhoi = tenKhoi;
            SoLuongLop = soLuongLop;
            SoLuongHS = soLuongHS;
            HocPhi = hocPhi;
            TienAn = tienAn;
        }

        public ChiTietKeHoachDTO() { }

        public string MaKeHoach { get; set; }
        public string MaCTKeHoach { get; set; }
        public string TenKhoi { get; set; }
        public int SoLuongLop { get; set; }
        public int SoLuongHS { get; set; }
        public int HocPhi { get; set; }
        public int TienAn { get; set; }
    }
}
