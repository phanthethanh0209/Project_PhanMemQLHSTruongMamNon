using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUL
{
    public class CTPhongHocBUL
    {
        CTPhongHocDAL ctPhongHocDAL = new CTPhongHocDAL();

        public bool ThemCTPhongHoc(CTPhongHocDTO p)
        {
            return ctPhongHocDAL.themCTPhong(p);
        }

        //public bool SuaPhongHoc(CTPhongHocDTO nguoidung)
        //{
        //    return ctPhongHocDAL.suaPhongHoc(nguoidung);
        //}

        //public bool XoaPhongHoc(CTPhongHocDTO nguoidung)
        //{
        //    return ctPhongHocDAL.xoaPhongHoc(nguoidung);
        //}
    }
}
