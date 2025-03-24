using BUL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDanhGia : Form
    {
        string maND;
        public FrmDanhGia(string maND)
        {
            InitializeComponent();
            this.maND = maND;
        }

        NamHocBUL namHocBUL;
        KhoiLopBUL khoiLopBUL;
        LopHocBUL lopHocBUL;
        PhanCongBUL phanCongBUL;
        HocSinhBUL hocSinhBUL;
        DanhGiaTuanBUL danhGiaTuanBUL;
        NamHocDTO nam;
        string maLop;
        string tacVu = "xem";
        string maDG;
        Guna2MessageDialog message;

        private void ckChon_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {

        }

        private void FrmDanhGia_Load(object sender, System.EventArgs e)
        {
            message = new Guna2MessageDialog
            {
                Style = MessageDialogStyle.Light,
            };

            namHocBUL = new NamHocBUL();
            khoiLopBUL = new KhoiLopBUL();
            lopHocBUL = new LopHocBUL();
            phanCongBUL = new PhanCongBUL();
            hocSinhBUL = new HocSinhBUL();
            danhGiaTuanBUL = new DanhGiaTuanBUL();

            btnLuu.Enabled = false;
            btnHuy.Enabled = true;
            btnDG.Enabled = false;
            btnSua.Enabled = false;

            txtNoiDung.Multiline = true;        // Cho phép nhập nhiều dòng
            txtNoiDung.ScrollBars = ScrollBars.Vertical; // Hiển thị thanh cuộn dọc
            txtNoiDung.WordWrap = true;
            txtNoiDung.Enabled = false;
            ckChon.Enabled = false;


            string namHoc = DateTime.Now.Year.ToString();
            nam = namHocBUL.layNamHocMoi();
            if (nam != null)
                lbNamHoc.Text = nam.TenNamHoc;

            string maGV = maND;
            PhanCongDTO p = phanCongBUL.layLopGVDayTrongNamHT(maGV, nam.MaNamHoc);
            maLop = p.MaLop;

            // lấy tên khối
            LopHocDTO lop = lopHocBUL.getLopHocTheoMa(p.MaLop);
            KhoiLopDTO k = khoiLopBUL.layTenKhoiTheoMa(lop.MaKhoi);
            lbTenKhoi.Text = k.TenKhoi;
            lbTenLop.Text = lop.TenLop;

            loadTreeView();

            loadCboThang();
            loadCboTuan();
            UploadHinh("Upload\\Images\\phieuBeChuaNgoan.jpg", lbHinh);

            int thangHienTai = DateTime.Now.Month;
            cboThang.SelectedIndex = thangHienTai - 1;
            DanhGiaTuanDTO dg = danhGiaTuanBUL.layTuanDanhGiaMoi(maLop, thangHienTai);
            int tuan = dg.Tuan == null ? 1 : dg.Tuan + 1;
            cboTuan.SelectedIndex = tuan >= 4 ? 3 : tuan - 1;
        }

        void loadCboThang()
        {
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add("Tháng " + i);
            }
        }

        void loadCboTuan()
        {
            for (int i = 1; i <= 4; i++)
            {
                cboTuan.Items.Add("Tuần " + i);
            }
        }

        int thang = 0; int tuan = 0;
        void loadTreeView()
        {
            treeViewDSHocSinh.Nodes.Clear();
            thang = cboThang.SelectedIndex + 1;
            tuan = cboTuan.SelectedIndex + 1;

            // Tạo một node cấp 1 
            TreeNode nodeLop = new TreeNode(lbTenLop.Text);
            //nodeLop.Tag = khoiLop.MaKhoi;

            // Lấy danh sách học sinh dựa vào mã lớp
            if (maLop != null)
            {
                List<HocSinhDTO> danhSachHocSinh = hocSinhBUL.layTatCaHocSinhTheoMaLop(maLop);

                foreach (HocSinhDTO hocSinh in danhSachHocSinh)
                {
                    // Tạo một node cấp 2
                    TreeNode nodeHS = new TreeNode(hocSinh.HoTen);
                    nodeHS.Tag = hocSinh.MaHS;

                    List<DanhGiaTuanDTO> dsHSDaDG = danhGiaTuanBUL.layDSHSDaDanhGia(maLop, thang, tuan);
                    foreach (DanhGiaTuanDTO hs in dsHSDaDG)
                    {
                        if (hocSinh.MaHS == hs.MaHS)
                            nodeHS.ForeColor = Color.Gray;
                    }
                    // Thêm node lớp vào node khối
                    nodeLop.Nodes.Add(nodeHS);
                }

                // Thêm node lớp vào TreeView
                treeViewDSHocSinh.Nodes.Add(nodeLop);

                // Mở rộng TreeView để hiển thị tất cả các node
                treeViewDSHocSinh.ExpandAll();
            }

        }

        private void treeViewDSHocSinh_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            lbMaHS.Text = "";
            lbTenHS.Text = "";
            txtNoiDung.Text = "";
            ckChon.Checked = false;
            ckChon.Enabled = false;
            txtNoiDung.Enabled = false;

            // Kiểm tra nếu node được click là node cấp 2 (lớp) không có node con
            if (e.Node.Level == 1 && e.Node.Nodes.Count == 0 && cboTuan.SelectedIndex != -1)
            {
                lbMaHS.Text = e.Node.Tag.ToString();
                lbTenHS.Text = e.Node.Text.ToString();
                cboThang.Enabled = false;
                cboTuan.Enabled = false;



                if (e.Node.ForeColor == Color.Gray) //Đã đánh giá rồi
                {
                    DanhGiaTuanDTO danhGia = danhGiaTuanBUL.layThongTinDanhGiaTuanCua1HS(maLop, lbMaHS.Text, tuan, thang);
                    txtNoiDung.Text = danhGia.NoiDung;
                    ckChon.Checked = danhGia.DatPhieuBeNgoan == 1 ? true : false;
                    lbNgayDG.Text = danhGia.NgayDG.ToString();
                    maDG = danhGia.MaDanhGiaTuan;
                    if (ckChon.Checked)
                        UploadHinh("Upload\\Images\\phieuBeNgoan.jpg", lbHinh);

                    btnDG.Enabled = false;
                    btnLuu.Enabled = false;

                    if (danhGiaTuanBUL.kiemTraDanhGia3Ngay(maLop, lbMaHS.Text, thang, tuan)) //Được sửa
                    {
                        btnSua.Enabled = true;
                    }
                    else
                    {
                        btnSua.Enabled = false;
                    }
                }
                else //Chưa đánh giá
                {
                    int thang = cboThang.SelectedIndex + 1;
                    int tuanMoi = cboTuan.SelectedIndex + 1;
                    lbNgayDG.Text = DateTime.Now.ToString();
                    maDG = danhGiaTuanBUL.TaoMaDanhGiaTuan(thang, tuanMoi, nam.MaNamHoc, lbMaHS.Text);
                    btnDG.Enabled = true;
                    btnLuu.Enabled = false;
                    btnSua.Enabled = false;
                    resetHinh();
                }
            }
            else
            {
                //btnTao.Enabled = false;
                MessageBox.Show("Vui lòng chọn thời gian đánh giá", "Thông Báo");
            }
        }

        bool kiemTraHopLe()
        {
            if (maDG == null)
            {
                MessageBox.Show("Mã đánh giá chưa có", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (lbNgayDG.Text.Length == 0)
            {
                MessageBox.Show("Ngày đánh giá chưa có", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (maLop == null)
            {
                MessageBox.Show("Chưa có lớp học", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (lbMaHS.Text.Length == 0)
            {
                MessageBox.Show("Chưa chọn học sinh", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (cboTuan.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn tuần", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }

            if (cboThang.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn tháng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }

            if (txtNoiDung.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập nội dung", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult r = CustomMessageBox.Show(this.ParentForm, "Bạn có chắc chắn muốn lưu đánh giá ?", "Xác nhận", MessageDialogIcon.Question, MessageDialogButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                int thang = cboThang.SelectedIndex + 1;
                int tuan = cboTuan.SelectedIndex + 1;
                int datPhieu = ckChon.Checked ? 1 : 0;
                DanhGiaTuanDTO danhGia = new DanhGiaTuanDTO(maDG, maLop, lbMaHS.Text, tuan, thang, datPhieu, txtNoiDung.Text, DateTime.Parse(lbNgayDG.Text)); //mốt xem lại

                if (kiemTraHopLe() && tacVu == "them")
                {

                    if (danhGiaTuanBUL.Insert(danhGia))
                    {
                        //MessageBox.Show("Đánh giá thành công");
                        message.Buttons = MessageDialogButtons.OK;
                        message.Icon = MessageDialogIcon.Information;
                        message.Parent = this.ParentForm;
                        message.Show("Đánh giá thành công", "Thông Báo");

                        lbNgayDG.Text = "";
                        txtNoiDung.Text = string.Empty;
                        txtNoiDung.Enabled = false;
                        ckChon.Checked = false;
                        ckChon.Enabled = false;
                        lbMaHS.Text = "";
                        lbTenHS.Text = "";
                        btnLuu.Enabled = false;
                        loadTreeView();
                        resetHinh();
                    }
                    else
                    {
                        //MessageBox.Show("Đánh giá thất bại");
                        message.Buttons = MessageDialogButtons.OK;
                        message.Icon = MessageDialogIcon.Error;
                        message.Parent = this.ParentForm;
                        message.Show("Đánh giá thất bại", "Thông Báo");
                    }
                }
                else if (kiemTraHopLe() && tacVu == "sua")
                {
                    if (danhGiaTuanBUL.Update(danhGia))
                    {
                        //MessageBox.Show("Cập nhật đánh giá thành công");
                        message.Buttons = MessageDialogButtons.OK;
                        message.Icon = MessageDialogIcon.Information;
                        message.Parent = this.ParentForm;
                        message.Show("Cập nhật đánh giá thành công", "Thông Báo");

                        lbNgayDG.Text = "";
                        txtNoiDung.Text = string.Empty;
                        txtNoiDung.Enabled = false;
                        ckChon.Checked = false;
                        ckChon.Enabled = false;
                        btnLuu.Enabled = false;
                        lbMaHS.Text = "";
                        lbTenHS.Text = "";
                        loadTreeView();
                        resetHinh();
                    }
                    else
                    {
                        //MessageBox.Show("Cập nhật đánh giá thất bại");
                        message.Buttons = MessageDialogButtons.OK;
                        message.Icon = MessageDialogIcon.Error;
                        message.Parent = this.ParentForm;
                        message.Show("Cập nhật đánh giá thất bại", "Thông Báo");
                    }
                }

            }
        }

        private void cboTuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (maLop != null)
            {
                int tuanChon = int.Parse(cboTuan.SelectedIndex.ToString()) + 1;
                int tuanMax = danhGiaTuanBUL.layTuanDGGanNhatCuaThang(maLop, DateTime.Now.Month); //tuần đánh giá gần nhất của tháng hiện tại 
                if (tuanChon > tuanMax + 1)
                {
                    MessageBox.Show("Bạn chưa thể đánh giá tuần sau", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    btnDG.Enabled = false;
                    btnLuu.Enabled = false;
                    btnSua.Enabled = false;
                    cboTuan.Enabled = false;
                    cboTuan.SelectedIndex = -1;
                    txtNoiDung.Text = string.Empty;
                    ckChon.Checked = false;
                }
                else
                {
                    loadTreeView();
                    int thang = cboThang.SelectedIndex + 1;
                    int tuan = cboTuan.SelectedIndex + 1;
                }


                //loadTreeView();
                //int thang = cboThang.SelectedIndex + 1;
                //int tuan = cboTuan.SelectedIndex + 1;
            }


        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTuan.Enabled = true;
            cboTuan.SelectedIndex = -1;

            if (int.Parse(cboThang.SelectedIndex.ToString()) + 1 > int.Parse(DateTime.Now.Month.ToString()))
            {
                MessageBox.Show("Bạn chưa thể đánh giá tháng sau", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                btnDG.Enabled = false;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                cboTuan.Enabled = false;
                cboTuan.SelectedIndex = -1;
                btnHuy.Enabled = true;
                txtNoiDung.Text = string.Empty;
                ckChon.Checked = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //btnTao.Enabled = true;
            lbNgayDG.Text = string.Empty;
            lbMaHS.Text = string.Empty;
            lbTenHS.Text = string.Empty;
            cboThang.SelectedIndex = -1;
            cboTuan.SelectedIndex = -1;
            txtNoiDung.Text = string.Empty;
            txtNoiDung.Enabled = false;
            ckChon.Checked = false;
            ckChon.Enabled = false;
            cboThang.Enabled = true;
            cboTuan.Enabled = false;



            btnLuu.Enabled = false;

            btnDG.Enabled = false;
            btnSua.Enabled = false;
            resetHinh();
        }

        // Hàm để upload và hiển thị hình ảnh
        void UploadHinh(string hinh, Guna2PictureBox lbHinh)
        {
            try
            {
                // Tạo đối tượng Image từ file hình ảnh
                Image selectedImage = Image.FromFile(hinh);

                lbHinh.Image = selectedImage;

                lbHinh.Image = new Bitmap(selectedImage, new Size(lbHinh.Width, lbHinh.Height));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị hình ảnh: " + ex.Message);
            }
        }

        void resetHinh()
        {
            UploadHinh("Upload\\Images\\phieuBeChuaNgoan.jpg", lbHinh);
        }

        private void ckChon_CheckedChanged_1(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            resetHinh();
            if (ckChon.Checked)
            {
                UploadHinh("Upload\\Images\\phieuBeNgoan.jpg", lbHinh);
            }
        }

        private void btnDG_Click(object sender, EventArgs e)
        {
            tacVu = "them";
            lbNgayDG.Text = DateTime.Now.ToString();
            btnDG.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnSua.Enabled = false;
            txtNoiDung.Enabled = true;
            txtNoiDung.Clear();
            ckChon.Checked = false;
            ckChon.Enabled = true;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tacVu = "sua";
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnDG.Enabled = false;
            txtNoiDung.Enabled = true;
            ckChon.Enabled = true;

        }

        private void ckChon_CheckedChanged_1(object sender, EventArgs e)
        {
            resetHinh();
            if (ckChon.Checked)
            {
                UploadHinh("Upload\\Images\\phieuBeNgoan.jpg", lbHinh);
            }
        }
    }
}
