namespace DTO
{
    public class PhanLopDTO
    {
        public PhanLopDTO(string maLop, string maHS)
        {
            MaLop = maLop;
            MaHS = maHS;
        }

        public PhanLopDTO(string maLop, string maHS, string danhGia)
        {
            MaLop = maLop;
            MaHS = maHS;
            DanhGia = danhGia;
        }

        public PhanLopDTO(string maLop, string maHS, string danhGia, string xepLoai)
        {
            MaLop = maLop;
            MaHS = maHS;
            DanhGia = danhGia;
            XepLoai = xepLoai;
        }

        public PhanLopDTO()
        {
        }

        public string MaLop { get; set; }
        public string MaHS { get; set; }
        public string TinhTrang { get; set; }
        public string DanhGia { get; set; }
        public string XepLoai { get; set; }

    }
}
