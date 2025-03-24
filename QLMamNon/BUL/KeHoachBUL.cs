using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class KeHoachBUL
    {
        KeHoachDAL keHoachDAL = new KeHoachDAL();

        //public NamHocDTO layNamHocTruoc(string namHoc)
        //{
        //    DataTable table = namHocDAL.layNamHocTruoc(namHoc);
        //    NamHocDTO dto = new NamHocDTO();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        string maNH = row["MaNamHoc"].ToString();
        //        string tenNH = row["TenNamHoc"].ToString();
        //        DateTime ngayBD = DateTime.Parse(row["NgayDB"].ToString());
        //        DateTime ngayKT = DateTime.Parse(row["NgayKT"].ToString());

        //        dto = new NamHocDTO(maNH, tenNH, ngayBD, ngayKT);
        //    }
        //    return dto;
        //}

        public KeHoachDTO layTTKeHoach(string maNamHoc, string maKhoi)
        {
            DataTable table = keHoachDAL.layTTKeHoach(maNamHoc, maKhoi);
            KeHoachDTO dto = new KeHoachDTO();
            foreach (DataRow row in table.Rows)
            {
                string maNH = row["MaNamHoc"].ToString();
                string maKhoii = row["MaKhoi"].ToString();
                int soLopMo = int.Parse(row["SoLopMo"].ToString());
                int tongHs = int.Parse(row["TongHS"].ToString());
                int siSoTT = int.Parse(row["SiSoToiThieu"].ToString());
                int siSoTD = int.Parse(row["SiSoToiDa"].ToString());         

                dto = new KeHoachDTO(maNamHoc, maKhoii, soLopMo, siSoTT, siSoTD, tongHs);
            }
            return dto;
        }

        public List<KeHoachDTO> layDSKhoiLopTrongNamHoc(string maNamHoc)
        {
            DataTable table = keHoachDAL.layDSKhoiLopTrongNamHoc(maNamHoc);
            List<KeHoachDTO> lst= new List<KeHoachDTO>();
            KeHoachDTO dto = new KeHoachDTO();
            foreach (DataRow row in table.Rows)
            {
                string maNH = row["MaNamHoc"].ToString();
                string maKhoi = row["MaKhoi"].ToString();        
                int soLopMo = int.Parse(row["SoLopMo"].ToString());
                int tongHs = int.Parse(row["TongHS"].ToString());
                int siSoTT = int.Parse(row["SiSoToiThieu"].ToString());
                int siSiTD = int.Parse(row["SiSoToiDa"].ToString());
                dto = new KeHoachDTO(maNamHoc, maKhoi, soLopMo, siSoTT, siSiTD, tongHs);
                lst.Add(dto);
            }
            return lst;
        }

        // Thêm năm học
        public bool themKeHoach(KeHoachDTO k)
        {
            return keHoachDAL.themKeHoach(k);
        }

        public bool suaKeHoach(KeHoachDTO k)
        {
            return keHoachDAL.suaKeHoach(k);
        }
    }
}
