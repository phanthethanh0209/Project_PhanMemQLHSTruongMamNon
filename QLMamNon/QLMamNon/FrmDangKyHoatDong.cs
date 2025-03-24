using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDangKyHoatDong : Form
    {
        NamHocBUL namHocBUL;
        HoatDongBUL hoatDongBUL;
        KhoiLopBUL khoiLopBUL;
        LopHocBUL lopHocBUL;
        HocSinhBUL hocSinhBUL;
        ThamGiaNgoaiKhoaBUL tgNgoaiKhoaBUL;
        MessageBoxCustome message;
        string maND;
        public FrmDangKyHoatDong(string maND)
        {
            InitializeComponent();
            message = new MessageBoxCustome();

            namHocBUL = new NamHocBUL();
            hoatDongBUL = new HoatDongBUL();
            khoiLopBUL = new KhoiLopBUL();
            lopHocBUL = new LopHocBUL();
            hocSinhBUL = new HocSinhBUL();
            tgNgoaiKhoaBUL = new ThamGiaNgoaiKhoaBUL();
            this.maND = maND;
        }

        bool isLoaded = false;
        bool loadXong = false;
        string maLopDangChon;
        private void FrmThamGiaHoatDong_Load(object sender, System.EventArgs e)
        {
            namHocBUL = new NamHocBUL();
            hoatDongBUL = new HoatDongBUL();
            List<NamHocDTO> dsNamHoc = namHocBUL.layTatCaNamHoc();

            cboNamHoc.DataSource = dsNamHoc;
            cboNamHoc.ValueMember = "MaNamHoc";
            cboNamHoc.DisplayMember = "TenNamHoc";
            isLoaded = true;


            cboTuyChon.Items.Add("Hoạt động sắp diễn ra");
            cboTuyChon.Items.Add("Tất cả hoạt động trong năm");
            cboTuyChon.SelectedIndex = 0;

            NamHocDTO namHocDTO = namHocBUL.layNamHocMoi();
            if (namHocDTO.MaNamHoc != null)
                cboNamHoc.SelectedValue = namHocDTO.MaNamHoc;


            List<HoatDongDTO> dsHoatDong = hoatDongBUL.layTatCaHoatDongSapDienRaTrongNam(cboNamHoc.SelectedValue.ToString());
            loadCboHoatDong(dsHoatDong);
            loadcboTrangThai();

            //Enable
            btnThanhToan.Enabled = false;
            txtTienNhan.Enabled = false;
            //btnIN.Enabled = false;

        }

        void loadcboTrangThai()
        {
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Đã đăng ký");
            cboTrangThai.Items.Add("Chưa đăng ký");
            cboTrangThai.SelectedIndex = 0;
        }

        private TreeNode _previousNode = null;
        private void HighlightSelectedNode(TreeNode node)
        {
            // Đặt lại màu cho node trước
            if (_previousNode != null)
            {
                _previousNode.ForeColor = treeViewDSHocSinh.ForeColor;
            }

            // Đặt màu cho node mới được chọn
            if (node != null)
            {
                node.ForeColor = Color.Blue;
                _previousNode = node;
            }
        }


        void loadTreeView(string maNamHoc)
        {
            // Xóa các node hiện có trong TreeView để tránh chồng chéo khi load lại
            treeViewDSHocSinh.Nodes.Clear();

            // Lấy danh sách khối lớp dựa vào mã năm học
            List<KhoiLopDTO> danhSachKhoiLop = khoiLopBUL.layKhoiLopTrongNam(maNamHoc);

            foreach (KhoiLopDTO khoiLop in danhSachKhoiLop)
            {
                // Tạo một node cấp 1 cho từng khối lớp
                TreeNode nodeKhoi = new TreeNode(khoiLop.TenKhoi); // hoặc tùy vào tên thuộc tính của khối lớp
                nodeKhoi.Tag = khoiLop.MaKhoi; // Lưu mã khối vào Tag để dễ truy xuất

                // Lấy danh sách lớp học dựa vào mã khối và năm học
                List<LopHocDTO> danhSachLopHoc = lopHocBUL.layLopHocTheoKeHoach(khoiLop.MaKhoi, maNamHoc);

                foreach (LopHocDTO lopHoc in danhSachLopHoc)
                {
                    // Tạo một node cấp 2 cho từng lớp học trong khối
                    TreeNode nodeLop = new TreeNode(lopHoc.TenLop); // hoặc tùy vào tên thuộc tính của lớp học
                    nodeLop.Tag = lopHoc.MaLop; // Lưu mã lớp vào Tag

                    // Thêm node lớp vào node khối
                    nodeKhoi.Nodes.Add(nodeLop);
                }

                // Thêm node khối vào TreeView
                treeViewDSHocSinh.Nodes.Add(nodeKhoi);
            }

            // Mở rộng TreeView để hiển thị tất cả các node
            treeViewDSHocSinh.ExpandAll();
        }


        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                maLopDangChon = null;

                dgvDSHS.DataSource = null;
                dgvDSHS.Rows.Clear();

                lbKhoiLop.Text = "...";
                lbLopHoc.Text = "...";
                txtTienNhan.Text = "";
                lbMaThanhToan.Text = "";
                lbMaHS.Text = "";
                lbTenHS.Text = "";
                lbTenHD.Text = "";
                lbNgayDK.Text = "";
                lbTongTien.Text = "";
                lbTienThua.Text = "";
                //btnIN.Enabled = false;


                NamHocDTO namHocDTO = namHocBUL.layNamHocMoi();
                if (namHocDTO.MaNamHoc != null && cboNamHoc.SelectedValue.ToString() != namHocDTO.MaNamHoc.ToString()) //năm hiện tại
                {
                    cboTuyChon.SelectedIndex = 1;
                    cboTuyChon.Enabled = false;

                    loadXong = false;
                    List<HoatDongDTO> dsHoatDong = hoatDongBUL.layTatCaHoatDongTrongNam(cboNamHoc.SelectedValue.ToString());
                    loadCboHoatDong(dsHoatDong);
                }
                else
                {
                    cboTuyChon.SelectedIndex = 0;
                    cboTuyChon.Enabled = true;

                    loadXong = false;
                    List<HoatDongDTO> dsHoatDong = hoatDongBUL.layTatCaHoatDongSapDienRaTrongNam(cboNamHoc.SelectedValue.ToString());
                    loadCboHoatDong(dsHoatDong);
                }

                loadTreeView(cboNamHoc.SelectedValue.ToString());


            }
        }

        void loadDGV()
        {
            if (ktraDaDuThongTin())
            {
                dgvDSHS.AutoGenerateColumns = false;
                dgvDSHS.AllowUserToAddRows = false;

                if (dgvDSHS.RowCount > 0)
                    dgvDSHS.Rows.Clear();

                List<ThamGiaNgoaiKhoaDTO> tgNgoaiKhoa = tgNgoaiKhoaBUL.layDSHSThamGiaNgoaiKhoaTheoTrangThaiDK(cboTrangThai.Text, cboHoatDong.SelectedValue.ToString(), maLopDangChon);

                foreach (ThamGiaNgoaiKhoaDTO thamGia in tgNgoaiKhoa)
                {
                    int rowIndex = dgvDSHS.Rows.Add();
                    DataGridViewRow row = dgvDSHS.Rows[rowIndex];

                    row.Cells["MaHS"].Value = thamGia.MaHS;
                    row.Cells["HoTen"].Value = thamGia.HoTen;

                    if (!string.IsNullOrEmpty(thamGia.MaHD))
                    {
                        row.Cells["TrangThai"].Value = "Đã đăng ký";
                    }
                    else
                    {
                        row.Cells["TrangThai"].Value = "Chưa đăng ký";
                    }
                }
            }

        }
        private void treeViewDSHocSinh_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (dgvDSHS.Rows.Count > 0)
            {
                dgvDSHS.DataSource = null;
                dgvDSHS.Rows.Clear();
            }

            lbKhoiLop.Text = "...";
            lbLopHoc.Text = "...";
            txtTienNhan.Text = "";
            lbMaThanhToan.Text = "";
            lbMaHS.Text = "";
            lbTenHS.Text = "";
            lbTenHD.Text = "";
            lbNgayDK.Text = "";
            lbTongTien.Text = "";
            lbTienThua.Text = "";
            //btnIN.Enabled = false;

            // Kiểm tra nếu node được click là node cấp 2 (lớp) không có node con
            if (e.Node.Level == 1 && e.Node.Nodes.Count == 0)
            {
                maLopDangChon = e.Node.Tag.ToString();

                //Lấy thông tin lớp học
                LopHocDTO lopHoc = lopHocBUL.getLopHocTheoMa(maLopDangChon);
                lbKhoiLop.Text = e.Node.Parent.Text;
                lbLopHoc.Text = lopHoc.TenLop;

                if (cboHoatDong.SelectedIndex >= 0)
                {
                    //Hiên thị thông tin hoạt động
                    lbSoHsToanTruong.Text = tgNgoaiKhoaBUL.demSoHSThamGiaToanTruong(cboHoatDong.SelectedValue.ToString()).ToString();
                    HoatDongDTO hoatDongDTO = hoatDongBUL.layThongTinMotHoatDong(cboHoatDong.SelectedValue.ToString());
                    lbNgayTG.Text = hoatDongDTO.NgayTG.ToString("dd/MM/yyyy");
                    if (hoatDongDTO.TrangThaiDK == "Đã hết hạn đăng ký")
                    {
                        lbTinhTrangHD.Text = "Hoạt động đã dừng thu phí";
                    }
                    else
                    {
                        lbTinhTrangHD.Text = "Hoạt động còn thu phí";
                    }

                    if (maLopDangChon != null)
                    {
                        int sl = tgNgoaiKhoaBUL.demSoHSThamGiaHD(maLopDangChon, cboHoatDong.SelectedValue.ToString());
                        if (sl > 0)
                            lbSoLuongDK.Text = sl.ToString();
                        else
                            lbSoLuongDK.Text = "0";
                    }

                    if (hoatDongDTO.TrangThaiDK == "Đã hết hạn đăng ký" || hoatDongDTO.NgayTG <= DateTime.Now)
                    {
                        btnThanhToan.Enabled = false;
                        txtTienNhan.Enabled = false;
                    }

                    //Lấy danh sách học sinh của lớp đó
                    loadDGV();
                }


                //ẨN HIỆN
                //btnPhanCong.Enabled = true;
            }
            else
            {
                //btnPhanCong.Enabled = false;
            }
        }

        private void loadCboHoatDong(List<HoatDongDTO> dsHoatDong)
        {
            cboHoatDong.DataSource = dsHoatDong;
            cboHoatDong.ValueMember = "MaHD";
            cboHoatDong.DisplayMember = "TenHDNK";

            loadXong = true;
            cboHoatDong.SelectedIndex = -1;
        }


        private void dgvDSHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDSHS.Rows[e.RowIndex];
                lbMaThanhToan.Text = tgNgoaiKhoaBUL.TaoMaThanhToanHD(cboHoatDong.SelectedValue.ToString(), row.Cells["MaHS"].Value?.ToString());
                lbMaHS.Text = row.Cells["MaHS"].Value?.ToString();
                lbTenHS.Text = row.Cells["HoTen"].Value?.ToString();
                lbTenHD.Text = cboHoatDong.Text.ToString();
                lbNgayDK.Text = DateTime.Now.ToString();

                HoatDongDTO hoatDongDTO = hoatDongBUL.layThongTinMotHoatDong(cboHoatDong.SelectedValue.ToString());
                lbTongTien.Text = hoatDongDTO.SoTien.ToString();


                ThamGiaNgoaiKhoaDTO tgnk = tgNgoaiKhoaBUL.layThongTinThamGiaHoatDongCua1HS(lbMaHS.Text, cboHoatDong.SelectedValue.ToString());
                NamHocDTO namHocDTO = namHocBUL.layNamHocMoi();
                //if (namHocDTO != null)
                //{
                if (namHocDTO.MaNamHoc != null && cboNamHoc.SelectedValue.ToString() != namHocDTO.MaNamHoc.ToString()) //năm cu
                {
                    if (tgnk != null)
                    {
                        txtTienNhan.Text = tgnk.TienNhan.ToString() ?? string.Empty;
                        lbTienThua.Text = (double.Parse(txtTienNhan.Text) - double.Parse(lbTongTien.Text)).ToString();
                        //btnIN.Enabled = true;
                    }
                    else
                    {
                        txtTienNhan.Text = "";
                        lbMaThanhToan.Text = "";
                        lbMaHS.Text = "";
                        lbTenHS.Text = "";
                        lbTenHD.Text = "";
                        lbNgayDK.Text = "";
                        lbTongTien.Text = "";
                        lbTienThua.Text = "";
                        //btnIN.Enabled = false;

                    }


                    //Enable
                    btnThanhToan.Enabled = false;
                    txtTienNhan.Enabled = false;
                }





                else // năm namw hiejen tai
                {
                    if (tgnk != null) //đã thanh toán
                    {
                        txtTienNhan.Text = tgnk.TienNhan.ToString();
                        lbTienThua.Text = (double.Parse(txtTienNhan.Text) - double.Parse(lbTongTien.Text)).ToString();

                        //Enable
                        btnThanhToan.Enabled = false;
                        txtTienNhan.Enabled = false;
                        // btnIN.Enabled = true;
                    }
                    else
                    {
                        //Enable
                        btnThanhToan.Enabled = true;
                        txtTienNhan.Enabled = true;
                        txtTienNhan.Text = "";
                        lbTienThua.Text = "";
                        //btnIN.Enabled = false;
                    }


                }
                //}
            }
        }

        bool kiemTraThanhToan()
        {
            if (double.Parse(txtTienNhan.Text) < double.Parse(lbTongTien.Text))
            {
                message.ShowError("Số tiền không hợp lệ", "Lỗi");
                return false;
            }
            return true;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTienNhan.Text))
            {
                message.Parent = this.ParentForm;
                message.ShowError("Vui lòng nhập vào tiền nhận!", "Thông báo");
                return;
            }

            message.Parent = this.ParentForm;
            DialogResult r = message.ShowQuestion("Bạn có muốn thanh toán không?", "Xác nhận thanh toán");
            if (r == DialogResult.Yes && kiemTraThanhToan())
            {
                ThamGiaNgoaiKhoaDTO tgnk = new ThamGiaNgoaiKhoaDTO(lbMaThanhToan.Text, DateTime.Parse(lbNgayDK.Text), cboHoatDong.SelectedValue.ToString(), lbMaHS.Text, lbTenHS.Text, double.Parse(txtTienNhan.Text), maND);
                if (tgNgoaiKhoaBUL.Insert(tgnk))
                {
                    message.Parent = this.ParentForm;
                    message.ShowSuccess("Thanh toán thành công");
                    btnThanhToan.Enabled = false;
                    txtTienNhan.Enabled = false;
                    int sl = tgNgoaiKhoaBUL.demSoHSThamGiaHD(maLopDangChon, cboHoatDong.SelectedValue.ToString());
                    lbSoLuongDK.Text = sl.ToString();

                    int slToanTruong = tgNgoaiKhoaBUL.demSoHSThamGiaToanTruong(cboHoatDong.SelectedValue.ToString());
                    lbSoHsToanTruong.Text = slToanTruong.ToString();
                    loadDGV();

                    //btnIN.Enabled = true;

                }
                else
                {
                    message.Parent = this.ParentForm;
                    message.ShowFail("Thanh toán thất bại");

                }
            }

        }

        private void txtTienNhan_TextChanged(object sender, EventArgs e)
        {

            string inputText = txtTienNhan.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là số không
            foreach (char c in inputText)
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
                message.ShowError("Tiền nhận không nhập kí tự khác số!");

                txtTienNhan.Text = filteredText;
                txtTienNhan.SelectionStart = txtTienNhan.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtTienNhan.Text = filteredText; // Chỉ giữ lại ký tự số
            }


            if (double.TryParse(txtTienNhan.Text, out _) && double.Parse(txtTienNhan.Text) >= double.Parse(lbTongTien.Text))
                lbTienThua.Text = (double.Parse(txtTienNhan.Text) - double.Parse(lbTongTien.Text)).ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            dgvDSHS.AutoGenerateColumns = false;
            dgvDSHS.AllowUserToAddRows = false;

            //Lấy ra danh sách học sinh của lớp kèm tham gia ngoại khóa
            if (cboHoatDong.SelectedIndex == -1)
            {
                message.Parent = this.ParentForm;
                message.ShowWarning("Hãy chọn hoạt động"); return;

            }

            List<ThamGiaNgoaiKhoaDTO> tgNgoaiKhoa = tgNgoaiKhoaBUL.timKiemHocSinhTheoMaHoacTen(txtTimKiem.Text, cboHoatDong.SelectedValue.ToString(), maLopDangChon);

            if (dgvDSHS.RowCount > 0)
                dgvDSHS.Rows.Clear();

            foreach (ThamGiaNgoaiKhoaDTO thamGia in tgNgoaiKhoa)
            {
                int rowIndex = dgvDSHS.Rows.Add();
                DataGridViewRow row = dgvDSHS.Rows[rowIndex];

                row.Cells["MaHS"].Value = thamGia.MaHS;
                row.Cells["HoTen"].Value = thamGia.HoTen;

                if (!string.IsNullOrEmpty(thamGia.MaHD))
                {
                    row.Cells["TrangThai"].Value = "Đã đăng ký";
                }
                else
                {
                    row.Cells["TrangThai"].Value = "Chưa đăng ký";
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            loadDGV();
        }

        bool ktraDaDuThongTin()
        {
            if (cboHoatDong.SelectedIndex == -1)
            {
                return false;
            }
            if (maLopDangChon == null)
            {
                return false;
            }

            return true;
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void cboHoatDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadXong && cboHoatDong.SelectedIndex >= 0 && maLopDangChon != null)
            {
                txtTienNhan.Text = "";
                lbMaThanhToan.Text = "";
                lbMaHS.Text = "";
                lbTenHS.Text = "";
                lbTenHD.Text = "";
                lbNgayDK.Text = "";
                lbTongTien.Text = "";
                lbTienThua.Text = "";
                //btnIN.Enabled = false;


                loadDGV();

                //Hiên thị thông tin hoạt động
                lbSoHsToanTruong.Text = tgNgoaiKhoaBUL.demSoHSThamGiaToanTruong(cboHoatDong.SelectedValue.ToString()).ToString();
                HoatDongDTO hoatDongDTO = hoatDongBUL.layThongTinMotHoatDong(cboHoatDong.SelectedValue.ToString());
                lbNgayTG.Text = hoatDongDTO.NgayTG.ToString("dd/MM/yyyy");
                if (hoatDongDTO.TrangThaiDK == "Đã hết hạn đăng ký")
                {
                    lbTinhTrangHD.Text = "Hoạt động đã dừng thu phí";
                }
                else
                {
                    lbTinhTrangHD.Text = "Hoạt động còn thu phí";
                }

                if (maLopDangChon != null)
                {
                    int sl = tgNgoaiKhoaBUL.demSoHSThamGiaHD(maLopDangChon, cboHoatDong.SelectedValue.ToString());
                    if (sl > 0)
                        lbSoLuongDK.Text = sl.ToString();
                    else
                        lbSoLuongDK.Text = "0";
                }

                if (hoatDongDTO.TrangThaiDK == "Đã hết hạn đăng ký" || hoatDongDTO.NgayTG <= DateTime.Now)
                {
                    btnThanhToan.Enabled = false;
                    txtTienNhan.Enabled = false;
                }
            }
            else
            {
                lbSoHsToanTruong.Text = "";
                lbNgayTG.Text = "";
                lbTinhTrangHD.Text = "";
                lbSoLuongDK.Text = "";
                if (dgvDSHS.RowCount > 0)
                    dgvDSHS.Rows.Clear();
            }
        }

        private void bunifuGroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cboTuyChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDSHS.RowCount > 0)
            {
                dgvDSHS.Rows.Clear();
            }

            if (cboTuyChon.SelectedIndex == 0)
            {
                List<HoatDongDTO> dsHoatDong = hoatDongBUL.layTatCaHoatDongSapDienRaTrongNam(cboNamHoc.SelectedValue.ToString());
                loadCboHoatDong(dsHoatDong);
            }
            else
            {
                List<HoatDongDTO> dsHoatDong = hoatDongBUL.layTatCaHoatDongTrongNam(cboNamHoc.SelectedValue.ToString());
                loadCboHoatDong(dsHoatDong);
            }

        }

        private void treeViewDSHocSinh_AfterSelect(object sender, TreeViewEventArgs e)
        {
            HighlightSelectedNode(e.Node);
        }

        private void btnIN_Click(object sender, EventArgs e)
        {

        }
    }
}
