using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoSoHocSinhDTO
    {
        public string MaHS { get; set; }
        public string MaDinhDanh { get; set; }
        public string QuocTich { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        public string QueQuan { get; set; }
        public string NoiSinh { get; set; }
        public string TinhTrangSucKhoe { get; set; }
        public string DonXinNhapHoc { get; set; }
        public string GiayKhaiSinh { get; set; }

        public HoSoHocSinhDTO()
        {

        }

        public HoSoHocSinhDTO(string maHS, string maDinhDanh, string quocTich, string danToc, string tonGiao, string queQuan, string noiSinh, string tinhTrangSK, string donXinNhapHoc, string giayKhaiSinh)
        {
            MaHS = maHS;
            MaDinhDanh = maDinhDanh;
            QuocTich = quocTich;
            DanToc = danToc;
            TonGiao = tonGiao;
            QueQuan = queQuan;
            NoiSinh = noiSinh;
            TinhTrangSucKhoe = tinhTrangSK;
            DonXinNhapHoc = donXinNhapHoc;
            GiayKhaiSinh = giayKhaiSinh;
        }
    }

    
}
