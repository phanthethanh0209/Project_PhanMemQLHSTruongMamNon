using System;

namespace DTO
{
    public class HocSinhDTO
    {
        public string MaHS { get; set; }
        public string MaPH1 { get; set; }
        public string MaPH2 { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public int ChieuCao { get; set; }
        public string HinhAnh { get; set; }
        public string CanNang { get; set; }
        public string QuocTich { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayNhapHoc { get; set; }
        public string TinhTrang { get; set; }
        public DateTime? NgayKetThuc { get; set; }


        public int STT { get; set; }
        public string HoTenPH1 { get; set; }
        public string HoTenPH2 { get; set; }
        public string DienThoai1 { get; set; }
        public string DienThoai2 { get; set; }
        public HocSinhDTO()
        {

        }

        public HocSinhDTO(string maHS, string maPH1, string maPH2, string hoTen, string gioiTinh, DateTime ngaySinh, string diaChi, int chieuCao, string hinhAnh, string canNang, DateTime ngayNhapHoc, string ghiChu, string tinhTrang, DateTime? ngayKetThuc)
        {
            MaHS = maHS;
            MaPH1 = maPH1;
            MaPH2 = maPH2;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            ChieuCao = chieuCao;
            HinhAnh = hinhAnh;
            CanNang = canNang;
            NgayNhapHoc = ngayNhapHoc;
            GhiChu = ghiChu;
            TinhTrang = tinhTrang;
            NgayKetThuc = ngayKetThuc;

        }


        public HocSinhDTO(string maHS, string hoTen, string gioiTinh, DateTime ngaySinh, string diaChi, string quocTich)
        {
            MaHS = maHS;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            QuocTich = quocTich;


        }


        //DTO dùng để phân lớp
        public HocSinhDTO(string maHS, string hoTen, string gioiTinh, DateTime ngaySinh, string diaChi)
        {
            MaHS = maHS;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
        }


    }
}
