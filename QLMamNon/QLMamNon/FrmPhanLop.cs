using BUL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmPhanLop : Form
    {
        PhanLopBUL phanlopBUL;
        NamHocBUL namHocBUL;
        KhoiLopBUL khoiLopBUL;
        LopHocBUL lopHocBUL;
        PhanCongBUL phanCongBUL;
        GiaoVienBUL giaoVienBUL;
        HocSinhBUL hocSinhBUL;
        KeHoachBUL keHoachBUL;
        NguoiDungBUL nguoiDungBUL;

        string maND;

        public FrmPhanLop(string maND)
        {
            InitializeComponent();

            this.maND = maND;
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPhanLop.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvPhanLop.SelectedRows[0];
                HocSinhDTO selectedHocSinh = (HocSinhDTO)selectedRow.DataBoundItem;

                // Hiển thị xác nhận xóa
                DialogResult result = CustomMessageBox.Show(this.ParentForm, "Bạn có chắc muốn xóa học sinh này?", "Xác nhận", MessageDialogIcon.Question, MessageDialogButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    PhanLopDTO p = new PhanLopDTO(cboLopHoc.SelectedValue.ToString(), selectedHocSinh.MaHS);

                    if (dsHSDangPhanLop.Exists(t => t.MaHS == selectedHocSinh.MaHS))
                    {
                        dsHSTrongLop.Remove(selectedHocSinh);
                        dsHSDangPhanLop.Remove(selectedHocSinh);
                        // Cập nhật lại DataGridView
                        dgvPhanLop.DataSource = null;  // Reset lại datasource
                        dgvPhanLop.DataSource = dsHSTrongLop;  // Gán lại danh sách đã xóa
                        siSoHienTai = dsHSTrongLop.Count;
                        siSoConTrong = siSoTD - siSoHienTai;
                        lbSiSoLopHT.Text = "Sỉ số hiện tại: " + siSoHienTai.ToString();
                        lbSiSoConTrong.Text = "Sỉ số còn trống: " + siSoConTrong.ToString();
                        CustomMessageBox.Show(this.ParentForm, "Xóa học sinh khỏi lớp thành công");
                        return;
                    }

                    using (TransactionScope scope = new TransactionScope())
                    {
                        try
                        {
                            if (!phanlopBUL.Delete(p))
                            {
                                throw new Exception("Bạn không thể xóa học sinh khỏi lớp!");
                            }

                            dsHSTrongLop.Remove(selectedHocSinh);
                            LopHocDTO lophoc = new LopHocDTO(cboLopHoc.SelectedValue.ToString(), dsHSTrongLop.Count, cboKhoiLop.SelectedValue.ToString()); //mốt xem lại

                            if (!lopHocBUL.capNhatLopHoc(lophoc))
                            {
                                throw new Exception("Cập nhật sỉ số lớp thất bại");
                            }

                            scope.Complete();
                            CustomMessageBox.Show(this.ParentForm, "Xóa học sinh khỏi lớp thành công");

                            // Cập nhật lại DataGridView
                            dgvPhanLop.DataSource = null;  // Reset lại datasource
                            dgvPhanLop.DataSource = dsHSTrongLop;  // Gán lại danh sách đã xóa
                            siSoHienTai = dsHSTrongLop.Count;
                            siSoConTrong = siSoTD - siSoHienTai;
                            lbSiSoLopHT.Text = "Sỉ số hiện tại: " + siSoHienTai.ToString();
                            lbSiSoConTrong.Text = "Sỉ số còn trống: " + siSoConTrong.ToString();
                        }

                        catch (Exception ex)
                        {
                            CustomMessageBox.Show(this.ParentForm, ex.Message);
                        }
                    }
                }
            }
        }

        private void dgvDSHS_MouseDown(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem bảng có dòng hay không
            //dgvPhanLop.DataSource.ToString();
            if (dgvPhanLop.Rows.Count > 0)
            {
                //int rowIndex = dgvPhanLop.SelectedRows[0].Index;
                // Kiểm tra xem người dùng có nhấn chuột phải không
                if (e.Button == MouseButtons.Right)
                {
                    // Lấy tọa độ chuột và xác định dòng trong DataGridView
                    DataGridView.HitTestInfo hitTestInfo = dgvPhanLop.HitTest(e.X, e.Y);

                    // Kiểm tra nếu nhấp vào một dòng hợp lệ (RowIndex >= 0)
                    if (hitTestInfo.RowIndex >= 0 && hitTestInfo.RowIndex < dgvPhanLop.Rows.Count)
                    {
                        // Clear selection trước khi chọn dòng mới
                        dgvPhanLop.ClearSelection();

                        // Chọn dòng tương ứng
                        dgvPhanLop.Rows[hitTestInfo.RowIndex].Selected = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dòng dữ liệu nào trong bảng.");
            }

            //if (e.Button == MouseButtons.Right)
            //{
            //    // Kiểm tra nếu DataGridView có dữ liệu
            //    if (dgvPhanLop.Rows.Count > 0)
            //    {
            //        // Lấy tọa độ chuột và xác định dòng trong DataGridView
            //        DataGridView.HitTestInfo hitTestInfo = dgvPhanLop.HitTest(e.X, e.Y);
            //        if (hitTestInfo.RowIndex >= 0)
            //        {
            //            dgvPhanLop.ClearSelection();
            //            dgvPhanLop.Rows[hitTestInfo.RowIndex].Selected = true;
            //        }
            //    }

            //    //// Lấy tọa độ chuột và xác định dòng trong DataGridView
            //    //DataGridView.HitTestInfo hitTestInfo = dgvPhanLop.HitTest(e.X, e.Y);
            //    //if (hitTestInfo.RowIndex >= 0)
            //    //{
            //    //    dgvPhanLop.ClearSelection();
            //    //    dgvPhanLop.Rows[hitTestInfo.RowIndex].Selected = true;
            //    //}
            //}
        }

        public List<string> dsHSDangPhanLop2 = new List<string>();
        public List<HocSinhDTO> dsHSDangPhanLop;
        public List<HocSinhDTO> dsHSTrongLop;
        public int siSoTT { get; set; }
        public int siSoTD { get; set; }
        public int siSoConTrong; //sỉ số tối đa- sỉ số hiện tại 
        public int siSoHienTai;
        public string tuoiTheoKhoi { get; set; }
        public string tenKhoiTruoc { get; set; }
        bool flagHuy = true;


        private void btnDSHSCu_Click(object sender, System.EventArgs e)
        {
            //siSoHienTai = int.Parse(lbSiSoDS.Text);
            siSoConTrong = siSoTD - siSoHienTai;

            string tenKhoi = cboKhoiLop.Text;
            tenKhoiTruoc = "";
            if (tenKhoi == "Lớp Lá") tenKhoiTruoc = "Lớp Chồi";
            if (tenKhoi == "Lớp Mầm") tenKhoiTruoc = "Nhà Trẻ";
            if (tenKhoi == "Lớp Chồi") tenKhoiTruoc = "Lớp Mầm";

            FrmDSHSCu myForm = new FrmDSHSCu();
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.Owner = this;
            myForm.ShowDialog();
        }

        private bool isLoaded = false;
        bool flag = false;
        public string maNamHoc;

        private void FrmPhanLop_Load(object sender, System.EventArgs e)
        {
            dsHSDangPhanLop = new List<HocSinhDTO>();
            phanlopBUL = new PhanLopBUL();
            namHocBUL = new NamHocBUL();
            khoiLopBUL = new KhoiLopBUL();
            lopHocBUL = new LopHocBUL();
            phanCongBUL = new PhanCongBUL();
            giaoVienBUL = new GiaoVienBUL();
            hocSinhBUL = new HocSinhBUL();
            keHoachBUL = new KeHoachBUL();
            nguoiDungBUL = new NguoiDungBUL();

            btnDSHSCu.Enabled = false;
            btnDSHSMoi.Enabled = false;
            btnPhanLop.Enabled = false;
            //btnHuy.Enabled = false;
            btnGuiMail.Enabled = false;

            dgvPhanLop.MouseDown += dgvDSHS_MouseDown;

            // Tạo ContextMenuStrip
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Xóa học sinh");
            contextMenu.Items.Add(deleteMenuItem);

            // Gán ContextMenuStrip vào DataGridView
            dgvPhanLop.ContextMenuStrip = contextMenu;

            // Xử lý sự kiện khi click vào item "Xóa học sinh"
            deleteMenuItem.Click += DeleteMenuItem_Click;

            //lấy tên năm học hiện tại
            NamHocDTO nam = namHocBUL.layNamHocMoi();
            if (nam != null)
            {
                lbNamHoc.Text = nam.TenNamHoc;

                maNamHoc = nam.MaNamHoc;
                loadCboKhoi(nam.MaNamHoc);
            }
        }


        private void hienThiTTLop(string malop)
        {
            PhanCongDTO pcpt_dto = phanCongBUL.layGVPhuTrachTheoLop(malop);
            GiaoVienDTO gvpt_dto = giaoVienBUL.layThongTinMotGV(pcpt_dto.MaGV);

            //PhanCongDTO pcht_dto = phanCongBUL.layGVHoTroTheoLop(malop);
            //GiaoVienDTO gvht_dto = giaoVienBUL.layThongTinMotGV(pcht_dto.MaGV);

            //LopHocDTO l = lopHocBUL.getLopHocTheoMa(malop);


            lbGVPhuTrach.Text = gvpt_dto.TenGV == null ? "Chưa có" : gvpt_dto.TenGV.ToString();
            //lbGVHoTro.Text = gvht_dto.TenGV == null ? "Chưa có" : gvht_dto.TenGV.ToString();
            // lbSiSoQuyDinh.Text = l.SiSo.ToString();
            //lbSiSoQuyDinh.Text = 30.ToString();
        }

        bool loadSiSoLop = false;
        public void hienThiDgv(List<HocSinhDTO> dsHS)
        {
            //đưa vào dsHSDangPhanLop để cập nhật lại
            if (dsHS.Count == 0)
                dsHSTrongLop = hocSinhBUL.layTatCaHocSinhTheoMaLop(cboLopHoc.SelectedValue.ToString());
            dsHSDangPhanLop.AddRange(dsHS); // ds hs mới cbi phân lớp
            dsHSTrongLop.AddRange(dsHS); // ds hs đã tồn tại trong lớp

            dgvPhanLop.DataSource = null;
            dgvPhanLop.AutoGenerateColumns = false;
            dgvPhanLop.AllowUserToAddRows = false;

            if (dsHSTrongLop.Count > 0)
                dgvPhanLop.DataSource = dsHSTrongLop;

            if (dsHSDangPhanLop.Count > 0)
            {
                btnPhanLop.Enabled = true;
                //btnHuy.Enabled = true;
            }

            siSoHienTai = dgvPhanLop.Rows.Count;
            siSoConTrong = siSoTD - siSoHienTai;
            lbSiSoLopHT.Text = "Sỉ số hiện tại: " + siSoHienTai.ToString();
            lbSiSoConTrong.Text = "Sỉ số còn trống: " + siSoConTrong.ToString();
            loadSiSoLop = true;
        }

        private void btnDSHSMoi_Click(object sender, System.EventArgs e)
        {
            //siSoHienTai = dgvPhanLop.Rows.Count;
            siSoConTrong = siSoTD - siSoHienTai;
            FrmDSHSMoi myForm = new FrmDSHSMoi(dsHSDangPhanLop, siSoConTrong, tuoiTheoKhoi);
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.Owner = this;
            myForm.ShowDialog();
        }

        private void btnPhanLop_Click(object sender, System.EventArgs e)
        {
            string maLop = cboLopHoc.SelectedValue.ToString();
            DialogResult result = CustomMessageBox.Show(this.ParentForm, "Bạn có muốn phân các học sinh trong danh sách vào lớp '" + cboLopHoc.Text + "'?", "Xác nhận", MessageDialogIcon.Question, MessageDialogButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (siSoHienTai < siSoTT || siSoHienTai > siSoTD)
                {
                    CustomMessageBox.Show(this.ParentForm, "Sỉ số lớp phải >= sỉ số tối thiểu và <= sỉ số tối đa");
                    return;
                }

                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        foreach (HocSinhDTO hs in dsHSDangPhanLop)
                        {
                            //string maHS = row.Cells["MaHS"].Value.ToString();
                            string maHS = hs.MaHS;

                            PhanLopDTO phanLop = new PhanLopDTO(maLop, maHS, null, null); //mốt xem lại
                            LopHocDTO lophoc = new LopHocDTO(maLop, dgvPhanLop.Rows.Count, cboKhoiLop.SelectedValue.ToString()); //mốt xem lại

                            if (!phanlopBUL.Insert(phanLop))
                            {
                                throw new Exception("Thêm lớp học thất bại!");
                            }

                            if (!lopHocBUL.capNhatLopHoc(lophoc))
                            {
                                throw new Exception("Cập nhật sỉ số lớp thất bại!");
                            }
                        }

                        scope.Complete();
                        CustomMessageBox.Show(this.ParentForm, "Phân lớp thành công");
                        btnPhanLop.Enabled = false;
                        dsHSDangPhanLop = new List<HocSinhDTO>();
                        dgvPhanLop.DataSource = null;  // Reset lại datasource
                        dgvPhanLop.DataSource = dsHSTrongLop;
                        siSoHienTai = dgvPhanLop.Rows.Count;
                        siSoConTrong = siSoTD - siSoHienTai;
                        lbSiSoLopHT.Text = "Sỉ số hiện tại: " + siSoHienTai.ToString();
                        lbSiSoConTrong.Text = "Sỉ số còn trống: " + siSoConTrong.ToString();
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show(this.ParentForm, ex.Message);
                    }
                }
            }
        }

        private void loadCboKhoi(string maNamHoc)
        {
            cboKhoiLop.DataSource = khoiLopBUL.layKhoiLopTrongNam(maNamHoc);
            cboKhoiLop.ValueMember = "MaKhoi";
            cboKhoiLop.DisplayMember = "TenKhoi";
            cboKhoiLop.SelectedIndex = -1;

            cboLopHoc.Enabled = false;
            flag = true;
        }

        private void cboKhoiLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                string maKhoi = cboKhoiLop.SelectedValue.ToString();
                isLoaded = false;

                loadCboLopHoc(maKhoi, maNamHoc);
                cboLopHoc.Enabled = true;

                KhoiLopDTO k = khoiLopBUL.layTenKhoiTheoMa(maKhoi);
                tuoiTheoKhoi = k.DoTuoi;

                dgvPhanLop.DataSource = null;
                dgvPhanLop.AllowUserToAddRows = false;
            }
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

        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsHSDangPhanLop.Clear();

            btnDSHSCu.Enabled = false;
            btnDSHSMoi.Enabled = false;
            if (isLoaded)
            {
                string maLop = cboLopHoc.SelectedValue.ToString();
                hienThiTTLop(maLop);
                hienThiDgv(new List<HocSinhDTO>());

                KeHoachDTO k = keHoachBUL.layTTKeHoach(maNamHoc, cboKhoiLop.SelectedValue.ToString());
                siSoTD = k.SiSoToiDa;
                siSoTT = k.SiSoToiThieu;
                lbSiSoTD.Text = "Sỉ số tối đa: " + siSoTD.ToString();
                lbSiSoTT.Text = "Sỉ số tối thiểu: " + siSoTT.ToString();

                LopHocDTO lh = lopHocBUL.getLopHocTheoMa(cboLopHoc.SelectedValue.ToString());
                lbSiSoLopHT.Text = "Sỉ số hiện tại: " + lh.SiSo.ToString();
                siSoHienTai = lh.SiSo;
                siSoConTrong = siSoTD - siSoHienTai;
                lbSiSoConTrong.Text = "Sỉ số còn trống: " + siSoConTrong.ToString();


                if (lh.SiSo < siSoTD)
                {
                    btnDSHSCu.Enabled = false;
                    if (tuoiTheoKhoi != "1-2") //nếu là khối nhà trẻ thì ko chọn được nút DS HS cũ
                    {
                        btnDSHSCu.Enabled = true;
                    }
                    btnDSHSMoi.Enabled = true;
                }

                if (dgvPhanLop.Rows.Count > 0 && lbGVPhuTrach.Text != "Chưa có")
                {
                    btnGuiMail.Enabled = true;
                }
                else
                {
                    btnGuiMail.Enabled = false;
                }
            }
            else
            {
                //siSoHienTai = 0;
                lbSiSoConTrong.Text = "Sỉ số còn trống: ";
                lbSiSoLopHT.Text = "Sỉ số hiện tại: ";
                lbSiSoTD.Text = "Sỉ số tối đa: ";
                lbSiSoTT.Text = "Sỉ số tối thiểu: ";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            flag = false;
            //flagHuy = false;
            isLoaded = false;
            cboLopHoc.SelectedIndex = -1;
            cboKhoiLop.SelectedIndex = -1;
            cboLopHoc.Enabled = false;

            dgvPhanLop.DataSource = null;
            lbSiSoConTrong.Text = "Sỉ số còn trống: ";
            lbSiSoLopHT.Text = "Sỉ số hiện tại: ";
            lbSiSoTD.Text = "Sỉ số tối đa: ";
            lbSiSoTT.Text = "Sỉ số tối thiểu: ";
            isLoaded = true;
            flag = true;
        }


        private void dgvPhanLop_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //siSoHienTai = dgvPhanLop.Rows.Count;
            //lbSiSoLopHT.Text = "Sỉ số hiện tại: " + siSoHienTai.ToString();

            if (dgvPhanLop.Rows.Count > 0)
            {
                siSoHienTai = dgvPhanLop.Rows.Count;
                lbSiSoLopHT.Text = "Sỉ số hiện tại: " + siSoHienTai.ToString();
            }
            else
            {
                lbSiSoLopHT.Text = "Sỉ số hiện tại: 0";
            }


        }

        private void lbSiSoLopHT_TextChanged(object sender, EventArgs e)
        {
            if (loadSiSoLop)
            {
                //int siSoQD = int.Parse(lbSiSoTD.Text);
                //int siSoHT = int.Parse(lbSiSoLopHT.Text);

                if (tuoiTheoKhoi != "1-2") //nếu là khối nhà trẻ thì ko chọn được nút DS HS cũ
                {
                    btnDSHSCu.Enabled = true;
                }

                btnDSHSMoi.Enabled = true;
                if (siSoHienTai >= siSoTD)
                {
                    btnDSHSCu.Enabled = false;
                    btnDSHSMoi.Enabled = false;
                }
            }
        }

        private void dgvPhanLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhanLop.SelectedRows.Count > 0)
            {

            }
        }

        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            FrmGuiMail f = new FrmGuiMail(cboLopHoc.SelectedValue.ToString(), maNamHoc, maND, cboLopHoc.Text);
            f.ShowDialog();
        }
    }
}
