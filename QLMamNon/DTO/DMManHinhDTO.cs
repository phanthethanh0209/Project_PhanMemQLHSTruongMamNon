namespace DTO
{
    public class DMManHinhDTO
    {
        public string MaMH { get; set; }
        public string TenMH { get; set; }

        public DMManHinhDTO()
        {
            MaMH = "";
            TenMH = "";
        }
        public DMManHinhDTO(string maManHinh, string tenManHinh)
        {
            MaMH = maManHinh;
            TenMH = tenManHinh;
        }
    }
}
