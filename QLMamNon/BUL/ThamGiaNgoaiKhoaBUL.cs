using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class ThamGiaNgoaiKhoaBUL
    {
        ThamGiaNgoaiKhoaDAL thamGiaNgoaiKhoaDAL = new ThamGiaNgoaiKhoaDAL();

        //public List<ThamGiaNgoaiKhoaDTO> layDSHSThamGiaNgoaiKhoa(string MaHD, string maLop)
        //{
        //    DataTable table = thamGiaNgoaiKhoaDAL.layDSHSThamGiaNgoaiKhoa(MaHD, maLop);
        //    List<ThamGiaNgoaiKhoaDTO> lst = new List<ThamGiaNgoaiKhoaDTO>();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        ThamGiaNgoaiKhoaDTO dto = new ThamGiaNgoaiKhoaDTO();
        //        string maTTHD = row["MaTTHD"].ToString();
        //        string maHS = row["MaHS"].ToString();
        //        string maHD = row["MaHD"].ToString();
        //        string tenHS = row["HoTen"].ToString();
        //        double tienNhan = row["TienNhan"] == DBNull.Value ? 0 : double.Parse( row["TienNhan"].ToString());
        //        DateTime ngayDK = row["NgayDK"] == DBNull.Value ? DateTime.Now : DateTime.Parse(row["NgayDK"].ToString());

        //        dto = new ThamGiaNgoaiKhoaDTO(maTTHD, ngayDK, maHD, maHS, tenHS, tienNhan);
        //        lst.Add(dto);
        //    }
        //    return lst;
        //}

        public List<ThamGiaNgoaiKhoaDTO> timKiemHocSinhTheoMaHoacTen(string search, string MaHD, string maLop)
        {
            DataTable table = thamGiaNgoaiKhoaDAL.timKiemHocSinhTheoMaHoacTen(search, MaHD, maLop);
            List<ThamGiaNgoaiKhoaDTO> lst = new List<ThamGiaNgoaiKhoaDTO>();
            foreach (DataRow row in table.Rows)
            {
                ThamGiaNgoaiKhoaDTO dto = new ThamGiaNgoaiKhoaDTO();
                string maTTHD = row["MaTTHD"].ToString();
                string maHS = row["MaHS"].ToString();
                string maHD = row["MaHD"].ToString();
                string tenHS = row["HoTen"].ToString();
                double tienNhan = row["TienNhan"] == DBNull.Value ? 0 : double.Parse(row["TienNhan"].ToString());
                DateTime ngayDK = row["NgayDK"] == DBNull.Value ? DateTime.Now : DateTime.Parse(row["NgayDK"].ToString());

                dto = new ThamGiaNgoaiKhoaDTO(maTTHD, ngayDK, maHD, maHS, tenHS, tienNhan);
                lst.Add(dto);
            }
            return lst;
        }


        public List<ThamGiaNgoaiKhoaDTO> layDSHSThamGiaNgoaiKhoaTheoTrangThaiDK(string trangThai, string MaHD, string maLop)
        {
            DataTable table = thamGiaNgoaiKhoaDAL.layDSHSThamGiaNgoaiKhoaTheoTrangThaiDK(trangThai, MaHD, maLop);
            List<ThamGiaNgoaiKhoaDTO> lst = new List<ThamGiaNgoaiKhoaDTO>();
            foreach (DataRow row in table.Rows)
            {
                ThamGiaNgoaiKhoaDTO dto = new ThamGiaNgoaiKhoaDTO();
                string maTTHD = row["MaTTHD"].ToString();
                string maHS = row["MaHS"].ToString();
                string maHD = row["MaHD"].ToString();
                string tenHS = row["HoTen"].ToString();
                double tienNhan = row["TienNhan"] == DBNull.Value ? 0 : double.Parse(row["TienNhan"].ToString());
                DateTime ngayDK = row["NgayDK"] == DBNull.Value ? DateTime.Now : DateTime.Parse(row["NgayDK"].ToString());

                dto = new ThamGiaNgoaiKhoaDTO(maTTHD, ngayDK, maHD, maHS, tenHS, tienNhan);
                lst.Add(dto);
            }
            return lst;
        }

        public int demSoHSThamGiaHD(string maLop, string maHD)
        {
            return thamGiaNgoaiKhoaDAL.demSoHSThamGiaHD(maLop, maHD);
        }


        public int demSoHSThamGiaToanTruong(string maHD)
        {
            return thamGiaNgoaiKhoaDAL.demSoHSThamGiaToanTruong(maHD);
        }

        public ThamGiaNgoaiKhoaDTO layThongTinThamGiaHoatDongCua1HS(string MaHS, string MaHD)
        {
            DataTable table = thamGiaNgoaiKhoaDAL.layThongTinThamGiaHoatDongCua1HS(MaHD, MaHS);
            ThamGiaNgoaiKhoaDTO dto = null;

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];

                string maTTHD = row["MaTTHD"].ToString();
                DateTime ngayDK = DateTime.Parse(row["NgayDK"].ToString());
                string maHD = row["MaHD"].ToString();
                string maHS = row["MaHS"].ToString();
                double tienNhan = double.Parse(row["TienNhan"].ToString());

                dto = new ThamGiaNgoaiKhoaDTO(maTTHD, ngayDK, maHD, maHS, tienNhan);
            }

            return dto;
        }

        public string TaoMaThanhToanHD(string maHD, string maHS)
        {
            string key = maHD.Trim() + "_" + maHS.Trim();

            return key;

        }

        public bool ktraDaThanhToan(string maHD, string maHS)
        {
            return thamGiaNgoaiKhoaDAL.ktraDaThanhToan(maHD, maHS) > 0;
        }


        public bool Insert(ThamGiaNgoaiKhoaDTO tgnk)
        {
            return thamGiaNgoaiKhoaDAL.Insert(tgnk);
        }

        public bool Delete(ThamGiaNgoaiKhoaDTO tgnk)
        {
            return thamGiaNgoaiKhoaDAL.Delete(tgnk);
        }
    }
}
