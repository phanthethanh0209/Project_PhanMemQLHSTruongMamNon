using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDSHSCu : Form
    {
        NamHocBUL namHocBUL;
        KhoiLopBUL khoiLopBUL;
        LopHocBUL lopHocBUL;
        HocSinhBUL hocSinhBUL;
        PhanLopBUL phanLopBUL;
        PhanCongBUL phanCongBUL;
        GiaoVienBUL giaoVienBUL;
        public FrmDSHSCu()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle; // Không cho thay đổi kích thước
            MaximizeBox = false; // Ẩn nút phóng to

            namHocBUL = new NamHocBUL();
            khoiLopBUL = new KhoiLopBUL();
            lopHocBUL = new LopHocBUL();
            hocSinhBUL = new HocSinhBUL();
            phanLopBUL = new PhanLopBUL();
            phanCongBUL = new PhanCongBUL();
            giaoVienBUL = new GiaoVienBUL();
        }

        private bool isLoaded = false;
        bool flag = false;
        public string maNamHoc;
        private string tuoiHSCu;
        //string maKhoi;
        bool loadXong = false;
        int siSoConTrong;
        private void FrmLayHSCu_Load(object sender, System.EventArgs e)
        {
            //lấy tên năm học hiện tại
            btnChuyenLop.Enabled = false;
            string namHoc = DateTime.Now.Year.ToString();
            NamHocDTO nam = namHocBUL.layNamHocTruoc(namHoc);
            lbNamHoc.Text = nam.TenNamHoc;

            maNamHoc = nam.MaNamHoc;

            FrmPhanLop frm = (FrmPhanLop)this.Owner;
            //tuoiHSCu = frm.tuoiHSDaChon - 1;
            siSoConTrong = frm.siSoConTrong;
            lbSiSoConTrong.Text = "Sỉ số còn trống: " + siSoConTrong;

            lbKhoiLop.Text = frm.tenKhoiTruoc;
            KhoiLopDTO k = khoiLopBUL.layMaKhoiTheoTenKhoi(frm.tenKhoiTruoc);

            loadCboLopHoc(k.MaKhoi, maNamHoc);
            dgvDSHS.AllowUserToAddRows = false;
            dgvDSHS.AutoGenerateColumns = false;

            loadXong = true;
            ckChon.Enabled = false;
        }
        private void loadCboLopHoc(string maKhoi, string maNamHoc)
        {
            cboLopHoc.DataSource = lopHocBUL.layLopHocTheoKeHoach(maKhoi, maNamHoc);
            cboLopHoc.ValueMember = "MaLop";
            cboLopHoc.DisplayMember = "TenLop";
            cboLopHoc.SelectedIndex = -1;
            // Đặt cờ là true sau khi đã load xong dữ liệu
            isLoaded = true;
        }
        //private void loadCboKhoi(string maNamHoc)
        //{
        //    cboKhoiLop.DataSource = khoiLopBUL.layKhoiLopTrongNam(maNamHoc);
        //    cboKhoiLop.ValueMember = "MaKhoi";
        //    cboKhoiLop.DisplayMember = "TenKhoi";
        //    cboKhoiLop.SelectedIndex = -1;
        //    flag = true;
        //}

        private void dgvDSHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        bool loadXongDS = false;
        private void hienThiDS(string malop)
        {
            FrmPhanLop frmPhanLop = (FrmPhanLop)this.Owner;

            string namHoc = DateTime.Now.Year.ToString();
            NamHocDTO nam = namHocBUL.layNamHocMoi();
            if (nam != null)
            {
                dgvDSHS.AutoGenerateColumns = false;
                dgvDSHS.DataSource = phanLopBUL.layDSHSChuaDuocChonVaChuaPhanLop(frmPhanLop.dsHSDangPhanLop, malop, nam.MaNamHoc);

                loadXongDS = true;
                loadXong = true;
                btnChuyenLop.Enabled = false;

                if (dgvDSHS.Rows.Count <= 0)
                {
                    ckChon.Enabled = false;
                }
                else
                {
                    ckChon.Enabled = true;
                }
            }

        }

        private void hienThiTTLop(string malop)
        {
            PhanCongDTO pcpt_dto = phanCongBUL.layGVPhuTrachTheoLop(malop);
            GiaoVienDTO gvpt_dto = giaoVienBUL.layThongTinMotGV(pcpt_dto.MaGV);

            PhanCongDTO pcht_dto = phanCongBUL.layGVHoTroTheoLop(malop);
            GiaoVienDTO gvht_dto = giaoVienBUL.layThongTinMotGV(pcht_dto.MaGV);

            LopHocDTO l = lopHocBUL.getLopHocTheoMa(malop);

            lbGVPhuTrach.Text = gvpt_dto.TenGV == null ? "Chưa có" : gvpt_dto.TenGV.ToString();
            //lbGVHoTro.Text = gvht_dto.TenGV == null ? "Chưa có" : gvht_dto.TenGV.ToString();
            //lbSiSoLopHT.Text = l.SiSo.ToString();

            ckChon.Enabled = true;
            //int siSoCon = int.Parse(lbSiSoQuyDinh.Text);
            if (dgvDSHS.Rows.Count > siSoConTrong)
            {
                ckChon.Enabled = false;
            }
        }

        private void cboLopHoc_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (isLoaded)
            {
                string maLop = cboLopHoc.SelectedValue.ToString();
                loadXong = false;
                ckChon.Checked = false;
                hienThiTTLop(maLop);
                loadXongDS = false;
                hienThiDS(maLop);
            }
        }

        private void btnChuyenLop_Click(object sender, System.EventArgs e)
        {
            List<HocSinhDTO> danhSachHSChon = new List<HocSinhDTO>();

            foreach (DataGridViewRow row in dgvDSHS.Rows)
            {
                // Kiểm tra nếu ô checkbox được đánh dấu
                if (Convert.ToBoolean(row.Cells[5].Value))
                {
                    string maHS = row.Cells["MaHS"].Value.ToString();
                    string tenHS = row.Cells["HoTen"].Value.ToString();
                    DateTime ngaySinh = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                    string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                    string diaChi = row.Cells["DiaChi"].Value.ToString();
                    HocSinhDTO hocsinh = new HocSinhDTO(maHS, tenHS, gioiTinh, ngaySinh, diaChi);
                    danhSachHSChon.Add(hocsinh);
                }
            }

            // Đếm số lượng học sinh đã chọn
            //FrmPhanLop frmPhanLop = new FrmPhanLop();
            FrmPhanLop frmPhanLop = (FrmPhanLop)this.Owner;
            int siso = frmPhanLop.siSoTD;
            if (danhSachHSChon.Count <= siso)
            {
                frmPhanLop.hienThiDgv(danhSachHSChon);
                this.Hide();
            }
            else
            {
                CustomMessageBox.Show(this, "Số lượng học sinh nhiều hơn sỉ số lớp quy định", "Thông báo");
            }
        }

        //private void cboKhoiLop_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    isLoaded = false;
        //    loadCboLopHoc(maKhoi, maNamHoc);
        //}

        //private void ckChon_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        //{
        //    if (loadXong)
        //    {
        //        foreach (DataGridViewRow row in dgvDSHS.Rows)
        //        {
        //            row.Cells["ChonHS"].Value = ckChon.Checked;
        //        }
        //        btnChuyenLop.Enabled = ckChon.Checked;
        //    }
        //}

        private void dgvDSHS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvDSHS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra cột checkbox và hàng hợp lệ
            if (e.RowIndex >= 0 && dgvDSHS.Columns[e.ColumnIndex].Name == "ChonHS" && loadXongDS)
            {
                int count = 0;
                //int siSoCon = int.Parse(lbSiSoQuyDinh.Text);
                bool isAnyRowSelected = false;
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvDSHS.Rows[e.RowIndex].Cells["ChonHS"];

                if (checkBoxCell.Value == null || !(bool)checkBoxCell.Value)
                {
                    checkBoxCell.Value = true; // Gán giá trị true khi tick
                }
                else
                {
                    checkBoxCell.Value = false; // Gán giá trị false khi bỏ tick
                }

                dgvDSHS.EndEdit(); // Kết thúc chỉnh sửa để cập nhật giá trị ngay lập tức
                                   // Kiểm tra từng dòng
                foreach (DataGridViewRow row in dgvDSHS.Rows)
                {
                    if (row.Cells["ChonHS"] is DataGridViewCheckBoxCell checkBoxCell2)
                    {
                        // Chuyển đổi giá trị checkbox (null sẽ được coi là false)
                        bool isChecked = Convert.ToBoolean(checkBoxCell2.Value);

                        // Đếm số lượng học sinh được tick
                        if (isChecked)
                        {
                            count++;

                            // Nếu vượt quá giới hạn, hiển thị thông báo và reset giá trị checkbox hiện tại
                            if (count > siSoConTrong)
                            {
                                CustomMessageBox.Show(this, "Đã đạt đủ số lượng học sinh!", "Thông Báo");
                                //dgvDSHS.CancelEdit(); // Hủy chỉnh sửa giá trị checkbox đang click
                                checkBoxCell.Value = false;
                                return; // Thoát ngay khi vượt giới hạn
                            }
                        }
                    }
                }

                if (count == 0)
                {
                    ckChon.Checked = false;
                }

                // Cập nhật trạng thái nút (chỉ kích hoạt nếu có ít nhất một checkbox được tick)
                isAnyRowSelected = count > 0;
                btnChuyenLop.Enabled = isAnyRowSelected;
            }
        }

        private void ckChon_CheckedChanged(object sender, EventArgs e)
        {

            if (loadXong)
            {
                foreach (DataGridViewRow row in dgvDSHS.Rows)
                {
                    row.Cells["ChonHS"].Value = ckChon.Checked;
                }
                btnChuyenLop.Enabled = ckChon.Checked;
            }
        }

        private void ckChon_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {

        }
    }
}
