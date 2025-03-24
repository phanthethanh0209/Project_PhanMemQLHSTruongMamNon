using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTPhongHocDTO
    {
        public string MaPhong { get; set; }
        public string MaLop { get; set; }
        
       
        public CTPhongHocDTO()
        {

        }

        public CTPhongHocDTO(string maPhong, string maLop)
        {
            MaPhong = maPhong;
            MaLop = maLop;       

        }
    }
}
