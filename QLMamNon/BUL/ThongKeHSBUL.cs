using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class ThongKeHSBUL
    {
        ThongKeHSDAL hsDAL = new ThongKeHSDAL();

        //Học phí theo năm
        public List<ThongKeHSDTO> ThongKeHSDatKhenThuong(string maLop)
        {
            List<ThongKeHSDTO> lst = new List<ThongKeHSDTO>();
            DataTable table = hsDAL.ThongKeHSDatKhenThuong(maLop);
            foreach (DataRow row in table.Rows)
            {
                ThongKeHSDTO dto;
                string tenLop = row["TenLop"].ToString();
                string maHS = row["MaHS"].ToString();
                string hoTen = row["HoTen"].ToString();
                string xepLoai = row["XepLoai"].ToString();
                dto = new ThongKeHSDTO(tenLop, maHS, hoTen, xepLoai, maLop);
                lst.Add(dto);
            }
            return lst;
        }

        public DataTable InThongKeHSDatKhenThuongBUL(string maNamHoc, string tenNamHoc, string maLop)
        {
            DataTable table = hsDAL.InThongKeHSDatKhenThuong(maNamHoc, tenNamHoc, maLop);
            return table;
        }

        public List<ThongKeHSDTO> ThongKeTongHSDatKhenThuong(string maNamHoc)
        {
            List<ThongKeHSDTO> lst = new List<ThongKeHSDTO>();
            DataTable table = hsDAL.ThongKeTongSoHSDuocKhenThuong(maNamHoc);
            foreach (DataRow row in table.Rows)
            {
                ThongKeHSDTO dto;
                string tenLop = row["TenLop"].ToString();
                string TongSoHSDatKhenThuong = row["TongSoHSDatKhenThuong"].ToString();
                dto = new ThongKeHSDTO(tenLop, TongSoHSDatKhenThuong, maNamHoc);
                lst.Add(dto);
            }
            return lst;
        }

        public List<ThongKeHSDTO> ThongKeHSQueQuan(string maLop)
        {
            List<ThongKeHSDTO> lst = new List<ThongKeHSDTO>();
            DataTable table = hsDAL.ThongKeHSQueQuan(maLop);
            foreach (DataRow row in table.Rows)
            {
                ThongKeHSDTO dto;
                string queQuan = row["QueQuan"].ToString();
                string soHocSinh = row["soHocSinh"].ToString();
                string noiSinh = row["NoiSinh"].ToString();
                dto = new ThongKeHSDTO(queQuan, soHocSinh, maLop, noiSinh);
                lst.Add(dto);
            }
            return lst;
        }

        //public DataTable InDoanhThuHPTrongThang(string maNamHoc, string tenNamHoc, string thang)
        //{
        //    DataTable table = doanhThuDAL.InThongKeDoanhThuHPTheoThang(maNamHoc, tenNamHoc, thang);
        //    return table;
        //}
    }
}
