using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BUL;
using DTO;

namespace QLMamNon.UC_Control
{
    public partial class FrmTiLeHSKhuVuc : Form
    {
        NamHocBUL namHocbul;
        ThongKeHSBUL ThongKeHSBUL;
        List<ThongKeHSDTO> ThongKeHSDTO;
        public FrmTiLeHSKhuVuc()
        {
            namHocbul = new NamHocBUL();
            ThongKeHSBUL = new ThongKeHSBUL();
            ThongKeHSDTO = new List<ThongKeHSDTO>();
            InitializeComponent();
        }

        private void loadCboNamHoc()
        {
            cboNamHoc.DataSource = namHocbul.layTatCaNamHoc();
            cboNamHoc.ValueMember = "MaNamHoc";
            cboNamHoc.DisplayMember = "TenNamHoc";
            cboNamHoc.SelectedIndex = -1;
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
            ThongKeHSDTO = ThongKeHSBUL.ThongKeHSQueQuan(maNamHoc);
            dgvThongKe.DataSource = ThongKeHSDTO;
            TaoChart(dgvThongKe, "", "Khu Vực");
        }

        private void FrmTiLeHSKhuVuc_Load(object sender, EventArgs e)
        {
            loadCboNamHoc();
        }

        private void TaoChart(DataGridView dgvThongKe, string nameTitle, string seriesName)
        {
            try
            {
                ChartThongKe.Series.Clear();
                ChartThongKe.Series.Add(seriesName);

                for (int i = 0; i < dgvThongKe.RowCount; i++)
                {
                    string KhuVuc = dgvThongKe.Rows[i].Cells[1].Value?.ToString() ?? "";
                    string SoHocSinh = dgvThongKe.Rows[i].Cells[2].Value?.ToString() ?? "";
                    ChartThongKe.Series[seriesName].Points.AddXY(KhuVuc, SoHocSinh);
                }

                ChartThongKe.Titles.Clear();
                ChartThongKe.Titles.Add(nameTitle);

                ChartThongKe.ChartAreas[0].AxisX.Title = dgvThongKe.Columns[1].HeaderText;
                ChartThongKe.ChartAreas[0].AxisY.Title = dgvThongKe.Columns[2].HeaderText;
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

        private void TaoChartPie(DataGridView dgvThongKe, string nameTitle, string seriesName)
        {
            try
            {
                ChartThongKe.Series.Clear();
                Series series = new Series(seriesName)
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true, // Hiển thị giá trị trên biểu đồ
                    LabelFormat = "#PERCENT",  // Hiển thị tỷ lệ phần trăm
                    BorderWidth = 1
                };
                ChartThongKe.Series.Add(series);

                int totalStudents = 0;

                // Tính tổng số học sinh
                for (int i = 0; i < dgvThongKe.RowCount; i++)
                {
                    string SoHocSinh = dgvThongKe.Rows[i].Cells[2].Value?.ToString() ?? "";
                    if (int.TryParse(SoHocSinh, out int count))
                    {
                        totalStudents += count;
                    }
                }

                // Thêm các điểm vào biểu đồ và tính tỷ lệ phần trăm
                for (int i = 0; i < dgvThongKe.RowCount; i++)
                {
                    string KhuVuc = dgvThongKe.Rows[i].Cells[1].Value?.ToString() ?? "";
                    string SoHocSinh = dgvThongKe.Rows[i].Cells[2].Value?.ToString() ?? "";

                    if (int.TryParse(SoHocSinh, out int count))
                    {
                        // Tính tỷ lệ phần trăm của số học sinh trong khu vực so với tổng số học sinh/ Ở dữ liệu năm cũ lấy được từ bảng phân lớp là có 32 hs thôi mn, nên tính là 32 * 100
                        double percentage = (double)count / totalStudents * 100;

                        // Thêm các điểm giá trị vào biểu đồ
                        series.Points.AddXY(KhuVuc, count);

                        // Thêm tên khu vực với tỉ lệ % nè thanh
                        series.Points[series.Points.Count - 1].Label = $"{KhuVuc}: {percentage.ToString("0.##")}%";
                    }
                }

                ChartThongKe.Titles.Clear();
                ChartThongKe.Titles.Add(nameTitle);

                ChartThongKe.ChartAreas[0].AxisX.Title = dgvThongKe.Columns[1].HeaderText;
                ChartThongKe.ChartAreas[0].AxisY.Title = dgvThongKe.Columns[2].HeaderText;

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

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm!");
                return;
            }
            ChartThongKe.Series[0].ChartType = SeriesChartType.Bar;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm!");
                return;
            }
            ChartThongKe.Series[0].ChartType = SeriesChartType.Column;
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn năm!");
                return;
            }
            TaoChartPie(dgvThongKe, "", "Khu Vực");
        }
    }
}
