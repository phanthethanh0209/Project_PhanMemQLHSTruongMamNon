using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;


namespace BUL
{
    public class NguoiDung_NhomNguoiDungBUL
    {
        NguoiDung_NhomNguoiDungDAL nhomNguoiDungDAL = new NguoiDung_NhomNguoiDungDAL();


        // ND_NhomNDDAL nhomNguoidungDAL = new ND_NhomNDDAL();
        public List<NguoiDung_NhomNguoiDungDTO> layNguoiDungTheoMaNhom(string maNhomDK)
        {
            List<NguoiDung_NhomNguoiDungDTO> lst = new List<NguoiDung_NhomNguoiDungDTO>();
            DataTable table = nhomNguoiDungDAL.layNguoiDungTheoMaNhom(maNhomDK);
            foreach (DataRow row in table.Rows)
            {
                NguoiDung_NhomNguoiDungDTO dto;

                string maNhom = row["MaNhomNguoiDung"].ToString().Trim();
                string maND = row["MaND"].ToString().Trim();
                string tenTk = row["TenTK"].ToString().Trim();
                string tenND = row["HoTen"].ToString().Trim();
                string ghiChu = row["GhiChu"].ToString().Trim();

                dto = new NguoiDung_NhomNguoiDungDTO(maNhom, maND, tenTk, tenND, ghiChu);
                lst.Add(dto);
            }
            return lst;
        }

        public List<string> layDSMaNhomTuTenTK(string maND)
        {
            List<string> lst = new List<string>();
            DataTable table = nhomNguoiDungDAL.layDSMaNhomTuTenTK(maND);
            foreach (DataRow row in table.Rows)
            {
                string maNhom = row["MaNhomNguoiDung"].ToString().Trim();

                lst.Add(maNhom);
            }
            return lst;
        }

        public bool themND_NhomND(NguoiDung_NhomNguoiDungDTO nd_nhomND)
        {
            return nhomNguoiDungDAL.themND_NhomND(nd_nhomND);
        }

        public bool xoaND_NhomND(NguoiDung_NhomNguoiDungDTO nd_nhomND)
        {
            return nhomNguoiDungDAL.xoaND_NhomND(nd_nhomND);
        }
    }
}
