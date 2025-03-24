using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongKeHSDTO
    {
        public string TenLop { get; set; }
        public string MaHS { get; set; }
        public string HoTen { get; set; }
        public string XepLoai { get; set; }
        public string TongSoHSDatKhenThuong { get; set; }
        public string MaNamHoc { get; set; }
        public string SoHocSinh { get; set; }
        public string QueQuan { get; set; }
        public string NoiSinh {  get; set; } 

        public string MaLop { get; set; }   

        public ThongKeHSDTO(string tenLop, string maHS, string hoTen, string xepLoai, string maLop)
        {
            TenLop = tenLop;
            MaHS = maHS;
            HoTen = hoTen;
            XepLoai = xepLoai;
            MaLop = maLop;
        }

        public ThongKeHSDTO(string tenLop, string tongSoHSDatKhenThuong, string maNamHoc)
        {
            TenLop = tenLop;
            TongSoHSDatKhenThuong = tongSoHSDatKhenThuong;
            MaNamHoc = maNamHoc;
        }

        public ThongKeHSDTO(string queQuan, string soHocSinh, string maNamHoc, string noiSinh)
        {
            QueQuan = queQuan;
            SoHocSinh = soHocSinh;
            MaNamHoc = maNamHoc;
        }
    }
}
