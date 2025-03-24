namespace DTO
{
    public class LopHocDTO
    {
        public LopHocDTO(string maLop, string tenLop, int siSo, string maKhoi, string maNamHoc, string maPhong)
        {
            MaLop = maLop;
            TenLop = tenLop;
            SiSo = siSo;
            MaKhoi = maKhoi;
            MaNamHoc = maNamHoc;
            MaPhong = maPhong;
        }

        public LopHocDTO(string maLop, string tenLop, int siSo, string maKhoi)
        {
            MaLop = maLop;
            TenLop = tenLop;
            SiSo = siSo;
            MaKhoi = maKhoi;
        }

        public LopHocDTO(string tenLop, string maLop, string maNamHoc, string maKhoi)
        {
            MaNamHoc = maNamHoc;
            MaLop = maLop;
            TenLop = tenLop;
        }

        public LopHocDTO(string maLop, int siSo, string maKhoi)
        {
            MaLop = maLop;
            SiSo = siSo;
            MaKhoi = maKhoi;
        }

        //Frm Lập kế hoạch - Tạo danh sách lớp - Tên phòng ở bảng chi tiết
        public LopHocDTO(string maLop, string tenLop, string maKhoi, string maNamHoc, string maPhong, string tenPhong)
        {
            MaLop = maLop;
            TenLop = tenLop;
            MaPhong = maPhong;
            TenPhong = tenPhong;
            MaKhoi = maKhoi;
            MaNamHoc = maNamHoc;
        }


        public LopHocDTO()
        {
        }

        public string MaLop { get; set; }
        public string MaKhoi { get; set; }
        public string MaNamHoc { get; set; }
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string TenLop { get; set; }
        public int SiSo { get; set; }
    }
}
