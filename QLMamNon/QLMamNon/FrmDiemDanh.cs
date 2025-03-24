using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDiemDanh : Form
    {
        DiemDanhBUL diemDanhBUL;
        NamHocBUL namHocBUL;
        LopHocBUL lopHocBUL;
        PhanCongBUL phanCongBUL;
        KhoiLopBUL khoiLopBUL;
        GiaoVienBUL giaoVienBUL;
        PhanLopBUL phanLopBUL;
        HocSinhBUL hocSinhBUL;

        string maGV;
        public FrmDiemDanh(string maND)
        {
            InitializeComponent();
            maGV = maND;

            if (string.IsNullOrEmpty(maGV))
            {
                MessageBox.Show("Bạn không có quyền truy cập!");
                return;
            }
        }

        string maLop;
        private void FrmDiemDanh_Load(object sender, EventArgs e)
        {
            namHocBUL = new NamHocBUL();
            lopHocBUL = new LopHocBUL();
            phanCongBUL = new PhanCongBUL();
            khoiLopBUL = new KhoiLopBUL();
            giaoVienBUL = new GiaoVienBUL();
            phanLopBUL = new PhanLopBUL();
            hocSinhBUL = new HocSinhBUL();
            diemDanhBUL = new DiemDanhBUL();

            //string maGV = "ND001";

            NamHocDTO namHocDTO = namHocBUL.layNamHocMoi();
            if (namHocDTO != null)
            {
                lbNamHoc.Text = namHocDTO.TenNamHoc;
                PhanCongDTO pc = phanCongBUL.layLopGVDayTrongNamHT(maGV, namHocDTO.MaNamHoc);

                maLop = pc.MaLop;
                LopHocDTO l = lopHocBUL.getLopHocTheoMa(maLop);
                KhoiLopDTO k = khoiLopBUL.layTenKhoiTheoMa(l.MaKhoi);

                lbKhoiLop.Text = k.TenKhoi;
                lbLopHoc.Text = l.TenLop;

                GiaoVienDTO giaoVienDTO = giaoVienBUL.layThongTinMotGV(maGV);
                lbGVPhuTrach.Text = giaoVienDTO.TenGV;

                txtNgayDiemDanh.Value = DateTime.Now;
                btnLuu.Enabled = true;

                LoadDGV();
            }


            //lbSoHSVang.Text = "0";
        }

        public void LoadDGV()
        {
            DateTime ngayDiemDanh = txtNgayDiemDanh.Value.Date; // Lấy giá trị ngày không có thời gian
            string ngayDiemDanhStr = ngayDiemDanh.ToString("yyyy-MM-dd");
            int soHSVang = diemDanhBUL.demSoHSVangTheoNgay(maLop, ngayDiemDanhStr);
            lbSoHSVang.Text = soHSVang.ToString();

            // Gọi phương thức lấy danh sách điểm danh theo ngày
            List<DiemDanhDTO> dsDiemDanh = diemDanhBUL.layThongTinDiemDanhTheoNgay(maLop, ngayDiemDanhStr, null);
            if (dsDiemDanh.Count > 0)
            {
                loadDSDaDiemDanh(dsDiemDanh);
            }
        }

        List<DiemDanhDTO> danhSachHSVang;
        private void themHSVangVaoList()
        {
            danhSachHSVang = new List<DiemDanhDTO>();
            string maDiemDanh;
            string ngayThangNam = "";

            foreach (DataGridViewRow row in dgvDSHS.Rows)
            {
                if (Convert.ToBoolean(row.Cells["VangKPhep"].Value) || Convert.ToBoolean(row.Cells["VangCP"].Value))
                {
                    string maHS = row.Cells["MaHS"].Value.ToString();
                    string tenHS = row.Cells["HoTen"].Value.ToString();
                    //DateTime ngaySinh = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                    string ghiChu = row.Cells["GhiChu"].Value?.ToString();
                    int vang = Convert.ToBoolean(row.Cells["VangKPhep"].Value) ? 0 : 1;

                    ngayThangNam = txtNgayDiemDanh.Value.ToString("ddMMyy");
                    maDiemDanh = diemDanhBUL.TaoMaDiemDanh(maLop, ngayThangNam, maHS);

                    DiemDanhDTO d = new DiemDanhDTO(maDiemDanh, maLop, maHS, txtNgayDiemDanh.Value, vang, ghiChu);
                    danhSachHSVang.Add(d);
                }

            }
        }


        List<DiemDanhDTO> dsCapNhatVang;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            DateTime ngayDiemDanh = txtNgayDiemDanh.Value.Date; // Lấy giá trị ngày không có thời gian
            string ngayDiemDanhStr = ngayDiemDanh.ToString("yyyy-MM-dd");
            int xetDiemDanhChua = diemDanhBUL.demSoHSVangTheoNgay(maLop, ngayDiemDanhStr);

            FrmXacNhanDiemDanh myForm = new FrmXacNhanDiemDanh();
            if (xetDiemDanhChua == 0) // chưa điểm danh ngày đó 
            {
                themHSVangVaoList();
                if (danhSachHSVang.Count <= 0)
                {
                    DialogResult r = MessageBox.Show("Bạn có chắc muốn lưu điểm danh?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        MessageBox.Show("Điểm danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    return;
                }

                myForm = new FrmXacNhanDiemDanh(danhSachHSVang, ngayDiemDanh, maLop, this);

            }
            else // điểm danh ngày đó rồi -> thì chỉ thêm hs vắng mới hoặc xóa 
            {
                dsCapNhatVang = new List<DiemDanhDTO>();
                danhSachHSVang = diemDanhBUL.layTatCaHSVangTheoNgay(maLop, ngayDiemDanhStr);
                foreach (DataGridViewRow row in dgvDSHS.Rows)
                {
                    string maHS = row.Cells["MaHS"].Value.ToString();
                    string tenHS = row.Cells["HoTen"].Value.ToString();
                    //DateTime ngaySinh = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                    string ghiChu = row.Cells["GhiChu"].Value == null ? null : row.Cells["GhiChu"].Value.ToString();
                    string ngaydd = txtNgayDiemDanh.Value.ToString("ddMMyy");
                    string maDiemDanh = diemDanhBUL.TaoMaDiemDanh(maLop, ngaydd, maHS);
                    if (Convert.ToBoolean(row.Cells["VangKPhep"].Value) || Convert.ToBoolean(row.Cells["VangCP"].Value))
                    { // thêm hs vắng mới
                        int vang = Convert.ToBoolean(row.Cells["VangKPhep"].Value) ? 0 : 1;

                        DiemDanhDTO d = new DiemDanhDTO(maDiemDanh, maLop, maHS, txtNgayDiemDanh.Value, vang, ghiChu);

                        if (!danhSachHSVang.Exists(t => t.MaDiemDanh.Trim() == d.MaDiemDanh)) // thêm hs vắng mới
                        {
                            dsCapNhatVang.Add(d);
                        }
                        else if (danhSachHSVang.Exists(t => t.MaDiemDanh.Trim() == d.MaDiemDanh && (t.VangKPhep != d.VangKPhep || t.GhiChu != d.GhiChu)))
                        { // cập nhật thông tin vắng
                            dsCapNhatVang.Add(d);
                        }
                    }
                    else // kh chọn vắng -> xóa hs khỏi điểm danh
                    {
                        DiemDanhDTO d = new DiemDanhDTO(maDiemDanh, maLop, maHS, txtNgayDiemDanh.Value, ghiChu);

                        if (danhSachHSVang.Exists(t => t.MaDiemDanh.Trim() == d.MaDiemDanh)) // thêm hs vắng mới
                        {
                            dsCapNhatVang.Add(d);
                        }
                    }

                    // điểm danh lại -> hs kh vắng -> xóa 

                    // điểm danh lại -> sửa tt vắng của hs -> cập nhật
                }

                myForm = new FrmXacNhanDiemDanh(dsCapNhatVang, ngayDiemDanh, xetDiemDanhChua, maLop, this);
            }

            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.ShowDialog();
            //LoadDGV();
        }

        private void bunifuGroupBox3_Enter(object sender, EventArgs e)
        {

        }

        int soHS = 0;
        private void dgvDSHS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //lbSoHSVang.Text = diemDanhBUL.demSoHSVangTheoNgay();
            if (e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell checkBoxCell1 = (DataGridViewCheckBoxCell)dgvDSHS.Rows[e.RowIndex].Cells["VangCP"];
                DataGridViewCheckBoxCell checkBoxCell2 = (DataGridViewCheckBoxCell)dgvDSHS.Rows[e.RowIndex].Cells["VangKPhep"];

                if (e.ColumnIndex == checkBoxCell1.ColumnIndex && (bool)checkBoxCell1.Value)
                {
                    checkBoxCell2.Value = false;
                }
                else if (e.ColumnIndex == checkBoxCell2.ColumnIndex && (bool)checkBoxCell2.Value)
                {
                    checkBoxCell1.Value = false;
                }

            }
        }

        private void dgvDSHS_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDSHS.IsCurrentCellDirty)
            {
                dgvDSHS.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void txtNgayDiemDanh_ValueChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            // Kiểm tra nếu ngày chọn lớn hơn ngày hiện tại
            if (txtNgayDiemDanh.Value > DateTime.Now)
            {
                //MessageBox.Show("Bạn không được điểm danh vào ngày tương lai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CustomMessageBox.Show(this.ParentForm, "Chỉ được đánh giá ngày hiện tại!", "Lưu ý", Guna.UI2.WinForms.MessageDialogIcon.Warning);
                txtNgayDiemDanh.Value = DateTime.Now; // Đặt lại ngày thành hôm nay
                dgvDSHS.ReadOnly = false;
                btnLuu.Enabled = true;
                return; // Thoát ra nếu là ngày tương lai
            }
        }


        private void loadDSDaDiemDanh(List<DiemDanhDTO> dsDiemDanh)
        {
            dgvDSHS.AutoGenerateColumns = false;
            dgvDSHS.AllowUserToAddRows = false;
            dgvDSHS.DataSource = null;
            dgvDSHS.Rows.Clear();
            danhSachHSVang = new List<DiemDanhDTO>();
            foreach (DiemDanhDTO hs in dsDiemDanh)
            {
                // Tạo một hàng mới trong DataGridView
                int rowIndex = dgvDSHS.Rows.Add();
                DataGridViewRow row = dgvDSHS.Rows[rowIndex];
                HocSinhDTO dto = hocSinhBUL.layThongTinMotHocSinh(hs.MaHS);

                row.Cells["MaHS"].Value = dto.MaHS;
                row.Cells["HoTen"].Value = dto.HoTen;
                row.Cells["NgaySinh"].Value = dto.NgaySinh.ToString("dd/MM/yyyy"); // Gán ngày sinh

                row.Cells["VangCP"].Value = false;
                row.Cells["VangCP"].Value = false;
                if (hs.VangKPhep == 1)
                {
                    row.Cells["VangCP"].Value = true;
                }
                else if (hs.VangKPhep == 0)
                {
                    row.Cells["VangKPhep"].Value = true;
                }
                row.Cells["GhiChu"].Value = hs.GhiChu;
            }

            dgvDSHS.ReadOnly = false;
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;

            DateTime ngayDiemDanh = txtNgayDiemDanh.Value.Date; // Lấy giá trị ngày không có thời gian
            string ngayDiemDanhStr = ngayDiemDanh.ToString("yyyy-MM-dd");
            int soHSVang = diemDanhBUL.demSoHSVangTheoNgay(maLop, ngayDiemDanhStr);
            lbSoHSVang.Text = soHSVang.ToString();

            btnLuu.Enabled = true;
            List<DiemDanhDTO> diemDanhDTOs = new List<DiemDanhDTO>();
            //string ngayDiemDanhStr = ngayDiemDanh.ToString("yyyy-MM-dd");
            if (ngayDiemDanh == DateTime.Now.Date)
            {
                // tìm kiếm trong ds hs chứ kh trong điểm danh
                diemDanhDTOs = diemDanhBUL.layThongTinDiemDanhTheoNgay(maLop, ngayDiemDanhStr, txtTimKiem.Text);

            }
            else
            {
                diemDanhDTOs = diemDanhBUL.timKiemHocSinhTheoMaTenNgay(maLop, ngayDiemDanhStr, txtTimKiem.Text);
            }

            loadDSDaDiemDanh(diemDanhDTOs);

            if (txtNgayDiemDanh.Value.Date != DateTime.Now.Date)
            {
                CustomMessageBox.Show(this.ParentForm, "Chỉ được điểm danh ngày hiện tại!", "Lưu ý", Guna.UI2.WinForms.MessageDialogIcon.Warning);
                btnLuu.Enabled = false;
                dgvDSHS.ReadOnly = true;
            }
        }

    }
}
