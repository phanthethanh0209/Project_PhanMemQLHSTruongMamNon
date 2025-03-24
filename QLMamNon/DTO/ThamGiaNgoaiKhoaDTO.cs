using System;

namespace DTO
{
    public class ThamGiaNgoaiKhoaDTO
    {
        public ThamGiaNgoaiKhoaDTO(string maTTHD, DateTime ngayDK, string maHD, string maHS, string tenHS, double tienNhan)
        {
            MaTTHD = maTTHD;
            MaHS = maHS;
            MaHD = maHD;
            NgayDK = ngayDK;
            HoTen = tenHS;
            TienNhan = tienNhan;
        }

        public ThamGiaNgoaiKhoaDTO(string maTTHD, DateTime ngayDK, string maHD, string maHS, double tienNhan)
        {
            MaTTHD = maTTHD;
            MaHS = maHS;
            MaHD = maHD;
            NgayDK = ngayDK;
            TienNhan = tienNhan;
        }

        public ThamGiaNgoaiKhoaDTO(string maTTHD, DateTime ngayDK, string maHD, string maHS, string tenHS, double tienNhan, string maND)
        {
            MaTTHD = maTTHD;
            MaHS = maHS;
            MaHD = maHD;
            NgayDK = ngayDK;
            HoTen = tenHS;
            TienNhan = tienNhan;
            MaND = maND;
        }

        public ThamGiaNgoaiKhoaDTO()
        {

        }
        public string MaTTHD { get; set; }
        public DateTime NgayDK { get; set; }
        public string MaHD { get; set; }
        public string MaHS { get; set; }
        public string HoTen { get; set; }
        public double TienNhan { get; set; }
        public string MaND { get; set; }
    }
}
