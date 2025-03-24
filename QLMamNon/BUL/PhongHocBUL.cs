using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class PhongHocBUL
    {
        PhongHocDAL phongHocDAL = new PhongHocDAL();

        public List<PhongHocDTO> layTatCaPhongHoc()
        {
            List<PhongHocDTO> lst = new List<PhongHocDTO>();
            DataTable table = phongHocDAL.layTatCaPhongHoc();
            foreach (DataRow row in table.Rows)
            {
                PhongHocDTO dto;
                string maPhong = row["MaPhong"].ToString();
                string tenPhong = row["TenPhong"].ToString();
                string viTri = row["ViTri"].ToString();
                string tinhTrang = row["TinhTrang"].ToString();
                int sucChua = int.Parse(row["SucChua"].ToString());
                dto = new PhongHocDTO(maPhong, tenPhong, sucChua, viTri, tinhTrang);
                lst.Add(dto);
            }
            return lst;
        }



        public PhongHocDTO layThongTin1PhongHoc(string maP)
        {
            DataTable table = phongHocDAL.layThongTin1PhongHoc(maP);
            PhongHocDTO dto = null;

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];

                string maPhong = row["MaPhong"].ToString();
                string tenPhong = row["TenPhong"].ToString();
                string viTri = row["ViTri"].ToString();
                string tinhTrang = row["TinhTrang"].ToString();
                int sucChua = int.Parse(row["SucChua"].ToString());

                dto = new PhongHocDTO(maPhong, tenPhong, sucChua, viTri, tinhTrang);
            }

            return dto;
        }

        public PhongHocDTO layThongTin1PhongHocTheoTenPhong(string tenP)
        {
            DataTable table = phongHocDAL.layThongTin1PhongHocTheoTenPhong(tenP);
            PhongHocDTO dto = null;

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];

                string maPhong = row["MaPhong"].ToString();
                string tenPhong = row["TenPhong"].ToString();
                string viTri = row["ViTri"].ToString();
                string tinhTrang = row["TinhTrang"].ToString();
                int sucChua = int.Parse(row["SucChua"].ToString());

                dto = new PhongHocDTO(maPhong, tenPhong, sucChua, viTri, tinhTrang);
            }

            return dto;
        }


        public int demSoPhong()
        {
            return phongHocDAL.demSoPhong();
        }


        public string TaoMaPhong()
        {
            return phongHocDAL.LayMaPhongLonNhat();
        }


        public bool ThemPhongHoc(PhongHocDTO nguoidung)
        {
            return phongHocDAL.themPhongHoc(nguoidung);
        }

        public bool SuaPhongHoc(PhongHocDTO nguoidung)
        {
            return phongHocDAL.suaPhongHoc(nguoidung);
        }

        public bool XoaPhongHoc(PhongHocDTO nguoidung)
        {
            return phongHocDAL.xoaPhongHoc(nguoidung);
        }
    }
}
