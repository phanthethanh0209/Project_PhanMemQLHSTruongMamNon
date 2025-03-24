using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmXacNhanDiemDanh : Form
    {
        DiemDanhBUL diemDanhBUL;
        HocSinhBUL hocSinhBUL;
        List<DiemDanhDTO> dshs;
        private FrmDiemDanh frmCha;
        public FrmXacNhanDiemDanh()
        {
            InitializeComponent();

            diemDanhBUL = new DiemDanhBUL();
            hocSinhBUL = new HocSinhBUL();
        }

        DateTime ngaydd;
        string malop;
        public FrmXacNhanDiemDanh(List<DiemDanhDTO> danhSachHSVang, DateTime ngayDiemDanh, string maLop, FrmDiemDanh frmCha)
        {
            InitializeComponent();

            diemDanhBUL = new DiemDanhBUL();
            hocSinhBUL = new HocSinhBUL();

            dshs = danhSachHSVang;

            ngaydd = ngayDiemDanh;
            int ngay = ngaydd.Day;
            int thang = ngaydd.Month;
            int nam = ngaydd.Year;
            string ngayThangNam = $"ngày {ngay} tháng {thang} năm {nam}";
            txtNgayDiemDanh.Text = ngayThangNam;
            malop = maLop;
            this.frmCha = frmCha;
        }

        public FrmXacNhanDiemDanh(List<DiemDanhDTO> danhSachHSVang, DateTime ngayDiemDanh, int daDiemDanh, string maLop, FrmDiemDanh frmCha)
        {
            InitializeComponent();

            diemDanhBUL = new DiemDanhBUL();
            hocSinhBUL = new HocSinhBUL();

            dshs = danhSachHSVang;
            ngaydd = ngayDiemDanh;
            int ngay = ngaydd.Day;
            int thang = ngaydd.Month;
            int nam = ngaydd.Year;
            string ngayThangNam = $"ngày {ngay} tháng {thang} năm {nam}";
            txtNgayDiemDanh.Text = ngayThangNam;
            malop = maLop;

            if (daDiemDanh > 0)
                label1.Text = "Cập nhật điểm danh";
            this.frmCha = frmCha;

        }

        private void FrmXacNhanDiemDanh_Load(object sender, System.EventArgs e)
        {
            dgvDSHS.ReadOnly = true;
            LoadDGV();
        }

        private void LoadDGV()
        {

            dgvDSHS.AutoGenerateColumns = false;
            dgvDSHS.AllowUserToAddRows = false;
            dgvDSHS.DataSource = null; // Xóa dữ liệu cũ (nếu có)

            foreach (DiemDanhDTO hs in dshs)
            {
                // Tạo một hàng mới trong DataGridView
                int rowIndex = dgvDSHS.Rows.Add();
                DataGridViewRow row = dgvDSHS.Rows[rowIndex];
                HocSinhDTO dto = hocSinhBUL.layThongTinMotHocSinh(hs.MaHS);

                row.Cells["MaHS"].Value = dto.MaHS;
                row.Cells["HoTen"].Value = dto.HoTen;
                row.Cells["NgaySinh"].Value = dto.NgaySinh.ToString("dd/MM/yyyy"); // Gán ngày sinh
                row.Cells["VangCP"].Value = false;
                row.Cells["VangKPhep"].Value = false;

                if (hs.VangKPhep == 0)
                {
                    row.Cells["VangKPhep"].Value = true;
                }
                else if (hs.VangKPhep == 1)
                {
                    row.Cells["VangCP"].Value = true;
                }
                row.Cells["GhiChu"].Value = hs.GhiChu;
            }

            dgvDSHS.ReadOnly = true;
        }

        List<DiemDanhDTO> danhSachHSVang;
        private void btnLuu_Click(object sender, System.EventArgs e)
        {
            bool flag = true;
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (DiemDanhDTO hs in dshs)
                {
                    int vang = -1;
                    if (hs.VangKPhep != null)
                        vang = Convert.ToBoolean(hs.VangKPhep) ? 1 : 0;
                    DiemDanhDTO d = new DiemDanhDTO(hs.MaDiemDanh, hs.MaLop, hs.MaHS, hs.NgayDiemDanh, vang, hs.GhiChu);
                    string ngayDiemDanhStr = ngaydd.ToString("yyyy-MM-dd");
                    danhSachHSVang = diemDanhBUL.layTatCaHSVangTheoNgay(malop, ngayDiemDanhStr);
                    if (danhSachHSVang.Exists(t => t.MaDiemDanh.Trim() == d.MaDiemDanh && d.VangKPhep == -1))
                    {
                        // xóa
                        if (!diemDanhBUL.xoaDiemDanh(d))
                        {
                            flag = false;
                        }
                    }
                    else if (danhSachHSVang.Exists(t => t.MaDiemDanh.Trim() == d.MaDiemDanh && (t.VangKPhep != d.VangKPhep || t.GhiChu != d.GhiChu)))
                    { // cập nhật thông tin vắng
                        if (!diemDanhBUL.capNhatDiemDanh(d))
                        {
                            flag = false;
                        }
                    }
                    else if (danhSachHSVang.Exists(t => t.MaDiemDanh != d.MaDiemDanh) || danhSachHSVang.Count == 0)
                    {
                        // thêm
                        if (!diemDanhBUL.InsertDiemDanh(d))
                        {
                            flag = false;
                        }
                    }
                }

                if (!flag)
                {
                    MessageBox.Show("Điểm danh thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Điểm danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCha.LoadDGV();
                    this.Close();
                }

                scope.Complete();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
