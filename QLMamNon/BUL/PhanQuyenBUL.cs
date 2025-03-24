using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;


namespace BUL
{
    public class PhanQuyenBUL
    {
        PhanQuyenDAL phanQuyenDAL = new PhanQuyenDAL();

        //public bool IsValid(PhanQuyenDTO phanQuyen)
        //{
        //    return phanQuyenDAL.IsValid(phanQuyen);
        //}

        public DataTable layDSTenMH(string maNhom)
        {            
            return phanQuyenDAL.layDSTenMH(maNhom);
        }


        public List<NhomNguoiDungDTO> LayNhomNguoiDungChuaCoManHinh(string maMH)
        {
            List<NhomNguoiDungDTO> lst = new List<NhomNguoiDungDTO>();
            DataTable table = phanQuyenDAL.LayNhomNguoiDungChuaCoManHinh(maMH);
            foreach (DataRow row in table.Rows)
            {
                NhomNguoiDungDTO dto;

                string maNhom = row["MaNhom"].ToString().Trim();
                string tenNhom = row["TenNhom"].ToString().Trim();

                dto = new NhomNguoiDungDTO(maNhom, tenNhom, "");
                lst.Add(dto);
            }
            return lst;
        }

        public List<PhanQuyenDTO> LayNhomNguoiDungCoManHinh(string maMH)
        {
            List<PhanQuyenDTO> lst = new List<PhanQuyenDTO>();
            DataTable table = phanQuyenDAL.LayNhomNguoiDungCoManHinh(maMH);
            foreach (DataRow row in table.Rows)
            {
                PhanQuyenDTO dto;

                string maNhom = row["MaNhom"].ToString().Trim();
                string tenNhom = row["TenNhom"].ToString().Trim();
                string tenMH = row["TenMH"].ToString().Trim();

                dto = new PhanQuyenDTO(maNhom, maMH, tenNhom, tenMH, "");
                lst.Add(dto);
            }
            return lst;
        }


        public bool Insert(PhanQuyenDTO phanQuyen)
        {
            return phanQuyenDAL.Insert(phanQuyen);
        }

        //public bool Update(PhanQuyenDTO phanQuyen)
        //{
        //    return phanQuyenDAL.Update(phanQuyen);
        //}

        public bool Delete(PhanQuyenDTO phanQuyen)
        {
            return phanQuyenDAL.Delete(phanQuyen);
        }

        public DataTable getManHinh(string maNhomND)
        {
            return phanQuyenDAL.getManHinh(maNhomND);
        }
    }
}
