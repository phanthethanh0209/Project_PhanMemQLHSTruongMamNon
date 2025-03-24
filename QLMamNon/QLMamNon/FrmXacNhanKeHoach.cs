using BUL;
using DTO;
using QLMamNon.UC_Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmXacNhanKeHoach : Form
    {

        NamHocBUL namHocBUL;
        KeHoachBUL keHoachBUL;
        LopHocBUL lopHocBUL;
        KhoanThuBUL khoanThuBUL;
        PhanLopBUL phanLopBUL;

        List<LopHocDTO> DsLopNT;
        List<LopHocDTO> DsLopMam;
        List<LopHocDTO> DsLopChoi;
        List<LopHocDTO> DsLopLa;

        NamHocDTO NamHoc;
        KeHoachDTO KeHoachNT;
        KeHoachDTO KeHoachMam;
        KeHoachDTO KeHoachChoi;
        KeHoachDTO KeHoachLa;


        List<LopHocDTO> DsLopSeThem = null;
        List<LopHocDTO> DsLopSeXoa = null;


        string TenKhoiNT, TenKhoiMam, TenKhoiChoi, TenKhoiLa, HocPhi, TienAn, TacVuChinh;


        public string TacVu { get; set; }
        public FrmXacNhanKeHoach()
        {
            InitializeComponent();

            namHocBUL = new NamHocBUL();
            keHoachBUL = new KeHoachBUL();
            lopHocBUL = new LopHocBUL();
            khoanThuBUL = new KhoanThuBUL();
            phanLopBUL = new PhanLopBUL();
        }


        MessageBoxCustome message;
        public FrmXacNhanKeHoach(List<LopHocDTO> dsLopNT, List<LopHocDTO> dsLopMam, List<LopHocDTO> dsLopChoi, List<LopHocDTO> dsLopLa,
            NamHocDTO namHoc, KeHoachDTO keHoachNT, KeHoachDTO keHoachMam, KeHoachDTO keHoachChoi, KeHoachDTO keHoachLa,
            string tenKhoiNT, string tenKhoiMam, string tenKhoiChoi, string tenKhoiLa, string hocPhi, string tienAn,
            string tacVuChinh, List<LopHocDTO> dsLopSeThem, List<LopHocDTO> dsLopSeXoa)
        {
            InitializeComponent();

            message = new MessageBoxCustome();

            namHocBUL = new NamHocBUL();
            keHoachBUL = new KeHoachBUL();
            lopHocBUL = new LopHocBUL();
            khoanThuBUL = new KhoanThuBUL();
            phanLopBUL = new PhanLopBUL();

            DsLopNT = dsLopNT;
            DsLopMam = dsLopMam;
            DsLopChoi = dsLopChoi;
            DsLopLa = dsLopLa;

            DsLopSeThem = dsLopSeThem;
            DsLopSeXoa = dsLopSeXoa;

            NamHoc = namHoc;
            KeHoachNT = keHoachNT;
            KeHoachMam = keHoachMam;
            KeHoachChoi = keHoachChoi;
            KeHoachLa = keHoachLa;
            TenKhoiNT = tenKhoiNT;
            TenKhoiMam = tenKhoiMam;
            TenKhoiChoi = tenKhoiChoi;
            TenKhoiLa = tenKhoiLa;
            HocPhi = hocPhi;
            TienAn = tienAn;
            TacVuChinh = tacVuChinh;
        }


        private void FrmXacNhanKeHoach_Load(object sender, EventArgs e)
        {
            //Thông tin năm học
            lbMaNH.Text = NamHoc.MaNamHoc;
            lbTenNH.Text = NamHoc.TenNamHoc;
            lbNgayKG.Text = NamHoc.NgayDB.ToString("dd/MM/yyyy");
            lbNgayKT.Text = NamHoc.NgayKT.ToString("dd/MM/yyyy");
            lbHocPhi.Text = HocPhi;
            lbTienAn.Text = TienAn;

            pnlKeHoach.AutoScroll = true;

            //Thông tin khối nhà trẻ
            KeHoach_UC keHoach_NT = new KeHoach_UC();
            keHoach_NT.Top = 200;
            keHoach_NT.Left = 20;
            keHoach_NT.TenKhoi = TenKhoiNT;
            keHoach_NT.SoLopMo = KeHoachNT.SoLopMo.ToString();
            keHoach_NT.SiSoTD = KeHoachNT.SiSoToiDa.ToString();
            keHoach_NT.SiSoTT = KeHoachNT.SiSoToiThieu.ToString();
            keHoach_NT.TongHS = KeHoachNT.TongHS.ToString();
            keHoach_NT.DsLop = DsLopNT;
            pnlKeHoach.Controls.Add(keHoach_NT);


            //Thông tin khối mầm
            KeHoach_UC keHoach_Mam = new KeHoach_UC();
            keHoach_Mam.Top = 640;
            keHoach_Mam.Left = 20;
            keHoach_Mam.TenKhoi = TenKhoiMam;
            keHoach_Mam.SoLopMo = KeHoachMam.SoLopMo.ToString();
            keHoach_Mam.SiSoTD = KeHoachMam.SiSoToiDa.ToString();
            keHoach_Mam.SiSoTT = KeHoachMam.SiSoToiThieu.ToString();
            keHoach_Mam.TongHS = KeHoachMam.TongHS.ToString();
            keHoach_Mam.DsLop = DsLopMam;
            pnlKeHoach.Controls.Add(keHoach_Mam);

            //Thông tin khối chồi
            KeHoach_UC keHoach_Choi = new KeHoach_UC();
            keHoach_Choi.Top = 1080;
            keHoach_Choi.Left = 20;
            keHoach_Choi.TenKhoi = TenKhoiChoi;
            keHoach_Choi.SoLopMo = KeHoachChoi.SoLopMo.ToString();
            keHoach_Choi.SiSoTD = KeHoachChoi.SiSoToiDa.ToString();
            keHoach_Choi.SiSoTT = KeHoachChoi.SiSoToiThieu.ToString();
            keHoach_Choi.TongHS = KeHoachChoi.TongHS.ToString();
            keHoach_Choi.DsLop = DsLopChoi;
            pnlKeHoach.Controls.Add(keHoach_Choi);

            //Thông tin khối lá
            KeHoach_UC keHoach_La = new KeHoach_UC();
            keHoach_La.Top = 1520;
            keHoach_La.Left = 20;
            keHoach_La.TenKhoi = TenKhoiLa;
            keHoach_La.SoLopMo = KeHoachLa.SoLopMo.ToString();
            keHoach_La.SiSoTD = KeHoachLa.SiSoToiDa.ToString();
            keHoach_La.SiSoTT = KeHoachLa.SiSoToiThieu.ToString();
            keHoach_La.TongHS = KeHoachLa.TongHS.ToString();
            keHoach_La.DsLop = DsLopLa;
            pnlKeHoach.Controls.Add(keHoach_La);
        }


        void lapKeHoachNamHoc()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    // thêm năm học
                    if (namHocBUL.themNamHoc(NamHoc))
                    {
                        KhoanThuDTO tienAn = new KhoanThuDTO(khoanThuBUL.TaoMaKhoanThu(NamHoc.MaNamHoc), NamHoc.MaNamHoc, "Tiền ăn", double.Parse(TienAn));
                        if (khoanThuBUL.Insert(tienAn))
                        {
                            KhoanThuDTO hocPhi = new KhoanThuDTO(khoanThuBUL.TaoMaKhoanThu(NamHoc.MaNamHoc), NamHoc.MaNamHoc, "Học phí", double.Parse(HocPhi));
                            if (khoanThuBUL.Insert(hocPhi))
                            {
                                // thêm kế hoạch
                                if (keHoachBUL.themKeHoach(KeHoachNT))
                                {
                                    foreach (LopHocDTO l in DsLopNT)
                                    {
                                        LopHocDTO lop = new LopHocDTO(l.MaLop, l.TenLop, 0, l.MaKhoi, l.MaNamHoc, l.MaPhong);
                                        if (!lopHocBUL.themLopHoc(lop))
                                        {
                                            throw new Exception("Thêm lớp học cho nhà trẻ thất bại!"); // Nếu thêm chi tiết không thành công, ném lỗi để rollback
                                        }
                                    }
                                }

                                // thêm kế hoạch
                                if (keHoachBUL.themKeHoach(KeHoachMam))
                                {
                                    foreach (LopHocDTO l in DsLopMam)
                                    {
                                        LopHocDTO lop = new LopHocDTO(l.MaLop, l.TenLop, 0, l.MaKhoi, l.MaNamHoc, l.MaPhong);
                                        if (!lopHocBUL.themLopHoc(lop))
                                        {
                                            throw new Exception("Thêm lớp học cho lớp mầm thất bại!"); // Nếu thêm chi tiết không thành công, ném lỗi để rollback
                                        }
                                    }
                                }

                                // thêm kế hoạch
                                if (keHoachBUL.themKeHoach(KeHoachChoi))
                                {
                                    foreach (LopHocDTO l in DsLopChoi)
                                    {
                                        LopHocDTO lop = new LopHocDTO(l.MaLop, l.TenLop, 0, l.MaKhoi, l.MaNamHoc, l.MaPhong);
                                        if (!lopHocBUL.themLopHoc(lop))
                                        {
                                            throw new Exception("Thêm lớp học cho lớp chồi thất bại!"); // Nếu thêm chi tiết không thành công, ném lỗi để rollback
                                        }
                                    }
                                }

                                // thêm kế hoạch
                                if (keHoachBUL.themKeHoach(KeHoachLa))
                                {
                                    foreach (LopHocDTO l in DsLopLa)
                                    {
                                        LopHocDTO lop = new LopHocDTO(l.MaLop, l.TenLop, 0, l.MaKhoi, l.MaNamHoc, l.MaPhong);
                                        if (!lopHocBUL.themLopHoc(lop))
                                        {
                                            throw new Exception("Thêm lớp học cho lớp lá thất bại!"); // Nếu thêm chi tiết không thành công, ném lỗi để rollback
                                        }
                                    }
                                }
                            }

                        }


                        scope.Complete();
                        message.Parent = this;
                        message.ShowSuccess("Thêm thành công!", "Thông Báo");

                        TacVu = "LuuKeHoach"; //đánh dấu để xét chế độ xem hay sửa tiếp khi đóng form này
                        this.Close();

                    }
                    else
                    {
                        throw new Exception("Thêm kế hoạch thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, transaction sẽ tự động rollback
                    message.Parent = this;
                    message.ShowError(ex.Message, "Thông Báo");
                }
            }
        }


        void suaKeHoachNamHoc()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    // sửa năm học
                    if (namHocBUL.suaNamHoc(NamHoc))
                    {
                        List<KhoanThuDTO> kthus = khoanThuBUL.layTatCaKhoanThuTrongNamHoc(NamHoc.MaNamHoc);
                        KhoanThuDTO tienAn = new KhoanThuDTO();
                        KhoanThuDTO hocPhi = new KhoanThuDTO();
                        foreach (KhoanThuDTO kt in kthus)
                        {
                            if (kt.TenKhoanThu == "Tiền ăn")
                            {
                                tienAn = new KhoanThuDTO(kt.MaKhoanThu, kt.MaNamHoc, kt.TenKhoanThu, double.Parse(TienAn));   //lấy số tiền mới               
                            }
                            if (kt.TenKhoanThu == "Học phí")
                            {
                                hocPhi = new KhoanThuDTO(kt.MaKhoanThu, kt.MaNamHoc, kt.TenKhoanThu, double.Parse(HocPhi));
                            }
                        }

                        //sửa khoản thu
                        if (khoanThuBUL.Update(tienAn) && khoanThuBUL.Update(hocPhi))
                        {
                            //Xóa những lớp càn xóa
                            if (DsLopSeXoa != null || DsLopSeXoa.Count > 0)
                            {
                                foreach (LopHocDTO lopXoa in DsLopSeXoa)
                                {
                                    if (!lopHocBUL.xoaLopHoc(lopXoa.MaLop))
                                    {
                                        throw new Exception("Xóa lớp học thất bại!");
                                    }
                                }
                            }

                            //Thêm những lớp mới tạo
                            if (DsLopSeThem != null || DsLopSeThem.Count > 0)
                            {
                                foreach (LopHocDTO lopMoi in DsLopSeThem)
                                {
                                    if (!lopHocBUL.themLopHoc(lopMoi))
                                    {
                                        throw new Exception("Thêm lớp học thất bại!");
                                    }
                                }
                            }

                            // sửa kế hoạch
                            if (keHoachBUL.suaKeHoach(KeHoachNT) && keHoachBUL.suaKeHoach(KeHoachMam) && keHoachBUL.suaKeHoach(KeHoachChoi) && keHoachBUL.suaKeHoach(KeHoachLa))
                            {
                                //Cập nhật thông tin (tên lớp, phòng) lại những lớp trong dsLopNT, dsLopMam, dsChoi, dsLa
                                foreach (LopHocDTO l in DsLopNT)
                                {
                                    LopHocDTO lop = new LopHocDTO(l.MaLop, l.TenLop, 0, l.MaKhoi, l.MaNamHoc, l.MaPhong);
                                    if (!lopHocBUL.suaLopHoc(lop))
                                    {
                                        throw new Exception("Sửa lớp học cho nhà trẻ thất bại!");
                                    }
                                }
                                foreach (LopHocDTO l in DsLopMam)
                                {
                                    LopHocDTO lop = new LopHocDTO(l.MaLop, l.TenLop, 0, l.MaKhoi, l.MaNamHoc, l.MaPhong);
                                    if (!lopHocBUL.suaLopHoc(lop))
                                    {
                                        throw new Exception("Sửa lớp học cho lớp mầm thất bại!");
                                    }
                                }
                                foreach (LopHocDTO l in DsLopChoi)
                                {
                                    LopHocDTO lop = new LopHocDTO(l.MaLop, l.TenLop, 0, l.MaKhoi, l.MaNamHoc, l.MaPhong);
                                    if (!lopHocBUL.suaLopHoc(lop))
                                    {
                                        throw new Exception("Sửa lớp học cho lớp chồi thất bại!");
                                    }
                                }
                                foreach (LopHocDTO l in DsLopLa)
                                {
                                    LopHocDTO lop = new LopHocDTO(l.MaLop, l.TenLop, 0, l.MaKhoi, l.MaNamHoc, l.MaPhong);
                                    if (!lopHocBUL.suaLopHoc(lop))
                                    {
                                        throw new Exception("Sửa lớp học cho lớp lá thất bại!");
                                    }
                                }

                            }

                        }


                        scope.Complete();
                        message.Parent = this;
                        message.ShowSuccess("Sửa thành công!", "Thông Báo");

                        TacVu = "LuuKeHoach"; //đánh dấu để xét chế độ xem hay sửa tiếp khi đóng form này
                        this.Close();

                    }
                    else
                    {
                        throw new Exception("Sửa kế hoạch thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, transaction sẽ tự động rollback
                    message.Parent = this;
                    message.ShowError(ex.Message, "Thông Báo");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (TacVuChinh == "LapKeHoach")
            {
                lapKeHoachNamHoc();
            }
            else if (TacVuChinh == "SuaKeHoach")
            {
                suaKeHoachNamHoc();
            }


            //xuất ra word
            DataTable tbl_DSLop = new DataTable();

            tbl_DSLop.Columns.Add("MaLop", typeof(string));
            tbl_DSLop.Columns.Add("TenLop", typeof(string));
            tbl_DSLop.Columns.Add("TenPhong", typeof(string));

            // Tạo danh sách tổng hợp tất cả các danh sách lớp
            List<List<LopHocDTO>> allClasses = new List<List<LopHocDTO>> { DsLopNT, DsLopMam, DsLopChoi, DsLopLa };

            foreach (List<LopHocDTO> classList in allClasses)
            {
                foreach (LopHocDTO l in classList)
                {
                    tbl_DSLop.Rows.Add(l.MaLop, l.TenLop, l.TenPhong);
                }
            }

            // Thêm cột STT vào đầu bảng và gán giá trị tự tăng
            DataColumn col = new DataColumn("STT", typeof(int));
            tbl_DSLop.Columns.Add(col);
            col.SetOrdinal(0);
            for (int i = 0; i < tbl_DSLop.Rows.Count; ++i)
            {
                tbl_DSLop.Rows[i]["STT"] = i + 1;
            }


            Dictionary<string, string> dic = new Dictionary<string, string>();
            ////string format = "MM/dd/yyyy h:mm:ss tt";

            dic.Add("ngayht", DateTime.Now.Day.ToString());
            dic.Add("thanght", DateTime.Now.Month.ToString());
            dic.Add("namht", DateTime.Now.Year.ToString());
            dic.Add("namhoc", NamHoc.TenNamHoc);

            string namHoc = DateTime.Now.Year.ToString();
            NamHocDTO namCu = namHocBUL.layNamHocTruoc(namHoc);
            dic.Add("namhoccu", namCu.TenNamHoc);

            string namsinhNT = (int.Parse(DateTime.Now.Year.ToString()) - 1) + ", " + (int.Parse(DateTime.Now.Year.ToString()) - 2);
            dic.Add("namsinhNT", namsinhNT);
            dic.Add("namsinhM", (int.Parse(DateTime.Now.Year.ToString()) - 3).ToString());
            dic.Add("namsinhC", (int.Parse(DateTime.Now.Year.ToString()) - 4).ToString());
            dic.Add("namsinhL", (int.Parse(DateTime.Now.Year.ToString()) - 5).ToString());

            int soHsNTCu = phanLopBUL.demSoHSTrongKhoi(namCu.MaNamHoc, "Nhà Trẻ");
            int soHsMCu = phanLopBUL.demSoHSTrongKhoi(namCu.MaNamHoc, "Lớp Mầm");
            int soHsCCu = phanLopBUL.demSoHSTrongKhoi(namCu.MaNamHoc, "Lớp Chồi");
            int soHsLaCu = phanLopBUL.demSoHSTrongKhoi(namCu.MaNamHoc, "Lớp Lá");

            dic.Add("slNTCu", soHsNTCu.ToString());
            dic.Add("slMCu", soHsMCu.ToString());
            dic.Add("slCCu", soHsCCu.ToString());
            dic.Add("slLaCu", soHsLaCu.ToString());
            dic.Add("tongCu", (soHsNTCu + soHsMCu + soHsCCu + soHsLaCu).ToString());

            dic.Add("slNTMoi", KeHoachNT.TongHS.ToString());
            dic.Add("slMMoi", KeHoachMam.TongHS.ToString());
            dic.Add("slCMoi", KeHoachChoi.TongHS.ToString());
            dic.Add("slLaMoi", KeHoachLa.TongHS.ToString());
            dic.Add("tongMoi", (KeHoachNT.TongHS + KeHoachMam.TongHS + KeHoachChoi.TongHS + KeHoachLa.TongHS).ToString());
            dic.Add("sltuyensinh", (KeHoachNT.TongHS + KeHoachMam.TongHS + KeHoachChoi.TongHS + KeHoachLa.TongHS).ToString());

            dic.Add("tongNT", (soHsNTCu + KeHoachNT.TongHS).ToString());
            dic.Add("tongM", (soHsMCu + KeHoachMam.TongHS).ToString());
            dic.Add("tongC", (soHsCCu + KeHoachChoi.TongHS).ToString());
            dic.Add("tongLa", (soHsLaCu + KeHoachLa.TongHS).ToString());
            dic.Add("tongcong", (soHsNTCu + soHsMCu + soHsCCu + soHsLaCu + KeHoachNT.TongHS + KeHoachMam.TongHS + KeHoachChoi.TongHS + KeHoachLa.TongHS).ToString());

            dic.Add("tongLopMo", (KeHoachNT.SoLopMo + KeHoachMam.SoLopMo + KeHoachChoi.SoLopMo + KeHoachChoi.SoLopMo).ToString());
            dic.Add("soLopNT", KeHoachNT.SoLopMo.ToString());
            dic.Add("soLopMam", KeHoachMam.SoLopMo.ToString());
            dic.Add("soLopChoi", KeHoachChoi.SoLopMo.ToString());
            dic.Add("soLopLa", KeHoachLa.SoLopMo.ToString());

            dic.Add("ssNTToiThieu", KeHoachNT.SiSoToiThieu.ToString());
            dic.Add("ssNTToiDa", KeHoachNT.SiSoToiDa.ToString());
            dic.Add("ssMamToiThieu", KeHoachMam.SiSoToiThieu.ToString());
            dic.Add("ssMamToiDa", KeHoachMam.SiSoToiDa.ToString());
            dic.Add("ssChoiToiThieu", KeHoachChoi.SiSoToiThieu.ToString());
            dic.Add("ssChoiToiDa", KeHoachChoi.SiSoToiDa.ToString());
            dic.Add("ssLaToiThieu", KeHoachLa.SiSoToiThieu.ToString());
            dic.Add("ssLaToiDa", KeHoachLa.SiSoToiDa.ToString());

            // Đường dẫn file Template mình để, còn true là mở file word lên
            WordExport wd = new WordExport(Application.StartupPath + "/Template/KeHoach.dotx", true);

            // In các Field
            wd.WriteFields(dic);
            wd.WriteTable(tbl_DSLop, 3);

            MessageBox.Show("Xuất file word thành công!!!");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            TacVu = "HuyLuuKeHoach";
            this.Close();
        }
    }
}
