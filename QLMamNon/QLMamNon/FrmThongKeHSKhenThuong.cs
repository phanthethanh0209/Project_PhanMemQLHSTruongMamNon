using BUL;
using DTO;
using QLMamNon.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmThongKeHSKhenThuong : Form
    {
        NamHocBUL namHocbul;
        LopHocBUL lophocbul;
        ThongKeHSBUL ThongKeHSBUL;
        List<ThongKeHSDTO> ThongKeHSDTO;
        public FrmThongKeHSKhenThuong()
        {
            lophocbul = new LopHocBUL();
            namHocbul = new NamHocBUL();
            ThongKeHSBUL = new ThongKeHSBUL();
            ThongKeHSDTO = new List<ThongKeHSDTO>();
            InitializeComponent();
        }

        bool flag = false;
        private void loadCboNamHoc()
        {
            cboNamHoc.DataSource = namHocbul.layTatCaNamHoc();
            cboNamHoc.ValueMember = "MaNamHoc";
            cboNamHoc.DisplayMember = "TenNamHoc";
            cboNamHoc.SelectedIndex = -1;
            flag = true;
        }

        private void loadCboLopHoc()
        {
            string maNamHoc = cboNamHoc.SelectedValue.ToString();
            cboTenLop.DataSource = lophocbul.getLopHocTheoNam(maNamHoc);
            cboTenLop.ValueMember = "MaLop";
            cboTenLop.DisplayMember = "TenLop";
            cboTenLop.SelectedIndex = -1;
        }
        private void btnXemDSHS_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm học để thống kê!");
                return;
            }
            if (cboTenLop.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn lớp!");
                return;
            }
            string MaNamHoc = cboNamHoc.SelectedValue.ToString();
            string maLop = cboTenLop.SelectedValue.ToString();
            dgvThongKe.AutoGenerateColumns = false;
            dgvThongKe.AllowUserToAddRows = false;
            ThongKeHSDTO = ThongKeHSBUL.ThongKeHSDatKhenThuong(maLop);
            dgvThongKe.DataSource = ThongKeHSDTO;


            dgvTongHS.AutoGenerateColumns = false;
            dgvTongHS.AllowUserToAddRows = false;
            ThongKeHSDTO = ThongKeHSBUL.ThongKeTongHSDatKhenThuong(MaNamHoc);
            dgvTongHS.DataSource = ThongKeHSDTO;
            //foreach (ThongKeHSDTO item in ThongKeHSDTO)
            //{
            //    lbTongDoanhThu.Text = item.TongDoanhThu.ToString();
            //}
        }

        private void FrmThongKeHSKhenThuong_Load(object sender, EventArgs e)
        {
            loadCboNamHoc();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm để in báo cáo!");
                return;
            }
            string tenNamHoc = cboNamHoc.Text;
            string maNamHoc = cboNamHoc.SelectedValue.ToString();
            string maLop = cboTenLop.SelectedValue.ToString();
            DataTable dt = ThongKeHSBUL.InThongKeHSDatKhenThuongBUL(maNamHoc, tenNamHoc, maLop);
            rptKhenThuongHS baoCao = new rptKhenThuongHS();
            baoCao.SetDataSource(dt);

            FrmInPhieu f = new FrmInPhieu();
            f.crystalReportViewer1.ReportSource = baoCao;
            f.ShowDialog();
        }

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                cboTenLop.Enabled = true;
                loadCboLopHoc();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
