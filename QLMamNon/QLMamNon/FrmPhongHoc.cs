using BUL;
using DTO;
using System;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmPhongHoc : Form
    {
        PhongHocBUL bul = new PhongHocBUL();
        public FrmPhongHoc()
        {
            InitializeComponent();
        }
        string tacVu = "";
        public void binding()
        {
            txtMaPhong.DataBindings.Clear();
            txtMaPhong.DataBindings.Add("Text", dgvPhongHoc.DataSource, "MaPhong");

            txtTenPhong.DataBindings.Clear();
            txtTenPhong.DataBindings.Add("Text", dgvPhongHoc.DataSource, "TenPhong");

            txtSucChua.DataBindings.Clear();
            txtSucChua.DataBindings.Add("Text", dgvPhongHoc.DataSource, "SucChua");

            txtViTri.DataBindings.Clear();
            txtViTri.DataBindings.Add("Text", dgvPhongHoc.DataSource, "ViTri");

            cboTinhTrang.DataBindings.Clear();
            cboTinhTrang.DataBindings.Add("Text", dgvPhongHoc.DataSource, "TinhTrang");
        }

        public void loadData()
        {
            dgvPhongHoc.AutoGenerateColumns = false;
            dgvPhongHoc.ReadOnly = true;
            dgvPhongHoc.DataSource = bul.layTatCaPhongHoc();
            binding();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            tacVu = "Them";
            hideButton(false);
            txtMaPhong.Text = bul.TaoMaPhong();
            txtTenPhong.Clear();
            txtSucChua.Clear();
            cboTinhTrang.ResetText();
            txtViTri.Clear();
            //Lock();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tacVu = "Sua";
            hideButton(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            tacVu = "Xoa";
            hideButton(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text.Trim().ToString();
            string tenPhong = txtTenPhong.Text.Trim().ToString();
            int sucChua = int.Parse(txtSucChua.Text.Trim());
            string viTri = txtViTri.Text.Trim().ToString();
            string tinhTrang = cboTinhTrang.Text.Trim().ToString();
            PhongHocDTO nguoidung = new PhongHocDTO(maPhong, tenPhong, sucChua, viTri, tinhTrang);

            if (tacVu == "Them")
            {
                bool kp = bul.ThemPhongHoc(nguoidung);
                if (kp == true)
                    MessageBox.Show("Them thanh cong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Them that bai! Phòng học đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (tacVu == "Sua")
            {
                bool kp = bul.SuaPhongHoc(nguoidung);
                if (kp == true)
                    MessageBox.Show("Sua thanh cong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sua that bai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (tacVu == "Xoa")
            {
                bool kp = bul.XoaPhongHoc(nguoidung);
                if (kp == true)
                    MessageBox.Show("Xoa thanh cong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xoa that bai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadData();
            hideButton(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Clear();
            hideButton(true);
        }

        private void FrmPhongHoc_Load(object sender, EventArgs e)
        {
            loadData();
            cboTinhTrang.Items.Add("Khả Dụng");
            cboTinhTrang.Items.Add("Bảo Trì");
        }

        private void hideButton(bool t)
        {
            btnHuy.Enabled = !t;
            btnLuu.Enabled = !t;
            btnSua.Enabled = t;
            btnThem.Enabled = t;
            btnXoa.Enabled = t;
        }
        private void Clear()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtSucChua.Clear();
            cboTinhTrang.ResetText();
            txtViTri.Clear();
        }

        //private void Lock()
        //{
        //    dgvPhongHoc.SelectionMode = DataGridViewSelectionMode.CellSelect;

        //    foreach (DataGridViewRow row in dgvPhongHoc.Rows)
        //    {
        //        row.ReadOnly = true;
        //    }
        //}
    }
}
