using BUL;
using DTO;
using System;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDMManHinh : Form
    {
        DMManHinhBUL bul = new DMManHinhBUL();
        public FrmDMManHinh()
        {
            InitializeComponent();
        }

        public void loadData()
        {

            dgvManHinh.AutoGenerateColumns = false;
            dgvManHinh.ReadOnly = true;
            dgvManHinh.DataSource = bul.getAll();
            binding();
        }

        public void binding()
        {
            txtMaMH.DataBindings.Clear();
            txtMaMH.DataBindings.Add("Text", dgvManHinh.DataSource, "MaMH");
            txtTenMH.DataBindings.Clear();
            txtTenMH.DataBindings.Add("Text", dgvManHinh.DataSource, "TenMH");

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
            string maMH = txtMaMH.Text.Trim().ToString();
            string tenMH = txtTenMH.Text.Trim().ToString();

            if (tacVu == "Them")
            {
                DMManHinhDTO manHinh = new DMManHinhDTO(maMH, tenMH);
                bool kp = bul.InsertScreen(manHinh);
                if (kp == true)
                    MessageBox.Show("Them thanh cong");
                else
                    MessageBox.Show("Them that bai");

            }
            else if (tacVu == "Sua")
            {
                DMManHinhDTO manHinh = new DMManHinhDTO(maMH, tenMH);
                bool kp = bul.UpdateScreen(manHinh);
                if (kp == true)
                    MessageBox.Show("Sua thanh cong");
                else
                    MessageBox.Show("Sua that bai");
            }
            else if (tacVu == "Xoa")
            {
                bool kp = bul.DeleteScreen(maMH);
                if (kp == true)
                    MessageBox.Show("Xoa thanh cong");
                else
                    MessageBox.Show("Xoa that bai");
            }

            loadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtMaMH.Focus();
        }

        private void FrmDMManHinh_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvManHinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
