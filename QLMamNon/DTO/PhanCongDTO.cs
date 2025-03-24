namespace DTO
{
    public class PhanCongDTO
    {
        //public PhanCongDTO(string maLop, string maGV, string vaiTro)
        //{
        //    MaLop = maLop;
        //    MaGV = maGV;
        //    VaiTro = vaiTro;
        //}



        public PhanCongDTO(string maGV, string hoTen, string gt)
        {
            MaGV = maGV;
            HoTen = hoTen;
            GioiTinh = gt;
        }

        public PhanCongDTO(string maGV)
        {
            MaGV = maGV;
        }

        public PhanCongDTO(string maLop, string maGV)
        {
            MaLop = maLop;
            MaGV = maGV;
        }

        public PhanCongDTO()
        {
        }


        public PhanCongDTO(string maGV, string tenGV, string gt, string maLop, string vaiTro)
        {
            MaGV = maGV;
            HoTen = tenGV;
            GioiTinh = gt;
            MaLop = maLop;
            VaiTro = vaiTro;
        }


        public string HoTen { get; set; }
        public string MaGV { get; set; }
        public string MaLop { get; set; }
        public string VaiTro { get; set; }
        public string GioiTinh { get; set; }
    }
}
