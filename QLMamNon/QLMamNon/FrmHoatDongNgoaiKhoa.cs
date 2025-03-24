using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmHoatDongNgoaiKhoa : Form
    {
        NamHocBUL namHocBUL;
        HoatDongBUL hoatDongBUL;
        public FrmHoatDongNgoaiKhoa()
        {
            InitializeComponent();
        }

        string maNamHoc;
        private void FrmHoatDongNgoaiKhoa_Load(object sender, EventArgs e)
        {
            namHocBUL = new NamHocBUL();
            hoatDongBUL = new HoatDongBUL();
            List<NamHocDTO> dsNamHoc = namHocBUL.layTatCaNamHoc();
            cboNamHoc.DataSource = dsNamHoc;
            cboNamHoc.ValueMember = "MaNamHoc";
            cboNamHoc.DisplayMember = "TenNamHoc";
            //cboNamHoc.SelectedIndex = -1;

            NamHocDTO namHocDTO = namHocBUL.layNamHocMoi();
            if (namHocDTO.MaNamHoc != null)
                cboNamHoc.SelectedValue = namHocDTO.MaNamHoc;

            //btnThem.Enabled = false;
            //btnXoa.Enabled = false;
            //btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            cboNamHoc.Enabled = true;

            txtTenHD.Enabled = false;
            txtSoTien.Enabled = false;
            dpNgayTG.Enabled = false;

            cboTrangThaiDK.Items.Add("Đang diễn ra");
            cboTrangThaiDK.Items.Add("Đã hết hạn đăng ký");
        }

        public void loadData(string maNamHoc)
        {
            dgvDSHD.AutoGenerateColumns = false;
            dgvDSHD.ReadOnly = true;
            dgvDSHD.DataSource = hoatDongBUL.layTatCaHoatDongTrongNam(maNamHoc);
        }

        int flag = 0;
        private void resetButton(bool r)
        {
            btnThem.Enabled = !r;
            btnSua.Enabled = !r;
            btnXoa.Enabled = !r;
            btnLuu.Enabled = r;
            btnHuy.Enabled = r;
            cboNamHoc.Enabled = !r;

            //txtTenHD.Enabled = r;
            //txtSoTien.Enabled = r;
            //dpNgayTG.Enabled = r;
        }

        private void xoaText()
        {
            txtTenHD.Clear();
            txtSoTien.Clear();
            lbMaHD.Text = "";
            dpNgayTG.Value = DateTime.Now;
            cboTrangThaiDK.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (cboNamHoc.SelectedIndex != -1)
            {
                xoaText();
                lbMaHD.Text = hoatDongBUL.TaoMaHS(maNamHoc);
                flag = 1;
                resetButton(true);
                txtSoTien.Enabled = true;
                txtTenHD.Enabled = true;
                dpNgayTG.Enabled = true;
                cboTrangThaiDK.SelectedIndex = 0;
                cboTrangThaiDK.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenHD.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn hoạt động để sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            flag = 2;
            resetButton(true);
            txtSoTien.Enabled = true;
            txtTenHD.Enabled = true;
            dpNgayTG.Enabled = true;
            cboTrangThaiDK.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTenHD.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn hoạt động để xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            flag = 3;
            resetButton(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            flag = 0;
            resetButton(false);
            txtSoTien.Enabled = false;
            txtTenHD.Enabled = false;
            cboTrangThaiDK.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maHD = lbMaHD.Text.Trim().ToString();
            string tenHD = txtTenHD.Text.Trim().ToString();

            if (tenHD.Length == 0 || txtSoTien.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double soTien = double.Parse(txtSoTien.Text.ToString());
            string trangThaiDK = cboTrangThaiDK.Text;
            HoatDongDTO hd = new HoatDongDTO(maHD, tenHD, dpNgayTG.Value, soTien, maNamHoc, trangThaiDK);

            if (flag == 1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm hoạt động này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool kp = hoatDongBUL.themHoatDong(hd);
                    if (kp)
                        MessageBox.Show("Thêm thành công");
                    else
                        MessageBox.Show("Thêm thất bại");
                }
            }
            else if (flag == 2)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa hoạt động này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool kp = hoatDongBUL.suaHoatDong(hd);
                    if (kp)
                        MessageBox.Show("Sửa thành công");
                    else
                        MessageBox.Show("Sửa thất bại");
                }
            }
            else if (flag == 3)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hoạt động này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool kp = hoatDongBUL.xoaHoatDong(hd);
                    if (kp)
                        MessageBox.Show("Xóa thành công");
                    else
                        MessageBox.Show("Xóa thất bại");
                }
            }

            // Sau khi thực hiện thao tác, tải lại dữ liệu và reset các nút
            loadData(cboNamHoc.SelectedValue.ToString());
            resetButton(false);
            xoaText();
            txtSoTien.Enabled = false;
            txtTenHD.Enabled = false;
            cboTrangThaiDK.Enabled = false;
        }

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex != -1)
            {
                maNamHoc = cboNamHoc.SelectedValue.ToString();
                resetButton(false);
                loadData(maNamHoc);
            }
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDSHD.Rows[e.RowIndex];

                txtSoTien.Text = row.Cells["SoTien"].Value?.ToString();
                txtTenHD.Text = row.Cells["TenHDNK"].Value?.ToString();
                lbMaHD.Text = row.Cells["MaHD"].Value?.ToString();
                cboTrangThaiDK.SelectedItem = row.Cells["TrangThaiDK"].Value?.ToString();

                HoatDongDTO hoatDongDTO = hoatDongBUL.layThongTinMotHoatDong(lbMaHD.Text);
                dpNgayTG.Text = hoatDongDTO.NgayTG.ToString("dd-MM-yyyy");

                cboNamHoc.Enabled = false;
                txtSoTien.Enabled = false;
                txtTenHD.Enabled = false;
                dpNgayTG.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                cboTrangThaiDK.Enabled = false;
            }
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            string inputText = txtSoTien.Text;
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
                MessageBox.Show("Số tiền hoạt động nhập không hợp lệ!");
                txtSoTien.Text = filteredText;
                txtSoTien.SelectionStart = txtSoTien.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtSoTien.Text = filteredText; // Chỉ giữ lại ký tự số
            }
        }
    }
}
