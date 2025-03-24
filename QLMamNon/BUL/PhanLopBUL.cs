using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BUL
{
    public class PhanLopBUL
    {
        PhanLopDAL phanlopDAL = new PhanLopDAL();
        HocSinhDAL hocsinhDAL = new HocSinhDAL();

        public List<HocSinhDTO> layDSHSChuaPhanLop(string malop, string maNamHoc)
        {
            List<PhanLopDTO> lst = new List<PhanLopDTO>();
            List<HocSinhDTO> lstHocSinh = new List<HocSinhDTO>();
            DataTable table = phanlopDAL.layDSHSChuaPhanLop(malop, maNamHoc);
            foreach (DataRow row in table.Rows)
            {
                string maHS = row[0].ToString();
                string maLop = row[1].ToString();

                DataTable tableHS = hocsinhDAL.layThongTinMotHocSinh(maHS);

                foreach (DataRow hs in tableHS.Rows)
                {
                    HocSinhDTO hsdto;
                    string tenhs = hs["HoTen"].ToString();
                    string gioiTinh = hs["GioiTinh"].ToString();
                    string diaChi = hs["DiaChi"].ToString();

                    DateTime ngaySinh;
                    if (DateTime.TryParse(row["NgaySinh"].ToString(), out ngaySinh))
                    {
                        ngaySinh = ngaySinh.Date;
                        hsdto = new HocSinhDTO(maHS, tenhs, gioiTinh, ngaySinh, diaChi);
                        lstHocSinh.Add(hsdto);
                    }

                }
            }
            return lstHocSinh;
        }

        public int demSoHSTrongKhoi(string maNH, string tenKhoi)
        {
            return phanlopDAL.demSoHSTrong1Khoi(maNH, tenKhoi);
        }

        public List<HocSinhDTO> layDSHSChuaDuocChonVaChuaPhanLop(List<HocSinhDTO> dsHSDaChon, string malop, string maNamHoc)
        {
            List<HocSinhDTO> dsHS = layDSHSChuaPhanLop(malop, maNamHoc);
            List<HocSinhDTO> dsChuaCoLop = new List<HocSinhDTO>();
            foreach (HocSinhDTO hs in dsHS)
            {
                if (dsHSDaChon == null || !dsHSDaChon.Any(h => h.MaHS == hs.MaHS))
                {
                    dsChuaCoLop.Add(hs);
                }

            }
            return dsChuaCoLop;
        }

        public List<PhanLopDTO> layTatCaHocSinhTheoMaLop(string malop)
        {
            List<PhanLopDTO> lst = new List<PhanLopDTO>();
            DataTable table = phanlopDAL.layTatCaHocSinhTheoMaLop(malop);
            foreach (DataRow row in table.Rows)
            {
                PhanLopDTO dto;
                string maHS = row["MaHS"].ToString();
                string maLop = row["MaLop"].ToString();
                //string tinhTrang = row["TinhTrang"].ToString();
                string danhGia = row["DanhGia"].ToString();
                dto = new PhanLopDTO(maLop, maHS, danhGia);
                lst.Add(dto);
            }
            return lst;
        }


        public bool Insert(PhanLopDTO nguoidung)
        {
            return phanlopDAL.Insert(nguoidung);
        }

        public bool CapNhatTTCuoiNam(PhanLopDTO pl)
        {
            return phanlopDAL.CapNhatTTCuoiNam(pl);
        }


        public PhanLopDTO layThongTinDanhGia(string maHS, string maLop)
        {
            PhanLopDTO dto = new PhanLopDTO();
            DataTable table = phanlopDAL.layThongTinDanhGia(maHS, maLop);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                //string tinhTrang = row["TinhTrang"].ToString();
                string danhGia = row["DanhGia"].ToString();
                string xepLoai = row["XepLoai"].ToString();

                //dto = new PhanLopDTO(maLop, maHS, tinhTrang, danhGia, xepLoai);
                dto = new PhanLopDTO(maLop, maHS, danhGia, xepLoai);
            }

            return dto;
        }

        public bool Delete(PhanLopDTO nguoidung)
        {
            return phanlopDAL.Delete(nguoidung);
        }
    }
}
