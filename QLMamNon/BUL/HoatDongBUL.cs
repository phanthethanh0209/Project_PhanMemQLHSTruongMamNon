using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class HoatDongBUL
    {
        HoatDongDAL hoatDongDAL = new HoatDongDAL();

        public List<HoatDongDTO> layTatCaHoatDongTrongNam(string maNamHoc)
        {
            List<HoatDongDTO> lst = new List<HoatDongDTO>();
            DataTable table = hoatDongDAL.layTatCaHoatDongTrongNam(maNamHoc);
            foreach (DataRow row in table.Rows)
            {
                HoatDongDTO dto;
                string maHD = row["MaHD"].ToString();
                string tenHDNK = row["TenHDNK"].ToString();
                DateTime ngayTG = DateTime.Parse(row["NgayTG"].ToString());
                double soTien = double.Parse(row["SoTien"].ToString());
                string trangThaiDK = row["TrangThaiDK"].ToString();

                dto = new HoatDongDTO(maHD, tenHDNK, ngayTG, soTien, maNamHoc, trangThaiDK);
                lst.Add(dto);
            }
            return lst;
        }

        public List<HoatDongDTO> layTatCaHoatDongSapDienRaTrongNam(string maNamHoc)
        {
            List<HoatDongDTO> lst = new List<HoatDongDTO>();
            DataTable table = hoatDongDAL.layTatCaHoatDongSapDienRaTrongNam(maNamHoc);
            foreach (DataRow row in table.Rows)
            {
                HoatDongDTO dto;
                string maHD = row["MaHD"].ToString();
                string tenHDNK = row["TenHDNK"].ToString();
                DateTime ngayTG = DateTime.Parse(row["NgayTG"].ToString());
                double soTien = double.Parse(row["SoTien"].ToString());
                string trangThaiDK = row["TrangThaiDK"].ToString();

                dto = new HoatDongDTO(maHD, tenHDNK, ngayTG, soTien, maNamHoc, trangThaiDK);
                lst.Add(dto);
            }
            return lst;
        }


        public HoatDongDTO layThongTinMotHoatDong(string maHD)
        {
            HoatDongDTO dto = new HoatDongDTO();
            DataTable table = hoatDongDAL.layThongTinMotHoatDong(maHD);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string tenHDNK = row["TenHDNK"].ToString();
                string maNamHoc = row["MaNamHoc"].ToString();
                DateTime ngayTG = DateTime.Parse(row["NgayTG"].ToString());
                double soTien = double.Parse(row["SoTien"].ToString());
                string trangThaiDK = row["TrangThaiDK"].ToString();

                dto = new HoatDongDTO(maHD, tenHDNK, ngayTG, soTien, maNamHoc, trangThaiDK);
            }
            return dto;
        }

        //public List<GiaoVienDTO> layGiaoVienChuaCoLop(string maLop)
        //{
        //    // Điều chỉnh phương thức này để chỉ lấy giáo viên chưa có phân công cho lớp maLop
        //    return nguoidungDAL.LayGiaoVienChuaPhanCongChoLop(maLop);
        //}

        public string TaoMaHS(string maNamHoc)
        {
            string key = "HD" + maNamHoc.Trim();

            DataTable dt = hoatDongDAL.layMaHDCuoiCung(key);

            if (dt.Rows.Count == 0)
            {
                key += "-001";
            }
            else
            {

                string maBanDau = dt.Rows[0][0].ToString();
                string sott = maBanDau.Substring(9, 3);
                int num = int.Parse(sott) + 1;
                if (num < 10)
                    key += "-00" + num;
                else
                {
                    if (num < 100)
                        key += "-0" + num;
                    else
                        key += num;
                }
            }
            return key;

        }


        public bool themHoatDong(HoatDongDTO nguoidung)
        {
            return hoatDongDAL.themHoatDong(nguoidung);
        }

        public bool suaHoatDong(HoatDongDTO nguoidung)
        {
            return hoatDongDAL.suaHoatDong(nguoidung);
        }

        public bool xoaHoatDong(HoatDongDTO nguoidung)
        {
            return hoatDongDAL.xoaHoatDong(nguoidung);
        }
    }
}
