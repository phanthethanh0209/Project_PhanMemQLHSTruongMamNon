using BUL;
using DTO;
using QLMamNon.Reports;

//using QLMamNon.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmThanhToanHocPhi : Form
    {
        NamHocBUL namHocBUL;
        CTPhieuHocPhiBUL ctPHPBUL;
        KhoanThuBUL ktBUL;
        KhoiLopBUL khoiBUL;
        LopHocBUL lopBUL;
        HocSinhBUL hocSinhBUL;
        PhieuHocPhiBUL phpBUL;
        string tentk;
        public FrmThanhToanHocPhi(string tentk)
        {
            InitializeComponent();
            this.tentk = tentk;
        }

        string maLopDangChon;
        bool namCu = false;
        int thangDangChon;
        string maNamHocDangChon;

        private void FrmThamGiaHoatDong_Load(object sender, System.EventArgs e)
        {
            namHocBUL = new NamHocBUL();
            ctPHPBUL = new CTPhieuHocPhiBUL();
            ktBUL = new KhoanThuBUL();
            khoiBUL = new KhoiLopBUL();
            lopBUL = new LopHocBUL();
            hocSinhBUL = new HocSinhBUL();
            phpBUL = new PhieuHocPhiBUL();

            loadcboTrangThai();
            loadCboThang();
            loadCboNamHoc();

            //Enable
            btnThanhToan.Enabled = false;
            txtTienNhan.Enabled = false;
            btnIn.Enabled = false;

        }

        void loadCboNamHoc()
        {
            cboNamHoc.DataSource = namHocBUL.layTatCaNamHoc(); //2 lần selected
            cboNamHoc.DisplayMember = "TenNamHoc";
            cboNamHoc.ValueMember = "MaNamHoc";

            //Chọn năm học hiện tại
            NamHocDTO namHocDTO = namHocBUL.layNamHocMoi();
            if (namHocDTO.MaNamHoc != null)
                cboNamHoc.SelectedValue = namHocDTO.MaNamHoc;
        }

        void loadCboThang()
        {
            for (int i = 1; i <= 12; i++)
            {
                cboThangTT.Items.Add("Tháng " + i);
            }

        }

        void loadcboTrangThai()
        {
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Đã thanh toán");
            cboTrangThai.Items.Add("Chưa thanh toán");
            cboTrangThai.SelectedIndex = 0;
        }


        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetText();

            cboThangTT.SelectedIndex = -1;
            maNamHocDangChon = cboNamHoc.SelectedValue.ToString();

            //namCu = false;
            loadTreeView(maNamHocDangChon);

            //Nếu là năm học hiện tại thì đề xuất tháng hiện tại trên cboThangTT
            NamHocDTO nh = namHocBUL.layNamHocMoi();
            if (nh.MaNamHoc != null)
            {
                if (cboNamHoc.SelectedValue.ToString().Trim() == nh.MaNamHoc.ToString().Trim())
                {
                    cboThangTT.SelectedIndex = int.Parse(DateTime.Now.Month.ToString()) - 1;
                }
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

                List<PhieuHocPhiDTO> phpList = phpBUL.layDSHSThanhToanTheoTrangThai(cboTrangThai.Text, maLopDangChon, thangDangChon);

                foreach (PhieuHocPhiDTO php in phpList)
                {
                    int rowIndex = dgvDSHS.Rows.Add();
                    DataGridViewRow row = dgvDSHS.Rows[rowIndex];

                    row.Cells["MaHS"].Value = php.MaHS;
                    row.Cells["HoTen"].Value = php.HoTen;

                    if (php.TrangThaiThanhToan == 1)
                    {
                        row.Cells["TrangThai"].Value = "Đã thanh toán";
                    }
                    else
                    {
                        row.Cells["TrangThai"].Value = "Chưa thanh toán";
                    }
                }
            }

        }

        void loadTreeView(string maNamHoc)
        {

            treeViewDSHocSinh.Nodes.Clear();
            List<KhoiLopDTO> danhSachKhoiLop = khoiBUL.layKhoiLopTrongNam(maNamHoc);

            foreach (KhoiLopDTO khoiLop in danhSachKhoiLop)
            {
                // Tạo một node cấp 1 cho từng khối lớp
                TreeNode nodeKhoi = new TreeNode(khoiLop.TenKhoi);
                nodeKhoi.Tag = khoiLop.MaKhoi;

                // Lấy danh sách lớp học dựa vào mã khối và năm học
                List<LopHocDTO> danhSachLopHoc = lopBUL.layLopHocTheoKeHoach(khoiLop.MaKhoi, maNamHoc);

                foreach (LopHocDTO lopHoc in danhSachLopHoc)
                {
                    // Tạo một node cấp 2 cho từng lớp học trong khối
                    TreeNode nodeLop = new TreeNode(lopHoc.TenLop);
                    nodeLop.Tag = lopHoc.MaLop;

                    nodeKhoi.Nodes.Add(nodeLop);
                }

                treeViewDSHocSinh.Nodes.Add(nodeKhoi);
            }

            treeViewDSHocSinh.ExpandAll();
        }

        private void treeViewDSHocSinh_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (dgvDSHS.Rows.Count > 0)
            {
                dgvDSHS.DataSource = null;
                dgvDSHS.Rows.Clear();
            }

            lbKhoiLop.Text = "";
            lbLopHoc.Text = "";
            lbSoHSChuaThanhToan.Text = "";
            resetText();

            // Kiểm tra nếu node được click là node cấp 2 (lớp) không có node con
            if (e.Node.Level == 1 && e.Node.Nodes.Count == 0)
            {
                maLopDangChon = e.Node.Tag.ToString();

                //Lấy thông tin lớp học
                LopHocDTO lopHoc = lopBUL.getLopHocTheoMa(maLopDangChon);
                lbKhoiLop.Text = e.Node.Parent.Text;
                lbLopHoc.Text = lopHoc.TenLop;

                //Hiển thị số hs chưa thanh toán
                lbSoHSChuaThanhToan.Text = phpBUL.demSoHSChuaThanhToanHocPhi(maLopDangChon, thangDangChon).ToString();

                //Lấy danh sách học sinh của lớp đó
                loadDGV();


                //ẨN HIỆN
                //btnPhanCong.Enabled = true;
            }
            else
            {
                //btnPhanCong.Enabled = false;
            }
        }

        void ktraDaLapPhieuHocPhi()
        {
            //Kiểm tra đã lập phiếu học phí chưa
            bool result = phpBUL.kiemTraTonTaiPhieuHocPhi(thangDangChon, maNamHocDangChon);
            if (result) //đã lập thì hiển thị treeview
            {
                treeViewDSHocSinh.Enabled = true;
            }
            else //chưa lập phiếu thì ko hiện treeview
            {
                treeViewDSHocSinh.Enabled = false;
            }
        }


        private void dgvDSHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDSHS.Rows[e.RowIndex];

                //cboTrangThai.SelectedIndex = 0;
                lbNamHoc.Text = cboNamHoc.Text;
                lbKhoiHD.Text = lbKhoiLop.Text;
                lbLopHD.Text = lbLopHoc.Text;
                lbSoBuoiHoc.Text = lbSoBuoiHocTrongThang.Text;
                lbThang.Text = cboThangTT.Text;

                lbMaHS.Text = row.Cells["MaHS"].Value?.ToString();
                PhieuHocPhiDTO phpCuaHS = phpBUL.layPhieuHocPhiCua1HS(maLopDangChon, lbMaHS.Text, thangDangChon);
                lbMaPHP.Text = phpCuaHS.MaPhieuHP;
                lbTenHS.Text = row.Cells["HoTen"].Value?.ToString();
                lbSoNgayVang.Text = phpCuaHS.SoNgayHSVang.ToString();
                lbNgayLap.Text = phpCuaHS.NgayLapPhieu.ToString();
                lbSoNgayDaHoc.Text = phpCuaHS.SoNgayHSHoc.ToString();

                List<CTPhieuHocPhiDTO> ct = ctPHPBUL.layCTHocPhiTheoMaPhieuHP(phpCuaHS.MaPhieuHP);
                foreach (CTPhieuHocPhiDTO k in ct)
                {
                    KhoanThuDTO kthu = ktBUL.lay1KhoanThu(k.MaKhoanThu);
                    if (kthu.TenKhoanThu == "Tiền ăn")
                    {
                        lbTienAn.Text = kthu.SoTien.ToString();
                    }
                    if (kthu.TenKhoanThu == "Học phí")
                    {
                        lbHocPhi.Text = kthu.SoTien.ToString();
                    }

                }

                lbTinhTienAn.Text = lbSoNgayDaHoc.Text + "x" + lbTienAn.Text;
                lbThanhTienAn.Text = (double.Parse(lbSoNgayDaHoc.Text) * double.Parse(lbTienAn.Text)).ToString();
                lbThanhTienHP.Text = lbHocPhi.Text;
                lbTongTien.Text = phpCuaHS.TongTien.ToString();
                if (phpCuaHS.TienNhan == null) //chưa thanh toán
                {
                    txtTienNhan.Text = string.Empty;
                    lbTienThoi.Text = string.Empty;
                    btnThanhToan.Enabled = true;
                    txtTienNhan.Enabled = true;
                    btnIn.Enabled = false;
                }
                else
                {
                    txtTienNhan.Text = phpCuaHS.TienNhan.ToString();
                    lbTienThoi.Text = (double.Parse(txtTienNhan.Text) - double.Parse(lbTongTien.Text)).ToString();
                    btnThanhToan.Enabled = false;
                    txtTienNhan.Enabled = false;
                    btnIn.Enabled = true;
                }

                // dgvDSHS.Rows.Clear();                
            }
        }


        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thanh toán không?", "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                if (phpBUL.Update(lbMaPHP.Text, double.Parse(txtTienNhan.Text)))
                {
                    MessageBox.Show("Thanh toán thành công");
                    btnThanhToan.Enabled = false;
                    txtTienNhan.Enabled = false;
                    btnIn.Enabled = true;

                    loadDGV();
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại");
                }
            }

        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (ktraDaDuThongTin())
            {
                dgvDSHS.AutoGenerateColumns = false;
                dgvDSHS.AllowUserToAddRows = false;

                if (dgvDSHS.RowCount > 0)
                    dgvDSHS.Rows.Clear();

                dgvDSHS.AutoGenerateColumns = false;
                dgvDSHS.AllowUserToAddRows = false;

                //Lấy ra danh sách học sinh của lớp 
                List<PhieuHocPhiDTO> phpList = phpBUL.timKiemHocSinhTheoMaHoacTen(txtTimKiem.Text, maLopDangChon, thangDangChon);

                foreach (PhieuHocPhiDTO php in phpList)
                {
                    int rowIndex = dgvDSHS.Rows.Add();
                    DataGridViewRow row = dgvDSHS.Rows[rowIndex];

                    row.Cells["MaHS"].Value = php.MaHS;
                    row.Cells["HoTen"].Value = php.HoTen;

                    if (php.TrangThaiThanhToan == 1)
                    {
                        row.Cells["TrangThai"].Value = "Đã thanh toán";
                    }
                    else
                    {
                        row.Cells["TrangThai"].Value = "Chưa thanh toán";
                    }
                }
            }
        }



        bool ktraDaDuThongTin()
        {
            if (cboThangTT.SelectedIndex == -1)
            {
                return false;
            }
            if (maLopDangChon == null)
            {
                return false;
            }

            return true;
        }

        private void resetText()
        {
            cboTrangThai.SelectedIndex = 0;
            lbNamHoc.Text = string.Empty;
            lbKhoiHD.Text = string.Empty;
            lbLopHD.Text = string.Empty;
            lbSoBuoiHoc.Text = string.Empty;
            lbThang.Text = string.Empty;
            lbSoHSChuaThanhToan.Text = string.Empty;

            lbMaHS.Text = string.Empty;
            lbMaPHP.Text = string.Empty;
            lbTenHS.Text = string.Empty;
            lbSoNgayVang.Text = string.Empty;
            lbNgayLap.Text = string.Empty;
            lbSoNgayDaHoc.Text = string.Empty;

            lbTienAn.Text = string.Empty;
            lbHocPhi.Text = string.Empty;
            lbTinhTienAn.Text = string.Empty;
            lbThanhTienAn.Text = string.Empty;
            lbThanhTienHP.Text = string.Empty;
            lbTongTien.Text = string.Empty;
            txtTienNhan.Text = string.Empty;
            lbTienThoi.Text = string.Empty;

            dgvDSHS.Rows.Clear();
        }


        private void cboThangTT_SelectedIndexChanged(object sender, EventArgs e)
        {

            thangDangChon = int.Parse(cboThangTT.SelectedIndex.ToString()) + 1;
            loadTreeView(maNamHocDangChon);

            resetText();

            int sbh = phpBUL.laySoBuoiHocCuaThang(maNamHocDangChon, thangDangChon);
            if (sbh >= 0)
            {
                lblSoBuoiHocTrongThang.Text = "Số buổi học tháng " + thangDangChon;
                lbSoBuoiHocTrongThang.Text = sbh.ToString();
            }
            else
            {
                lblSoBuoiHocTrongThang.Text = "Số buổi học tháng " + thangDangChon;
                lbSoBuoiHocTrongThang.Text = "";
            }
            ktraDaLapPhieuHocPhi();
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDGV();
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
                MessageBox.Show("Tiền nhận không nhập kí tự khác số!");
                txtTienNhan.Text = filteredText;
                txtTienNhan.SelectionStart = txtTienNhan.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtTienNhan.Text = filteredText; // Chỉ giữ lại ký tự số
            }


            if (double.TryParse(txtTienNhan.Text, out _) && double.Parse(txtTienNhan.Text) >= double.Parse(lbTongTien.Text))
                lbTienThoi.Text = (double.Parse(txtTienNhan.Text) - double.Parse(lbTongTien.Text)).ToString();
        }

        public static string NumberToWords(long number)
        {
            if (number == 0) return "không";

            string[] units = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] levels = { "", "nghìn", "triệu", "tỷ" };

            string result = "";
            int level = 0;

            while (number > 0)
            {
                int group = (int)(number % 1000); // Lấy 3 chữ số cuối
                number /= 1000;                  // Bỏ 3 chữ số cuối

                if (group > 0)
                {
                    string groupText = ConvertGroupToWords(group, units);
                    result = groupText + " " + levels[level] + " " + result;
                }

                level++;
            }

            return result.Trim() + " đồng";
        }

        private static string ConvertGroupToWords(int number, string[] units)
        {
            int hundreds = number / 100;
            int tens = (number % 100) / 10;
            int ones = number % 10;

            string result = "";

            // Hàng trăm
            if (hundreds > 0)
            {
                result += units[hundreds] + " trăm";
            }

            // Hàng chục và hàng đơn vị
            if (tens > 1)
            {
                result += " " + units[tens] + " mươi";
                if (ones == 1) result += " mốt";
                else if (ones == 5) result += " lăm";
                else if (ones > 0) result += " " + units[ones];
            }
            else if (tens == 1)
            {
                result += " mười";
                if (ones == 1) result += " một";
                else if (ones == 5) result += " lăm";
                else if (ones > 0) result += " " + units[ones];
            }
            else if (tens == 0 && ones > 0)
            {
                if (hundreds > 0) result += " lẻ"; // Chỉ thêm "lẻ" nếu có hàng trăm
                result += " " + units[ones];
            }

            return result.Trim();
        }



        private void btnIn_Click(object sender, EventArgs e)
        {
            long tongTien = long.Parse(lbTongTien.Text);
            string tongtienBangChu = NumberToWords(tongTien);

            double tienThua = double.Parse(lbTienThoi.Text);

            DataTable dt = phpBUL.inPhieuHPTheoHS(lbMaPHP.Text, tongtienBangChu, tienThua);
            rptThanhToanHP baoCao = new rptThanhToanHP();
            baoCao.SetDataSource(dt);

            FrmInPhieu f = new FrmInPhieu();
            f.crystalReportViewer1.ReportSource = baoCao;
            f.ShowDialog();
        }
    }
}
