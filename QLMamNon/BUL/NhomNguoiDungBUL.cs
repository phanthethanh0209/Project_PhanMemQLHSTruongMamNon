using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DAL;
using System.Data;


namespace BUL
{
    public class NhomNguoiDungBUL
    {
        NhomNguoiDungDAL nhomNguoiDungDAL= new NhomNguoiDungDAL();

        public bool IsValid(NhomNguoiDungDTO nhomND)
        {
            return nhomNguoiDungDAL.IsValid(nhomND);
        }

        public List<NhomNguoiDungDTO> getAll()
        {
            List<NhomNguoiDungDTO> lst = new List<NhomNguoiDungDTO>();
            DataTable table = nhomNguoiDungDAL.getAll();
            foreach(DataRow row in table.Rows)
            {
                NhomNguoiDungDTO dto;
                string maNhom = row["MaNhom"].ToString();
                string tenNhom = row["TenNhom"].ToString();
                string ghiChu = row["GhiChu"].ToString();
                dto = new NhomNguoiDungDTO(maNhom, tenNhom, ghiChu);    
                lst.Add(dto);
            }
            return lst;
        }

        public bool InsertRole(NhomNguoiDungDTO nhomND)
        {
            return nhomNguoiDungDAL.InsertRole(nhomND);
        }

        public bool UpdateRole(NhomNguoiDungDTO nhomND)
        {
            return nhomNguoiDungDAL.UpdateRole(nhomND);
        }

        public bool DeleteRole(string maNhom)
        {
            return nhomNguoiDungDAL.DeleteRole(maNhom);
        }
    }
}
