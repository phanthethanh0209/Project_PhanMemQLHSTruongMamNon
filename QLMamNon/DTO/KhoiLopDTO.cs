namespace DTO
{
    public class KhoiLopDTO
    {
        public KhoiLopDTO(string maKhoi, string tenKhoi, string doTuoi)
        {
            MaKhoi = maKhoi;
            TenKhoi = tenKhoi;
            DoTuoi = doTuoi;
        }

        public KhoiLopDTO()
        {
        }

        public string MaKhoi { get; set; }
        public string TenKhoi { get; set; }
        public string DoTuoi { get; set; }
    }
}
