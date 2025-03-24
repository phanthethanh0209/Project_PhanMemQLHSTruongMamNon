namespace DTO
{
    public class PhuHuynhDTO
    {
        public string MaPH { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public int NamSinh { get; set; }
        public string DiaChiCQ { get; set; }
        public string NgheNghiep { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string QuanHe { get; set; }


        public PhuHuynhDTO()
        {

        }

        public PhuHuynhDTO(string maPH, string hoTen, string gioiTinh, int namSinh, string diaChiCQ, string ngheNghiep, string dienThoai, string email, string quanHe)
        {
            MaPH = maPH;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NamSinh = namSinh;
            DiaChiCQ = diaChiCQ;
            NgheNghiep = ngheNghiep;
            DienThoai = dienThoai;
            Email = email;
            QuanHe = quanHe;
        }
    }
}
