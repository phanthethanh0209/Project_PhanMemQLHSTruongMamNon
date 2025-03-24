namespace DTO
{
    public class DanhGiaThangDTO
    {
        public DanhGiaThangDTO(string maDanhGiaThang, string maLop, string maHS, int thang, int datPhieuChauNgoanBH, string noiDung)
        {
            MaDanhGiaThang = maDanhGiaThang;
            MaLop = maLop;
            MaHS = maHS;
            Thang = thang;
            DatPhieuChauNgoanBH = datPhieuChauNgoanBH;
            NoiDung = noiDung;
        }

        public DanhGiaThangDTO(string maLop, string maHS, int thang)
        {
            MaLop = maLop;
            MaHS = maHS;
            Thang = thang;

        }

        public DanhGiaThangDTO(int tongSoPhieuTrongNam)
        {
            TongSoPhieuTrongNam = tongSoPhieuTrongNam;
        }

        public DanhGiaThangDTO()
        {

        }

        public string MaDanhGiaThang { get; set; }
        public string MaLop { get; set; }
        public string MaHS { get; set; }
        public int Thang { get; set; }
        public int DatPhieuChauNgoanBH { get; set; }
        public string NoiDung { get; set; }
        public int TongSoPhieuTrongNam { get; set; }
    }
}
