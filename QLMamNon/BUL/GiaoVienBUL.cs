using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class GiaoVienBUL
    {
        GiaoVienDAL nguoidungDAL = new GiaoVienDAL();

        public List<GiaoVienDTO> getAll()
        {
            List<GiaoVienDTO> lst = new List<GiaoVienDTO>();
            DataTable table = nguoidungDAL.getAll();
            foreach (DataRow row in table.Rows)
            {
                GiaoVienDTO dto;
                string maGV = row["MaGV"].ToString();
                string tenGV = row["TenGV"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string email = row["Email"].ToString();
                string dienThoai = row["DienThoai"].ToString();
                string diaChi = row["DiaChi"].ToString();
                string trinhDo = row["TrinhDo"].ToString();
                string chuyenMon = row["ChuyenMon"].ToString();
                string noiDaoTao = row["NoiDaoTao"].ToString();
                string chucVu = row["ChucVu"].ToString();
                //string gioiTinh = row["GioiTinh"].ToString();

                dto = new GiaoVienDTO(maGV, tenGV, ngaySinh, email, dienThoai, diaChi, trinhDo, chuyenMon, noiDaoTao, chucVu);
                lst.Add(dto);
            }
            return lst;
        }

        public List<GiaoVienDTO> layTatCaGVTheoMalop(string maLop)
        {
            List<GiaoVienDTO> lst = new List<GiaoVienDTO>();
            DataTable table = nguoidungDAL.layTatCaGVTheoMalop(maLop);
            GiaoVienDTO dto = new GiaoVienDTO();

            foreach (DataRow row in table.Rows)
            {
                string maGV = row["MaGV"].ToString();
                string tenGV = row["HoTen"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string email = row["Email"].ToString();
                string dienThoai = row["DienThoai"].ToString();
                string diaChi = row["DiaChi"].ToString();
                string trinhDo = row["TrinhDo"].ToString();
                string chuyenMon = row["ChuyenMon"].ToString();
                string noiDaoTao = row["NoiDaoTao"].ToString();
                string chucVu = row["ChucVu"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                string vaiTro = row["VaiTro"].ToString();
                dto = new GiaoVienDTO(maGV, tenGV, ngaySinh, email, dienThoai, diaChi, trinhDo, chuyenMon, noiDaoTao, chucVu, gioiTinh, vaiTro);
                lst.Add(dto);
            }
            return lst;
        }

        public GiaoVienDTO layThongTinMotGV(string maGV)
        {
            DataTable table = nguoidungDAL.layThongTinMotGV(maGV);
            GiaoVienDTO dto = new GiaoVienDTO();
            foreach (DataRow row in table.Rows)
            {
                string tenGV = row["HoTen"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string email = row["Email"].ToString();
                string dienThoai = row["DienThoai"].ToString();
                string diaChi = row["DiaChi"].ToString();
                string trinhDo = row["TrinhDo"].ToString();
                string chuyenMon = row["ChuyenMon"].ToString();
                string noiDaoTao = row["NoiDaoTao"].ToString();
                string chucVu = row["ChucVu"].ToString();
                dto = new GiaoVienDTO(maGV, tenGV, ngaySinh, email, dienThoai, diaChi, trinhDo, chuyenMon, noiDaoTao, chucVu);
            }
            return dto;
        }



        public GiaoVienDTO layGVPhuTrachTheoLop(string maLop)
        {
            DataTable table = nguoidungDAL.layGVPhuTrachTheoLop(maLop);
            GiaoVienDTO dto = new GiaoVienDTO();
            foreach (DataRow row in table.Rows)
            {
                string maGV = row["MaGV"].ToString();
                string tenGV = row["HoTen"].ToString();
                //DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string email = row["Email"].ToString();
                string dienThoai = row["DienThoai"].ToString();
                //string trinhDo = row[6].ToString();
                //string chuyenMon = row[7].ToString();
                //string noiDaoTao = row[8].ToString();
                //string chucVu = row[9].ToString();
                dto = new GiaoVienDTO(maGV, tenGV, email, dienThoai);
            }
            return dto;
        }

        public List<GiaoVienDTO> layGiaoVienChuaCoLop(string maLop)
        {
            // Điều chỉnh phương thức này để chỉ lấy giáo viên chưa có phân công cho lớp maLop
            return nguoidungDAL.LayGiaoVienChuaPhanCongChoLop(maLop);
        }



        public GiaoVienDTO layThongTinGV(string maGV)
        {
            DataTable table = nguoidungDAL.layThongTinMotGV(maGV);
            GiaoVienDTO dto = new GiaoVienDTO();
            foreach (DataRow row in table.Rows)
            {
                string trinhDo = row["TrinhDo"].ToString();
                string chuyenMon = row["ChuyenMon"].ToString();
                string noiDaoTao = row["NoiDaoTao"].ToString();
                string hoTen = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                dto = new GiaoVienDTO(maGV, trinhDo, chuyenMon, noiDaoTao, gioiTinh, hoTen);
            }
            return dto;
        }

        public GiaoVienDTO kiemTraNDLaGV(string maGV)
        {
            DataTable table = nguoidungDAL.kiemTraNDLaGV(maGV);
            GiaoVienDTO dto = new GiaoVienDTO();
            foreach (DataRow row in table.Rows)
            {
                string trinhDo = row["TrinhDo"].ToString();
                string chuyenMon = row["ChuyenMon"].ToString();
                string noiDaoTao = row["NoiDaoTao"].ToString();

                dto = new GiaoVienDTO(maGV);
            }
            return dto;
        }

        public int isExit(string maND)
        {
            return nguoidungDAL.demSoGV(maND);
        }
        public bool InsertUser(GiaoVienDTO nguoidung)
        {
            return nguoidungDAL.InsertUser(nguoidung);
        }

        public bool UpdateUser(GiaoVienDTO nguoidung)
        {
            return nguoidungDAL.UpdateUser(nguoidung);
        }

        public bool DeleteUser(GiaoVienDTO nguoidung)
        {
            return nguoidungDAL.DeleteUser(nguoidung);
        }
    }
}
