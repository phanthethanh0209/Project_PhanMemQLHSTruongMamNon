using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;


namespace BUL
{
    public class DMManHinhBUL
    {
        DMManHinhDAL manHinhDAL = new DMManHinhDAL();

        //public bool IsValid(DMManHinhDTO dM_ManHinh)
        //{
        //    return manHinhDAL.IsValid(dM_ManHinh);
        //}

        public List<DMManHinhDTO> getAll()
        {
            List<DMManHinhDTO> lst = new List<DMManHinhDTO>();
            DataTable table = manHinhDAL.getAll();
            foreach (DataRow row in table.Rows)
            {
                DMManHinhDTO dto;
                string maManHinh = row[0].ToString();
                string tenManHinh = row[1].ToString();

                dto = new DMManHinhDTO(maManHinh, tenManHinh);
                lst.Add(dto);
            }
            return lst;
        }

        public bool InsertScreen(DMManHinhDTO manHinh)
        {
            return manHinhDAL.InsertScreen(manHinh);
        }

        public bool UpdateScreen(DMManHinhDTO manHinh)
        {
            return manHinhDAL.UpdateScreen(manHinh);
        }

        public bool DeleteScreen(string maMH)
        {
            return manHinhDAL.DeleteScreen(maMH);
        }
    }
}
