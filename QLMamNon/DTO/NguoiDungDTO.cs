using System;

namespace DTO
{
    public class NguoiDungDTO
    {
        public string MaND { get; set; }
        public string TenTK { get; set; }
        public string MatKhau { get; set; }
        public int TrangThai { get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string ChucVu { get; set; }
        public string Email { get; set; }

        public NguoiDungDTO()
        {
            TrangThai = 0;
        }
        public NguoiDungDTO(string maND, string tenTK, string hoTen, string chucVu)
        {
            MaND = maND;
            TenTK = tenTK;
            HoTen = hoTen;
            ChucVu = chucVu;
        }

        public NguoiDungDTO(string maND, string tenTK, string hoTen)
        {
            MaND = maND;
            TenTK = tenTK;
            HoTen = hoTen;
        }

        public NguoiDungDTO(string maND, string tenTK, string matKhau, int trangThai, string hoTen, string gioiTinh)
        {
            MaND = maND;
            TenTK = tenTK;
            MatKhau = matKhau;
            HoTen = hoTen;
            TrangThai = trangThai;
            GioiTinh = gioiTinh;
        }

        public NguoiDungDTO(string maND, string tenTK, string matKhau, int trangThai, string hoTen, string dienThoai, string diaChi, string gioiTinh, DateTime ngaySinh, string chucVu, string email)
        {
            MaND = maND;
            TenTK = tenTK;
            MatKhau = matKhau;
            TrangThai = trangThai;
            HoTen = hoTen;
            DienThoai = dienThoai;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            ChucVu = chucVu;
            Email = email;
        }
    }
}
