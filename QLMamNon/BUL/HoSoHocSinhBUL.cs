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
    public class HoSoHocSinhBUL
    {
        HoSoHocSinhDAL dal = new HoSoHocSinhDAL();

        public List<HoSoHocSinhDTO> getAll()
        {
            List<HoSoHocSinhDTO> lst = new List<HoSoHocSinhDTO>();
            DataTable table = dal.layTatCaHoSoHS();
            foreach (DataRow row in table.Rows)
            {
                HoSoHocSinhDTO dto;
                string maHS = row["MaHS"].ToString();
                string maDinhDanh = row["MaDinhDanh"].ToString();
                string quocTich = row["QuocTich"].ToString();
                string danToc = row["DanToc"].ToString();
                string tonGiao = row["TonGiao"].ToString();
                string queQuan = row["QueQuan"].ToString();
                string noiSinh = row["NoiSinh"].ToString();
                string tinhTrangSK = row["TinhTrangSucKhoe"].ToString();
                string donXinNhapHoc = row["DonXinNhapHoc"].ToString();
                string giayKhaiSinh = row["GiayKhaiSinh"].ToString();
                dto = new HoSoHocSinhDTO(maHS, maDinhDanh, quocTich, danToc, tonGiao, queQuan, noiSinh, tinhTrangSK, donXinNhapHoc, giayKhaiSinh );
                lst.Add(dto);
            }
            return lst;
        }

        public HoSoHocSinhDTO layHoSoMotHocSinh(string maHSMoi)
        {
            DataTable table = dal.layHoSoMotHocSinh(maHSMoi);
            HoSoHocSinhDTO dto= null;

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];

                
                string maHS = row["MaHS"].ToString();
                string maDinhDanh = row["MaDinhDanh"].ToString();
                string quocTich = row["QuocTich"].ToString();
                string danToc = row["DanToc"].ToString();
                string tonGiao = row["TonGiao"].ToString();
                string queQuan = row["QueQuan"].ToString();
                string noiSinh = row["NoiSinh"].ToString();
                string tinhTrangSK = row["TinhTrangSucKhoe"].ToString();
                string donXinNhapHoc = row["DonXinNhapHoc"].ToString();
                string giayKhaiSinh = row["GiayKhaiSinh"].ToString();

                dto = new HoSoHocSinhDTO(maHS, maDinhDanh, quocTich, danToc, tonGiao, queQuan, noiSinh, tinhTrangSK, donXinNhapHoc, giayKhaiSinh);
            }

            return dto;
        }

        


        public bool themHoSoHocSinh(HoSoHocSinhDTO hoSoHS)
        {
            return dal.themHoSoHocSinh(hoSoHS);
        }

        public bool suaHoSoHocSinh(HoSoHocSinhDTO hoSoHS)
        {
            return dal.suaHoSoHocSinh(hoSoHS);
        }

        public bool xoaHoSoHocSinh(string maHS)
        {
            return dal.xoaHoSoHocSinh(maHS);
        }
    }
}
