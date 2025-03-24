using BUL;
using Bunifu.UI.WinForms;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmLapKeHoach : Form
    {
        NamHocBUL namHocbul;
        LopHocBUL lopHocbUL;
        PhongHocBUL phongHocbUL;
        CTPhongHocBUL ctPhongHocbUL;
        KhoiLopBUL khoiLopBUL;
        KeHoachBUL keHoachBUL;
        KhoanThuBUL khoanThuBUL;
        PhanLopBUL phanLopBUL;

        KhoiLopDTO k = new KhoiLopDTO();

        List<LopHocDTO> dsLopLa = new List<LopHocDTO>();
        List<LopHocDTO> dsLopMam = new List<LopHocDTO>();
        List<LopHocDTO> dsLopChoi = new List<LopHocDTO>();
        List<LopHocDTO> dsLopNT = new List<LopHocDTO>();
        List<PhongHocDTO> dsPhong = new List<PhongHocDTO>();

        List<LopHocDTO> dsLopSeXoa = new List<LopHocDTO>();
        List<LopHocDTO> dsLopSeThem = new List<LopHocDTO>();

        KeHoachDTO keHoachNT = new KeHoachDTO();
        KeHoachDTO keHoachMam = new KeHoachDTO();
        KeHoachDTO keHoachChoi = new KeHoachDTO();
        KeHoachDTO keHoachLa = new KeHoachDTO();

        MessageBoxCustome message;
        public FrmLapKeHoach()
        {
            InitializeComponent();

            message = new MessageBoxCustome();

            namHocbul = new NamHocBUL();
            lopHocbUL = new LopHocBUL();
            phongHocbUL = new PhongHocBUL();
            khoiLopBUL = new KhoiLopBUL();
            khoanThuBUL = new KhoanThuBUL();
            keHoachBUL = new KeHoachBUL();
            ctPhongHocbUL = new CTPhongHocBUL();
            phanLopBUL = new PhanLopBUL();

        }

        string tacVu = "";
        string tacVuChinh = "";

        string tenNHCu;

        int soLopTreCu;
        int soLopMamCu;
        int soLopChoiCu;
        int soLopLaCu;
        int soPhongHienCo;

        int soHsNTCu, soHsMCu, soHsCCu, soHsLaCu;






        private void btnThem_Click(object sender, EventArgs e)
        {
            tacVu = "Them";
        }

        string tenKhoi;
        private void FrmAdjustKeHoach_Load(object sender, EventArgs e)
        {
            dgvKeHoach.AutoGenerateColumns = false;
            dgvKeHoach.AllowUserToAddRows = false;


            //Enable - Luôn khóa
            txtMaNamHoc.Enabled = false;
            txtTenNamHoc.Enabled = false;
            txtMaLop.Enabled = false;
            txtViTriPhong.Enabled = false;
            txtSucChua.Enabled = false;
            txtTinhTrang.Enabled = false;

            //Enable
            resetTextbox();
            reset(false);

            dgvKeHoach.MouseDown += dgvKeHoach_MouseDown;

            dsPhong = phongHocbUL.layTatCaPhongHoc();

            loadCboNamHoc();

            // năm mới đã có kế hoạch thì ẩn nút lập
            NamHocDTO n = namHocbul.layNamHocMoi();
            if (n.MaNamHoc != null)
            {
                btn_batdau.Enabled = false;
            }
        }



        private void loadCboNamHoc()
        {
            cboTenNH.DataSource = namHocbul.layTatCaNamHoc();
            cboTenNH.ValueMember = "MaNamHoc";
            cboTenNH.DisplayMember = "TenNamHoc";
            cboTenNH.SelectedIndex = -1;

        }

        private void btnXemKH_Click(object sender, EventArgs e)
        {

            if (cboTenNH.SelectedIndex > 0)
            {
                resetTextbox();
                reset(false);
                btn_batdau.Enabled = false;
                btnXemKH.Enabled = true;
                btnXemDSLopNT.Enabled = true;
                btnXemDSLopMam.Enabled = true;
                btnXemDSLopChoi.Enabled = true;
                btnXemDSLopLa.Enabled = true;
                btnLamMoi.Enabled = true;

                dsLopNT.Clear();
                dsLopMam.Clear();
                dsLopChoi.Clear();
                dsLopLa.Clear();

                //xét xem năm học đó nó là năm học hiện tại thì dc sửa
                NamHocDTO nh = namHocbul.layNamHocMoi();
                if (nh != null)
                {
                    if (nh.MaNamHoc != null && cboTenNH.SelectedValue.ToString().Trim() == nh.MaNamHoc.ToString().Trim())
                    {
                        btnSuaKH.Enabled = true;
                    }
                    else
                    {
                        btnSuaKH.Enabled = false;
                    }
                }


                tacVuChinh = "XemKeHoach";


                //Dựa vào mã năm học lấy ra thông tin năm học, khoản thu, 4 kế hoạch, 4 danh sách các lớp học
                NamHocDTO namHoc = namHocbul.layThongTinCua1NamHoc(cboTenNH.SelectedValue.ToString());
                txtMaNamHoc.Text = namHoc.MaNamHoc;
                txtTenNamHoc.Text = namHoc.TenNamHoc;
                dtpNgayKG.Value = namHoc.NgayDB;
                dtpNgayKT.Value = namHoc.NgayKT;
                List<KhoanThuDTO> khoanThu = khoanThuBUL.layTatCaKhoanThuTrongNamHoc(cboTenNH.SelectedValue.ToString());
                foreach (KhoanThuDTO kt in khoanThu)
                {
                    if (kt.TenKhoanThu == "Tiền ăn")
                    {
                        txtTienAn.Text = kt.SoTien.ToString();
                    }
                    if (kt.TenKhoanThu == "Học phí")
                    {
                        txtHocPhi.Text = kt.SoTien.ToString();
                    }
                }

                List<KeHoachDTO> dsKeHoach = keHoachBUL.layDSKhoiLopTrongNamHoc(cboTenNH.SelectedValue.ToString());
                KhoiLopDTO khoi = khoiLopBUL.layMaKhoiTheoTenKhoi("Nhà Trẻ");
                KhoiLopDTO khoiM = khoiLopBUL.layMaKhoiTheoTenKhoi("Lớp Mầm");
                KhoiLopDTO khoiC = khoiLopBUL.layMaKhoiTheoTenKhoi("Lớp Chồi");
                KhoiLopDTO khoiL = khoiLopBUL.layMaKhoiTheoTenKhoi("Lớp Lá");


                foreach (KeHoachDTO kh in dsKeHoach)
                {
                    //Kế hoạch nhà trẻ
                    if (kh.MaKhoi == khoi.MaKhoi)
                    {
                        KeHoachDTO khNhaTre = keHoachBUL.layTTKeHoach(cboTenNH.SelectedValue.ToString(), khoi.MaKhoi);
                        txtSoLopMoTre.Text = khNhaTre.SoLopMo.ToString();
                        txtSiSoToiDaTre.Text = khNhaTre.SiSoToiDa.ToString();
                        txtSiSoToiThieuTre.Text = khNhaTre.SiSoToiThieu.ToString();
                        txtTongHSTre.Text = khNhaTre.TongHS.ToString();

                        List<LopHocDTO> lstLopKhoiNT = lopHocbUL.layLopHocTheoKeHoach(khoi.MaKhoi, cboTenNH.SelectedValue.ToString());
                        foreach (LopHocDTO lh in lstLopKhoiNT)
                        {
                            PhongHocDTO phong = phongHocbUL.layThongTin1PhongHoc(lh.MaPhong);

                            dsLopNT.Add(new LopHocDTO
                            {
                                MaLop = lh.MaLop,
                                MaNamHoc = lh.MaNamHoc,
                                MaKhoi = lh.MaKhoi,
                                TenLop = lh.TenLop,
                                MaPhong = lh.MaPhong,
                                TenPhong = phong.TenPhong,
                            });

                            //Cập nhật lại phần tử trong cbo
                            foreach (PhongHocDTO p in dsPhong) //dsPhong đã load khi form load
                            {
                                if (p.MaPhong == lh.MaPhong)
                                {
                                    p.TenPhong = phong.TenPhong + "-" + lh.TenLop;
                                    loadCboPhongHoc();
                                    cboPhongHoc.SelectedValue = -1;
                                }
                            }

                        }
                    }





                    //Kế hoạch khối mầm
                    if (kh.MaKhoi == khoiM.MaKhoi)
                    {
                        KeHoachDTO khMam = keHoachBUL.layTTKeHoach(cboTenNH.SelectedValue.ToString(), khoiM.MaKhoi);
                        txtSoLopMoMam.Text = khMam.SoLopMo.ToString();
                        txtSiSoToiDaMam.Text = khMam.SiSoToiDa.ToString();
                        txtSiSoToiThieuMam.Text = khMam.SiSoToiThieu.ToString();
                        txtTongHSMam.Text = khMam.TongHS.ToString();
                        List<LopHocDTO> lstLopKhoiMam = lopHocbUL.layLopHocTheoKeHoach(khoiM.MaKhoi, cboTenNH.SelectedValue.ToString());
                        foreach (LopHocDTO lh in lstLopKhoiMam)
                        {
                            PhongHocDTO phong = phongHocbUL.layThongTin1PhongHoc(lh.MaPhong);

                            dsLopMam.Add(new LopHocDTO
                            {
                                MaLop = lh.MaLop,
                                MaNamHoc = lh.MaNamHoc,
                                MaKhoi = lh.MaKhoi,
                                TenLop = lh.TenLop,
                                MaPhong = lh.MaPhong,
                                TenPhong = phong.TenPhong,
                            });

                            //Cập nhật lại phần tử trong cbo
                            foreach (PhongHocDTO p in dsPhong) //dsPhong đã load khi form load
                            {
                                if (p.MaPhong == lh.MaPhong)
                                {
                                    p.TenPhong = phong.TenPhong + "-" + lh.TenLop;
                                    loadCboPhongHoc();
                                    cboPhongHoc.SelectedValue = -1;
                                }
                            }

                        }
                    }




                    //Kế hoạch khối chồi
                    if (kh.MaKhoi == khoiC.MaKhoi)
                    {
                        KeHoachDTO khChoi = keHoachBUL.layTTKeHoach(cboTenNH.SelectedValue.ToString(), khoiC.MaKhoi);
                        txtSoLopMoChoi.Text = khChoi.SoLopMo.ToString();
                        txtSiSoToiDaChoi.Text = khChoi.SiSoToiDa.ToString();
                        txtSiSoToiThieuChoi.Text = khChoi.SiSoToiThieu.ToString();
                        txtTongHSChoi.Text = khChoi.TongHS.ToString();
                        List<LopHocDTO> lstLopKhoiChoi = lopHocbUL.layLopHocTheoKeHoach(khoiC.MaKhoi, cboTenNH.SelectedValue.ToString());
                        foreach (LopHocDTO lh in lstLopKhoiChoi)
                        {
                            PhongHocDTO phong = phongHocbUL.layThongTin1PhongHoc(lh.MaPhong);

                            dsLopChoi.Add(new LopHocDTO
                            {
                                MaLop = lh.MaLop,
                                MaNamHoc = lh.MaNamHoc,
                                MaKhoi = lh.MaKhoi,
                                TenLop = lh.TenLop,
                                MaPhong = lh.MaPhong,
                                TenPhong = phong.TenPhong,
                            });

                            //Cập nhật lại phần tử trong cbo
                            foreach (PhongHocDTO p in dsPhong) //dsPhong đã load khi form load
                            {
                                if (p.MaPhong == lh.MaPhong)
                                {
                                    p.TenPhong = phong.TenPhong + "-" + lh.TenLop;
                                    loadCboPhongHoc();
                                    cboPhongHoc.SelectedValue = -1;
                                }
                            }

                        }
                    }





                    //Kế hoạch khối lá
                    if (kh.MaKhoi == khoiL.MaKhoi)
                    {
                        KeHoachDTO khLa = keHoachBUL.layTTKeHoach(cboTenNH.SelectedValue.ToString(), khoiL.MaKhoi);
                        txtSoLopMoLa.Text = khLa.SoLopMo.ToString();
                        txtSiSoToiDaLa.Text = khLa.SiSoToiDa.ToString();
                        txtSiSoToiThieuLa.Text = khLa.SiSoToiThieu.ToString();
                        txtTongHSLa.Text = khLa.TongHS.ToString();
                        List<LopHocDTO> lstLopKhoiLa = lopHocbUL.layLopHocTheoKeHoach(khoiL.MaKhoi, cboTenNH.SelectedValue.ToString());
                        foreach (LopHocDTO lh in lstLopKhoiLa)
                        {
                            PhongHocDTO phong = phongHocbUL.layThongTin1PhongHoc(lh.MaPhong);

                            dsLopLa.Add(new LopHocDTO
                            {
                                MaLop = lh.MaLop,
                                MaNamHoc = lh.MaNamHoc,
                                MaKhoi = lh.MaKhoi,
                                TenLop = lh.TenLop,
                                MaPhong = lh.MaPhong,
                                TenPhong = phong.TenPhong,
                            });

                            //Cập nhật lại phần tử trong cbo
                            foreach (PhongHocDTO p in dsPhong) //dsPhong đã load khi form load
                            {
                                if (p.MaPhong == lh.MaPhong)
                                {
                                    p.TenPhong = phong.TenPhong + "-" + lh.TenLop;
                                    loadCboPhongHoc();
                                    cboPhongHoc.SelectedValue = -1;
                                }
                            }

                        }
                    }



                }
            }
            else
            {
                message.Parent = this.ParentForm;
                message.ShowError("Vui lòng chọn 1 năm học!", "Lỗi");
            }


        }

        void resetTextbox()
        {
            dgvKeHoach.Rows.Clear();
            dtpNgayKG.Text = DateTime.Now.ToString();
            dtpNgayKT.Text = DateTime.Now.ToString();
            txtMaNamHoc.Text = string.Empty;
            txtTenNamHoc.Text = string.Empty;
            txtTienAn.Text = string.Empty;
            txtHocPhi.Text = string.Empty;
            txtSoLopMoTre.Text = string.Empty;
            txtSoLopMoMam.Text = string.Empty;
            txtSoLopMoChoi.Text = string.Empty;
            txtSoLopMoLa.Text = string.Empty;
            txtSiSoToiThieuTre.Text = string.Empty;
            txtSiSoToiThieuMam.Text = string.Empty;
            txtSiSoToiThieuChoi.Text = string.Empty;
            txtSiSoToiThieuLa.Text = string.Empty;
            txtSiSoToiDaTre.Text = string.Empty;
            txtSiSoToiDaMam.Text = string.Empty;
            txtSiSoToiDaChoi.Text = string.Empty;
            txtSiSoToiDaLa.Text = string.Empty;
            txtTongHSTre.Text = string.Empty;
            txtTongHSMam.Text = string.Empty;
            txtTongHSChoi.Text = string.Empty;
            txtTongHSLa.Text = string.Empty;
            cboPhongHoc.SelectedIndex = -1;
            txtTenLop.Text = string.Empty;
            txtMaLop.Text = string.Empty;
            txtViTriPhong.Text = string.Empty;
            txtSucChua.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;
            cboPhongHoc.Text = string.Empty;
            lbLuuy.Text = string.Empty;
        }

        void reset(bool anHien)
        {

            btnLamMoi.Enabled = anHien;
            btnSuaKH.Enabled = anHien;
            btnLuuKeHoach.Enabled = anHien;
            btnLuuLop.Enabled = anHien;
            btnTaoDSLopNT.Enabled = anHien;
            btnTaoDSLopMam.Enabled = anHien;
            btnTaoDSLopChoi.Enabled = anHien;
            btnTaoDSLopLa.Enabled = anHien;
            btnXemDSLopNT.Enabled = anHien;
            btnXemDSLopMam.Enabled = anHien;
            btnXemDSLopChoi.Enabled = anHien;
            btnXemDSLopLa.Enabled = anHien;
            dtpNgayKG.Enabled = anHien;
            dtpNgayKT.Enabled = anHien;
            txtTienAn.Enabled = anHien;
            txtHocPhi.Enabled = anHien;
            txtSoLopMoTre.Enabled = anHien;
            txtSoLopMoMam.Enabled = anHien;
            txtSoLopMoChoi.Enabled = anHien;
            txtSoLopMoLa.Enabled = anHien;
            txtSiSoToiThieuTre.Enabled = anHien;
            txtSiSoToiThieuMam.Enabled = anHien;
            txtSiSoToiThieuChoi.Enabled = anHien;
            txtSiSoToiThieuLa.Enabled = anHien;
            txtSiSoToiDaTre.Enabled = anHien;
            txtSiSoToiDaMam.Enabled = anHien;
            txtSiSoToiDaChoi.Enabled = anHien;
            txtSiSoToiDaLa.Enabled = anHien;
            txtTongHSTre.Enabled = anHien;
            txtTongHSMam.Enabled = anHien;
            txtTongHSChoi.Enabled = anHien;
            txtTongHSLa.Enabled = anHien;
            cboPhongHoc.Enabled = anHien;
            txtTenLop.Enabled = anHien;
        }



        private void AnHienlbSoLopCu(bool hien)
        {
            if (hien)
            {
                soPhongHienCo = phongHocbUL.demSoPhong();
                lbSoPhongHienCo.Text = "Số phòng hiện có: " + soPhongHienCo.ToString();

                string namHoc = DateTime.Now.Year.ToString();
                NamHocDTO nam = namHocbul.layNamHocTruoc(namHoc);
                tenNHCu = nam.TenNamHoc;
                List<KeHoachDTO> dsKeHoach = keHoachBUL.layDSKhoiLopTrongNamHoc(nam.MaNamHoc);
                KhoiLopDTO khoi = khoiLopBUL.layMaKhoiTheoTenKhoi("Nhà Trẻ");
                KhoiLopDTO khoiM = khoiLopBUL.layMaKhoiTheoTenKhoi("Lớp Mầm");
                KhoiLopDTO khoiC = khoiLopBUL.layMaKhoiTheoTenKhoi("Lớp Chồi");
                KhoiLopDTO khoiL = khoiLopBUL.layMaKhoiTheoTenKhoi("Lớp Lá");

                KeHoachDTO keHoachNhatre = keHoachBUL.layTTKeHoach(nam.MaNamHoc, khoi.MaKhoi);
                KeHoachDTO keHoachLopMam = keHoachBUL.layTTKeHoach(nam.MaNamHoc, khoiM.MaKhoi);
                KeHoachDTO keHoachLopChoi = keHoachBUL.layTTKeHoach(nam.MaNamHoc, khoiC.MaKhoi);
                KeHoachDTO keHoachLopLa = keHoachBUL.layTTKeHoach(nam.MaNamHoc, khoiL.MaKhoi);

                soLopTreCu = keHoachNhatre.SoLopMo;
                soLopMamCu = keHoachLopMam.SoLopMo;
                soLopChoiCu = keHoachLopChoi.SoLopMo;
                soLopLaCu = keHoachLopLa.SoLopMo;

                soHsNTCu = phanLopBUL.demSoHSTrongKhoi(nam.MaNamHoc, khoi.TenKhoi);
                soHsMCu = phanLopBUL.demSoHSTrongKhoi(nam.MaNamHoc, khoiM.TenKhoi);
                soHsCCu = phanLopBUL.demSoHSTrongKhoi(nam.MaNamHoc, khoiC.TenKhoi);
                soHsLaCu = phanLopBUL.demSoHSTrongKhoi(nam.MaNamHoc, khoiL.TenKhoi);

                lbSoLopTreCu.Text = soLopTreCu.ToString() + " lớp Nhà Trẻ- " + soHsNTCu.ToString() + " trẻ";
                lbSoLopMamCu.Text = soLopMamCu.ToString() + " lớp Mầm- " + soHsMCu.ToString() + " trẻ";
                lbSoLopChoiCu.Text = soLopChoiCu.ToString() + " lớp Chồi- " + soHsCCu.ToString() + " trẻ";
                lbSoLopLaCu.Text = soLopLaCu.ToString() + " lớp Lá- " + soHsLaCu.ToString() + " trẻ";
            }

            // hiển thị
            lbSoPhongHienCo.Visible = hien;
            label25.Visible = hien;
            lbSoLopTreCu.Visible = hien;
            lbSoLopMamCu.Visible = hien;
            lbSoLopChoiCu.Visible = hien;
            lbSoLopLaCu.Visible = hien;
        }

        private void btn_batdau_Click(object sender, EventArgs e)
        {
            //Enabled
            resetTextbox();
            reset(true);
            cboTenNH.SelectedIndex = -1;
            btn_batdau.Enabled = false;
            cboPhongHoc.Enabled = false;
            txtTenLop.Enabled = false;
            btnLuuLop.Enabled = false;
            cboTenNH.Enabled = false;  //Không được xem nữa (trừ khi ấn nút làm mới)
            btnXemKH.Enabled = false;
            btnSuaKH.Enabled = false;

            dsPhong = phongHocbUL.layTatCaPhongHoc();
            tacVu = "";
            loadCboPhongHoc();

            //Tạo mã
            txtMaNamHoc.Text = namHocbul.TaoMaNH();
            txtTenNamHoc.Text = namHocbul.TaoTenNH();

            tacVuChinh = "LapKeHoach";

            AnHienlbSoLopCu(true);
        }

        private void themLop(List<LopHocDTO> lst, int soLopMo)
        {
            // Xóa dữ liệu cũ trong DataGridView trước khi thêm mới
            dgvKeHoach.Rows.Clear();
            lst.Clear();

            k = khoiLopBUL.layMaKhoiTheoTenKhoi(tenKhoi); //lấy mã khối theo đúng năm học
            string prefix = "L" + k.MaKhoi.Trim().Substring(1, 2) + txtMaNamHoc.Text.Substring(2);
            for (int i = 1; i <= soLopMo; i++)
            {
                // Định dạng số thứ tự 3 chữ số (001, 002,...)
                string maLop = prefix + i.ToString("D3");
                string tenLop = tenKhoi + " " + i;

                lst.Add(new LopHocDTO
                {
                    MaLop = maLop,
                    MaNamHoc = txtMaNamHoc.Text,
                    MaKhoi = k.MaKhoi,
                    TenLop = tenLop,
                    MaPhong = null,
                    TenPhong = null,
                });

                //dgvKeHoach.Rows.Add(maLop, tenLop, null); //tên phòng ban đầu là null
            }

            // kiểm tra số phòng với số lớp đã tạo
            if ((dsLopChoi.Count + dsLopLa.Count + dsLopMam.Count + dsLopNT.Count) > soPhongHienCo)
            {
                message.Parent = this.ParentForm;
                message.ShowFail("Số phòng hiện có không đủ để tạo lớp", "Thông báo");
                lst.Clear();

                return;
            }

            foreach (LopHocDTO lop in lst)
            {
                dgvKeHoach.Rows.Add(lop.MaLop, lop.TenLop, null); // Tên phòng ban đầu là null
            }
        }

        bool kiemTraKhoiLopDayDuThongTin(int soLopMo, int siSoToiThieu, int siSoToiDa, int tongHS)
        {
            if (soLopMo == 0 || siSoToiThieu == 0 || siSoToiDa == 0 || tongHS == 0)
            {
                message.Parent = this.ParentForm;
                message.ShowError("Vui lòng nhập đầy đủ thông tin!", "Lỗi");
                return false;
            }
            return true;
        }


        private void btnXemDSLopNT_Click(object sender, EventArgs e)
        {
            cboPhongHoc.Text = string.Empty;
            lbLuuy.Text = string.Empty;
            cboPhongHoc.SelectedIndex = -1;
            txtTenLop.Text = string.Empty;
            txtMaLop.Text = string.Empty;
            txtViTriPhong.Text = string.Empty;
            txtSucChua.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;


            if (dsLopNT.Count > 0)
                loadDataGridView(dsLopNT); //tạo lớp rồi thì có phòng
            else
            {
                message.Parent = this.ParentForm;
                message.ShowError("Hãy tạo tạo danh sách lớp trước!", "Lỗi");
            }


            //Gán tác vụ để lưu mã phòng theo đúng khối
            tacVu = "XemKhoiNhaTre";

        }

        private void btnXemDSLopMam_Click(object sender, EventArgs e)
        {
            cboPhongHoc.Text = string.Empty;
            lbLuuy.Text = string.Empty;
            cboPhongHoc.SelectedIndex = -1;
            txtTenLop.Text = string.Empty;
            txtMaLop.Text = string.Empty;
            txtViTriPhong.Text = string.Empty;
            txtSucChua.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;

            if (dsLopMam.Count > 0)
                loadDataGridView(dsLopMam); //tạo lớp rồi thì có phòng
            else
            {
                message.Parent = this.ParentForm;
                message.ShowError("Hãy tạo tạo danh sách lớp trước!", "Lỗi");
            }

            //Gán tác vụ để lưu mã phòng theo đúng khối
            tacVu = "XemKhoiMam";

        }

        private void btnXemDSLopChoi_Click(object sender, EventArgs e)
        {
            cboPhongHoc.Text = string.Empty;
            lbLuuy.Text = string.Empty;
            cboPhongHoc.SelectedIndex = -1;
            txtTenLop.Text = string.Empty;
            txtMaLop.Text = string.Empty;
            txtViTriPhong.Text = string.Empty;
            txtSucChua.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;

            if (dsLopChoi.Count > 0)
                loadDataGridView(dsLopChoi); //tạo lớp rồi thì có phòng
            else
            {
                message.Parent = this.ParentForm;
                message.ShowError("Hãy tạo tạo danh sách lớp trước!", "Lỗi");
            }

            //Gán tác vụ để lưu mã phòng theo đúng khối
            tacVu = "XemKhoiChoi";
        }

        private void btnXemDSLopLa_Click(object sender, EventArgs e)
        {
            cboPhongHoc.Text = string.Empty;
            lbLuuy.Text = string.Empty;
            cboPhongHoc.SelectedIndex = -1;
            txtTenLop.Text = string.Empty;
            txtMaLop.Text = string.Empty;
            txtViTriPhong.Text = string.Empty;
            txtSucChua.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;

            if (dsLopLa.Count > 0)
                loadDataGridView(dsLopLa); //tạo lớp rồi thì có phòng
            else
            {
                message.Parent = this.ParentForm;
                message.ShowError("Hãy tạo tạo danh sách lớp trước!", "Lỗi");
            }

            //Gán tác vụ để lưu mã phòng theo đúng khối
            tacVu = "XemKhoiLa";
        }

        private void btnTaoDSLopNT_Click(object sender, EventArgs e)
        {
            cboPhongHoc.Text = string.Empty;
            lbLuuy.Text = string.Empty;
            cboPhongHoc.SelectedIndex = -1;
            txtTenLop.Text = string.Empty;
            txtMaLop.Text = string.Empty;
            txtViTriPhong.Text = string.Empty;
            txtSucChua.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;

            // Kiểm tra nếu TextBox rỗng
            if (kiemTraKhoiLopDayDuThongTin(txtSoLopMoTre.Text.Length, txtSiSoToiThieuTre.Text.Length, txtSiSoToiDaTre.Text.Length, txtTongHSTre.Text.Length))
            {

                int soLopMo = int.Parse(txtSoLopMoTre.Text);

                tenKhoi = "Nhà Trẻ";

                k = khoiLopBUL.layMaKhoiTheoTenKhoi(tenKhoi);
                int soLop = int.Parse(txtSoLopMoTre.Text);
                int siSoTT = int.Parse(txtSiSoToiThieuTre.Text);
                int siSoTD = int.Parse(txtSiSoToiDaTre.Text);
                int tongHS = int.Parse(txtTongHSTre.Text);
                keHoachNT = new KeHoachDTO(txtMaNamHoc.Text, k.MaKhoi, soLop, siSoTT, siSoTD, tongHS);

                if (siSoTT > siSoTD)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    DialogResult r = message.Show("Sỉ số tối đa phải lớn hơn sỉ số tối thiểu", "Thông Báo");

                    return;
                }

                if (dsLopNT.Count > 0) //Phải reset lại combo Phòng trước khi tạo mới
                {
                    List<string> lstMaPhong = new List<string>();
                    //List<LopHocDTO> dsLopNTCu = dsLopNT;
                    List<LopHocDTO> dsLopNTCu = new List<LopHocDTO>(dsLopNT);

                    //XỬ LÝ ĐỐI VỚI TH SỬA KẾ HOẠCH
                    if (tacVuChinh == "SuaKeHoach") //lưu vào danh sách mã lớp cần xóa trong csdl
                    {
                        // kiểm tra số phòng với số lớp đã tạo
                        if ((dsLopChoi.Count + dsLopLa.Count + dsLopMam.Count + soLop) > soPhongHienCo)
                        {
                            message.Parent = this.ParentForm;
                            message.ShowFail("Số phòng hiện có không đủ để tạo lớp", "Thông báo");

                            return;
                        }

                        if (dsLopNTCu.Count > soLop) //ds cũ > số lg lớp mới sắp mở ==> xóa
                        {
                            //Lấy ra [dsLopNT.Count - số lớp mở] dòng kể từ dsLopNT.Count       
                            for (int i = soLopMo; i < dsLopNTCu.Count; i++)
                            {
                                dsLopSeXoa.Add(dsLopNTCu[i]); //đưa vào ds để qua kia xóa ra csdl
                                lstMaPhong.Add(dsLopNTCu[i].MaPhong); //đưa vào lstMaPhong để nó xóa tên lớp khỏi cbo
                                dsLopNT.Remove(dsLopNTCu[i]); //xóa ra để nó hiện đúng số lớp mới trên dgv
                                loadDataGridView(dsLopNT);

                            }
                        }

                        if (dsLopNTCu.Count < soLop) //Tạo tiếp các lớp bổ sung --> lưu mã mới tạo vào list chờ thêm
                        {
                            string prefix = "L" + k.MaKhoi.Trim().Substring(1, 2) + txtMaNamHoc.Text.Substring(2);
                            for (int i = dsLopNTCu.Count + 1; i <= soLopMo; i++)
                            {
                                // Tạo thêm lớp học mới
                                string maLop = prefix + i.ToString("D3");
                                string tenLop = tenKhoi + " " + i;
                                LopHocDTO lopMoi = new LopHocDTO
                                {
                                    MaLop = maLop,
                                    MaNamHoc = txtMaNamHoc.Text,
                                    MaKhoi = k.MaKhoi,
                                    TenLop = tenLop,
                                    MaPhong = null,
                                    TenPhong = null,
                                };
                                dsLopNT.Add(lopMoi); //thêm vào để nó hiện đúng số lớp mới trên dgv

                                dsLopSeThem.Add(lopMoi); //đưa vào ds để qua kia thêm vào csdl
                                loadDataGridView(dsLopNT);
                                //dgvKeHoach.Rows.Add(maLop, tenLop, null);
                            }
                        }

                    }
                    else
                    {
                        //XỬ LÝ ĐỐI VỚI TH LẬP KẾ HOẠCH
                        foreach (LopHocDTO lh in dsLopNTCu) //lấy ra các mã phòng trong dsNhaTre- sắp bị xóa
                        {
                            if (lh.MaPhong != null)
                            {
                                lstMaPhong.Add(lh.MaPhong); //gôm các mã phòng trong ds cần xóa
                            }
                        }
                    }




                    //XỬ LÝ LẠI MÃ PHÒNG VỀ NGUYÊN BẢN
                    foreach (PhongHocDTO p in dsPhong)//Phòng nào có chứa mã phòng trong ds thì cắt chuỗi về định dạng cũ (lúc chưa có lớp)
                    {
                        foreach (string maPhong in lstMaPhong)
                        {
                            if (p.MaPhong == maPhong)
                            {
                                int index = p.TenPhong.IndexOf('-');
                                if (index >= 0) // Kiểm tra nếu có dấu '-'
                                    p.TenPhong = p.TenPhong.Substring(0, index).Trim(); // Cắt chuỗi từ đầu đến vị trí của dấu '-' và loại bỏ khoảng trắng
                                else
                                    p.TenPhong = p.TenPhong.Trim(); // Không có dấu '-', sử dụng toàn bộ chuỗi
                            }
                        }
                    }


                }

                if (tacVuChinh == "LapKeHoach")
                    themLop(dsLopNT, soLopMo); //mới tạo lớp thì chưa có phòng

                //Gán tác vụ để lưu mã phòng theo đúng khối
                tacVu = "XemKhoiNhaTre";
            }


        }

        private void btnTaoDSLopMam_Click(object sender, EventArgs e)
        {
            cboPhongHoc.Text = string.Empty;
            lbLuuy.Text = string.Empty;
            cboPhongHoc.SelectedIndex = -1;
            txtTenLop.Text = string.Empty;
            txtMaLop.Text = string.Empty;
            txtViTriPhong.Text = string.Empty;
            txtSucChua.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;

            // Kiểm tra nếu TextBox rỗng hoặc giá trị nhập không hợp lệ
            if (kiemTraKhoiLopDayDuThongTin(txtSoLopMoMam.Text.Length, txtSiSoToiThieuMam.Text.Length, txtSiSoToiDaMam.Text.Length, txtTongHSMam.Text.Length))
            {

                int soLopMo = int.Parse(txtSoLopMoMam.Text);
                tenKhoi = "Lớp Mầm";

                k = khoiLopBUL.layMaKhoiTheoTenKhoi(tenKhoi);
                int soLop = int.Parse(txtSoLopMoMam.Text);
                int siSoTT = int.Parse(txtSiSoToiThieuMam.Text);
                int siSoTD = int.Parse(txtSiSoToiDaMam.Text);
                int tongHS = int.Parse(txtTongHSMam.Text);
                keHoachMam = new KeHoachDTO(txtMaNamHoc.Text, k.MaKhoi, soLop, siSoTT, siSoTD, tongHS);

                if (siSoTT > siSoTD)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    DialogResult r = message.Show("Sỉ số tối đa phải lớn hơn sỉ số tối thiểu", "Thông Báo");

                    return;
                }

                // ktra số lớp của khối cũ năm ngoái (nhà trẻ) <= số lớp mới (mầm non)
                if (soLop < soLopTreCu)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    DialogResult r = message.Show("Số lớp Mầm mới phải lớn hơn số Nhà Trẻ cũ", "Thông Báo");

                    return;
                }

                if (dsLopMam.Count > 0) //Phải reset lại combo Phòng trước khi tạo mới
                {
                    List<string> lstMaPhong = new List<string>();
                    //List<LopHocDTO> dsLopMamCu = dsLopMam;
                    List<LopHocDTO> dsLopMamCu = new List<LopHocDTO>(dsLopMam);

                    //XỬ LÝ ĐỐI VỚI TH SỬA KẾ HOẠCH
                    if (tacVuChinh == "SuaKeHoach") //lưu vào danh sách mã lớp cần xóa trong csdl
                    {
                        // kiểm tra số phòng với số lớp đã tạo
                        if ((dsLopChoi.Count + dsLopLa.Count + dsLopNT.Count + soLop) > soPhongHienCo)
                        {
                            message.Parent = this.ParentForm;
                            message.ShowFail("Số phòng hiện có không đủ để tạo lớp", "Thông báo");

                            return;
                        }
                        if (dsLopMamCu.Count > soLop) //ds cũ > số lg lớp mới sắp mở ==> xóa
                        {
                            //Lấy ra [dsLopMam.Count - số lớp mở] dòng kể từ dsLopMam.Count       
                            for (int i = soLopMo; i < dsLopMamCu.Count; i++)
                            {
                                dsLopSeXoa.Add(dsLopMamCu[i]); //đưa vào ds để qua kia xóa ra csdl
                                lstMaPhong.Add(dsLopMamCu[i].MaPhong); //đưa vào lstMaPhong để nó xóa tên lớp khỏi cbo
                                dsLopMam.Remove(dsLopMamCu[i]); //xóa ra để nó hiện đúng số lớp mới trên dgv
                                loadDataGridView(dsLopMam);

                            }
                        }

                        if (dsLopMamCu.Count < soLop) //Tạo tiếp các lớp bổ sung --> lưu mã mới tạo vào list chờ thêm
                        {
                            string prefix = "L" + k.MaKhoi.Trim().Substring(1, 2) + txtMaNamHoc.Text.Substring(2);
                            for (int i = dsLopMamCu.Count + 1; i <= soLopMo; i++)
                            {
                                // Tạo thêm lớp học mới
                                string maLop = prefix + i.ToString("D3");
                                string tenLop = tenKhoi + " " + i;
                                LopHocDTO lopMoi = new LopHocDTO
                                {
                                    MaLop = maLop,
                                    MaNamHoc = txtMaNamHoc.Text,
                                    MaKhoi = k.MaKhoi,
                                    TenLop = tenLop,
                                    MaPhong = null,
                                    TenPhong = null,
                                };
                                dsLopMam.Add(lopMoi); //thêm vào để nó hiện đúng số lớp mới trên dgv
                                dsLopSeThem.Add(lopMoi); //đưa vào ds để qua kia thêm vào csdl
                                loadDataGridView(dsLopMam);
                                //dgvKeHoach.Rows.Add(maLop, tenLop, null);
                            }
                        }

                    }
                    else
                    {
                        //XỬ LÝ ĐỐI VỚI TH LẬP KẾ HOẠCH
                        foreach (LopHocDTO lh in dsLopMamCu) //lấy ra các mã phòng trong dsNhaTre- sắp bị xóa
                        {
                            if (lh.MaPhong != null)
                            {
                                lstMaPhong.Add(lh.MaPhong); //gôm các mã phòng trong ds cần xóa
                            }
                        }
                    }




                    //XỬ LÝ LẠI MÃ PHÒNG VỀ NGUYÊN BẢN
                    foreach (PhongHocDTO p in dsPhong)//Phòng nào có chứa mã phòng trong ds thì cắt chuỗi về định dạng cũ (lúc chưa có lớp)
                    {
                        foreach (string maPhong in lstMaPhong)
                        {
                            if (p.MaPhong == maPhong)
                            {
                                int index = p.TenPhong.IndexOf('-');
                                if (index >= 0) // Kiểm tra nếu có dấu '-'
                                    p.TenPhong = p.TenPhong.Substring(0, index).Trim(); // Cắt chuỗi từ đầu đến vị trí của dấu '-' và loại bỏ khoảng trắng
                                else
                                    p.TenPhong = p.TenPhong.Trim(); // Không có dấu '-', sử dụng toàn bộ chuỗi
                            }
                        }
                    }


                }

                if (tacVuChinh == "LapKeHoach")
                    themLop(dsLopMam, soLopMo); //mới tạo lớp thì chưa có phòng

                //Gán tác vụ để lưu mã phòng theo đúng khối
                tacVu = "XemKhoiMam";
            }


        }

        private void btnTaoDSLopChoi_Click(object sender, EventArgs e)
        {
            cboPhongHoc.Text = string.Empty;
            lbLuuy.Text = string.Empty;
            cboPhongHoc.SelectedIndex = -1;
            txtTenLop.Text = string.Empty;
            txtMaLop.Text = string.Empty;
            txtViTriPhong.Text = string.Empty;
            txtSucChua.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;

            // Kiểm tra nếu TextBox rỗng
            if (kiemTraKhoiLopDayDuThongTin(txtSoLopMoChoi.Text.Length, txtSiSoToiThieuChoi.Text.Length, txtSiSoToiDaChoi.Text.Length, txtTongHSChoi.Text.Length))
            {
                int soLopMo = int.Parse(txtSoLopMoChoi.Text);

                tenKhoi = "Lớp Chồi";

                k = khoiLopBUL.layMaKhoiTheoTenKhoi(tenKhoi);
                int soLop = int.Parse(txtSoLopMoChoi.Text);
                int siSoTT = int.Parse(txtSiSoToiThieuChoi.Text);
                int siSoTD = int.Parse(txtSiSoToiDaChoi.Text);
                int tongHS = int.Parse(txtTongHSChoi.Text);
                keHoachChoi = new KeHoachDTO(txtMaNamHoc.Text, k.MaKhoi, soLop, siSoTT, siSoTD, tongHS);

                if (siSoTT > siSoTD)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    DialogResult r = message.Show("Sỉ số tối đa phải lớn hơn sỉ số tối thiểu", "Thông Báo");

                    return;
                }

                // ktra số lớp của khối cũ năm ngoái (mầm) <= số lớp mới (chồi)
                if (soLop < soLopMamCu)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    DialogResult r = message.Show("Số lớp Chồi mới phải lớn hơn số lớp Mầm cũ", "Thông Báo");

                    return;
                }

                if (dsLopChoi.Count > 0) //Phải reset lại combo Phòng trước khi tạo mới
                {
                    List<string> lstMaPhong = new List<string>();
                    //List<LopHocDTO> dsLopChoiCu = dsLopChoi;
                    List<LopHocDTO> dsLopChoiCu = new List<LopHocDTO>(dsLopChoi);

                    //XỬ LÝ ĐỐI VỚI TH SỬA KẾ HOẠCH
                    if (tacVuChinh == "SuaKeHoach") //lưu vào danh sách mã lớp cần xóa trong csdl
                    {
                        // kiểm tra số phòng với số lớp đã tạo
                        if ((dsLopNT.Count + dsLopLa.Count + dsLopMam.Count + soLop) > soPhongHienCo)
                        {
                            message.Parent = this.ParentForm;
                            message.ShowFail("Số phòng hiện có không đủ để tạo lớp", "Thông báo");

                            return;
                        }
                        if (dsLopChoiCu.Count > soLop) //ds cũ > số lg lớp mới sắp mở ==> xóa
                        {
                            //Lấy ra [dsLopChoi.Count - số lớp mở] dòng kể từ dsLopChoi.Count       
                            for (int i = soLopMo; i < dsLopChoiCu.Count; i++)
                            {
                                dsLopSeXoa.Add(dsLopChoiCu[i]); //đưa vào ds để qua kia xóa ra csdl
                                lstMaPhong.Add(dsLopChoiCu[i].MaPhong); //đưa vào lstMaPhong để nó xóa tên lớp khỏi cbo
                                dsLopChoi.Remove(dsLopChoiCu[i]); //xóa ra để nó hiện đúng số lớp mới trên dgv
                                loadDataGridView(dsLopChoi);

                            }
                        }

                        if (dsLopChoiCu.Count < soLop) //Tạo tiếp các lớp bổ sung --> lưu mã mới tạo vào list chờ thêm
                        {
                            string prefix = "L" + k.MaKhoi.Trim().Substring(1, 2) + txtMaNamHoc.Text.Substring(2);
                            for (int i = dsLopChoiCu.Count + 1; i <= soLopMo; i++)
                            {
                                // Tạo thêm lớp học mới
                                string maLop = prefix + i.ToString("D3");
                                string tenLop = tenKhoi + " " + i;
                                LopHocDTO lopMoi = new LopHocDTO
                                {
                                    MaLop = maLop,
                                    MaNamHoc = txtMaNamHoc.Text,
                                    MaKhoi = k.MaKhoi,
                                    TenLop = tenLop,
                                    MaPhong = null,
                                    TenPhong = null,
                                };
                                dsLopChoi.Add(lopMoi); //thêm vào để nó hiện đúng số lớp mới trên dgv
                                dsLopSeThem.Add(lopMoi); //đưa vào ds để qua kia thêm vào csdl
                                loadDataGridView(dsLopChoi);
                                //dgvKeHoach.Rows.Add(maLop, tenLop, null);
                            }
                        }

                    }
                    else
                    {
                        //XỬ LÝ ĐỐI VỚI TH LẬP KẾ HOẠCH
                        foreach (LopHocDTO lh in dsLopChoiCu) //lấy ra các mã phòng trong dsNhaTre- sắp bị xóa
                        {
                            if (lh.MaPhong != null)
                            {
                                lstMaPhong.Add(lh.MaPhong); //gôm các mã phòng trong ds cần xóa
                            }
                        }
                    }




                    //XỬ LÝ LẠI MÃ PHÒNG VỀ NGUYÊN BẢN
                    foreach (PhongHocDTO p in dsPhong)//Phòng nào có chứa mã phòng trong ds thì cắt chuỗi về định dạng cũ (lúc chưa có lớp)
                    {
                        foreach (string maPhong in lstMaPhong)
                        {
                            if (p.MaPhong == maPhong)
                            {
                                int index = p.TenPhong.IndexOf('-');
                                if (index >= 0) // Kiểm tra nếu có dấu '-'
                                    p.TenPhong = p.TenPhong.Substring(0, index).Trim(); // Cắt chuỗi từ đầu đến vị trí của dấu '-' và loại bỏ khoảng trắng
                                else
                                    p.TenPhong = p.TenPhong.Trim(); // Không có dấu '-', sử dụng toàn bộ chuỗi
                            }
                        }
                    }


                }

                if (tacVuChinh == "LapKeHoach")
                    themLop(dsLopChoi, soLopMo); //mới tạo lớp thì chưa có phòng

                //Gán tác vụ để lưu mã phòng theo đúng khối
                tacVu = "XemKhoiChoi";
            }
        }

        private void btnTaoDSLopLa_Click(object sender, EventArgs e)
        {
            cboPhongHoc.Text = string.Empty;
            lbLuuy.Text = string.Empty;
            cboPhongHoc.SelectedIndex = -1;
            txtTenLop.Text = string.Empty;
            txtMaLop.Text = string.Empty;
            txtViTriPhong.Text = string.Empty;
            txtSucChua.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;

            // Kiểm tra nếu TextBox rỗng hoặc giá trị nhập không hợp lệ
            if (kiemTraKhoiLopDayDuThongTin(txtSoLopMoLa.Text.Length, txtSiSoToiThieuLa.Text.Length, txtSiSoToiDaLa.Text.Length, txtTongHSLa.Text.Length))
            {
                int soLopMo = int.Parse(txtSoLopMoLa.Text);

                tenKhoi = "Lớp Lá";

                k = khoiLopBUL.layMaKhoiTheoTenKhoi(tenKhoi);
                int soLop = int.Parse(txtSoLopMoLa.Text);
                int siSoTT = int.Parse(txtSiSoToiThieuLa.Text);
                int siSoTD = int.Parse(txtSiSoToiDaLa.Text);
                int tongHS = int.Parse(txtTongHSLa.Text);
                keHoachLa = new KeHoachDTO(txtMaNamHoc.Text, k.MaKhoi, soLop, siSoTT, siSoTD, tongHS);

                if (siSoTT > siSoTD)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    DialogResult r = message.Show("Sỉ số tối đa phải lớn hơn sỉ số tối thiểu", "Thông Báo");

                    return;
                }

                // ktra số lớp của khối cũ năm ngoái (Chồi) <= số lớp mới (Lá)
                if (soLop < soLopChoiCu)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Parent = this.ParentForm;
                    DialogResult r = message.Show("Số lớp Lá phải lớn hơn số lớp Chồi cũ", "Thông Báo");

                    return;
                }

                if (dsLopLa.Count > 0) //Phải reset lại combo Phòng trước khi tạo mới
                {
                    List<string> lstMaPhong = new List<string>();
                    //List<LopHocDTO> dsLopLaCu = dsLopLa;
                    List<LopHocDTO> dsLopLaCu = new List<LopHocDTO>(dsLopLa);

                    //XỬ LÝ ĐỐI VỚI TH SỬA KẾ HOẠCH
                    if (tacVuChinh == "SuaKeHoach") //lưu vào danh sách mã lớp cần xóa trong csdl
                    {
                        // kiểm tra số phòng với số lớp đã tạo
                        if ((dsLopChoi.Count + dsLopNT.Count + dsLopMam.Count + soLop) > soPhongHienCo)
                        {
                            message.Parent = this.ParentForm;
                            message.ShowFail("Số phòng hiện có không đủ để tạo lớp", "Thông báo");

                            return;
                        }

                        if (dsLopLaCu.Count > soLop) //ds cũ > số lg lớp mới sắp mở ==> xóa
                        {
                            //Lấy ra [dsLopLa.Count - số lớp mở] dòng kể từ dsLopLa.Count       
                            for (int i = soLopMo; i < dsLopLaCu.Count; i++)
                            {
                                dsLopSeXoa.Add(dsLopLaCu[i]); //đưa vào ds để qua kia xóa ra csdl
                                lstMaPhong.Add(dsLopLaCu[i].MaPhong); //đưa vào lstMaPhong để nó xóa tên lớp khỏi cbo
                                dsLopLa.Remove(dsLopLaCu[i]); //xóa ra để nó hiện đúng số lớp mới trên dgv
                                loadDataGridView(dsLopLa);

                            }
                        }

                        if (dsLopLaCu.Count < soLop) //Tạo tiếp các lớp bổ sung --> lưu mã mới tạo vào list chờ thêm
                        {

                            string prefix = "L" + k.MaKhoi.Trim().Substring(1, 2) + txtMaNamHoc.Text.Substring(2);
                            for (int i = dsLopLaCu.Count + 1; i <= soLopMo; i++)
                            {
                                // Tạo thêm lớp học mới
                                string maLop = prefix + i.ToString("D3");
                                string tenLop = tenKhoi + " " + i;
                                LopHocDTO lopMoi = new LopHocDTO
                                {
                                    MaLop = maLop,
                                    MaNamHoc = txtMaNamHoc.Text,
                                    MaKhoi = k.MaKhoi,
                                    TenLop = tenLop,
                                    MaPhong = null,
                                    TenPhong = null,
                                };
                                dsLopLa.Add(lopMoi); //thêm vào để nó hiện đúng số lớp mới trên dgv
                                dsLopSeThem.Add(lopMoi); //đưa vào ds để qua kia thêm vào csdl
                                loadDataGridView(dsLopLa);
                                //dgvKeHoach.Rows.Add(maLop, tenLop, null);
                            }
                        }

                    }
                    else
                    {
                        //XỬ LÝ ĐỐI VỚI TH LẬP KẾ HOẠCH
                        foreach (LopHocDTO lh in dsLopLaCu) //lấy ra các mã phòng trong dsNhaTre- sắp bị xóa
                        {
                            if (lh.MaPhong != null)
                            {
                                lstMaPhong.Add(lh.MaPhong); //gôm các mã phòng trong ds cần xóa
                            }
                        }
                    }




                    //XỬ LÝ LẠI MÃ PHÒNG VỀ NGUYÊN BẢN
                    foreach (PhongHocDTO p in dsPhong)//Phòng nào có chứa mã phòng trong ds thì cắt chuỗi về định dạng cũ (lúc chưa có lớp)
                    {
                        foreach (string maPhong in lstMaPhong)
                        {
                            if (p.MaPhong == maPhong)
                            {
                                int index = p.TenPhong.IndexOf('-');
                                if (index >= 0) // Kiểm tra nếu có dấu '-'
                                    p.TenPhong = p.TenPhong.Substring(0, index).Trim(); // Cắt chuỗi từ đầu đến vị trí của dấu '-' và loại bỏ khoảng trắng
                                else
                                    p.TenPhong = p.TenPhong.Trim(); // Không có dấu '-', sử dụng toàn bộ chuỗi
                            }
                        }
                    }


                }
                if (tacVuChinh == "LapKeHoach")
                    themLop(dsLopLa, soLopMo); //mới tạo lớp thì chưa có phòng

                //Gán tác vụ để lưu mã phòng theo đúng khối
                tacVu = "XemKhoiLa";
            }
        }


        private void dgvKeHoach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvKeHoach.Rows[e.RowIndex];
                txtMaLop.Text = selectedRow.Cells["MaLop"].Value.ToString();
                txtTenLop.Text = selectedRow.Cells["TenLop"].Value.ToString();
                loadCboPhongHoc();

                //Enable
                lbLuuy.Text = string.Empty;
                txtViTriPhong.Text = string.Empty;
                txtSucChua.Text = string.Empty;
                txtTinhTrang.Text = string.Empty;
                cboPhongHoc.Text = string.Empty;

                if (tacVuChinh == "XemKeHoach") //nếu là xem kế hoạch thì không
                {
                    cboPhongHoc.Enabled = false;
                    txtTenLop.Enabled = false;
                    btnLuuLop.Enabled = false;
                }
                else
                {
                    cboPhongHoc.Enabled = true;
                    txtTenLop.Enabled = true;
                    btnLuuLop.Enabled = true; //sửa và lập thì đc 
                }

                if (selectedRow.Cells["TenPhong"]?.Value != null)
                {
                    //cboPhongHoc.Text = selectedRow.Cells["TenPhong"].Value.ToString();

                    //Lấy mã phòng theo tên phòng (tên phòng là duy nhất)
                    PhongHocDTO dto = phongHocbUL.layThongTin1PhongHocTheoTenPhong(selectedRow.Cells["TenPhong"].Value.ToString());
                    txtTinhTrang.Text = dto.TinhTrang;
                    txtSucChua.Text = dto.SucChua.ToString();
                    txtViTriPhong.Text = dto.ViTri;
                    cboPhongHoc.SelectedValue = dto.MaPhong;
                }
                else
                {
                    cboPhongHoc.SelectedIndex = -1;
                }
            }
        }

        bool loadXong = false;
        //Lấy ra tất cả phòng học
        private void loadCboPhongHoc()
        {
            cboPhongHoc.DataSource = dsPhong;
            cboPhongHoc.ValueMember = "MaPhong";
            cboPhongHoc.DisplayMember = "TenPhong";
            cboPhongHoc.SelectedIndex = -1;
            loadXong = true;
        }


        void kiemTraSucChuaVoiSiSo(int sucChua, int siSoToiDa)
        {
            if (sucChua <= siSoToiDa)
                lbLuuy.Text = "Cảnh báo: Sức chứa phòng <= sỉ số lớp";
        }
        private void cboPhongHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (loadXong && cboPhongHoc.SelectedIndex >= 0)
            {
                PhongHocDTO dto = phongHocbUL.layThongTin1PhongHoc(cboPhongHoc.SelectedValue.ToString());
                txtTinhTrang.Text = dto.TinhTrang;
                txtSucChua.Text = dto.SucChua.ToString();
                txtViTriPhong.Text = dto.ViTri;

                //Kiểm tra sức chứa so với sỉ số lớp tối đa
                if (tacVu == "XemKhoiNhaTre")
                {
                    kiemTraSucChuaVoiSiSo(dto.SucChua, int.Parse(txtSiSoToiDaTre.Text));
                }

                if (tacVu == "XemKhoiMam")
                {
                    kiemTraSucChuaVoiSiSo(dto.SucChua, int.Parse(txtSiSoToiDaMam.Text));
                }

                if (tacVu == "XemKhoiChoi")
                {
                    kiemTraSucChuaVoiSiSo(dto.SucChua, int.Parse(txtSiSoToiDaChoi.Text));
                }

                if (tacVu == "XemKhoiLa")
                {
                    kiemTraSucChuaVoiSiSo(dto.SucChua, int.Parse(txtSiSoToiDaLa.Text));
                }

                //Enable
                //btnLuuLop.Enabled = true;
            }
            //else
            //{
            //    //Enable
            //    btnLuuLop.Enabled = false;
            //}    
        }


        void loadDataGridView(List<LopHocDTO> lstLopHoc)
        {
            dgvKeHoach.Rows.Clear();
            foreach (LopHocDTO lh in lstLopHoc)
            {
                dgvKeHoach.Rows.Add(lh.MaLop, lh.TenLop, lh.TenPhong); //mã phòng ban đầu là null
            }
        }

        bool capNhatDuLieuTrongDGV(List<LopHocDTO> lstLopHoc)
        {
            string maPhong = cboPhongHoc.SelectedValue.ToString();
            string tenPhong = cboPhongHoc.Text;
            int index = tenPhong.IndexOf('-');
            if (index >= 0) // Kiểm tra nếu có dấu '-'
                tenPhong = tenPhong.Substring(0, index).Trim(); // Cắt chuỗi từ đầu đến vị trí của dấu '-' và loại bỏ khoảng trắng
            else
                tenPhong = tenPhong.Trim(); // Không có dấu '-', sử dụng toàn bộ chuỗi

            string maLop = txtMaLop.Text;
            string tenLop = txtTenLop.Text;

            foreach (LopHocDTO lh in lstLopHoc)
            {
                if (lh.MaLop == maLop)
                {
                    lh.TenLop = tenLop; //gán bằng tên lớp mới
                    string lopCuaPhong = kiemTraPhongHocChuaCoLop(maPhong);
                    if (lopCuaPhong == null) //nếu phòng học này chưa gán cho lớp nào ==> thì gán lớp này = phòng mới
                    {
                        //kiểm tra lớp này đã xếp phòng chưa (trường hợp đang đổi phòng)==> có phòng r thì xóa lớp khỏi phòng đó trên cbo trước
                        if (lh.TenPhong != null) //có phòng rồi
                        {
                            foreach (PhongHocDTO p in dsPhong) //tìm và xóa tên lớp này khỏi phòng này trước
                            {
                                if (p.MaPhong == lh.MaPhong)
                                {
                                    int index2 = p.TenPhong.IndexOf('-');
                                    if (index2 >= 0) // Kiểm tra nếu có dấu '-'
                                        p.TenPhong = p.TenPhong.Substring(0, index2).Trim();
                                    //loadCboPhongHoc();
                                    //cboPhongHoc.SelectedValue = p.MaPhong; //chọn trên combobox
                                    break;
                                }
                            }
                        }


                        lh.TenPhong = tenPhong;
                        lh.MaPhong = maPhong;

                        //Cập nhật lại phần tử trong cbo
                        foreach (PhongHocDTO p in dsPhong)
                        {
                            if (p.MaPhong == cboPhongHoc.SelectedValue.ToString())
                            {
                                p.TenPhong = cboPhongHoc.Text + "-" + txtTenLop.Text;
                                loadCboPhongHoc();
                                cboPhongHoc.SelectedValue = p.MaPhong; //chọn trên combobox
                                break;
                            }
                        }
                    }
                    else //phòng này đã gán cho lớp nào đó rồi
                    {
                        if (lh.MaPhong != maPhong) //và đang ko gán lại cho chính nó
                        {
                            message.Parent = this.ParentForm;
                            message.ShowError("Phòng học này đã được chọn cho lớp " + lopCuaPhong + "", "Thông Báo");
                        }
                    }

                    loadDataGridView(lstLopHoc);
                    return true;
                }

            }
            return false;
        }



        //kiểm tra phòng học này chưa gán cho lớp nào chưa?
        string kiemTraPhongHocChuaCoLop(string maPhong)
        {
            //duyệt qua 4 list, xét maPhong
            foreach (LopHocDTO lopTre in dsLopNT)
            {
                if (lopTre.MaPhong == maPhong)
                {
                    return lopTre.TenLop;
                }
            }
            foreach (LopHocDTO lopMam in dsLopMam)
            {
                if (lopMam.MaPhong == maPhong)
                {
                    return lopMam.TenLop;
                }
            }
            foreach (LopHocDTO lopChoi in dsLopChoi)
            {
                if (lopChoi.MaPhong == maPhong)
                {
                    return lopChoi.TenLop;
                }
            }
            foreach (LopHocDTO lopLa in dsLopLa)
            {
                if (lopLa.MaPhong == maPhong)
                {
                    return lopLa.TenLop;
                }
            }
            return null;
        }

        private void btnLuuLop_Click(object sender, EventArgs e)
        {
            if (cboPhongHoc.SelectedIndex >= 0 && txtMaLop.Text.Length > 0)
            {
                //Nếu cập nhật dữ liệu thành công
                //(tức là kiểm tra phòng chưa được chọn cho lớp nào và cập nhật thành công)

                if (tacVu == "XemKhoiNhaTre")
                    capNhatDuLieuTrongDGV(dsLopNT);
                if (tacVu == "XemKhoiMam")
                    capNhatDuLieuTrongDGV(dsLopMam);
                if (tacVu == "XemKhoiChoi")
                    capNhatDuLieuTrongDGV(dsLopChoi);
                if (tacVu == "XemKhoiLa")
                    capNhatDuLieuTrongDGV(dsLopLa);

                //Enable
                txtMaLop.Text = string.Empty;
                txtTenLop.Text = string.Empty;
                cboPhongHoc.SelectedIndex = -1;
                txtTinhTrang.Text = string.Empty;
                txtSucChua.Text = string.Empty;
                txtViTriPhong.Text = string.Empty;
            }
            else
            {
                message.Parent = this.ParentForm;
                message.ShowError("Hãy chọn 1 phòng học cho lớp tương ứng", "Thông Báo");
            }
        }

        bool kiemTraDaDayDuChua()
        {
            foreach (LopHocDTO lopTre in dsLopNT)
            {
                if (lopTre.MaLop == null || lopTre.TenLop == null || lopTre.TenPhong == null)
                {
                    message.Parent = this.ParentForm;
                    message.ShowError("Thông tin lớp " + lopTre.TenLop + " chưa đầy đủ", "Thông Báo");
                    return false;
                }
            }

            foreach (LopHocDTO lopMam in dsLopMam)
            {
                if (lopMam.MaLop == null || lopMam.TenLop == null || lopMam.TenPhong == null)
                {
                    message.Parent = this.ParentForm;
                    message.ShowError("Thông tin lớp " + lopMam.TenLop + " chưa đầy đủ", "Thông Báo");
                    return false;
                }
            }

            foreach (LopHocDTO lopChoi in dsLopChoi)
            {
                if (lopChoi.MaLop == null || lopChoi.TenLop == null || lopChoi.TenPhong == null)
                {
                    message.Parent = this.ParentForm;
                    message.ShowError("Thông tin lớp " + lopChoi.TenLop + " chưa đầy đủ", "Thông Báo");
                    return false;
                }
            }

            foreach (LopHocDTO lopLa in dsLopLa)
            {
                if (lopLa.MaLop == null || lopLa.TenLop == null || lopLa.TenPhong == null)
                {
                    message.Parent = this.ParentForm;
                    message.ShowError("Thông tin lớp " + lopLa.TenLop + " chưa đầy đủ", "Thông Báo");
                    return false;
                }
            }

            if (txtMaNamHoc.Text.Length == 0 || txtTenNamHoc.Text.Length == 0 || txtTienAn.Text.Length == 0 || txtHocPhi.Text.Length == 0)
            {
                message.Parent = this.ParentForm;
                message.ShowError("Hãy nhập đầy đủ thông tin cho năm học mới", "Thông Báo");
                return false;
            }

            if (dtpNgayKG.Value >= dtpNgayKT.Value)
            {
                message.Parent = this.ParentForm;
                message.ShowError("Thời gian học của năm học không hợp lệ", "Thông Báo");
                return false;
            }

            return true;



        }

        private void btnLuuKeHoach_Click(object sender, EventArgs e)
        {

            if (kiemTraDaDayDuChua())
            {
                if (tacVuChinh == "SuaKeHoach") //Nếu là sửa thì có thể ko ấn nút tạo nên KeHoach chưa có
                {
                    //NT
                    k = khoiLopBUL.layMaKhoiTheoTenKhoi("Nhà Trẻ");
                    keHoachNT = new KeHoachDTO(txtMaNamHoc.Text, k.MaKhoi, int.Parse(txtSoLopMoTre.Text), int.Parse(txtSiSoToiThieuTre.Text), int.Parse(txtSiSoToiDaTre.Text), int.Parse(txtTongHSTre.Text));

                    //Mầm
                    k = khoiLopBUL.layMaKhoiTheoTenKhoi("Lớp Mầm");
                    keHoachMam = new KeHoachDTO(txtMaNamHoc.Text, k.MaKhoi, int.Parse(txtSoLopMoMam.Text), int.Parse(txtSiSoToiThieuMam.Text), int.Parse(txtSiSoToiDaMam.Text), int.Parse(txtTongHSMam.Text));

                    //Chồi
                    k = khoiLopBUL.layMaKhoiTheoTenKhoi("Lớp Chồi");
                    keHoachChoi = new KeHoachDTO(txtMaNamHoc.Text, k.MaKhoi, int.Parse(txtSoLopMoChoi.Text), int.Parse(txtSiSoToiThieuChoi.Text), int.Parse(txtSiSoToiDaChoi.Text), int.Parse(txtTongHSChoi.Text));

                    //Lá
                    k = khoiLopBUL.layMaKhoiTheoTenKhoi("Lớp Lá");
                    keHoachLa = new KeHoachDTO(txtMaNamHoc.Text, k.MaKhoi, int.Parse(txtSoLopMoLa.Text), int.Parse(txtSiSoToiThieuLa.Text), int.Parse(txtSiSoToiDaLa.Text), int.Parse(txtTongHSLa.Text));

                }


                NamHocDTO namHoc = new NamHocDTO
                {
                    MaNamHoc = txtMaNamHoc.Text,
                    TenNamHoc = txtTenNamHoc.Text,
                    NgayDB = dtpNgayKG.Value,
                    NgayKT = dtpNgayKT.Value,
                };

                FrmXacNhanKeHoach frm = new FrmXacNhanKeHoach(dsLopNT, dsLopMam, dsLopChoi, dsLopLa, namHoc,
                    keHoachNT, keHoachMam, keHoachChoi, keHoachLa, grbKhoiNhaTre.Text, grbKhoiLopMam.Text, grbKhoiLopChoi.Text, grbKhoiLopLa.Text,
                    txtHocPhi.Text, txtTienAn.Text, tacVuChinh, dsLopSeThem, dsLopSeXoa); //tacVuChinh xác định là đang thêm mới hay sửa kế hoạch
                frm.ShowDialog();


                if (frm.TacVu == "LuuKeHoach") //Nếu ấn lưu thì về chế độ xem//Nếu ấn hủy thì tiếp tục sửa
                {
                    reset(false);
                    btnXemDSLopNT.Enabled = true;
                    btnXemDSLopMam.Enabled = true;
                    btnXemDSLopChoi.Enabled = true;
                    btnXemDSLopLa.Enabled = true;

                    btnSuaKH.Enabled = true;
                    btnXemKH.Enabled = true;
                    cboTenNH.Enabled = true;
                    btnLamMoi.Enabled = true;

                    cboPhongHoc.SelectedIndex = -1;
                    txtTenLop.Text = string.Empty;
                    txtMaLop.Text = string.Empty;
                    txtViTriPhong.Text = string.Empty;
                    txtSucChua.Text = string.Empty;
                    txtTinhTrang.Text = string.Empty;
                    cboPhongHoc.Text = string.Empty;
                    lbLuuy.Text = string.Empty;

                    loadCboNamHoc();

                    tacVuChinh = "XemKeHoach"; //gán xem kế hoạch để click dgv nó ko cho sửa
                }

            }

        }



        private void kTraNhapKiTuSo(BunifuTextBox textBox)
        {
            string inputText = textBox.Text;
            string filteredText = "";

            foreach (char c in inputText) // Lặp qua từng ký tự và kiểm tra xem có phải là số không
            {
                if (char.IsDigit(c))
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là số
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                message.Parent = this.ParentForm;
                message.ShowError("Chỉ được nhập số!");
                textBox.Text = filteredText;
                textBox.SelectionStart = textBox.Text.Length; // Đặt con trỏ ở cuối
            }
        }


        private void txtSoLopMoTre_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSoLopMoTre);
        }

        private void txtSoLopMoMam_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSoLopMoMam);
        }

        private void txtSoLopMoChoi_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSoLopMoChoi);
        }

        private void txtSoLopMoLa_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSoLopMoLa);
        }

        private void txtSiSoToiThieuTre_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSiSoToiThieuTre);
        }

        private void txtSiSoToiThieuMam_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSiSoToiThieuMam);
        }

        private void txtSiSoToiThieuChoi_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSiSoToiThieuChoi);
        }

        private void txtSiSoToiThieuLa_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSiSoToiThieuLa);
        }

        private void txtSiSoToiDaTre_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSiSoToiDaTre);
        }

        private void txtSiSoToiDaMam_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSiSoToiDaMam);
        }

        private void txtSiSoToiDaChoi_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSiSoToiDaChoi);
        }

        private void txtSiSoToiDaLa_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtSiSoToiDaLa);
        }

        private void txtTongHSTre_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtTongHSTre);
        }

        private void txtTongHSMam_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtTongHSMam);
        }

        private void txtTongHSChoi_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtTongHSChoi);
        }

        private void txtTongHSLa_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtTongHSLa);
        }

        private void dgvKeHoach_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Lấy tọa độ chuột và xác định dòng trong DataGridView
                DataGridView.HitTestInfo hitTestInfo = dgvKeHoach.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvKeHoach.ClearSelection();
                    dgvKeHoach.Rows[hitTestInfo.RowIndex].Selected = true;
                }
            }

            // Tạo ContextMenuStrip
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Xóa phòng học khỏi lớp");
            contextMenu.Items.Add(deleteMenuItem);

            // Gán ContextMenuStrip vào DataGridView
            dgvKeHoach.ContextMenuStrip = contextMenu;

            // Xử lý sự kiện khi click vào item "Xóa học sinh"
            deleteMenuItem.Click += DeleteMenuItem_Click;
        }



        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvKeHoach.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvKeHoach.SelectedRows[0];
                string selectedTenPhong = selectedRow.Cells["TenPhong"]?.Value?.ToString();

                // Thực hiện xóa
                if (tacVu == "XemKhoiNhaTre")
                {
                    foreach (LopHocDTO lopTre in dsLopNT)
                    {
                        if (lopTre.TenPhong == selectedTenPhong)
                        {
                            //Sửa tên phòng đó trong cbo phòng
                            foreach (PhongHocDTO p in dsPhong)
                            {
                                if (p.MaPhong == lopTre.MaPhong)
                                {
                                    //p.TenPhong = cboPhongHoc.Text + "-" + txtTenLop.Text;

                                    int index = p.TenPhong.IndexOf('-');
                                    if (index >= 0) // Kiểm tra nếu có dấu '-'
                                        p.TenPhong = p.TenPhong.Substring(0, index).Trim(); // Cắt chuỗi từ đầu đến vị trí của dấu '-' và loại bỏ khoảng trắng
                                    else
                                        p.TenPhong = p.TenPhong.Trim(); // Không có dấu '-', sử dụng toàn bộ chuỗi

                                    loadCboPhongHoc();
                                    //cboPhongHoc.SelectedValue = p.MaPhong; //chọn trên combobox
                                    break;
                                }
                            }

                            //Xóa phòng khỏi list để mất trên dgv
                            lopTre.TenPhong = null;
                            lopTre.MaPhong = null;

                            //Enable
                            cboPhongHoc.Text = string.Empty;
                            cboPhongHoc.SelectedIndex = -1;
                            txtViTriPhong.Text = string.Empty;
                            txtSucChua.Text = string.Empty;
                            txtTinhTrang.Text = string.Empty;
                            txtTenLop.Text = string.Empty;
                            txtMaLop.Text = string.Empty;
                            cboPhongHoc.Enabled = false;
                            txtTenLop.Enabled = false;
                        }

                    }
                    loadDataGridView(dsLopNT);
                }

                if (tacVu == "XemKhoiMam")
                {
                    foreach (LopHocDTO lopMam in dsLopMam)
                    {
                        if (lopMam.TenPhong == selectedTenPhong)
                        {
                            //Sửa tên phòng đó trong cbo phòng
                            foreach (PhongHocDTO p in dsPhong)
                            {
                                if (p.MaPhong == lopMam.MaPhong)
                                {
                                    //p.TenPhong = cboPhongHoc.Text + "-" + txtTenLop.Text;

                                    int index = p.TenPhong.IndexOf('-');
                                    if (index >= 0) // Kiểm tra nếu có dấu '-'
                                        p.TenPhong = p.TenPhong.Substring(0, index).Trim(); // Cắt chuỗi từ đầu đến vị trí của dấu '-' và loại bỏ khoảng trắng
                                    else
                                        p.TenPhong = p.TenPhong.Trim(); // Không có dấu '-', sử dụng toàn bộ chuỗi

                                    loadCboPhongHoc();
                                    //cboPhongHoc.SelectedValue = p.MaPhong; //chọn trên combobox
                                    break;
                                }
                            }

                            //Xóa phòng khỏi list để mất trên dgv
                            lopMam.TenPhong = null;
                            lopMam.MaPhong = null;

                            //Enable
                            cboPhongHoc.Text = string.Empty;
                            cboPhongHoc.SelectedIndex = -1;
                            txtViTriPhong.Text = string.Empty;
                            txtSucChua.Text = string.Empty;
                            txtTinhTrang.Text = string.Empty;
                            txtTenLop.Text = string.Empty;
                            txtMaLop.Text = string.Empty;
                            cboPhongHoc.Enabled = false;
                            txtTenLop.Enabled = false;
                        }

                    }
                    loadDataGridView(dsLopMam);
                }

                if (tacVu == "XemKhoiChoi")
                {
                    foreach (LopHocDTO lopChoi in dsLopChoi)
                    {
                        if (lopChoi.TenPhong == selectedTenPhong)
                        {
                            //Sửa tên phòng đó trong cbo phòng
                            foreach (PhongHocDTO p in dsPhong)
                            {
                                if (p.MaPhong == lopChoi.MaPhong)
                                {
                                    //p.TenPhong = cboPhongHoc.Text + "-" + txtTenLop.Text;

                                    int index = p.TenPhong.IndexOf('-');
                                    if (index >= 0) // Kiểm tra nếu có dấu '-'
                                        p.TenPhong = p.TenPhong.Substring(0, index).Trim(); // Cắt chuỗi từ đầu đến vị trí của dấu '-' và loại bỏ khoảng trắng
                                    else
                                        p.TenPhong = p.TenPhong.Trim(); // Không có dấu '-', sử dụng toàn bộ chuỗi

                                    loadCboPhongHoc();
                                    //cboPhongHoc.SelectedValue = p.MaPhong; //chọn trên combobox
                                    break;
                                }
                            }

                            //Xóa phòng khỏi list để mất trên dgv
                            lopChoi.TenPhong = null;
                            lopChoi.MaPhong = null;

                            //Enable
                            cboPhongHoc.Text = string.Empty;
                            cboPhongHoc.SelectedIndex = -1;
                            txtViTriPhong.Text = string.Empty;
                            txtSucChua.Text = string.Empty;
                            txtTinhTrang.Text = string.Empty;
                            txtTenLop.Text = string.Empty;
                            txtMaLop.Text = string.Empty;
                            cboPhongHoc.Enabled = false;
                            txtTenLop.Enabled = false;
                        }

                    }
                    loadDataGridView(dsLopChoi);
                }

                if (tacVu == "XemKhoiLa")
                {
                    foreach (LopHocDTO lopLa in dsLopLa)
                    {
                        if (lopLa.TenPhong == selectedTenPhong)
                        {
                            //Sửa tên phòng đó trong cbo phòng
                            foreach (PhongHocDTO p in dsPhong)
                            {
                                if (p.MaPhong == lopLa.MaPhong)
                                {
                                    //p.TenPhong = cboPhongHoc.Text + "-" + txtTenLop.Text;

                                    int index = p.TenPhong.IndexOf('-');
                                    if (index >= 0) // Kiểm tra nếu có dấu '-'
                                        p.TenPhong = p.TenPhong.Substring(0, index).Trim(); // Cắt chuỗi từ đầu đến vị trí của dấu '-' và loại bỏ khoảng trắng
                                    else
                                        p.TenPhong = p.TenPhong.Trim(); // Không có dấu '-', sử dụng toàn bộ chuỗi

                                    loadCboPhongHoc();
                                    //cboPhongHoc.SelectedValue = p.MaPhong; //chọn trên combobox
                                    break;
                                }
                            }

                            //Xóa phòng khỏi list để mất trên dgv
                            lopLa.TenPhong = null;
                            lopLa.MaPhong = null;

                            //Enable
                            cboPhongHoc.Text = string.Empty;
                            cboPhongHoc.SelectedIndex = -1;
                            txtViTriPhong.Text = string.Empty;
                            txtSucChua.Text = string.Empty;
                            txtTinhTrang.Text = string.Empty;
                            txtTenLop.Text = string.Empty;
                            txtMaLop.Text = string.Empty;
                            cboPhongHoc.Enabled = false;
                            txtTenLop.Enabled = false;
                        }
                    }
                    loadDataGridView(dsLopLa);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            resetTextbox();
            reset(false);
            btnXemKH.Enabled = true;
            btn_batdau.Enabled = true;
            AnHienlbSoLopCu(false);
            cboTenNH.Enabled = true;

            dsLopNT.Clear();
            dsLopMam.Clear();
            dsLopChoi.Clear();
            dsLopLa.Clear();

            // năm mới đã có kế hoạch thì ẩn nút lập
            NamHocDTO n = namHocbul.layNamHocMoi();
            if (n.MaNamHoc != null)
            {
                btn_batdau.Enabled = false;
            }

            //txtMaNamHoc.Text = string.Empty;
            //txtTenNamHoc.Text= string.Empty;
            //dtpNgayKG.Text = DateTime.Now.ToString();
            //dtpNgayKT.Text = DateTime.Now.ToString();
            //txtTienAn.Text = string.Empty;
            //txtHocPhi.Text = string.Empty;
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            //Enabled
            reset(true);
            btn_batdau.Enabled = false;
            cboTenNH.Enabled = false;  //Không được xem nữa (trừ khi ấn nút làm mới)
            btnXemKH.Enabled = false;
            btnSuaKH.Enabled = false;

            //Enable
            cboPhongHoc.Text = string.Empty;
            cboPhongHoc.SelectedIndex = -1;
            txtViTriPhong.Text = string.Empty;
            txtSucChua.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;
            txtTenLop.Text = string.Empty;
            txtMaLop.Text = string.Empty;
            cboPhongHoc.Enabled = false;
            btnLuuLop.Enabled = false;
            txtTenLop.Enabled = false;

            AnHienlbSoLopCu(true);

            tacVuChinh = "SuaKeHoach";
        }

        private void txtTienAn_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtTienAn);
        }

        private void txtHocPhi_TextChanged(object sender, EventArgs e)
        {
            kTraNhapKiTuSo(txtHocPhi);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable tbl_DSLop = new DataTable();

            tbl_DSLop.Columns.Add("MaLop", typeof(string));
            tbl_DSLop.Columns.Add("TenLop", typeof(string));
            tbl_DSLop.Columns.Add("TenPhong", typeof(string));

            // Tạo danh sách tổng hợp tất cả các danh sách lớp
            List<List<LopHocDTO>> allClasses = new List<List<LopHocDTO>> { dsLopNT, dsLopMam, dsLopChoi, dsLopLa };

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
            dic.Add("namhoc", txtTenNamHoc.Text);
            dic.Add("namhoccu", tenNHCu);

            string namsinhNT = (int.Parse(DateTime.Now.Year.ToString()) - 1) + ", " + (int.Parse(DateTime.Now.Year.ToString()) - 2);
            dic.Add("namsinhNT", namsinhNT);
            dic.Add("namsinhM", (int.Parse(DateTime.Now.Year.ToString()) - 3).ToString());
            dic.Add("namsinhC", (int.Parse(DateTime.Now.Year.ToString()) - 4).ToString());
            dic.Add("namsinhL", (int.Parse(DateTime.Now.Year.ToString()) - 5).ToString());


            dic.Add("slNTCu", soHsNTCu.ToString());
            dic.Add("slMCu", soHsMCu.ToString());
            dic.Add("slCCu", soHsCCu.ToString());
            dic.Add("slLaCu", soHsLaCu.ToString());
            dic.Add("tongCu", (soHsNTCu + soHsMCu + soHsCCu + soHsLaCu).ToString());

            dic.Add("slNTMoi", txtTongHSTre.Text);
            dic.Add("slMMoi", txtTongHSMam.Text);
            dic.Add("slCMoi", txtTongHSChoi.Text);
            dic.Add("slLaMoi", txtTongHSLa.Text);
            dic.Add("tongMoi", (int.Parse(txtTongHSTre.Text) + int.Parse(txtTongHSMam.Text) + int.Parse(txtTongHSChoi.Text) + int.Parse(txtTongHSLa.Text)).ToString());
            dic.Add("sltuyensinh", (int.Parse(txtTongHSTre.Text) + int.Parse(txtTongHSMam.Text) + int.Parse(txtTongHSChoi.Text) + int.Parse(txtTongHSLa.Text)).ToString());

            dic.Add("tongNT", (soHsNTCu + int.Parse(txtTongHSTre.Text)).ToString());
            dic.Add("tongM", (soHsMCu + int.Parse(txtTongHSMam.Text)).ToString());
            dic.Add("tongC", (soHsCCu + int.Parse(txtTongHSChoi.Text)).ToString());
            dic.Add("tongLa", (soHsLaCu + int.Parse(txtTongHSLa.Text)).ToString());
            dic.Add("tongcong", (soHsNTCu + soHsMCu + soHsCCu + soHsLaCu + int.Parse(txtTongHSTre.Text) + int.Parse(txtTongHSMam.Text) + int.Parse(txtTongHSChoi.Text) + int.Parse(txtTongHSLa.Text)).ToString());

            dic.Add("tongLopMo", (int.Parse(txtSoLopMoTre.Text) + int.Parse(txtSoLopMoMam.Text) + int.Parse(txtSoLopMoChoi.Text) + int.Parse(txtSoLopMoLa.Text)).ToString());
            dic.Add("soLopNT", txtSoLopMoTre.Text);
            dic.Add("soLopMam", txtSoLopMoMam.Text);
            dic.Add("soLopChoi", txtSoLopMoChoi.Text);
            dic.Add("soLopLa", txtSoLopMoLa.Text);

            dic.Add("ssNTToiThieu", txtSiSoToiThieuTre.Text);
            dic.Add("ssNTToiDa", txtSiSoToiDaTre.Text);
            dic.Add("ssMamToiThieu", txtSiSoToiThieuMam.Text);
            dic.Add("ssMamToiDa", txtSiSoToiDaMam.Text);
            dic.Add("ssChoiToiThieu", txtSiSoToiThieuChoi.Text);
            dic.Add("ssChoiToiDa", txtSiSoToiDaChoi.Text);
            dic.Add("ssLaToiThieu", txtSiSoToiThieuLa.Text);
            dic.Add("ssLaToiDa", txtSiSoToiDaLa.Text);

            // Đường dẫn file Template mình để, còn true là mở file word lên
            WordExport wd = new WordExport(Application.StartupPath + "/Template/KeHoach.dotx", true);

            // In các Field
            wd.WriteFields(dic);
            wd.WriteTable(tbl_DSLop, 3);

            MessageBox.Show("Xuất xong!!!");
        }
    }
}
