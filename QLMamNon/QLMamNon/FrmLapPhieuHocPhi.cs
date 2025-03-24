using BUL;
using DTO;
using QLMamNon.Reports;

//using QLMamNon.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Transactions;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmLapPhieuHocPhi : Form
    {
        NamHocBUL namHocBUL;
        KhoanThuBUL ktBUL;
        KhoiLopBUL khoiBUL;
        LopHocBUL lopBUL;
        PhanLopBUL phanLopBUL;
        PhieuHocPhiBUL phpBUL;
        DiemDanhBUL diemDanhBUL;
        HocSinhBUL hocSinhBUL;
        CTPhieuHocPhiBUL ctPHPBUL;


        // string maNH;
        string maNamHienTai;
        string maNamHocDangChon;
        string maNamHoc;
        int thangDangChon;
        string tacVu = "Xem";

        bool loadXong = false;
        string tenND;
        public FrmLapPhieuHocPhi(string tentk)
        {
            InitializeComponent();
            tenND = tentk;

            namHocBUL = new NamHocBUL();
            ktBUL = new KhoanThuBUL();
            khoiBUL = new KhoiLopBUL();
            lopBUL = new LopHocBUL();
            phpBUL = new PhieuHocPhiBUL();
            phanLopBUL = new PhanLopBUL();
            diemDanhBUL = new DiemDanhBUL();
            hocSinhBUL = new HocSinhBUL();
            ctPHPBUL = new CTPhieuHocPhiBUL();
        }

        private void FrmThemKhoanThu_Load(object sender, EventArgs e)
        {
            loadCboNamHoc();

            chonNamHienTai();

            loadCboThang();

            chonThangHienTai();

            //Enable
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtSoBuoiHoc.Enabled = false;
            //ktraDaLapPhieuHocPhi();    
            btnInPhieuHP.Enabled = false;
            btnGuiMail.Enabled = false;

        }
        void chonNamHienTai()
        {
            NamHocDTO nh = namHocBUL.layNamHocMoi();
            if (nh.MaNamHoc != null)
            {
                maNamHienTai = nh.MaNamHoc.Trim();
                cboNamHoc.SelectedValue = nh.MaNamHoc;
                maNamHocDangChon = nh.MaNamHoc.Trim();
            }

        }

        void chonThangHienTai()
        {
            //Nếu là năm học hiện tại thì đề xuất tháng hiện tại trên cboThang
            if (cboNamHoc.SelectedValue.ToString().Trim() == maNamHienTai)
            {
                cboThang.SelectedIndex = DateTime.Now.Month - 1;
            }
        }

        void loadCboNamHoc()
        {
            cboNamHoc.DataSource = namHocBUL.layTatCaNamHoc(); //2 lần selected
            cboNamHoc.DisplayMember = "TenNamHoc";
            cboNamHoc.ValueMember = "MaNamHoc";
        }

        void loadCboThang()
        {
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add("Tháng " + i);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnLapPhieuHP.Enabled = true; //cho phép lập phiếu
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnInPhieuHP.Enabled = false;
            btnGuiMail.Enabled = false;

            cboNamHoc.Enabled = true;
            cboThang.Enabled = true;
            txtSoBuoiHoc.Enabled = false;
            txtSoBuoiHoc.Clear();
        }


        bool ktraDaTaoKhoanThu()
        {
            List<KhoanThuDTO> kthus = ktBUL.layTatCaKhoanThuTrongNamHoc(maNamHocDangChon);
            if (kthus.Count < 2)
                return false;
            return true;
        }

        void ktraDaLapPhieuHocPhi()
        {
            //Kiểm tra đã lập phiếu học phí chưa
            bool result = phpBUL.kiemTraTonTaiPhieuHocPhi(thangDangChon, maNamHocDangChon);
            if (result) //đã lập thì ko cho lập phiếu nữa
            {
                btnLapPhieuHP.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false; //cho ng dùng khỏi kích hoạt nút lập phiếu
                //btnInPhieuHP.Enabled = true;
                //btnGuiMail.Enabled = true;
                treeViewDSHocSinh.Enabled = true;

                //PhieuHocPhiDTO ph = phpBUL.lay // hỏi cô số buổi học lưu ở đâu rồi sẽ thêm vào đây
                //txtSoBuoiHoc.Text = 
            }
            else //chưa lập phiếu
            {
                int thangHT = DateTime.Now.Month;
                btnLapPhieuHP.Enabled = true; //cho phép lập phiếu
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                treeViewDSHocSinh.Enabled = false;

                if (thangDangChon < thangHT || thangDangChon > thangHT)
                    btnLapPhieuHP.Enabled = false; //cho phép lập phiếu
            }
        }

        bool namCu = false;
        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetText();
            lbHocPhi.Text = string.Empty;
            lbTienAn.Text = string.Empty;
            cboThang.SelectedIndex = -1;
            maNamHocDangChon = cboNamHoc.SelectedValue.ToString();
            btnInPhieuHP.Enabled = false;
            btnGuiMail.Enabled = false;

            namCu = false;
            loadTreeView(maNamHocDangChon);

            if (maNamHocDangChon.Trim() != maNamHienTai) //năm học khác năm học hiện tại ==> chỉ xem, không cho lập phiếu
            {
                btnLapPhieuHP.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false; //cho ng dùng khỏi kích hoạt nút lập phiếu
                //btnInPhieuHP.Enabled = true;
                namCu = true;
            }

            //Load thông tin cần thiết
            List<KhoanThuDTO> kthus = ktBUL.layTatCaKhoanThuTrongNamHoc(maNamHocDangChon);
            if (kthus.Count > 0)
            {
                foreach (KhoanThuDTO kt in kthus)
                {
                    if (kt.TenKhoanThu == "Tiền ăn")
                        lbTienAn.Text = kt.SoTien.ToString();
                    if (kt.TenKhoanThu == "Học phí")
                        lbHocPhi.Text = kt.SoTien.ToString();
                }
            }
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            thangDangChon = int.Parse(cboThang.SelectedIndex.ToString()) + 1;
            loadTreeView(maNamHocDangChon);
            lblSoBuoiHSVang.Text = "Số buổi hs vắng tháng " + (thangDangChon - 1);
            lblSoBuoiHocTrongThang.Text = "Số buổi học trong tháng " + thangDangChon;

            resetText();

            btnInPhieuHP.Enabled = false;
            btnGuiMail.Enabled = false;
            txtSoBuoiHoc.Enabled = false;
            int sbh = phpBUL.laySoBuoiHocCuaThang(maNamHocDangChon, thangDangChon);
            if (sbh >= 0)
            {
                txtSoBuoiHoc.Text = sbh.ToString();
            }
            else
            {
                txtSoBuoiHoc.Clear();
            }
            ktraDaLapPhieuHocPhi();
        }

        private void btnLapPhieuHP_Click(object sender, EventArgs e)
        {
            //Load năm hiện tại và tháng hiện tại
            chonNamHienTai();
            chonThangHienTai();

            //Enable
            btnLapPhieuHP.Enabled = false;
            cboNamHoc.Enabled = false;
            cboThang.Enabled = false;
            txtSoBuoiHoc.Enabled = true;
            txtSoBuoiHoc.Text = "";
            btnLuu.Enabled = false; //chưa chắc
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;

            //Kiểm tra đã tạo khoản thu chưa, nếu chưa thì bật form tạo khoản thu
            if (ktraDaTaoKhoanThu())
            {
                tacVu = "Them";
            }
            else
            {
                MessageBox.Show("Hãy tạo khoản thu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //FrmXemKhoanThu myForm = new FrmXemKhoanThu();
                //myForm.StartPosition = FormStartPosition.CenterScreen;
                //myForm.Owner = this;
                //myForm.ShowDialog();

                ////Tạo xong thì load các thông tin cần thiết ra
                //if (ktraDaTaoKhoanThu())
                //{
                //    List<KhoanThuDTO> kthus = ktBUL.layTatCaKhoanThuTrongNamHoc(maNamHocDangChon);
                //    if (kthus.Count > 0)
                //    {
                //        foreach (KhoanThuDTO kt in kthus)
                //        {
                //            if (kt.TenKhoanThu == "Tiền ăn")
                //                lbTienAn.Text = kt.SoTien.ToString();
                //            if (kt.TenKhoanThu == "Học phí")
                //                lbHocPhi.Text = kt.SoTien.ToString();
                //        }
                //    }
                //    tacVu = "Them";
                //}
                //else //chưa tạo ==> bật nút Lập phiếu cho ng dùng ấn lại
                //{
                //    btnLapPhieuHP.Enabled = true;
                //    btnLuu.Enabled = false;
                //    btnHuy.Enabled = false;
                //    btnInPhieuHP.Enabled = false;
                //    txtSoBuoiHoc.Enabled = false;
                //    txtSoBuoiHoc.Clear();
                //}
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSoBuoiHoc.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập số buổi học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult r = MessageBox.Show("Bạn có muốn lập phiếu học phí tháng " + cboThang.Text + " cho toàn trường", "Lập phiếu học phí", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes && ktraDaTaoKhoanThu() && tacVu == "Them")
            {
                // Enable
                btnLapPhieuHP.Enabled = false;
                cboThang.Enabled = true;
                cboNamHoc.Enabled = true;
                txtSoBuoiHoc.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnInPhieuHP.Enabled = true;
                btnGuiMail.Enabled = true;

                double tienAn = double.Parse(lbTienAn.Text);
                double hocPhi = double.Parse(lbHocPhi.Text);
                string maNamHoc = cboNamHoc.SelectedValue.ToString();
                using (TransactionScope scope = new TransactionScope())
                {
                    bool success = true; // Biến cờ để kiểm tra nếu tất cả thao tác thành công
                    List<KhoiLopDTO> dsKhoi = khoiBUL.layKhoiLopTrongNam(maNamHoc);

                    foreach (KhoiLopDTO k in dsKhoi)
                    {
                        List<LopHocDTO> dsLop = lopBUL.layLopHocTheoKeHoach(k.MaKhoi, maNamHoc);

                        foreach (LopHocDTO l in dsLop)
                        {
                            List<PhanLopDTO> dsHS = phanLopBUL.layTatCaHocSinhTheoMaLop(l.MaLop);

                            foreach (PhanLopDTO pl in dsHS)
                            {
                                string maPHP = phpBUL.taoMaPhieuHocPhi(thangDangChon, maNamHoc, pl.MaHS);
                                int soNgayVang = diemDanhBUL.demSoNgayVangCua1HS(l.MaLop, pl.MaHS, thangDangChon);
                                int soNgayHoc = int.Parse(txtSoBuoiHoc.Text) - soNgayVang;

                                double tongTienAn = tienAn * soNgayHoc;
                                double thanhTien = hocPhi + tongTienAn;

                                // Lưu phiếu học phí vào bảng phiếu học phí
                                PhieuHocPhiDTO php = new PhieuHocPhiDTO(maPHP, pl.MaHS, l.MaLop, tenND, DateTime.Now, null, 0, thangDangChon, soNgayVang, thanhTien, soNgayHoc, null, int.Parse(txtSoBuoiHoc.Text));

                                if (!phpBUL.Insert(php))
                                {
                                    success = false;
                                    MessageBox.Show($"Lập phiếu thất bại cho học sinh {pl.MaHS}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }

                                // Lưu khoản thu vào bảng chi tiết phiếu học phí nếu có khoản thu
                                if (ktraDaTaoKhoanThu())
                                {
                                    List<KhoanThuDTO> kthus = ktBUL.layTatCaKhoanThuTrongNamHoc(maNamHocDangChon);

                                    foreach (KhoanThuDTO kt in kthus)
                                    {
                                        CTPhieuHocPhiDTO ctPHP = new CTPhieuHocPhiDTO(maPHP, kt.MaKhoanThu);

                                        if (!ctPHPBUL.Insert(ctPHP))
                                        {
                                            success = false;
                                            MessageBox.Show($"Lập chi tiết phiếu thất bại cho học sinh {pl.MaHS}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                        }
                                    }
                                }

                                if (!success) break;
                            }

                            if (!success) break;
                        }

                        if (!success) break;
                    }

                    if (success)
                    {
                        // Hoàn tất giao dịch nếu tất cả các thao tác đều thành công
                        scope.Complete();
                        MessageBox.Show("Lập phiếu thành công cho toàn bộ học sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lập phiếu thất bại cho một số học sinh. Giao dịch đã bị hủy bỏ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    treeViewDSHocSinh.Enabled = true;
                }

            }
        }


        private void txtSoBuoiHoc_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtSoBuoiHoc.Text;
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
                MessageBox.Show("Số buổi học trong tháng nhập không hợp lệ!");
                txtSoBuoiHoc.Text = filteredText;
                txtSoBuoiHoc.SelectionStart = txtSoBuoiHoc.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtSoBuoiHoc.Text = filteredText; // Chỉ giữ lại ký tự số
            }
        }

        void loadTreeView(string maNamHoc)
        {
            // Xóa các node hiện có trong TreeView để tránh chồng chéo khi load lại
            treeViewDSHocSinh.Nodes.Clear();

            // Lấy danh sách khối lớp dựa vào mã năm học
            List<KhoiLopDTO> danhSachKhoiLop = khoiBUL.layKhoiLopTrongNam(maNamHoc);

            foreach (KhoiLopDTO khoiLop in danhSachKhoiLop)
            {
                // Tạo một node cấp 1 cho từng khối lớp
                TreeNode nodeKhoi = new TreeNode(khoiLop.TenKhoi); // hoặc tùy vào tên thuộc tính của khối lớp
                nodeKhoi.Tag = khoiLop.MaKhoi; // Lưu mã khối vào Tag để dễ truy xuất

                // Lấy danh sách lớp học dựa vào mã khối và năm học
                List<LopHocDTO> danhSachLopHoc = lopBUL.layLopHocTheoKeHoach(khoiLop.MaKhoi, maNamHoc);

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
        string maLop;
        string tenlop;
        private void treeViewDSHocSinh_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (dgvDSHS.Rows.Count > 0)
            {
                dgvDSHS.DataSource = null;
                dgvDSHS.Rows.Clear();
            }

            // Kiểm tra nếu node được click là node cấp 2 (lớp) không có node con
            if (e.Node.Level == 1 && e.Node.Nodes.Count == 0)
            {
                maLop = e.Node.Tag.ToString();
                tenlop = e.Node.Text;

                //Lấy thông tin lớp học
                List<PhieuHocPhiDTO> dshs = phpBUL.layPhieuHocPhiVaTTCuaTatCaHS(maLop, thangDangChon);
                resetText();

                dgvDSHS.AutoGenerateColumns = false;
                dgvDSHS.AllowUserToAddRows = false;
                if (dgvDSHS.RowCount > 0)
                    dgvDSHS.Rows.Clear();

                foreach (PhieuHocPhiDTO hs in dshs)
                {
                    int rowIndex = dgvDSHS.Rows.Add();
                    DataGridViewRow row = dgvDSHS.Rows[rowIndex];

                    row.Cells["MaHS"].Value = hs.MaHS;
                    row.Cells["HoTen"].Value = hs.HoTen;
                    row.Cells["NgaySinh"].Value = hs.NgaySinh.ToString("dd-MM-yyyy");
                    row.Cells["GioiTinh"].Value = hs.GioiTinh;
                    row.Cells["TrangThai"].Value = hs.TrangThaiThanhToan == 0 ? "Chưa thanh toán" : "Đã thanh toán";
                }

                if (dshs.Count > 0)
                {
                    btnInPhieuHP.Enabled = true;
                    btnGuiMail.Enabled = true;
                }
                else
                {
                    btnInPhieuHP.Enabled = false; //ko có gì để in
                    btnGuiMail.Enabled = false;
                }

                //ẨN HIỆN
                //btnPhanCong.Enabled = true;
            }
            else
            {
                //btnPhanCong.Enabled = false;
            }

        }

        private void dgvDSHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDSHS.Rows[e.RowIndex];

                lbMaHS.Text = row.Cells["MaHS"].Value.ToString();
                lbTenHS.Text = row.Cells["HoTen"].Value.ToString();

                //string maLop = row.Cells["MaLop"].Value.ToString();
                LopHocDTO lopHocDTO = lopBUL.getLopHocTheoMa(maLop);
                lbLopHoc.Text = lopHocDTO.TenLop;

                PhieuHocPhiDTO php = phpBUL.layPhieuHocPhiCua1HS(maLop, lbMaHS.Text, thangDangChon);
                lbMaPhieu.Text = php.MaPhieuHP.ToString();

                lbSoNgayVang.Text = php.SoNgayHSVang.ToString();
                lbSoNgayHSAn.Text = php.SoNgayHSHoc.ToString();
                double tongTienAn = double.Parse(lbTienAn.Text) * double.Parse(php.SoNgayHSHoc.ToString());

                lbTongTienAn.Text = tongTienAn.ToString();
                lbThanhTien.Text = php.TongTien.ToString();
            }
        }

        private void resetText()
        {
            //txtSoBuoiHoc.Enabled = false;
            //txtSoBuoiHoc.Clear();

            lbMaHS.Text = string.Empty;
            lbMaPhieu.Text = string.Empty;
            lbLopHoc.Text = string.Empty;
            lbSoNgayHSAn.Text = string.Empty;
            lbTenHS.Text = string.Empty;
            lbSoNgayVang.Text = string.Empty;
            lbTongTienAn.Text = string.Empty;
            lbThanhTien.Text = string.Empty;
            dgvDSHS.Rows.Clear();
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

        private void treeViewDSHocSinh_AfterSelect(object sender, TreeViewEventArgs e)
        {
            HighlightSelectedNode(e.Node);
        }

        private void btnKhoanThu_Click(object sender, EventArgs e)
        {
            FrmXemKhoanThu frm = new FrmXemKhoanThu();
            frm.ShowDialog();
        }

        private void btnInPhieuHP_Click(object sender, EventArgs e)
        {
            int thang = cboThang.SelectedIndex + 1;
            DataTable dt = phpBUL.inPhieuHPTheoThang(maLop, thang);
            rptPhieuHP baoCao = new rptPhieuHP();
            baoCao.SetDataSource(dt);

            FrmInPhieu f = new FrmInPhieu();
            f.crystalReportViewer1.ReportSource = baoCao;
            f.ShowDialog();
        }
        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            decimal tienAn = decimal.Parse(lbTienAn.Text);
            decimal tienHP = decimal.Parse(lbHocPhi.Text);

            FrmGuiMail f = new FrmGuiMail(maLop, tenlop, cboNamHoc.SelectedValue.ToString(), tenND, tienAn.ToString("N0"), tienHP.ToString("N0"), thangDangChon);
            f.ShowDialog();
        }
    }
}
