using System;

namespace DTO
{
    public class DiemDanhDTO
    {
        public string MaDiemDanh { get; set; }
        public string MaLop { get; set; }
        public string MaHS { get; set; }
        public DateTime? NgayDiemDanh { get; set; }
        public int? VangKPhep { get; set; }
        public string GhiChu { get; set; }

        public DiemDanhDTO(string maDiemDanh, string maLop, string maHS, DateTime? ngayDiemDanh, int? vangKPhep, string ghiChu)
        {
            MaDiemDanh = maDiemDanh;
            MaLop = maLop;
            MaHS = maHS;
            NgayDiemDanh = ngayDiemDanh;
            VangKPhep = vangKPhep;
            GhiChu = ghiChu;
        }

        public DiemDanhDTO(string maDiemDanh, string maLop, string maHS, DateTime? ngayDiemDanh, string ghiChu)
        {
            MaDiemDanh = maDiemDanh;
            MaLop = maLop;
            MaHS = maHS;
            NgayDiemDanh = ngayDiemDanh;
            GhiChu = ghiChu;
        }

        public DiemDanhDTO()
        {
        }
    }
}
