using BUL;
using System;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDsHocSinhTheoLop : Form
    {
        HocSinhBUL bul;
        string MaLopYC;
        public FrmDsHocSinhTheoLop(string maLop)
        {
            bul = new HocSinhBUL();
            InitializeComponent();

            MaLopYC = maLop;

            dgvDsHsMoi.AutoGenerateColumns = false;
            dgvDsHsMoi.ReadOnly = true;
            dgvDsHsMoi.DataSource = bul.layTatCaHocSinhTheoMaLop(MaLopYC);
            if (dgvDsHsMoi.RowCount > 0)
            {
                lbSoLuongHS.Text = "Danh sách gồm " + dgvDsHsMoi.RowCount.ToString() + " học sinh";

            }
            else
            {
                lbSoLuongHS.Text = "Lớp học chưa có học sinh";
            }


        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length > 0)
            {
                dgvDsHsMoi.AutoGenerateColumns = false;
                dgvDsHsMoi.DataSource = bul.timKiemHocSinhTheoMaTenLop(txtTimKiem.Text, MaLopYC);
                lbSoLuongHS.Text = "Danh sách gồm " + dgvDsHsMoi.RowCount.ToString() + " học sinh";

            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvDsHsMoi.AutoGenerateColumns = false;
            dgvDsHsMoi.DataSource = bul.layTatCaHocSinhTheoMaLop(MaLopYC);
            lbSoLuongHS.Text = "Danh sách gồm " + dgvDsHsMoi.RowCount.ToString() + " học sinh";

        }

        private void FrmDsHocSinhTheoLop_Load(object sender, EventArgs e)
        {

        }
    }
}
