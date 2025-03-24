using BUL;
using DTO;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDsHocSinh : Form
    {
        HocSinhBUL bul;
        NamHocBUL namHocBUL;
        PhuHuynhBUL phuHuynhBUL;
        private FrmHoSoHocSinh frmHoSoHocSinh;
        public FrmDsHocSinh(FrmHoSoHocSinh parentForm)
        {
            bul = new HocSinhBUL();
            namHocBUL = new NamHocBUL();
            phuHuynhBUL = new PhuHuynhBUL();
            InitializeComponent();
            frmHoSoHocSinh = parentForm;
            dgvDsHsMoi.AutoGenerateColumns = false;
            dgvDsHsMoi.ReadOnly = true;
            dgvDsHsMoi.DataSource = bul.layHocSinhToanTruong();
            lbSoLuongHS.Text = "Danh sách gồm " + dgvDsHsMoi.RowCount.ToString() + " học sinh";

            cboDoTuoi.Items.Add("1-2 tuổi"); //nhà trẻ
            cboDoTuoi.Items.Add("3 tuổi"); //mầm
            cboDoTuoi.Items.Add("4 tuổi"); //chồi
            cboDoTuoi.Items.Add("5 tuổi"); //lá

            cboLoc.Items.Add("Học sinh toàn trường");
            cboLoc.Items.Add("Học sinh mới");
            cboLoc.SelectedIndex = 0;
        }


        private void btnXemHS_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgvDsHsMoi.SelectedRows.Count > 0)
            {
                // Lấy MaHS từ dòng được chọn
                string maHS = dgvDsHsMoi.SelectedRows[0].Cells["MaHS"].Value.ToString();

                // Trả dữ liệu về form cha (FrmHoSoHocSinh)
                frmHoSoHocSinh.HienThiThongTinHocSinh(maHS);

                // Đóng form này
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học sinh.");
            }
        }

        private void FrmDsHsMoi_Load(object sender, EventArgs e)
        {

        }

        private void cboDoTuoi_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (cboLoc.SelectedIndex >= 0 && cboDoTuoi.SelectedIndex >= 0)
            {
                dgvDsHsMoi.AutoGenerateColumns = false;
                if (cboLoc.SelectedIndex == 0) //xem tất cả học sinh (bap gồm hs đã phân lớp và chưa có lớp)
                {
                    if (cboDoTuoi.Text == "1-2 tuổi")
                    {
                        dgvDsHsMoi.DataSource = bul.layHocSinhToanTruongTheoDoTuoi(1, 2);
                    }
                    else if (cboDoTuoi.Text == "3 tuổi")
                    {
                        dgvDsHsMoi.DataSource = bul.layHocSinhToanTruongTheoDoTuoi(3, 3);
                    }
                    else if (cboDoTuoi.Text == "4 tuổi")
                    {
                        dgvDsHsMoi.DataSource = bul.layHocSinhToanTruongTheoDoTuoi(4, 4);
                    }
                    else if (cboDoTuoi.Text == "5 tuổi")
                    {
                        dgvDsHsMoi.DataSource = bul.layHocSinhToanTruongTheoDoTuoi(5, 5);
                    }

                }
                else //xem học sinh mới
                {
                    if (cboDoTuoi.Text == "1-2 tuổi")
                    {
                        dgvDsHsMoi.DataSource = bul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(1, 2, null);
                    }
                    else if (cboDoTuoi.Text == "3 tuổi")
                    {
                        dgvDsHsMoi.DataSource = bul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(3, 3, null);
                    }
                    else if (cboDoTuoi.Text == "4 tuổi")
                    {
                        dgvDsHsMoi.DataSource = bul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(4, 4, null);
                    }
                    else if (cboDoTuoi.Text == "5 tuổi")
                    {
                        dgvDsHsMoi.DataSource = bul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(5, 5, null);
                    }
                }
                lbSoLuongHS.Text = "Danh sách gồm " + dgvDsHsMoi.RowCount.ToString() + " học sinh";


            }
            else
            {
                MessageBox.Show("Hãy chọn độ tuổi thích hợp");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length > 0)
            {
                dgvDsHsMoi.AutoGenerateColumns = false;
                dgvDsHsMoi.DataSource = bul.timKiemHocSinhTheoMaHoacTen(txtTimKiem.Text);
                lbSoLuongHS.Text = "Danh sách gồm " + dgvDsHsMoi.RowCount.ToString() + " học sinh";

            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvDsHsMoi.AutoGenerateColumns = false;
            dgvDsHsMoi.DataSource = bul.layHocSinhToanTruong();
            lbSoLuongHS.Text = "Danh sách gồm " + dgvDsHsMoi.RowCount.ToString() + " học sinh";

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXuatEx_Click(object sender, EventArgs e)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open("DSHocSinhTrungTuyen.xlsx");
                IWorksheet worksheet = workbook.Worksheets[0];

                worksheet.Replace("%TUYCHON", cboLoc.Text + " " + cboDoTuoi.Text);
                NamHocDTO namhoc = namHocBUL.layNamHocMoi();

                if (namhoc.TenNamHoc == null) namhoc = namHocBUL.layNamHocTruoc(DateTime.Now.Year.ToString());
                worksheet.Replace("%namhoc", namhoc.TenNamHoc);

                List<HocSinhDTO> dsHocSinh = new List<HocSinhDTO>();
                List<HocSinhDTO> lstHocSinh = dgvDsHsMoi.DataSource as List<HocSinhDTO>;

                if (lstHocSinh != null)
                {
                    foreach (HocSinhDTO h in lstHocSinh)
                    {
                        HocSinhDTO hs = bul.layThongTinMotHocSinh(h.MaHS);
                        if (hs != null)
                        {
                            PhuHuynhDTO ph1 = phuHuynhBUL.layThongTinMotPhuHuynh(hs.MaPH1);
                            PhuHuynhDTO ph2 = phuHuynhBUL.layThongTinMotPhuHuynh(hs.MaPH2);

                            // Thêm thông tin phụ huynh vào học sinh (nếu cần)
                            hs.HoTenPH1 = ph1?.HoTen ?? "N/A";
                            hs.DienThoai1 = "'" + ph1?.DienThoai ?? "N/A";
                            hs.HoTenPH2 = ph2?.HoTen ?? "N/A";
                            hs.DienThoai2 = "'" + ph2?.DienThoai ?? "N/A";

                            // Thêm học sinh vào danh sách
                            dsHocSinh.Add(hs);
                        }
                    }
                }

                //thêm cột số thứ tự
                int stt = 1;
                foreach (HocSinhDTO hs in dsHocSinh)
                {
                    hs.STT = stt;
                    stt++;
                }

                ITemplateMarkersProcessor marker = workbook.CreateTemplateMarkersProcessor();
                marker.AddVariable("Hocsinh", dsHocSinh);
                marker.ApplyMarkers();

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    workbook.Close();
                    excelEngine.Dispose();

                    // Mở Stream bằng Excel
                    try
                    {
                        string tempPath = System.IO.Path.GetTempFileName() + ".xlsx";

                        // Lưu Stream thành file tạm thời
                        System.IO.File.WriteAllBytes(tempPath, memoryStream.ToArray());

                        // Mở file bằng ứng dụng Excel
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = tempPath,
                            UseShellExecute = true // Mở file bằng ứng dụng mặc định
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể mở file Excel: " + ex.Message);
                    }
                }
            }
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
