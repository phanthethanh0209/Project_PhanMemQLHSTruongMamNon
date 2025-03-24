using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BUL
{
    public class HocSinhBUL
    {
        HocSinhDAL dal = new HocSinhDAL();

        public List<HocSinhDTO> getAll()
        {
            List<HocSinhDTO> lst = new List<HocSinhDTO>();
            DataTable table = dal.layTatCaHocSinh();
            foreach (DataRow row in table.Rows)
            {
                //HocSinhDTO dto;
                //string maHS = row["MaHS"].ToString();
                //string maPH1 = row["MaPH1"].ToString();
                //string maPH2 = row["MaPH2"].ToString();
                //string hoTen = row["HoTen"].ToString();
                //string gioiTinh = row["GioiTinh"].ToString();
                //string ngaySinh = Convert.ToDateTime(row["NgaySinh"]).ToString("yyyy-MM-dd");
                //string diaChi = row["DiaChi"].ToString();
                //int chieuCao = int.Parse(row["ChieuCao"].ToString());
                //string hinhAnh = row["HinhAnh"].ToString();
                //double canNang = double.Parse(row["CanNang"].ToString());
                //string ngayNhapHoc = Convert.ToDateTime(row["NgayNhapHoc"]).ToString("yyyy-MM-dd");
                //string ghiChu = row["GhiChu"].ToString();
                //string tinhTrang = row["TinhTrang"].ToString();
                //DateTime ngayKT = Convert.ToDateTime(row["NgayKetThuc"].ToString());
                //dto = new HocSinhDTO(maHS, maPH1, maPH2, hoTen, gioiTinh, ngaySinh, diaChi, chieuCao, hinhAnh, canNang, ngayNhapHoc, ghiChu, tinhTrang, ngayKT );
                //lst.Add(dto);
            }
            return lst;
        }

        public List<HocSinhDTO> layTatCaHocSinhTheoMaLop(string maLop)
        {
            List<HocSinhDTO> lst = new List<HocSinhDTO>();
            DataTable table = dal.layTatCaHocSinhTheoMaLop(maLop);
            foreach (DataRow row in table.Rows)
            {
                HocSinhDTO dto;
                string maHS = row["MaHS"].ToString();
                string maPH1 = row["MaPH1"].ToString();
                string maPH2 = row["MaPH2"].ToString();
                string hoTen = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string diaChi = row["DiaChi"].ToString();
                int chieuCao = int.Parse(row["ChieuCao"].ToString());
                string hinhAnh = row["HinhAnh"].ToString();
                string canNang = row["CanNang"].ToString();
                DateTime ngayNhapHoc = DateTime.Parse(row["NgayNhapHoc"].ToString());
                string ghiChu = row["GhiChu"].ToString();
                string tinhTrang = row["TinhTrang"].ToString();
                DateTime? ngayKT = row["NgayKetThuc"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayKetThuc"].ToString());
                dto = new HocSinhDTO(maHS, maPH1, maPH2, hoTen, gioiTinh, ngaySinh, diaChi, chieuCao, hinhAnh, canNang, ngayNhapHoc, ghiChu, tinhTrang, ngayKT);
                lst.Add(dto);
            }
            return lst;
        }

        public List<HocSinhDTO> layTatCaHocSinhChuaPhanLop()
        {
            List<HocSinhDTO> lst = new List<HocSinhDTO>();
            DataTable table = dal.layTatCaHocSinhChuaPhanLop();
            foreach (DataRow row in table.Rows)
            {
                HocSinhDTO dto;
                string maHS = row["MaHS"].ToString();
                string maPH1 = row["MaPH1"].ToString();
                string maPH2 = row["MaPH2"].ToString();
                string hoTen = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string diaChi = row["DiaChi"].ToString();
                int chieuCao = int.Parse(row["ChieuCao"].ToString());
                string hinhAnh = row["HinhAnh"].ToString();
                string canNang = row["CanNang"].ToString();
                DateTime ngayNhapHoc = DateTime.Parse(row["NgayNhapHoc"].ToString());
                string ghiChu = row["GhiChu"].ToString();
                string tinhTrang = row["TinhTrang"].ToString();
                DateTime? ngayKT = row["NgayKetThuc"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayKetThuc"].ToString());
                dto = new HocSinhDTO(maHS, maPH1, maPH2, hoTen, gioiTinh, ngaySinh, diaChi, chieuCao, hinhAnh, canNang, ngayNhapHoc, ghiChu, tinhTrang, ngayKT);
                lst.Add(dto);
            }
            return lst;
        }


        public List<HocSinhDTO> layTatCaHocSinhTheoMaLopCoQuocTich(string maLop)
        {
            List<HocSinhDTO> lst = new List<HocSinhDTO>();
            DataTable table = dal.layTatCaHocSinhTheoMaLopCoQuocTich(maLop);
            foreach (DataRow row in table.Rows)
            {
                HocSinhDTO dto;
                string maHS = row["MaHS"].ToString();

                string hoTen = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string diaChi = row["DiaChi"].ToString();

                string quocTich = row["QuocTich"].ToString();

                dto = new HocSinhDTO(maHS, hoTen, gioiTinh, ngaySinh, diaChi, quocTich);
                lst.Add(dto);
            }
            return lst;
        }

        public List<HocSinhDTO> timKiemHocSinhTheoMaTenLop(string serach, string maLop)
        {
            DataTable table = dal.timKiemHocSinhTheoMaTenLop(serach, maLop);
            List<HocSinhDTO> lst = new List<HocSinhDTO>();
            HocSinhDTO dto;
            foreach (DataRow row in table.Rows)
            {
                string maHS = row["MaHS"].ToString();
                string maPH1 = row["MaPH1"].ToString();
                string maPH2 = row["MaPH2"].ToString();
                string hoTen = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string diaChi = row["DiaChi"].ToString();
                int chieuCao = int.Parse(row["ChieuCao"].ToString());
                string hinhAnh = row["HinhAnh"].ToString();
                string canNang = row["CanNang"].ToString();
                DateTime ngayNhapHoc = DateTime.Parse(row["NgayNhapHoc"].ToString());
                string ghiChu = row["GhiChu"].ToString();
                string tinhTrang = row["TinhTrang"].ToString();
                DateTime? ngayKT = row["NgayKetThuc"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayKetThuc"].ToString());

                dto = new HocSinhDTO(maHS, maPH1, maPH2, hoTen, gioiTinh, ngaySinh, diaChi, chieuCao, hinhAnh, canNang, ngayNhapHoc, ghiChu, tinhTrang, ngayKT);
                lst.Add(dto);
            }
            return lst;
        }


        public HocSinhDTO layThongTinMotHocSinh(string maHSMoi)
        {
            DataTable table = dal.layThongTinMotHocSinh(maHSMoi);
            HocSinhDTO dto = null;

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];

                string maHS = row["MaHS"].ToString();
                string maPH1 = row["MaPH1"].ToString();
                string maPH2 = row["MaPH2"].ToString();
                string hoTen = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string diaChi = row["DiaChi"].ToString();
                int chieuCao = int.Parse(row["ChieuCao"].ToString());
                string hinhAnh = row["HinhAnh"].ToString();
                string canNang = row["CanNang"].ToString();
                DateTime ngayNhapHoc = DateTime.Parse(row["NgayNhapHoc"].ToString());
                string ghiChu = row["GhiChu"].ToString();
                string tinhTrang = row["TinhTrang"].ToString();
                DateTime? ngayKT = row["NgayKetThuc"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayKetThuc"].ToString());


                dto = new HocSinhDTO(maHS, maPH1, maPH2, hoTen, gioiTinh, ngaySinh, diaChi, chieuCao, hinhAnh, canNang, ngayNhapHoc, ghiChu, tinhTrang, ngayKT);
            }

            return dto;
        }



        //Form Phân lớp - DS Học sinh mới
        public List<HocSinhDTO> layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(int tuoiMin, int tuoiMax, List<HocSinhDTO> lstDSHSDangPhanLop)
        {
            List<HocSinhDTO> lst = new List<HocSinhDTO>();
            DataTable lstTheoDoTuoi = dal.layTatCaHocSinhTheoDoTuoi(tuoiMin, tuoiMax);
            // Lấy ra những học sinh thuộc lstTheoDoTuoi nhưng không thuộc lstDSHSDangPhanLop
            foreach (DataRow row in lstTheoDoTuoi.Rows)
            {
                string maHS = row["MaHS"].ToString();

                // Chỉ thêm học sinh chưa có trong danh sách đã phân lớp
                if (lstDSHSDangPhanLop == null || !lstDSHSDangPhanLop.Any(h => h.MaHS == maHS))
                {
                    HocSinhDTO dto = new HocSinhDTO
                    (
                        maHS,
                        row["HoTen"].ToString(),
                        row["GioiTinh"].ToString(),
                        DateTime.Parse(row["NgaySinh"].ToString()),
                        row["DiaChi"].ToString()
                    );
                    lst.Add(dto);
                }
            }
            return lst;
        }


        public List<HocSinhDTO> layHocSinhToanTruongTheoDoTuoi(int tuoiMin, int tuoiMax)
        {
            List<HocSinhDTO> lst = new List<HocSinhDTO>();
            DataTable table = dal.layHocSihToanTruongTheoDoTuoi(tuoiMin, tuoiMax);
            foreach (DataRow row in table.Rows)
            {
                HocSinhDTO dto = new HocSinhDTO
                (
                    row["MaHS"].ToString(),
                    row["HoTen"].ToString(),
                    row["GioiTinh"].ToString(),
                    DateTime.Parse(row["NgaySinh"].ToString()),
                    row["DiaChi"].ToString()
                );
                lst.Add(dto);
            }
            return lst;
        }

        public List<HocSinhDTO> layHocSinhToanTruong()
        {
            List<HocSinhDTO> lst = new List<HocSinhDTO>();
            DataTable table = dal.layHocSinhToanTruong();
            foreach (DataRow row in table.Rows)
            {
                HocSinhDTO dto = new HocSinhDTO
                (
                    row["MaHS"].ToString(),
                    row["HoTen"].ToString(),
                    row["GioiTinh"].ToString(),
                    DateTime.Parse(row["NgaySinh"].ToString()),
                    row["DiaChi"].ToString()
                );
                lst.Add(dto);
            }
            return lst;
        }

        public List<HocSinhDTO> timKiemHocSinhTheoMaHoacTen(string serach)
        {
            DataTable table = dal.timKiemHocSinhTheoMaHoacTen(serach);
            List<HocSinhDTO> lst = new List<HocSinhDTO>();
            HocSinhDTO dto;
            foreach (DataRow row in table.Rows)
            {
                string maHS = row["MaHS"].ToString();
                string maPH1 = row["MaPH1"].ToString();
                string maPH2 = row["MaPH2"].ToString();
                string hoTen = row["HoTen"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                string diaChi = row["DiaChi"].ToString();
                int chieuCao = int.Parse(row["ChieuCao"].ToString());
                string hinhAnh = row["HinhAnh"].ToString();
                string canNang = row["CanNang"].ToString();
                DateTime ngayNhapHoc = DateTime.Parse(row["NgayNhapHoc"].ToString());
                string ghiChu = row["GhiChu"].ToString();
                string tinhTrang = row["TinhTrang"].ToString();
                DateTime? ngayKT = row["NgayKetThuc"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(row["NgayKetThuc"].ToString());

                dto = new HocSinhDTO(maHS, maPH1, maPH2, hoTen, gioiTinh, ngaySinh, diaChi, chieuCao, hinhAnh, canNang, ngayNhapHoc, ghiChu, tinhTrang, ngayKT);
                lst.Add(dto);
            }
            return lst;
        }

        public string TaoMaHS(string maNH)
        {
            string key = "HS" + maNH;

            DataTable dt = dal.layMaHSCuoiCung(maNH);

            if (dt.Rows.Count == 0)
            {
                key += "0001";
            }
            else
            {

                string maBanDau = dt.Rows[0][0].ToString();
                string sott = maBanDau.Remove(0, 8);//xóa 8 kí tự đầu //maBanDau.Substring(2, 4);
                int num = int.Parse(sott) + 1;
                if (num < 10)
                    key += "000" + num;
                else
                {
                    if (num < 100)
                        key += "00" + num;
                    else if (num < 10)
                        key += "0" + num;
                    else
                        key += num;
                }
            }
            return key;

        }
        public bool CapNhatTrangThai(HocSinhDTO hs)
        {
            return dal.CapNhatTrangThai(hs);
        }

        public bool themHocSinh(HocSinhDTO hs)
        {
            return dal.themHocSinh(hs);
        }

        public bool suaHocSinh(HocSinhDTO hs)
        {
            return dal.suaHocSinh(hs);
        }

        public bool xoaHocSinh(string maHS)
        {
            return dal.xoaHocSinh(maHS);
        }
    }
}
