using BUL;
using DTO;
using QLMamNon.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLMamNon
{
    public partial class FrmThongKeDoanhThuHoatDong : Form
    {
        NamHocBUL namHocbul;
        LopHocBUL lopHocbUL;
        ThongKeDoanhThuNamBUL thongKeDoanhThuNamBUL;
        List<ThongKeDoanhThuDTO> thongKeDoanhThuDTO;

        KhoiLopDTO k = new KhoiLopDTO();

        public FrmThongKeDoanhThuHoatDong()
        {
            namHocbul = new NamHocBUL();
            thongKeDoanhThuNamBUL = new ThongKeDoanhThuNamBUL();
            thongKeDoanhThuDTO = new List<ThongKeDoanhThuDTO>();
            InitializeComponent();
        }

        private void loadCboNamHoc()
        {
            cboNamHoc.DataSource = namHocbul.layTatCaNamHoc();
            cboNamHoc.ValueMember = "MaNamHoc";
            cboNamHoc.DisplayMember = "TenNamHoc";
            cboNamHoc.SelectedIndex = -1;
        }

        private void FrmThongKeDoanhThuHoatDong_Load(object sender, EventArgs e)
        {
            loadCboNamHoc();
        }

        private void btnXemDSHS_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm học để thống kê!");
                return;
            }
            string maNamHoc = cboNamHoc.SelectedValue.ToString();
            dgvThongKe.AutoGenerateColumns = false;
            dgvThongKe.AllowUserToAddRows = false;
            thongKeDoanhThuDTO = thongKeDoanhThuNamBUL.DoanhThuHDTrongNam(maNamHoc);
            dgvThongKe.DataSource = thongKeDoanhThuDTO;
            foreach (ThongKeDoanhThuDTO item in thongKeDoanhThuDTO)
            {
                lbTongDoanhThu.Text = item.TongDoanhThu.ToString();
            }
            TaoChart(dgvThongKe, "", "Doanh Thu");
        }

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTongDoanhThu.Text = String.Empty;
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

        private void TaoChart(DataGridView dgvThongKe, string nameTitle, string seriesName)
        {
            try
            {
                ChartThongKe.Series.Clear();
                ChartThongKe.Series.Add(seriesName);

                for (int i = 0; i < dgvThongKe.RowCount; i++)
                {
                    string TenHoatDong = dgvThongKe.Rows[i].Cells[1].Value?.ToString() ?? "";
                    string DoanhThuHoatDong = dgvThongKe.Rows[i].Cells[3].Value?.ToString() ?? "";
                    ChartThongKe.Series[seriesName].Points.AddXY(TenHoatDong, DoanhThuHoatDong);
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

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm để in báo cáo!");
                return;
            }
            if (lbTongDoanhThu.Text == "")
            {
                MessageBox.Show("Hãy chọn số liệu báo cáo");
                return;
            }
            long tongTien = long.Parse(lbTongDoanhThu.Text);
            string tongtienBangChu = NumberToWords(tongTien);
            string tenNamHoc = cboNamHoc.Text;
            string maNamHoc = cboNamHoc.SelectedValue.ToString();
            DataTable dt = thongKeDoanhThuNamBUL.InThongKeDoanhThuHDTheoNam(maNamHoc, tongtienBangChu, tenNamHoc);
            rptDoanhThuHoatDong baoCao = new rptDoanhThuHoatDong();
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
            ChartThongKe.Series[0].ChartType = SeriesChartType.Bar;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm thống kê!");
                return;
            }
            ChartThongKe.Series[0].ChartType = SeriesChartType.Bar;
        }
    }
}
