using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class KhoiLopBUL
    {
        KhoiLopDAL khoiLopDAL = new KhoiLopDAL();

        //public List<LopHocDTO> getAll()
        //{
        //    List<NhanVienDTO> lst = new List<NhanVienDTO>();
        //    DataTable table = nguoidungDAL.getAll();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        NhanVienDTO dto;
        //        string maNV = row[0].ToString();
        //        string tenTKNV = row[1].ToString();
        //        string matKhau = row[2].ToString();
        //        string hoTen = row[3].ToString();
        //        string dienThoai = row[4].ToString();
        //        string diaChi = row[5].ToString();
        //        string chucVu = row[6].ToString();
        //        int tragThai = int.Parse(row[7].ToString());
        //        dto = new NhanVienDTO(maNV, tenTKNV, matKhau, hoTen, dienThoai, diaChi, chucVu, tragThai);
        //        lst.Add(dto);
        //    }
        //    return lst;
        //}

        public List<KhoiLopDTO> layKhoiLopTrongNam(string maNamHoc)
        {
            DataTable table = khoiLopDAL.layKhoiLopTrongNam(maNamHoc);
            List<KhoiLopDTO> lst = new List<KhoiLopDTO>();
            foreach (DataRow row in table.Rows)
            {
                KhoiLopDTO dto = new KhoiLopDTO();
                string maKhoi = row["MaKhoi"].ToString();
                string tenKhoi = row["TenKhoi"].ToString();
                string doTuoi = row["DoTuoi"].ToString();

                dto = new KhoiLopDTO(maKhoi, tenKhoi, doTuoi);
                lst.Add(dto);
            }
            return lst;
        }

        public KhoiLopDTO layKhoiLopTrongNamTheoDoTuoi(string tuoi, string maNamHoc)
        {
            DataTable table = khoiLopDAL.layKhoiLopTrongNamTheoDoTuoi(tuoi, maNamHoc);
            KhoiLopDTO dto = new KhoiLopDTO();
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string maKhoi = row["MaKhoi"].ToString();
                string tenKhoi = row["TenKhoi"].ToString();
                string doTuoi = row["DoTuoi"].ToString();

                dto = new KhoiLopDTO(maKhoi, tenKhoi, doTuoi);
            }
            return dto;
        }

        public KhoiLopDTO layMaKhoiTheoTenKhoi(string tenKhoi)
        {
            DataTable table = khoiLopDAL.layMaKhoiTheoTenKhoi(tenKhoi);
            KhoiLopDTO dto = new KhoiLopDTO();
            foreach (DataRow row in table.Rows)
            {
                string maKhoi = row["MaKhoi"].ToString();
                string ten = row["TenKhoi"].ToString();
                string doTuoi = row["DoTuoi"].ToString();

                dto = new KhoiLopDTO(maKhoi, tenKhoi, doTuoi);
            }
            return dto;
        }

        public KhoiLopDTO layTenKhoiTheoMa(string maKhoi)
        {
            DataTable table = khoiLopDAL.layTenKhoiTheoMa(maKhoi);
            KhoiLopDTO dto = new KhoiLopDTO();
            foreach (DataRow row in table.Rows)
            {
                string ten = row["TenKhoi"].ToString();
                string doTuoi = row["DoTuoi"].ToString();

                dto = new KhoiLopDTO(maKhoi, ten, doTuoi);
            }
            return dto;
        }
    }
}
