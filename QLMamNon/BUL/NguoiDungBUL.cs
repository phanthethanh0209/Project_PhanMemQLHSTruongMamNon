using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
namespace BUL
{
    public class NguoiDungBUL
    {
        NguoiDungDAL nguoidungDAL = new NguoiDungDAL();

        public List<NguoiDungDTO> getAll()
        {
            List<NguoiDungDTO> lst = new List<NguoiDungDTO>();
            DataTable table = nguoidungDAL.getAll();
            foreach (DataRow row in table.Rows)
            {
                NguoiDungDTO dto;
                string maND = row["MaND"].ToString();
                string tenTK = row["TenTK"].ToString();
                string matKhau = row["MatKhau"].ToString();
                int trangThai = int.Parse(row["TrangThai"].ToString());
                string hoTen = row["HoTen"].ToString();
                string dienThoai = row["DienThoai"].ToString();
                string diaChi = row["DiaChi"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string chucVu = row["ChucVu"].ToString();
                string email = row["Email"].ToString();
                dto = new NguoiDungDTO(maND, tenTK, matKhau, trangThai, hoTen, dienThoai, diaChi, gioiTinh, ngaySinh, chucVu, email);
                lst.Add(dto);
            }
            return lst;
        }

        public List<NguoiDungDTO> layThongTinTheoMa()
        {
            List<NguoiDungDTO> lst = new List<NguoiDungDTO>();
            DataTable table = nguoidungDAL.layThongTinMotND();
            foreach (DataRow row in table.Rows)
            {
                NguoiDungDTO dto;
                string maND = row["MaND"].ToString();
                string tenTK = row["TenTK"].ToString();
                string hoTen = row["HoTen"].ToString();
                string chucVu = row["ChucVu"].ToString();
                dto = new NguoiDungDTO(maND, tenTK, hoTen, chucVu);
                lst.Add(dto);
            }
            return lst;
        }

        public NguoiDungDTO layThongTinTheoMa(string maND)
        {
            NguoiDungDTO dto = new NguoiDungDTO();
            DataTable table = nguoidungDAL.layThongTinTheoMa(maND);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string tenTK = row["TenTK"].ToString();
                string matKhau = row["MatKhau"].ToString();
                int trangThai = int.Parse(row["TrangThai"].ToString());
                string hoTen = row["HoTen"].ToString();
                string dienThoai = row["DienThoai"].ToString();
                string diaChi = row["DiaChi"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string chucVu = row["ChucVu"].ToString();
                string email = row["Email"].ToString();
                dto = new NguoiDungDTO(maND, tenTK, matKhau, trangThai, hoTen, dienThoai, diaChi, gioiTinh, ngaySinh, chucVu, email);
            }
            return dto;
        }

        public string TaoMaND()
        {
            DataTable dt = nguoidungDAL.layMaNDTOP();

            // Kiểm tra dữ liệu trả về từ bảng
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                string maxMa = dt.Rows[0][0].ToString(); // Lấy giá trị MAX(MaND)

                // Lấy số phần của mã (VD: ND001 -> 001)
                string soPhan = maxMa.Substring(2);
                if (int.TryParse(soPhan, out int so))
                {
                    so++; // Tăng số lên 1
                    return "ND" + so.ToString("D3"); // Định dạng 3 chữ số (VD: 002 -> ND002)
                }
                else
                {
                    throw new Exception("Lỗi định dạng mã ND trong cơ sở dữ liệu.");
                }
            }
            else
            {
                return "ND001"; // Nếu chưa có dữ liệu, trả về mã đầu tiên
            }
        }

        public List<NguoiDungDTO> layTatCaNguoiDung()
        {
            List<NguoiDungDTO> lst = new List<NguoiDungDTO>();
            DataTable table = nguoidungDAL.layTatCaNguoiDung();
            foreach (DataRow row in table.Rows)
            {
                NguoiDungDTO dto;
                string maNV = row["MaND"].ToString();
                string tenTKNV = row["TenTK"].ToString();
                string matKhau = row["MatKhau"].ToString();
                int trangThai = int.Parse(row["TrangThai"].ToString());
                string hoTen = row["HoTen"].ToString();
                string dienThoai = row["DienThoai"].ToString();
                string diaChi = row["DiaChi"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string chucVu = row["ChucVu"].ToString();
                string email = row["Email"].ToString();
                dto = new NguoiDungDTO(maNV, tenTKNV, matKhau, trangThai, hoTen, dienThoai, diaChi, gioiTinh, ngaySinh, chucVu, email);
                lst.Add(dto);
            }
            return lst;
        }

        public NguoiDungDTO layMotNguoiDung(string maND)
        {
            DataTable table = nguoidungDAL.layMotNguoiDung(maND);
            NguoiDungDTO dto = new NguoiDungDTO();
            foreach (DataRow row in table.Rows)
            {

                string maNV = row["MaND"].ToString();
                string tenTKNV = row["TenTK"].ToString();
                string matKhau = row["MatKhau"].ToString();
                int trangThai = int.Parse(row["TrangThai"].ToString());
                string hoTen = row["HoTen"].ToString();
                string dienThoai = row["DienThoai"].ToString();
                string diaChi = row["DiaChi"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string chucVu = row["ChucVu"].ToString();
                string email = row["Email"].ToString();
                dto = new NguoiDungDTO(maNV, tenTKNV, matKhau, trangThai, hoTen, dienThoai, diaChi, gioiTinh, ngaySinh, chucVu, email);

            }
            return dto;
        }


        public NguoiDungDTO dangNhap(string tenTK, string mk)
        {
            DataTable table = nguoidungDAL.dangNhap(tenTK, mk);
            NguoiDungDTO dto = new NguoiDungDTO();
            foreach (DataRow row in table.Rows)
            {

                string maNV = row["MaND"].ToString();
                string tenTKNV = row["TenTK"].ToString();
                string matKhau = row["MatKhau"].ToString();
                int trangThai = int.Parse(row["TrangThai"].ToString());
                string hoTen = row["HoTen"].ToString();
                //string dienThoai = row["DienThoai"].ToString();
                //string diaChi = row["DiaChi"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                //DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                //string chucVu = row["ChucVu"].ToString();
                //string email = row["Email"].ToString();
                dto = new NguoiDungDTO(maNV, tenTKNV, matKhau, trangThai, hoTen, gioiTinh);

            }
            return dto;
        }


        public List<NguoiDungDTO> layNDConHoatDongVaKoCoTrongNhom(string maNhom)
        {
            List<NguoiDungDTO> lst = new List<NguoiDungDTO>();
            DataTable table = nguoidungDAL.layNDConHoatDongVaKoCoTrongNhom(maNhom);
            foreach (DataRow row in table.Rows)
            {
                NguoiDungDTO dto;
                string maNV = row["MaND"].ToString();
                string tenTKNV = row["TenTK"].ToString();

                string hoTen = row["HoTen"].ToString();

                dto = new NguoiDungDTO(maNV, tenTKNV, hoTen);
                lst.Add(dto);
            }
            return lst;
        }

        public bool InsertUser(NguoiDungDTO nguoidung)
        {
            return nguoidungDAL.InsertUser(nguoidung);
        }

        public bool UpdateUser(NguoiDungDTO nguoidung)
        {
            return nguoidungDAL.UpdateUser(nguoidung);
        }

        public bool DeleteUser(string TenDangNhap)
        {
            return nguoidungDAL.DeleteUser(TenDangNhap);
        }



        public bool doiMatKhau(string tentk, string mkCu, string mkMoi)
        {
            return nguoidungDAL.doiMatKhau(tentk, mkCu, mkMoi);
        }
    }
}
