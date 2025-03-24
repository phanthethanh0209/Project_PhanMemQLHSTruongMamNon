using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class DanhGiaTuanBUL
    {
        DanhGiaTuanDAL danhGiaTuanDAL = new DanhGiaTuanDAL();

        public DanhGiaTuanDTO layThongTinDanhGiaTuanCua1HS(string malop, string maHS, int tuan, int thang)
        {
            DanhGiaTuanDTO dto = new DanhGiaTuanDTO();
            DataTable table = danhGiaTuanDAL.layThongTinDanhGiaTuanCua1HS(malop, maHS, tuan, thang);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string maDG = row["MaDanhGiaTuan"].ToString();
                string noiDung = row["NoiDung"].ToString();
                int datPhieu = int.Parse(row["DatPhieuBeNgoan"].ToString());
                DateTime ngayDG = DateTime.Parse(row["NgayDG"].ToString());

                dto = new DanhGiaTuanDTO(maDG, malop, maHS, tuan, thang, datPhieu, noiDung, ngayDG);
            }
            return dto;
        }

        public DanhGiaTuanDTO layTuanDanhGiaMoi(string malop, int thang)
        {
            DanhGiaTuanDTO dto = new DanhGiaTuanDTO();
            DataTable table = danhGiaTuanDAL.layTuanDanhGiaMoi(malop, thang);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                if (row["Tuan"] != DBNull.Value && int.TryParse(row["Tuan"].ToString(), out int tuan))
                {
                    dto = new DanhGiaTuanDTO(malop, thang, tuan);
                }
            }
            return dto;
        }

        public int demSoTuanDanhGia(string maLop, string maHS, int thang)
        {
            return danhGiaTuanDAL.demSoTuanDanhGia(maLop, maHS, thang);
        }

        public bool kiemTraDanhGia3Ngay(string maLop, string maHS, int thang, int tuan)
        {
            return danhGiaTuanDAL.kiemTraDanhGia3Ngay(maLop, maHS, thang, tuan) != 0;
        }

        public List<DanhGiaTuanDTO> layDSHSDaDanhGia(string malop, int thang, int tuan)
        {
            List<DanhGiaTuanDTO> lst = new List<DanhGiaTuanDTO>();
            DataTable table = danhGiaTuanDAL.layDSHSDaDanhGia(malop, thang, tuan);
            foreach (DataRow row in table.Rows)
            {
                DanhGiaTuanDTO dto;
                string maHS = row["MaHS"].ToString();

                dto = new DanhGiaTuanDTO(malop, maHS, thang, tuan);

                lst.Add(dto);
            }
            return lst;
        }


        public string TaoMaDanhGiaTuan(int thang, int tuan, string maNam, string maHS)
        {
            string key = "DG";
            key += "T" + thang + "T" + tuan + maNam.Trim() + "_" + maHS;

            return key;
        }

        public int demDatPhieuBeNgoan(string maLop, string maHS, int thang)
        {
            return danhGiaTuanDAL.demDatPhieuBeNgoan(maLop, maHS, thang);
        }

        public int layTuanDGGanNhatCuaThang(string maLop, int thang)
        {
            return danhGiaTuanDAL.layTuanDGGanNhatCuaThang(maLop, thang);
        }

        public bool Insert(DanhGiaTuanDTO danhGia)
        {
            return danhGiaTuanDAL.Insert(danhGia);
        }

        public bool Update(DanhGiaTuanDTO danhGia)
        {
            return danhGiaTuanDAL.Update(danhGia);
        }
    }
}
