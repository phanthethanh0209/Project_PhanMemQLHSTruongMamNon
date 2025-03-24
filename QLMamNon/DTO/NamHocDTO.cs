using System;

namespace DTO
{
    public class NamHocDTO
    {
        public NamHocDTO(string maNamHoc, string tenNamHoc, DateTime ngayDB, DateTime ngayKT)
        {
            MaNamHoc = maNamHoc;
            TenNamHoc = tenNamHoc;
            NgayDB = ngayDB;
            NgayKT = ngayKT;
        }

        public NamHocDTO()
        {
        }

        public string MaNamHoc { get; set; }
        public string TenNamHoc { get; set; }
        public DateTime NgayDB { get; set; }
        public DateTime NgayKT { get; set; }
    }
}
