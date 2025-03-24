namespace DTO
{
    public class NguoiDung_NhomNguoiDungDTO
    {
        public string MaND { get; set; }
        public string MaNhomNguoiDung { get; set; }
        public string GhiChu { get; set; }
        public string TenTK { get; set; }
        public string HoTen { get; set; }


        public NguoiDung_NhomNguoiDungDTO()
        {
            MaND = "";
            MaNhomNguoiDung = "";
            GhiChu = "";
        }
        public NguoiDung_NhomNguoiDungDTO(string maND, string maNhomND, string ghiChu)
        {
            MaND = maND;
            MaNhomNguoiDung = maNhomND;
            GhiChu = ghiChu;
        }

        public NguoiDung_NhomNguoiDungDTO(string maNhom, string maND, string tenTK, string tenND, string ghiChu)
        {
            MaNhomNguoiDung = maNhom;
            MaND = maND;
            TenTK = tenTK;
            HoTen = tenND;
            GhiChu = ghiChu;
        }
    }
}
