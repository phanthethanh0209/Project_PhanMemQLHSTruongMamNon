using System;

namespace DTO
{
    public class GiaoVienDTO
    {
        public string MaGV { get; set; }
        public string TenGV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string TrinhDo { get; set; }
        public string ChuyenMon { get; set; }
        public string NoiDaoTao { get; set; }
        public string ChucVu { get; set; }
        public string GioiTinh { get; set; }
        public string VaiTro { get; set; } //phân công

        public GiaoVienDTO(string maGV, string tenGV, string email, string dienThoai)
        {
            MaGV = maGV;
            TenGV = tenGV;
            Email = email;
            DienThoai = dienThoai;
        }

        public GiaoVienDTO(string maGV)
        {
            MaGV = maGV;
        }

        public GiaoVienDTO(string maGV, string trinhDo, string chuyenMon, string noiDaoTao, string gioiTinh, string tenGV)
        {
            MaGV = maGV;
            TrinhDo = trinhDo;
            ChuyenMon = chuyenMon;
            NoiDaoTao = noiDaoTao;
            GioiTinh = gioiTinh;
            TenGV = tenGV;
        }

        public GiaoVienDTO(string maGV, string tenGV, DateTime ngaySinh, string email, string dienThoai, string diaChi, string trinhDo, string chuyenMon, string noiDaoTao, string chucVu)
        {
            MaGV = maGV;
            TenGV = tenGV;
            NgaySinh = ngaySinh;
            Email = email;
            DienThoai = dienThoai;
            DiaChi = diaChi;
            TrinhDo = trinhDo;
            ChuyenMon = chuyenMon;
            NoiDaoTao = noiDaoTao;
            ChucVu = chucVu;
        }

        //giáo viên có vai trò
        public GiaoVienDTO(string maGV, string tenGV, DateTime ngaySinh, string email, string dienThoai, string diaChi, string trinhDo, string chuyenMon, string noiDaoTao, string chucVu, string gioiTinh, string vaiTro)
        {
            MaGV = maGV;
            TenGV = tenGV;
            NgaySinh = ngaySinh;
            Email = email;
            DienThoai = dienThoai;
            DiaChi = diaChi;
            TrinhDo = trinhDo;
            ChuyenMon = chuyenMon;
            NoiDaoTao = noiDaoTao;
            ChucVu = chucVu;
            GioiTinh = gioiTinh;
            VaiTro = vaiTro;
        }

        public GiaoVienDTO(string maGV, string tenGV, DateTime ngaySinh, string gioiTinh, string trinhDo, string noiDaoTao, string email, string dienThoai)
        {
            MaGV = maGV;
            TenGV = tenGV;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;

            TrinhDo = trinhDo;

            NoiDaoTao = noiDaoTao;
            Email = email;
            DienThoai = dienThoai;
        }


        public GiaoVienDTO()
        {
        }
    }
}
