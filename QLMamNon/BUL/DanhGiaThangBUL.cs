using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class DanhGiaThangBUL
    {
        DanhGiaThangDAL danhGiaThangDAL = new DanhGiaThangDAL();


        public DanhGiaThangDTO layThongTinDanhGiaThangCua1HS(string malop, string maHS, int thang)
        {
            DanhGiaThangDTO dto = new DanhGiaThangDTO();
            DataTable table = danhGiaThangDAL.layThongTinDanhGiaThangCua1HS(malop, maHS, thang);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string maDG = row["MaDanhGiaThang"].ToString();
                string noiDung = row["NoiDung"].ToString();
                int datPhieu = int.Parse(row["DatPhieuChauNgoanBH"].ToString());

                dto = new DanhGiaThangDTO(maDG, malop, maHS, thang, datPhieu, noiDung);
            }
            return dto;
        }

        public List<DanhGiaThangDTO> layDSHSDaDanhGia(string malop, int thang)
        {
            List<DanhGiaThangDTO> lst = new List<DanhGiaThangDTO>();
            DataTable table = danhGiaThangDAL.layDSHSDaDanhGia(malop, thang);
            foreach (DataRow row in table.Rows)
            {
                DanhGiaThangDTO dto;
                string maHS = row["MaHS"].ToString();
                string noiDung = row["NoiDung"].ToString();
                string maDG = row["MaDanhGiaThang"].ToString();
                int datPhieu = int.Parse(row["DatPhieuChauNgoanBH"].ToString());

                dto = new DanhGiaThangDTO(maDG, malop, maHS, thang, datPhieu, noiDung);

                lst.Add(dto);
            }
            return lst;
        }

        public List<DanhGiaThangDTO> layDSHSDatPhieu(string malop, int thang)
        {
            List<DanhGiaThangDTO> lst = new List<DanhGiaThangDTO>();
            DataTable table = danhGiaThangDAL.layDSHSDatPhieu(malop, thang);
            foreach (DataRow row in table.Rows)
            {
                DanhGiaThangDTO dto;
                string maHS = row["MaHS"].ToString();
                string noiDung = row["NoiDung"].ToString();
                string maDG = row["MaDanhGiaThang"].ToString();
                int datPhieu = int.Parse(row["DatPhieuChauNgoanBH"].ToString());

                dto = new DanhGiaThangDTO(maDG, malop, maHS, thang, datPhieu, noiDung);

                lst.Add(dto);
            }
            return lst;
        }

        public string TaoMaDanhGiaThang(int thang, string maNam, string maHS)
        {
            string key = "DG";
            key += "T" + thang + maNam.Trim() + "_" + maHS;

            return key;
        }

        public bool Insert(DanhGiaThangDTO danhGia)
        {
            return danhGiaThangDAL.Insert(danhGia);
        }


        public DanhGiaThangDTO layTongSoPhieuBacHoCuaNam(string maHS, string maLop)
        {
            DanhGiaThangDTO dto = new DanhGiaThangDTO();
            DataTable table = danhGiaThangDAL.layTongSoPhieuBacHoCuaNam(maHS, maLop);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                int tongSoPhieu = int.Parse(row["TongSoPhieu"].ToString());

                dto = new DanhGiaThangDTO(tongSoPhieu);
            }
            return dto;
        }

        public DanhGiaThangDTO demSoLanDanhGia(string maHS, string maLop)
        {
            DanhGiaThangDTO dto = new DanhGiaThangDTO();
            DataTable table = danhGiaThangDAL.demSoLanDanhGia(maHS, maLop);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                int SoLanDanhGia = int.Parse(row["SoLanDanhGia"].ToString());

                dto = new DanhGiaThangDTO(SoLanDanhGia);
            }
            return dto;
        }
    }
}
