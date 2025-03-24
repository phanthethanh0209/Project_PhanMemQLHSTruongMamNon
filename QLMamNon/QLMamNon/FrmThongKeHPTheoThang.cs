using BUL;
using QLMamNon.Reports;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLMamNon
{
    public partial class FrmThongKeHPTheoThang : Form
    {
        NamHocBUL namHocbul;
        LopHocBUL lopHocbUL;
        ThongKeDoanhThuNamBUL thongKeDoanhThuNamBUL;

        public FrmThongKeHPTheoThang()
        {
            namHocbul = new NamHocBUL();
            thongKeDoanhThuNamBUL = new ThongKeDoanhThuNamBUL();
            InitializeComponent();
        }

        private void FrmThongKeHPTheoThang_Load(object sender, EventArgs e)
        {
            loadCbo();
        }

        private void loadCbo()
        {
            cboNamHoc.DataSource = namHocbul.layTatCaNamHoc();
            cboNamHoc.ValueMember = "MaNamHoc";
            cboNamHoc.DisplayMember = "TenNamHoc";
            cboNamHoc.SelectedIndex = -1;

            cboThang.Items.Add("1");
            cboThang.Items.Add("2");
            cboThang.Items.Add("3");
            cboThang.Items.Add("4");
            cboThang.Items.Add("5");
            cboThang.Items.Add("6");
            cboThang.Items.Add("7");
            cboThang.Items.Add("8");
            cboThang.Items.Add("9");
            cboThang.Items.Add("10");
            cboThang.Items.Add("11");
            cboThang.Items.Add("12");
            cboThang.SelectedIndex = -1;
        }

        private void TaoChart(DataGridView dgvThongKe, string nameTitle, string seriesName)
        {
            try
            {
                ChartThongKe.Series.Clear();
                ChartThongKe.Series.Add(seriesName);

                for (int i = 0; i < dgvThongKe.RowCount; i++)
                {
                    //var TenKhoi = dgvThongKe.Rows[i].Cells[0].Value?.ToString() ?? "";
                    string TenLop = dgvThongKe.Rows[i].Cells[1].Value?.ToString() ?? "";
                    //var TienHP = dgvThongKe.Rows[i].Cells[2].Value?.ToString() ?? "";
                    string TienDaThu = dgvThongKe.Rows[i].Cells[3].Value?.ToString() ?? "";
                    //var TienChuaThu = dgvThongKe.Rows[i].Cells[4].Value?.ToString() ?? "";
                    ChartThongKe.Series[seriesName].Points.AddXY(TenLop, TienDaThu);
                }

                ChartThongKe.Titles.Clear();
                ChartThongKe.Titles.Add(nameTitle);

                ChartThongKe.ChartAreas[0].AxisX.Title = dgvThongKe.Columns[1].HeaderText;
                ChartThongKe.ChartAreas[0].AxisY.Title = dgvThongKe.Columns[3].HeaderText;
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Không đủ cột!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu không hợp lệ!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "");
            }
        }
        private void btnXemDSHS_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm để thống kê!");
                return;
            }
            if (cboThang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tháng để thống kê!");
                return;
            }

            string maNamHoc = cboNamHoc.SelectedValue.ToString();
            string thang = cboThang.SelectedItem.ToString();
            dgvThongKe.AutoGenerateColumns = false;
            dgvThongKe.AllowUserToAddRows = false;
            dgvThongKe.DataSource = thongKeDoanhThuNamBUL.layTatCaKhoanThuTrongThang(maNamHoc, thang);
            TaoChart(dgvThongKe, "", "Doanh Thu");
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm để in báo cáo!");
                return;
            }
            if (cboThang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tháng để thống kê!");
                return;
            }
            //long tongTien = long.Parse(lbTongDoanhThu.Text);
            //string tongtienBangChu = NumberToWords(tongTien);
            string tenNamHoc = cboNamHoc.Text;
            string maNamHoc = cboNamHoc.SelectedValue.ToString();
            string thang = cboThang.SelectedItem.ToString();
            DataTable dt = thongKeDoanhThuNamBUL.InDoanhThuHPTrongThang(maNamHoc, tenNamHoc, thang);
            rptDoanhThuThang baoCao = new rptDoanhThuThang();
            baoCao.SetDataSource(dt);

            FrmInPhieu f = new FrmInPhieu();
            f.crystalReportViewer1.ReportSource = baoCao;
            f.ShowDialog();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm thống kê!");
                return;
            }
            if (cboThang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm thống kê!");
                return;
            }
            ChartThongKe.Series[0].ChartType = SeriesChartType.Bar;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm thống kê!");
                return;
            }
            if (cboThang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm thống kê!");
                return;
            }
            ChartThongKe.Series[0].ChartType = SeriesChartType.Column;
        }
    }
}
