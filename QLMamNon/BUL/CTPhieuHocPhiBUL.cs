using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class CTPhieuHocPhiBUL
    {
        CTPhieuHocPhiDAL CTphieuHocPhiDAL = new CTPhieuHocPhiDAL();
        public List<CTPhieuHocPhiDTO> layCTHocPhiTheoMaPhieuHP(string maPhieuHPP)
        {
            DataTable table = CTphieuHocPhiDAL.layCTHocPhiTheoMaPhieuHP(maPhieuHPP);
            List<CTPhieuHocPhiDTO> lst = new List<CTPhieuHocPhiDTO>();
            foreach (DataRow row in table.Rows)
            {
                CTPhieuHocPhiDTO dto;
                string maPhieuHP = row["MaPhieuHP"].ToString();
                string maKhoanThu = row["MaKhoanThu"].ToString();

                dto = new CTPhieuHocPhiDTO(maPhieuHP, maKhoanThu);
                lst.Add(dto);
            }
            return lst;
        }


        public bool Insert(CTPhieuHocPhiDTO p)
        {
            return CTphieuHocPhiDAL.Insert(p);
        }

        public bool Delete(CTPhieuHocPhiDTO p)
        {
            return CTphieuHocPhiDAL.Delete(p);
        }
    }
}
