using System;

namespace DTO
{
    public class DanhGiaTuanDTO
    {
        public DanhGiaTuanDTO(string maDanhGiaTuan, string maLop, string maHS, int tuan, int thang, int datPhieuBeNgoan, string noiDung, DateTime ngayDG)
        {
            MaDanhGiaTuan = maDanhGiaTuan;
            MaLop = maLop;
            MaHS = maHS;
            Tuan = tuan;
            Thang = thang;
            DatPhieuBeNgoan = datPhieuBeNgoan;
            NoiDung = noiDung;
            NgayDG = ngayDG;
        }

        public DanhGiaTuanDTO(string maLop, string maHS, int thang, int tuan)
        {
            MaLop = maLop;
            MaHS = maHS;
            Thang = thang;
            Tuan = tuan;
        }

        public DanhGiaTuanDTO(string maLop, int thang, int tuan)
        {
            MaLop = maLop;
            Thang = thang;
            Tuan = tuan;
        }

        public DanhGiaTuanDTO()
        {
        }

        public string MaDanhGiaTuan { get; set; }
        public string MaHS { get; set; }
        public string MaLop { get; set; }
        public int Tuan { get; set; }
        public int Thang { get; set; }
        public int DatPhieuBeNgoan { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDG { get; set; }
    }
}
