using BUL;
using DTO;
using System;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmNhomNguoiDung : Form
    {
        NhomNguoiDungBUL bul = new NhomNguoiDungBUL();
        public FrmNhomNguoiDung()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            dgvNhomNguoiDung.DataSource = bul.getAll();
            binding();
            dgvNhomNguoiDung.AutoGenerateColumns = false;
            dgvNhomNguoiDung.ReadOnly = true;
        }

        public void binding()
        {
            txtMaNhom.DataBindings.Clear();
            txtMaNhom.DataBindings.Add("Text", dgvNhomNguoiDung.DataSource, "MaNhom");
            txtTenNhom.DataBindings.Clear();
            txtTenNhom.DataBindings.Add("Text", dgvNhomNguoiDung.DataSource, "TenNhom");
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", dgvNhomNguoiDung.DataSource, "GhiChu");
        }
        string tacVu = "Xem";
        private void btnThem_Click(object sender, EventArgs e)
        {
            tacVu = "Them";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tacVu = "Sua";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            tacVu = "Xoa";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNhom = txtMaNhom.Text.Trim().ToString();
            string tenNhom = txtTenNhom.Text.Trim().ToString();
            string ghiChu = txtGhiChu.Text.Trim().ToString();

            if (tacVu == "Them")
            {
                NhomNguoiDungDTO nhomND = new NhomNguoiDungDTO(maNhom, tenNhom, ghiChu);
                bool kp = bul.InsertRole(nhomND);
                if (kp == true)
                    MessageBox.Show("Them thanh cong");
                else
                    MessageBox.Show("Them that bai");

            }
            else if (tacVu == "Sua")
            {
                NhomNguoiDungDTO nhomND = new NhomNguoiDungDTO(maNhom, tenNhom, ghiChu);
                bool kp = bul.UpdateRole(nhomND);
                if (kp == true)
                    MessageBox.Show("Sua thanh cong");
                else
                    MessageBox.Show("Sua that bai");

            }
            else if (tacVu == "Xoa")
            {
                bool kp = bul.DeleteRole(maNhom);
                if (kp == true)
                    MessageBox.Show("Xoa thanh cong");
                else
                    MessageBox.Show("Xoa that bai");
            }

            loadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNhom.Clear();
            txtTenNhom.Clear();
            txtGhiChu.Clear();
            txtMaNhom.Focus();
        }

        private void FrmNhomNguoiDung_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
