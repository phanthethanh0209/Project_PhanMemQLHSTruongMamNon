namespace DTO
{
    public class KeHoachDTO
    {
        public KeHoachDTO(string maNamHoc, string maKhoi, int soLopMo, int siSoToiThieu, int siSoToiDa, int tongHS)
        {
            MaNamHoc = maNamHoc;
            MaKhoi = maKhoi;
            SoLopMo = soLopMo;
            SiSoToiThieu = siSoToiThieu;
            SiSoToiDa = siSoToiDa;
            TongHS = tongHS;
        }

        public KeHoachDTO(string maNamHoc, string maKhoi, int siSoToiDa)
        {
            MaNamHoc = maNamHoc;
            MaKhoi = maKhoi;
            SiSoToiDa = siSoToiDa;
        }

        public KeHoachDTO()
        {
        }

        public string MaNamHoc { get; set; }
        public string MaKhoi { get; set; }
        public int SoLopMo { get; set; }
        public int SiSoToiThieu { get; set; }
        public int SiSoToiDa { get; set; }
        public int TongHS { get; set; }
    }
}
