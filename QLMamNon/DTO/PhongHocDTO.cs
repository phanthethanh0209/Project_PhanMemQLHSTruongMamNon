using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongHocDTO
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public int SucChua { get; set; }
        public string ViTri { get; set; }
        public string TinhTrang { get; set; }
       
        public PhongHocDTO()
        {

        }

        public PhongHocDTO(string maPhong, string tenPhong, int sucChua, string viTri, string tinhTrang)
        {
            MaPhong = maPhong;
            TenPhong = tenPhong;
            SucChua = sucChua;
            ViTri = viTri;
            TinhTrang = tinhTrang;       

        }
    }
}
