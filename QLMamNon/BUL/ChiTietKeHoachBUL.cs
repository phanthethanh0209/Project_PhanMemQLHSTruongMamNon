using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class ChiTietKeHoachBUL
    {
        ChiTietKeHoachDAL kehoachDAL = new ChiTietKeHoachDAL();

        public List<ChiTietKeHoachDTO> getAll()
        {
            List<ChiTietKeHoachDTO> lst = new List<ChiTietKeHoachDTO>();
            DataTable table = kehoachDAL.getAll();
            foreach (DataRow row in table.Rows)
            {
                ChiTietKeHoachDTO dto;
                string maCTKeHoach = row[0].ToString();
                string tenKhoi = row[1].ToString();
                int soLuongLop = int.Parse(row[2].ToString());
                int soLuongHS = int.Parse(row[3].ToString());
                int hocPhi = int.Parse(row[4].ToString());
                int tienAn = int.Parse(row[5].ToString());
                string maKeHoach = row[6].ToString();
                dto = new ChiTietKeHoachDTO(maCTKeHoach, maKeHoach, tenKhoi, soLuongLop, soLuongHS, hocPhi, tienAn);
                lst.Add(dto);
            }
            return lst;
        }

        public bool InsertKeHoach(ChiTietKeHoachDTO kehoach)
        {
            return kehoachDAL.InsertKeHoach(kehoach);
        }

        public bool UpdateKeHoach(ChiTietKeHoachDTO kehoach)
        {
            return kehoachDAL.UpdateKeHoach(kehoach);
        }

        //public bool DeleteUser(GiaoVienDTO nguoidung)
        //{
        //    return nguoidungDAL.DeleteUser(nguoidung);
        //}
    }
}
