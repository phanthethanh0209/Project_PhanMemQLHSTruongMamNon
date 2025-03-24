using System;

namespace DTO
{
    public class CTPhieuHocPhiDTO
    {
        public CTPhieuHocPhiDTO(string maPhieuHP, string maKhoanThu)
        {
            MaPhieuHP = maPhieuHP;
            MaKhoanThu = maKhoanThu;
        }

        public CTPhieuHocPhiDTO()
        {
        }

        public string MaPhieuHP { get; set; }
        public string MaKhoanThu { get; set; }
       

    }
}
