namespace DTO
{
    public class PhanQuyenDTO
    {
        public string MaNhom { get; set; }
        public string MaMH { get; set; }
        public string TenNhom { get; set; }
        public string TenMH { get; set; }
        public string GhiChu { get; set; }


        //public PhanQuyenDTO()
        //{
        //    MaNhom = "";
        //    MaMH = "";
        //    CoQuyen = 0;
        //}
        //public PhanQuyenDTO(string maNhomND, string maMH, int coQuyen)
        //{
        //    MaNhom = maNhomND;
        //    MaMH = maMH;
        //    CoQuyen = coQuyen;
        //}


        public PhanQuyenDTO()
        {
            MaNhom = string.Empty;
            MaMH = string.Empty;
            TenNhom = string.Empty;
            TenMH = string.Empty;
            GhiChu = string.Empty;
        }

        public PhanQuyenDTO(string maNhom, string maMH, string tenNhom, string tenMH, string ghiChu)
        {
            MaNhom = maNhom;
            MaMH= maMH;
            TenNhom = tenNhom;
            TenMH = tenMH;
            GhiChu = ghiChu;
        }
    }
}
