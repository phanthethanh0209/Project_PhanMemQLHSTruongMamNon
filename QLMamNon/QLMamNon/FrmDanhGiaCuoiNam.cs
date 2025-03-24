using BUL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Transactions;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDanhGiaCuoiNam : Form
    {
        HocSinhBUL hocSinhBUL;
        NamHocBUL namHocBUL;
        LopHocBUL lopHocBUL;
        DanhGiaTuanBUL danhGiaTuanBUL;
        DanhGiaThangBUL danhGiaThangBUL;
        PhanCongBUL phanCongBUL;
        KhoiLopBUL khoiLopBUL;
        GiaoVienBUL giaoVienBUL;
        PhanLopBUL phanLopBUL;
        HoSoHocSinhBUL hoSoHocSinhBUL;

        Guna2MessageDialog message;
        string maND;
        public FrmDanhGiaCuoiNam(string maND)
        {
            InitializeComponent();
            hocSinhBUL = new HocSinhBUL();
            namHocBUL = new NamHocBUL();
            lopHocBUL = new LopHocBUL();
            danhGiaTuanBUL = new DanhGiaTuanBUL();
            danhGiaThangBUL = new DanhGiaThangBUL();
            phanCongBUL = new PhanCongBUL();
            khoiLopBUL = new KhoiLopBUL();
            giaoVienBUL = new GiaoVienBUL();
            phanLopBUL = new PhanLopBUL();
            hoSoHocSinhBUL = new HoSoHocSinhBUL();
            this.maND = maND;
        }

        bool danhGia = true;
        string maLop;
        private void FrmDanhGiaCuoiNam_Load(object sender, System.EventArgs e)
        {
            dgvDSHS.AutoGenerateColumns = false;
            dgvDSHS.AllowUserToAddRows = false;

            //loadCboNamHoc();

            // lấy năm hiện tại
            //NamHocDTO nh = namHocBUL.layNamHocTruoc("2024");
            NamHocDTO nh = namHocBUL.layNamHocMoi();
            if (nh != null)
                lbNamHoc.Text = nh.TenNamHoc;

            //Lấy lớp học của giáo viên
            string maGV = maND;
            PhanCongDTO p = phanCongBUL.layLopGVDayTrongNamHT(maGV, nh.MaNamHoc);
            LopHocDTO lop = lopHocBUL.getLopHocTheoMa(p.MaLop);

            lbMaLop.Text = lop.MaLop;
            lbTenLop.Text = lop.TenLop;
            lbSiSo.Text = lop.SiSo.ToString();
            maLop = p.MaLop;
            guna2GroupBox1.Text = "Danh sách học sinh của lớp " + lop.TenLop;

            List<HocSinhDTO> hocSinhDTOs = hocSinhBUL.layTatCaHocSinhTheoMaLop(maLop);
            dgvDSHS.DataSource = hocSinhDTOs;

            message = new Guna2MessageDialog
            {
                Style = MessageDialogStyle.Light,
            };
            btnDanhGia.Enabled = false;
            txtDanhGia.Enabled = true;
            rdXuatSac.Enabled = true;
            rdNgoan.Enabled = true;
            btnSua.Enabled = false;

            dieuKienDanhGia(nh);
        }

        private void dieuKienDanhGia(NamHocDTO nh)
        {
            // kiểm tra qua thgian kết thúc môn học thì kh cho đánh giá
            if (nh.NgayKT < DateTime.Now)
            {
                btnDanhGia.Enabled = false;
                danhGia = false;
            }
        }


        bool flag = false;
        private void dgvDSHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDSHS.Rows[e.RowIndex];

                lbMaHS.Text = row.Cells["MaHS"].Value.ToString();
                lbTenHS.Text = row.Cells["HoTen"].Value.ToString();

                DateTime ngaysinh = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                int doTuoi = DateTime.Now.Year - ngaysinh.Year;
                lbDoTuoi.Text = doTuoi.ToString();

                HocSinhDTO hsdto = hocSinhBUL.layThongTinMotHocSinh(lbMaHS.Text);
                lbGioiTinh.Text = hsdto.GioiTinh;
                lbCanNang.Text = hsdto.CanNang.ToString() + " kg";
                lbChieuCao.Text = hsdto.ChieuCao.ToString() + " cm";
                string hinhanh = "Upload\\Images\\" + hsdto.HinhAnh;
                UploadHinh(hinhanh);

                HoSoHocSinhDTO hoso = hoSoHocSinhBUL.layHoSoMotHocSinh(lbMaHS.Text);
                lbSucKhoe.Text = hoso.TinhTrangSucKhoe;

                GiaoVienDTO giaoVienDTO = giaoVienBUL.layGVPhuTrachTheoLop(maLop);
                lbTenGV.Text = giaoVienDTO.TenGV;

                // đếm phiếu bé ngoan của mỗi tháng
                DanhGiaThangDTO dto = danhGiaThangBUL.layTongSoPhieuBacHoCuaNam(lbMaHS.Text, maLop);

                lbTienDo.Text = dto.TongSoPhieuTrongNam + " / 9";
                pbTienDo.Reset();
                pbTienDo.Value = (dto.TongSoPhieuTrongNam * 100) / 9;
                pbTienDo.Animated = false;

                txtDanhGia.Text = string.Empty;
                rdNgoan.Checked = false;
                rdXuatSac.Checked = false;

                txtDanhGia.Enabled = true;
                rdXuatSac.Enabled = true;
                rdNgoan.Enabled = true;
                btnDanhGia.Enabled = true;
                btnSua.Enabled = false;

                // xem đánh giá 
                PhanLopDTO plDTO = phanLopBUL.layThongTinDanhGia(lbMaHS.Text, maLop);
                if (!string.IsNullOrEmpty(plDTO.DanhGia))
                {
                    txtDanhGia.Text = plDTO.DanhGia;
                    if (plDTO.XepLoai == rdNgoan.Text) rdNgoan.Checked = true;
                    else if (plDTO.XepLoai == rdXuatSac.Text) rdXuatSac.Checked = true;

                    txtDanhGia.Enabled = false;
                    rdXuatSac.Enabled = false;
                    rdNgoan.Enabled = false;
                    btnDanhGia.Enabled = false;

                    btnSua.Enabled = true;
                }

                // đã kết thúc năm học kh đc đánh giá
                if (!danhGia)
                {
                    txtDanhGia.Enabled = false;
                    rdXuatSac.Enabled = false;
                    rdNgoan.Enabled = false;
                    btnDanhGia.Enabled = false;
                    btnSua.Enabled = false;

                }
            }
        }

        // Hàm để upload và hiển thị hình ảnh
        void UploadHinh(string hinh)
        {
            try
            {
                // Tạo đối tượng Image từ file hình ảnh
                Image selectedImage = Image.FromFile(hinh);

                // Hiển thị hình ảnh lên BunifuImageButton
                txtHinhAnh.Image = selectedImage;

                // Nếu muốn thay đổi kích thước của hình ảnh để phù hợp với kích thước của button:
                txtHinhAnh.Image = new Bitmap(selectedImage, new Size(txtHinhAnh.Width, txtHinhAnh.Height));
            }
            catch (Exception ex)
            {
                message.Parent = this.ParentForm;
                message.Show("Lỗi khi hiển thị hình ảnh: " + ex.Message, "Thông Báo");
            }
        }

        private void resetText()
        {
            lbMaHS.Text = string.Empty;
            rdNgoan.Checked = false;
            rdXuatSac.Checked = false;
            rdNgoan.Enabled = false;
            rdXuatSac.Enabled = false;
            lbDoTuoi.Text = string.Empty;
            lbTenGV.Text = string.Empty;
            lbTienDo.Text = "0 / 9";
            //pbTienDo.Reset();
            pbTienDo.Animated = true;
            lbTenHS.Text = string.Empty;
            btnDanhGia.Enabled = false;
            txtDanhGia.Text = string.Empty;
            txtDanhGia.Enabled = false;
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            DanhGiaThangDTO dto = danhGiaThangBUL.demSoLanDanhGia(lbMaHS.Text, maLop);
            if (dto.TongSoPhieuTrongNam < 9)
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Học sinh chưa được đánh giá đủ qua các tháng!", "Thông Báo");
                return;
            }

            string maHS = lbMaHS.Text;
            string tinhTrang = lbTinhTrang.Text;
            string danhGia = txtDanhGia.Text;
            string xepLoai = "";

            if (rdXuatSac.Checked) xepLoai = rdXuatSac.Text;
            else if (rdNgoan.Checked) xepLoai = rdNgoan.Text;

            if (string.IsNullOrEmpty(danhGia) || string.IsNullOrEmpty(tinhTrang) || string.IsNullOrEmpty(xepLoai))
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Parent = this.ParentForm;
                message.Show("Vui lòng nhập đầy đủ thông tin đánh giá!", "Thông Báo");
                return;
            }
            PhanLopDTO phanLopDTO = new PhanLopDTO(maLop, maHS, danhGia, xepLoai);
            HocSinhDTO hsdto = new HocSinhDTO();
            hsdto.TinhTrang = tinhTrang;
            hsdto.MaHS = maHS;

            message.Buttons = MessageDialogButtons.YesNo;
            message.Icon = MessageDialogIcon.Information;
            message.Parent = this.ParentForm;
            DialogResult r = message.Show("Bạn có muốn lưu đánh giá ?", "Xác nhận");

            if (r == DialogResult.Yes)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        if (!phanLopBUL.CapNhatTTCuoiNam(phanLopDTO))
                        {
                            throw new Exception("Cập nhật trạng thái phân lớp thất bại");
                        }

                        if (!hocSinhBUL.CapNhatTrangThai(hsdto))
                        {
                            throw new Exception("Cập nhật trạng thái học sinh thất bại");
                        }

                        // Nếu tất cả đều thành công, hoàn tất giao dịch
                        scope.Complete();
                        message.Buttons = MessageDialogButtons.OK;
                        message.Icon = MessageDialogIcon.Information;
                        message.Parent = this.ParentForm;
                        message.Show("Đánh giá năm học thành công!", "Thông Báo");

                        txtDanhGia.Enabled = false;
                        rdXuatSac.Enabled = false;
                        rdNgoan.Enabled = false;
                        btnDanhGia.Enabled = false;
                        btnSua.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        message.Buttons = MessageDialogButtons.OK;
                        message.Icon = MessageDialogIcon.Error;
                        message.Parent = this.ParentForm;
                        message.Show(ex.Message, "Thông Báo");

                        //btnSua.Enabled = true;
                    }
                }

            }
        }

        private void rdXuatSac_CheckedChanged(object sender, EventArgs e)
        {
            lbTinhTrang.Text = "Học tiếp";
            int doTuoi = int.Parse(lbDoTuoi.Text);
            if (doTuoi >= 5)
            {
                lbTinhTrang.Text = "Tốt nghiệp";
            }
        }

        private void rdNgoan_CheckedChanged(object sender, EventArgs e)
        {
            lbTinhTrang.Text = "Học tiếp";
            int doTuoi = int.Parse(lbDoTuoi.Text);
            if (doTuoi >= 5)
            {
                lbTinhTrang.Text = "Tốt nghiệp";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtDanhGia.Enabled = true;
            rdXuatSac.Enabled = true;
            rdNgoan.Enabled = true;
            btnDanhGia.Enabled = true;

            btnSua.Enabled = false;
        }

    }
}
