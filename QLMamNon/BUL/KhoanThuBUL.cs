using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class KhoanThuBUL
    {
        KhoanThuDAL khoanThuDAL = new KhoanThuDAL();

        public List<KhoanThuDTO> layTatCaKhoanThuTrongNamHoc(string maNamHoc)
        {
            List<KhoanThuDTO> lst = new List<KhoanThuDTO>();
            DataTable table = khoanThuDAL.layTatCaKhoanThuTrongNamHoc(maNamHoc);
            foreach (DataRow row in table.Rows)
            {
                KhoanThuDTO dto;
                string maKT = row["MaKhoanThu"].ToString();
                string tenKT = row["TenKhoanThu"].ToString();
                string maNH = row["MaNamHoc"].ToString();
                double soTien = double.Parse( row["SoTien"].ToString());
                
                dto = new KhoanThuDTO(maKT, maNH, tenKT, soTien );
                lst.Add(dto);
            }
            return lst;
        }

        public KhoanThuDTO lay1KhoanThu(string maKTT)
        {
            KhoanThuDTO dto = new KhoanThuDTO();
            DataTable table = khoanThuDAL.lay1KhoanThu(maKTT);
            foreach (DataRow row in table.Rows)
            {
                string maKT = row["MaKhoanThu"].ToString();
                string tenKT = row["TenKhoanThu"].ToString();
                string maNH = row["MaNamHoc"].ToString();
                double soTien = double.Parse(row["SoTien"].ToString());

                dto = new KhoanThuDTO(maKT, maNH, tenKT, soTien);
               
            }
            return dto;
        }

        public string TaoMaKhoanThu(string maNH)
        {
            string key = "KT" + maNH.Trim().Substring(2);

            DataTable dt = khoanThuDAL.layMaKTCuoiCung(maNH);

            if (dt.Rows.Count == 0)
            {
                key += "01";
            }
            else
            {

                string maBanDau = dt.Rows[0][0].ToString();
                string sott = maBanDau.Substring(6, 2);
                int num = int.Parse(sott) + 1;
                if (num < 10)
                    key += "0" + num;
                else
                {
                    key += num;
                }
            }
            return key;

        }

        public bool Insert(KhoanThuDTO p)
        {
            return khoanThuDAL.Insert(p);
        }

        public bool Update(KhoanThuDTO p)
        {
            return khoanThuDAL.Update(p);
        }

        public bool Delete(string maKhoanThu)
        {
            return khoanThuDAL.Delete(maKhoanThu);
        }
    }
}
