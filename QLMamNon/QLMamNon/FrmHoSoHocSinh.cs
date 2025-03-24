using BUL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmHoSoHocSinh : Form
    {
        HoSoHocSinhBUL hoSoHSBUL = new HoSoHocSinhBUL();
        HocSinhBUL hocSinhBUL = new HocSinhBUL();
        PhuHuynhBUL phuHuynhBUL = new PhuHuynhBUL();
        NamHocBUL namHocBUL = new NamHocBUL();
        MessageBoxCustome message;

        public FrmHoSoHocSinh()
        {
            InitializeComponent();
            message = new MessageBoxCustome();
            //txtNamSinh2.KeyPress += new KeyPressEventHandler(txtNamSinh2_KeyPress);
        }

        // Hàm này được gọi từ FrmDsHsMoi để hiển thị thông tin học sinh
        public void HienThiThongTinHocSinh(string maHS)
        {
            if (!string.IsNullOrEmpty(maHS))
            {
                HocSinhDTO hs = hocSinhBUL.layThongTinMotHocSinh(maHS);
                HoSoHocSinhDTO hoSo = hoSoHSBUL.layHoSoMotHocSinh(maHS);
                PhuHuynhDTO ph1 = phuHuynhBUL.layThongTinMotPhuHuynh(hs.MaPH1);
                PhuHuynhDTO ph2 = phuHuynhBUL.layThongTinMotPhuHuynh(hs.MaPH2);

                if (hs != null && hoSo != null && ph1 != null && ph2 != null)
                {
                    // Hiển thị thông tin học sinh lên các trường tương ứng
                    txtMaHS.Text = hs.MaHS;
                    txtMaPH1.Text = hs.MaPH1;
                    txtMaPH2.Text = hs.MaPH2;
                    txtHoTen.Text = hs.HoTen;
                    cboGioiTinh.SelectedIndex = hs.GioiTinh == "Nữ" ? 0 : 1;
                    txtNgaySinh.Text = hs.NgaySinh.ToString();
                    txtChoOHienNay.Text = hs.DiaChi;
                    txtChieuCao.Text = hs.ChieuCao.ToString();

                    anHienTextBox(false);
                    hinhAnh = hs.HinhAnh;
                    UploadHinh("Upload\\Images\\" + hinhAnh);

                    txtCanNang.Text = hs.CanNang.ToString();
                    //txtNgayNhapHoc.Text = hs.NgayNhapHoc.ToString();
                    txtGhiChu.Text = hs.GhiChu;
                    //cboTrangThai.SelectedIndex = hs.TinhTrang == "Đang học" ? 0 : 1;


                    txtMaDinhDanh.Text = hoSo.MaDinhDanh;
                    txtQuocTich.Text = hoSo.QuocTich;
                    txtDanToc.Text = hoSo.DanToc;
                    txtTonGiao.Text = hoSo.TonGiao;
                    txtQueQuan.Text = hoSo.QueQuan;
                    txtNoiSinh.Text = hoSo.NoiSinh;
                    txtTinhTrangSK.Text = hoSo.TinhTrangSucKhoe;
                    lbDonXinNhapHoc.Text = hoSo.DonXinNhapHoc;
                    lbGiayKhaiSinh.Text = hoSo.GiayKhaiSinh;

                    txtHoTen1.Text = ph1.HoTen;
                    cboGioiTinh1.SelectedIndex = ph1.GioiTinh == "Nữ" ? 0 : 1;
                    txtNamSinh1.Text = ph1.NamSinh.ToString();
                    txtDiaChi1.Text = ph1.DiaChiCQ;
                    txtNgheNghiep1.Text = ph1.NgheNghiep;
                    txtDienThoai1.Text = ph1.DienThoai;
                    txtEmail1.Text = ph1.Email;
                    cboQuanHe1.Text = ph1.QuanHe;

                    txtHoTen2.Text = ph2.HoTen;
                    cboGioiTinh2.SelectedIndex = ph2.GioiTinh == "Nữ" ? 0 : 1;
                    txtNamSinh2.Text = ph2.NamSinh.ToString();
                    txtDiaChi2.Text = ph2.DiaChiCQ;
                    txtNgheNghiep2.Text = ph2.NgheNghiep;
                    txtDienThoai2.Text = ph2.DienThoai;
                    txtEmail2.Text = ph1.Email;
                    cboQuanHe2.Text = ph2.QuanHe;

                }
                else
                {
                    message.Parent = this.ParentForm;
                    message.ShowError("Không tìm thấy thông tin học sinh.", "Thông Báo");
                }
            }
        }


        private void FrmHoSoHocSinh_Load(object sender, EventArgs e)
        {
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("Nam");

            cboGioiTinh1.Items.Add("Nữ");
            cboGioiTinh1.Items.Add("Nam");

            cboGioiTinh2.Items.Add("Nữ");
            cboGioiTinh2.Items.Add("Nam");


            cboQuanHe1.Items.Add("Ba");
            cboQuanHe1.Items.Add("Mẹ");
            cboQuanHe1.Items.Add("Ông");
            cboQuanHe1.Items.Add("Bà");
            cboQuanHe1.Items.Add("Anh");
            cboQuanHe1.Items.Add("Chị");
            cboQuanHe1.Items.Add("Chú");
            cboQuanHe1.Items.Add("Cô");


            cboQuanHe2.Items.Add("Ba");
            cboQuanHe2.Items.Add("Mẹ");
            cboQuanHe2.Items.Add("Ông");
            cboQuanHe2.Items.Add("Bà");
            cboQuanHe2.Items.Add("Anh");
            cboQuanHe2.Items.Add("Chị");
            cboQuanHe2.Items.Add("Chú");
            cboQuanHe2.Items.Add("Cô");

            cboQuanHe1.SelectedIndex = -1;
            cboQuanHe2.SelectedIndex = -1;
            //cboTrangThai.Items.Add("Đang học");
            //cboTrangThai.Items.Add("Nghỉ học");

            //Luôn luôn ẩn textbox
            txtMaHS.Enabled = false;
            txtMaPH1.Enabled = false;
            txtMaPH2.Enabled = false;

            //Mặc định ẩn textbox
            anHienTextBox(false);
            string hinhanh = "Upload\\Images\\imageInit.png";
            UploadHinh(hinhanh);

        }

        string tacVu = "Xem";
        private void btnThem_Click(object sender, EventArgs e)
        {
            tacVu = "Them";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            resetText();
            anHienTextBox(true);
            hinhAnh = "Upload\\Images\\imageInit.png";
            UploadHinh(hinhAnh);

            //tạo mã
            //lấy năm học hiện tại
            NamHocDTO nh = namHocBUL.layNamHocMoi();
            if (nh.MaNamHoc != null)
            {
                txtMaHS.Text = hocSinhBUL.TaoMaHS(nh.MaNamHoc);
                txtMaPH1.Text = phuHuynhBUL.TaoMaPH1(txtMaHS.Text.Trim());
                txtMaPH2.Text = phuHuynhBUL.TaoMaPH2(txtMaHS.Text.Trim());
            }
            else
            {
                NamHocDTO nhCu = namHocBUL.layNamHocTruoc(DateTime.Now.Year.ToString());
                if (nhCu.MaNamHoc != null)
                {
                    txtMaHS.Text = hocSinhBUL.TaoMaHS(nhCu.MaNamHoc);
                    txtMaPH1.Text = phuHuynhBUL.TaoMaPH1(txtMaHS.Text.Trim());
                    txtMaPH2.Text = phuHuynhBUL.TaoMaPH2(txtMaHS.Text.Trim());
                }
            }


            //mở textbox
            //cboTrangThai.SelectedIndex = 0;
            //cboTrangThai.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tacVu = "Sua";
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            anHienTextBox(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            tacVu = "Xoa";
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            anHienTextBox(false);
        }

        void resetText()
        {
            txtMaHS.Clear();
            txtMaPH1.Clear();
            txtMaPH2.Clear();
            txtHoTen.Clear();
            cboGioiTinh.SelectedIndex = -1;
            txtNgaySinh.Value = DateTime.Now;
            txtChoOHienNay.Clear();
            txtChieuCao.Clear();
            hinhAnh = "Upload\\Images\\imageInit.png";
            UploadHinh(hinhAnh);
            txtCanNang.Clear();
            // txtNgayNhapHoc.Value = DateTime.Now;
            txtGhiChu.Clear();
            txtTinhTrangSK.Clear();

            lbDonXinNhapHoc.Text = "";
            lbGiayKhaiSinh.Text = "";
            // cboTrangThai.SelectedIndex = -1;

            txtMaHS.Clear();
            txtMaDinhDanh.Clear();
            txtQuocTich.Clear();
            txtDanToc.Clear();
            txtTonGiao.Clear();
            txtQueQuan.Clear();
            txtNoiSinh.Clear();
            txtTinhTrangSK.Clear();

            txtMaPH1.Clear();
            txtMaPH2.Clear();
            txtHoTen1.Clear();
            txtHoTen2.Clear();
            cboGioiTinh1.SelectedIndex = -1;
            cboGioiTinh2.SelectedIndex = -1;
            txtNamSinh1.Clear();
            txtNamSinh2.Clear();
            txtDiaChi1.Clear();
            txtDiaChi2.Clear();
            txtNgheNghiep1.Clear();
            txtNgheNghiep2.Clear();
            txtDienThoai1.Clear();
            txtDienThoai2.Clear();
            txtEmail1.Clear();
            txtEmail2.Clear();
            cboQuanHe1.SelectedIndex = -1;
            cboQuanHe2.SelectedIndex = -1;
        }


        void anHienTextBox(bool anHien)
        {
            txtHoTen.Enabled = anHien;
            txtNgaySinh.Enabled = anHien;
            txtTonGiao.Enabled = anHien;
            txtNoiSinh.Enabled = anHien;
            txtQueQuan.Enabled = anHien;
            txtChoOHienNay.Enabled = anHien;
            txtChieuCao.Enabled = anHien;
            txtMaDinhDanh.Enabled = anHien;
            txtQuocTich.Enabled = anHien;
            cboGioiTinh.Enabled = anHien;
            txtDanToc.Enabled = anHien;
            txtTinhTrangSK.Enabled = anHien;
            txtCanNang.Enabled = anHien;
            txtDienThoai1.Enabled = anHien;
            txtDienThoai2.Enabled = anHien;
            txtNamSinh1.Enabled = anHien;
            txtNamSinh2.Enabled = anHien;
            cboGioiTinh1.Enabled = anHien;
            cboGioiTinh2.Enabled = anHien;
            txtNgheNghiep1.Enabled = anHien;
            txtNgheNghiep2.Enabled = anHien;
            txtDiaChi1.Enabled = anHien;
            txtDiaChi2.Enabled = anHien;
            txtEmail1.Enabled = anHien;
            txtEmail2.Enabled = anHien;
            txtHoTen1.Enabled = anHien;
            txtHoTen2.Enabled = anHien;
            txtGhiChu.Enabled = anHien;
            //txtNgayNhapHoc.Enabled = anHien;

            //cboTrangThai.Enabled = anHien;
            btnUpGiayKhaiSinh.Enabled = anHien;
            btnUpDonXinNhapHoc.Enabled = anHien;
            btnChonHinh.Enabled = anHien;
            cboQuanHe1.Enabled = anHien;
            cboQuanHe2.Enabled = anHien;

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetText();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = true;

            anHienTextBox(false);
            hinhAnh = "Upload\\Images\\imageInit.png";
            UploadHinh(hinhAnh);
        }


        void them(HocSinhDTO hocSinh, HoSoHocSinhDTO hoSoHS, PhuHuynhDTO phuHuynh1, PhuHuynhDTO phuHuynh2)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    // Thêm phụ huynh 1
                    if (!phuHuynhBUL.themPhuHuynh(phuHuynh1))
                    {
                        throw new Exception("Thêm phụ huynh 1 thất bại");
                    }

                    // Thêm phụ huynh 2
                    if (!phuHuynhBUL.themPhuHuynh(phuHuynh2))
                    {
                        throw new Exception("Thêm phụ huynh 2 thất bại");
                    }

                    // Thêm học sinh
                    if (!hocSinhBUL.themHocSinh(hocSinh))
                    {
                        throw new Exception("Thêm học sinh thất bại");
                    }

                    // Thêm hồ sơ học sinh
                    if (!hoSoHSBUL.themHoSoHocSinh(hoSoHS))
                    {
                        throw new Exception("Thêm hồ sơ học sinh thất bại");
                    }

                    // Nếu tất cả đều thành công, hoàn tất giao dịch
                    scope.Complete();
                    message.Parent = this.ParentForm;
                    message.ShowSuccess("Thêm thành công", "Thông Báo");
                }
                catch (Exception ex)
                {
                    message.Parent = this.ParentForm;
                    message.ShowSuccess(ex.Message, "Thông Báo");
                }
            }
        }

        void sua(HocSinhDTO hocSinh, HoSoHocSinhDTO hoSoHS, PhuHuynhDTO phuHuynh1, PhuHuynhDTO phuHuynh2)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    // Sửa phụ huynh 1
                    if (!phuHuynhBUL.suaPhuHuynh(phuHuynh1))
                    {
                        throw new Exception("Sửa phụ huynh 1 thất bại");
                    }

                    // Sửa phụ huynh 2
                    if (!phuHuynhBUL.suaPhuHuynh(phuHuynh2))
                    {
                        throw new Exception("Sửa phụ huynh 2 thất bại");
                    }

                    // Sửa học sinh
                    if (!hocSinhBUL.suaHocSinh(hocSinh))
                    {
                        throw new Exception("Sửa học sinh thất bại");
                    }

                    // Sửa hồ sơ học sinh
                    if (!hoSoHSBUL.suaHoSoHocSinh(hoSoHS))
                    {
                        throw new Exception("Sửa hồ sơ học sinh thất bại");
                    }

                    // Nếu tất cả đều thành công, hoàn tất giao dịch
                    scope.Complete();
                    message.Parent = this.ParentForm;
                    message.ShowSuccess("Sửa thành công", "Thông Báo");
                }
                catch (Exception ex)
                {
                    message.Parent = this.ParentForm;
                    message.ShowSuccess(ex.Message, "Thông Báo");
                }
            }
        }

        void xoa(HocSinhDTO hocSinh, HoSoHocSinhDTO hoSoHS, PhuHuynhDTO phuHuynh1, PhuHuynhDTO phuHuynh2)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    // Sửa hồ sơ học sinh
                    if (!hoSoHSBUL.xoaHoSoHocSinh(hoSoHS.MaHS))
                    {
                        throw new Exception("Xóa hồ sơ học sinh thất bại");
                    }

                    // Sửa học sinh
                    if (!hocSinhBUL.xoaHocSinh(hocSinh.MaHS))
                    {
                        throw new Exception("Xóa học sinh thất bại");
                    }

                    // Sửa phụ huynh 1
                    if (!phuHuynhBUL.xoaPhuHuynh(phuHuynh1.MaPH))
                    {
                        throw new Exception("Xóa phụ huynh 1 thất bại");
                    }

                    // Sửa phụ huynh 2
                    if (!phuHuynhBUL.xoaPhuHuynh(phuHuynh2.MaPH))
                    {
                        throw new Exception("Xóa phụ huynh 2 thất bại");
                    }

                    // Nếu tất cả đều thành công, hoàn tất giao dịch
                    scope.Complete();
                    message.Parent = this.ParentForm;
                    message.ShowSuccess("Xóa thành công", "Thông Báo");
                }
                catch (Exception ex)
                {
                    message.Parent = this.ParentForm;
                    message.ShowSuccess(ex.Message, "Thông Báo");
                }
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string chuoi = "xem";
            if (tacVu == "Them") chuoi = "thêm";
            if (tacVu == "Sua") chuoi = "sửa";
            if (tacVu == "Xoa") chuoi = "xóa";

            DialogResult result = CustomMessageBox.Show(this.ParentForm, "Bạn có muốn " + chuoi + " học sinh này không ?", "Xác nhận", MessageDialogIcon.Question, MessageDialogButtons.YesNo);

            if (result == DialogResult.Yes && kiemTraHopLe())
            {
                HoSoHocSinhDTO hoSoHS = new HoSoHocSinhDTO(txtMaHS.Text, txtMaDinhDanh.Text, txtQuocTich.Text, txtDanToc.Text, txtTonGiao.Text, txtQueQuan.Text, txtNoiSinh.Text, txtTinhTrangSK.Text, lbDonXinNhapHoc.Text, lbGiayKhaiSinh.Text);
                HocSinhDTO hocSinh = new HocSinhDTO(txtMaHS.Text, txtMaPH1.Text, txtMaPH2.Text, txtHoTen.Text, cboGioiTinh.SelectedItem.ToString(),
                    txtNgaySinh.Value, txtChoOHienNay.Text, int.Parse(txtChieuCao.Text), hinhAnh, txtCanNang.Text, DateTime.Now, txtGhiChu.Text, "Đang học", null);
                PhuHuynhDTO phuHuynh1 = new PhuHuynhDTO(txtMaPH1.Text, txtHoTen1.Text, cboGioiTinh1.SelectedItem.ToString(), int.Parse(txtNamSinh1.Text), txtDiaChi1.Text, txtNgheNghiep1.Text, txtDienThoai1.Text, txtEmail1.Text, cboQuanHe1.Text);
                PhuHuynhDTO phuHuynh2 = new PhuHuynhDTO(txtMaPH2.Text, txtHoTen2.Text, cboGioiTinh2.SelectedItem.ToString(), int.Parse(txtNamSinh2.Text), txtDiaChi2.Text, txtNgheNghiep2.Text, txtDienThoai2.Text, txtEmail2.Text, cboQuanHe2.Text);

                if (tacVu == "Them")
                {
                    them(hocSinh, hoSoHS, phuHuynh1, phuHuynh2);
                }
                else if (tacVu == "Sua")
                {
                    sua(hocSinh, hoSoHS, phuHuynh1, phuHuynh2);
                }
                else if (tacVu == "Xoa")
                {
                    xoa(hocSinh, hoSoHS, phuHuynh1, phuHuynh2);
                }

                if (tacVu == "Xoa")
                    resetText();
                anHienTextBox(false);
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnHuy.Enabled = true;
                btnLuu.Enabled = false;
            }

        }

        private void btnDsHsMoi_Click(object sender, EventArgs e)
        {
            // Mở form danh sách học sinh mới
            FrmDsHocSinh frmDsHsMoi = new FrmDsHocSinh(this);
            frmDsHsMoi.Show();
        }



        private void btnXemDS_Click(object sender, EventArgs e)
        {
            resetText();
            anHienTextBox(false);

            // Mở form danh sách học sinh mới
            FrmDsHocSinh frmDsHs = new FrmDsHocSinh(this);
            frmDsHs.StartPosition = FormStartPosition.CenterScreen;
            frmDsHs.ShowDialog();

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = true;

        }


        string hinhAnh;


        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Thiết lập các bộ lọc cho file (chỉ chọn hình ảnh)
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của file được chọn
                    string selectedFilePath = openFileDialog.FileName;

                    // Lấy mã học sinh từ TextBox txtMaHS
                    string maHS = txtMaHS.Text.Trim();

                    // Lấy phần mở rộng của file ảnh đã chọn
                    string fileExtension = Path.GetExtension(selectedFilePath);

                    // Tạo tên file mới dựa trên mã học sinh và phần mở rộng
                    string newFileName = $"{maHS}{fileExtension}";

                    // Đường dẫn tạm để tạo file mới với tên đã đổi
                    string tempFilePath = Path.Combine(Path.GetTempPath(), newFileName);

                    // Copy file vào đường dẫn tạm với tên mới
                    File.Copy(selectedFilePath, tempFilePath, true);

                    // Gọi hàm WriteFile để lưu file đã đổi tên vào thư mục "Images"
                    string savedFileName = WriteFile(tempFilePath, "Images");

                    // Xóa file tạm sau khi lưu thành công
                    File.Delete(tempFilePath);

                    // Hiển thị thông báo file đã được lưu
                    hinhAnh = savedFileName;
                    //CustomMessageBox.Show(this.ParentForm,"File đã được lưu với tên: " + savedFileName);

                    // Lấy đường dẫn của file đã lưu
                    string savedFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Images", savedFileName);


                    // Hiển thị hình ảnh lên BunifuImageButton
                    UploadHinh(savedFilePath);
                }
            }

        }

        // Hàm để upload và hiển thị hình ảnh
        //void UploadHinh(string hinh)
        //{
        //    try
        //    {
        //        // Tạo đối tượng Image từ file hình ảnh
        //        Image selectedImage = Image.FromFile(hinh);

        //        // Hiển thị hình ảnh lên BunifuImageButton
        //        txtHinhAnh.Image = selectedImage;

        //        // Nếu muốn thay đổi kích thước của hình ảnh để phù hợp với kích thước của button:
        //        txtHinhAnh.Image = new Bitmap(selectedImage, new Size(txtHinhAnh.Width, txtHinhAnh.Height));
        //    }
        //    catch (Exception ex)
        //    {
        //        message.Parent = this.ParentForm;
        //        message.ShowSuccess("Lỗi khi hiển thị hình ảnh: " + ex.Message, "Thông Báo");
        //    }
        //}
        void UploadHinh(string hinh)
        {
            try
            {
                // Đọc file hình ảnh vào luồng để không giữ khóa file
                using (FileStream stream = new FileStream(hinh, FileMode.Open, FileAccess.Read))
                {
                    // Tạo đối tượng Image từ luồng
                    Image selectedImage = Image.FromStream(stream);

                    // Hiển thị hình ảnh lên BunifuImageButton
                    txtHinhAnh.Image = new Bitmap(selectedImage, new Size(txtHinhAnh.Width, txtHinhAnh.Height));
                }
            }
            catch (Exception ex)
            {
                message.Parent = this.ParentForm;
                message.ShowSuccess("Lỗi khi hiển thị hình ảnh: " + ex.Message, "Thông Báo");
            }
        }



        private void btnUpDonXinNhapHoc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Thiết lập bộ lọc cho file PDF
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của file được chọn
                    string selectedFilePath = openFileDialog.FileName;

                    // Lấy mã học sinh từ TextBox txtMaHS
                    string maHS = txtMaHS.Text.Trim();

                    // Tạo tên file mới với định dạng DonXinNhapHoc_HS001.pdf
                    string newFileName = $"DonXinNhapHoc_{maHS}.pdf";

                    // Đường dẫn tạm để tạo file mới với tên đã đổi
                    string tempFilePath = Path.Combine(Path.GetTempPath(), newFileName);

                    // Copy file vào đường dẫn tạm với tên mới
                    File.Copy(selectedFilePath, tempFilePath, true);

                    // Gọi hàm WriteFile để lưu file đã đổi tên vào thư mục "DonXinNhapHoc"
                    string savedFileName = WriteFile(tempFilePath, "DonXinNhapHoc");

                    // Xóa file tạm sau khi lưu thành công
                    File.Delete(tempFilePath);

                    // Hiển thị thông báo file đã được lưu
                    message.Parent = this.ParentForm;
                    message.ShowSuccess("File đã được lưu với tên: " + savedFileName, "Thông Báo");

                    // Hiển thị tên file trong label
                    lbDonXinNhapHoc.Text = savedFileName;
                }
            }
        }

        private void btnUpGiayKhaiSinh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Thiết lập bộ lọc cho file PDF
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của file được chọn
                    string selectedFilePath = openFileDialog.FileName;

                    // Lấy mã học sinh từ TextBox txtMaHS
                    string maHS = txtMaHS.Text.Trim();

                    // Tạo tên file mới với định dạng GiayKhaiSinh_HS001.pdf
                    string newFileName = $"GiayKhaiSinh_{maHS}.pdf";

                    // Đường dẫn tạm để tạo file mới với tên đã đổi
                    string tempFilePath = Path.Combine(Path.GetTempPath(), newFileName);

                    // Copy file vào đường dẫn tạm với tên mới
                    File.Copy(selectedFilePath, tempFilePath, true);

                    // Gọi hàm WriteFile để lưu file đã đổi tên vào thư mục "GiayKhaiSinh"
                    string savedFileName = WriteFile(tempFilePath, "GiayKhaiSinh");

                    // Xóa file tạm sau khi lưu thành công
                    File.Delete(tempFilePath);

                    // Hiển thị thông báo file đã được lưu
                    message.Parent = this.ParentForm;
                    message.ShowSuccess("File đã được lưu với tên: " + savedFileName, "Thông Báo");

                    // Hiển thị tên file trong label
                    lbGiayKhaiSinh.Text = savedFileName;
                }
            }
        }

        private string WriteFile(string selectedFilePath, string folderName)
        {
            string fileName = Path.GetFileName(selectedFilePath);
            try
            {
                // Đường dẫn của thư mục 'Upload/[folderName]' được tạo từ thư mục hiện tại
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload\\{folderName}");

                // Kiểm tra xem thư mục có tồn tại hay không, nếu không thì tạo mới
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                // Xác định đường dẫn đích để lưu file
                string exactPath = Path.Combine(filePath, fileName);

                // Copy file từ đường dẫn đã chọn (selectedFilePath) đến vị trí lưu trữ (exactPath)
                File.Copy(selectedFilePath, exactPath, true); // 'true' để ghi đè nếu file đã tồn tại
            }
            catch (Exception ex)
            {
                message.Parent = this.ParentForm;
                message.ShowSuccess("Lỗi khi lưu file: " + ex.Message, "Thông Báo");
            }

            return fileName;
        }

        //private string WriteFile(string selectedFilePath, string folderName)
        //{
        //    string fileName = Path.GetFileName(selectedFilePath);
        //    try
        //    {
        //        // Đường dẫn của thư mục 'Upload/[folderName]' được tạo từ thư mục hiện tại
        //        string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload\\{folderName}");

        //        // Kiểm tra xem thư mục có tồn tại hay không, nếu không thì tạo mới
        //        if (!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }

        //        // Xác định đường dẫn đích để lưu file
        //        string exactPath = Path.Combine(filePath, fileName);

        //        // Nếu file đích tồn tại và đang hiển thị, giải phóng tài nguyên
        //        if (File.Exists(exactPath))
        //        {
        //            hinhAnh = "Upload\\Images\\imageInit.png";
        //            UploadHinh(hinhAnh);
        //            txtHinhAnh.Image?.Dispose();
        //            txtHinhAnh.Image = null;
        //        }

        //        // Tạo một file tạm với tên ngẫu nhiên
        //        string tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        //        // Copy file nguồn vào file tạm
        //        File.Copy(selectedFilePath, tempFile);

        //        // Copy từ file tạm đến vị trí đích (ghi đè nếu tồn tại)
        //        File.Copy(tempFile, exactPath, true);

        //        // Xóa file tạm sau khi hoàn thành
        //        File.Delete(tempFile);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Hiển thị lỗi hoặc log thông báo
        //        message.Parent = this.ParentForm;
        //        message.ShowSuccess("Lỗi khi lưu file: " + ex.Message, "Thông Báo");
        //    }

        //    return fileName;
        //}



        //RÀNG BUỘC

        bool kiemTraHopLe()
        {
            if (txtMaHS.Text == null) { CustomMessageBox.Show(this.ParentForm, "Chưa có mã học sinh"); return false; }
            if (txtHoTen.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập họ tên học sinh"); return false; }
            if (txtNgaySinh.Value == DateTime.Now) { CustomMessageBox.Show(this.ParentForm, "Chưa nhập ngày sinh"); return false; }
            if (txtTonGiao.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập tôn giáo học sinh"); return false; }
            if (txtNoiSinh.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập nơi sinh học sinh"); return false; }
            if (txtChoOHienNay.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập nơi ở học sinh"); return false; }
            if (txtChieuCao.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập chiều cao học sinh"); return false; }

            if (txtMaDinhDanh.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập mã định danh học sinh"); return false; }
            if (cboGioiTinh.Text == null) { CustomMessageBox.Show(this.ParentForm, "Chưa chọn giới tính học sinh"); return false; }
            if (txtQuocTich.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập quốc tịch học sinh"); return false; }
            if (txtQueQuan.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập quê quán học sinh"); return false; }
            if (txtTinhTrangSK.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập tình trạng sức khỏe học sinh"); return false; }
            if (txtCanNang.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập cân nặng học sinh"); return false; }

            if (txtMaPH1.Text == null) { CustomMessageBox.Show(this.ParentForm, "Chưa có mã phụ huynh 1"); return false; }
            if (txtMaPH2.Text == null) { CustomMessageBox.Show(this.ParentForm, "Chưa có mã phụ huynh 2"); return false; }
            if (txtHoTen1.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập họ tên phụ huynh 1"); return false; }
            if (txtHoTen2.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập họ tên phụ huynh 2"); return false; }
            if (txtDienThoai1.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập sđt phụ huynh 1"); return false; }
            if (txtDienThoai2.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập sđt phụ huynh 2"); return false; }
            if (txtNamSinh1.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập năm sinh phụ huynh 1"); return false; }
            if (txtNamSinh2.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập năm sinh phụ huynh 2"); return false; }
            if (cboGioiTinh1.Text == null) { CustomMessageBox.Show(this.ParentForm, "Chưa chọn giới tính phụ huynh 1"); return false; }
            if (cboGioiTinh2.Text == null) { CustomMessageBox.Show(this.ParentForm, "Chưa chọn giới tính phụ huynh 2"); return false; }
            if (txtNgheNghiep1.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập nghề nghiệp phụ huynh 1"); return false; }
            if (txtNgheNghiep2.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập nghề nghiệp phụ huynh 2"); return false; }
            if (txtDiaChi1.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập địa chỉ phụ huynh 1"); return false; }
            if (txtDiaChi2.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập địa chỉ phụ huynh 2"); return false; }
            if (txtEmail1.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập email phụ huynh 1"); return false; }
            if (txtEmail2.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa nhập email phụ huynh 2"); return false; }

            if (lbDonXinNhapHoc.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa up đơn xin nhập học"); return false; }
            if (lbGiayKhaiSinh.Text == "") { CustomMessageBox.Show(this.ParentForm, "Chưa up giấy khai sinh"); return false; }
            //if (cboTrangThai.Text == null) { CustomMessageBox.Show(this.ParentForm,"Chưa chọn trạng thái học sinh"); return false; }
            if (hinhAnh == null) { CustomMessageBox.Show(this.ParentForm, "Chưa chọn hình ảnh học sinh"); return false; }
            //ktra hình ảnh

            if (kiemTraEmailHopLe(txtEmail1.Text) == false) { CustomMessageBox.Show(this.ParentForm, "Email phụ huynh 1 chưa hợp lệ"); return false; }
            if (kiemTraEmailHopLe(txtEmail2.Text) == false) { CustomMessageBox.Show(this.ParentForm, "Email phụ huynh 2 chưa hợp lệ"); return false; }
            if (kiemTraSDTHopLe(txtDienThoai1.Text) == false) { CustomMessageBox.Show(this.ParentForm, "Điện thoại phụ huynh 1 chưa hợp lệ"); return false; }
            if (kiemTraSDTHopLe(txtDienThoai2.Text) == false) { CustomMessageBox.Show(this.ParentForm, "Điện thoại phụ huynh 2 chưa hợp lệ"); return false; }

            return true;
        }

        private void txtNamSinh1_TextChange(object sender, EventArgs e)
        {
            string inputText = txtNamSinh1.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là số không
            foreach (char c in inputText)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là số
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Năm sinh không nhập kí tự khác số!");
                txtNamSinh1.Text = filteredText;
                txtNamSinh1.SelectionStart = txtNamSinh1.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtNamSinh1.Text = filteredText; // Chỉ giữ lại ký tự số

            }
        }

        private void txtNamSinh2_TextChange(object sender, EventArgs e)
        {
            string inputText = txtNamSinh2.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là số không
            foreach (char c in inputText)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là số
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Năm sinh không nhập kí tự khác số!");
                txtNamSinh2.Text = filteredText;
                txtNamSinh2.SelectionStart = txtNamSinh2.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtNamSinh2.Text = filteredText; // Chỉ giữ lại ký tự số

            }
        }

        private void txtDienThoai1_TextChange(object sender, EventArgs e)
        {
            string inputText = txtDienThoai1.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là số không
            foreach (char c in inputText)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là số
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Điện thoại không nhập kí tự khác số!");
                txtDienThoai1.Text = filteredText;
                txtDienThoai1.SelectionStart = txtDienThoai1.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtDienThoai1.Text = filteredText; // Chỉ giữ lại ký tự số

            }
        }

        private void txtDienThoai2_TextChange(object sender, EventArgs e)
        {
            string inputText = txtDienThoai2.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là số không
            foreach (char c in inputText)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là số
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Điện thoại không nhập kí tự khác số!");
                txtDienThoai2.Text = filteredText;
                txtDienThoai2.SelectionStart = txtDienThoai2.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtDienThoai2.Text = filteredText; // Chỉ giữ lại ký tự số

            }
        }

        private void txtCanNang_TextChange(object sender, EventArgs e)
        {
            string inputText = txtCanNang.Text.Trim();
            string filteredText = "";
            bool hasDot = false;
            bool hasComma = false;

            // Lặp qua từng ký tự và kiểm tra xem có phải là số hoặc dấu hợp lệ không
            foreach (char c in inputText)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c; // Thêm ký tự nếu là số
                }
                else if (c == '.' && !hasDot && !hasComma) // Dấu '.' hợp lệ
                {
                    filteredText += c;
                    hasDot = true;
                }
                else if (c == ',' && !hasComma && !hasDot) // Dấu ',' hợp lệ
                {
                    filteredText += c;
                    hasComma = true;
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Cân nặng chỉ được nhập số, dấu chấm (.) hoặc dấu phẩy (,).");
                txtCanNang.Text = filteredText;
                txtCanNang.SelectionStart = txtCanNang.Text.Length; // Đặt con trỏ ở cuối
            }
        }

        private void txtChieuCao_TextChange(object sender, EventArgs e)
        {
            string inputText = txtChieuCao.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là số không
            foreach (char c in inputText)
            {
                if (char.IsDigit(c))
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là số
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Chiều cao không nhập kí tự khác số!");
                txtChieuCao.Text = filteredText;
                txtChieuCao.SelectionStart = txtChieuCao.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtChieuCao.Text = filteredText; // Chỉ giữ lại ký tự số

            }
        }

        private void txtHoTen_TextChange(object sender, EventArgs e)
        {
            string inputText = txtHoTen.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là chữ không
            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // Cho phép chữ cái và khoảng trắng
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là chữ
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Họ tên không nhập kí tự số hoặc ký tự đặc biệt!");
                txtHoTen.Text = filteredText; // Chỉ giữ lại ký tự chữ
                txtHoTen.SelectionStart = txtHoTen.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtHoTen.Text = filteredText; // Chỉ giữ lại ký tự chữ
            }
        }

        private void txtTonGiao_TextChange(object sender, EventArgs e)
        {
            string inputText = txtTonGiao.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là chữ không
            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // Cho phép chữ cái và khoảng trắng
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là chữ
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Tôn giáo không nhập kí tự số hoặc ký tự đặc biệt!");
                txtTonGiao.Text = filteredText; // Chỉ giữ lại ký tự chữ
                txtTonGiao.SelectionStart = txtTonGiao.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtTonGiao.Text = filteredText; // Chỉ giữ lại ký tự chữ
            }
        }

        private void txtQuocTich_TextChange(object sender, EventArgs e)
        {
            string inputText = txtQuocTich.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là chữ không
            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // Cho phép chữ cái và khoảng trắng
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là chữ
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Quốc tịch không nhập kí tự số hoặc ký tự đặc biệt!");
                txtQuocTich.Text = filteredText; // Chỉ giữ lại ký tự chữ
                txtQuocTich.SelectionStart = txtQuocTich.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtQuocTich.Text = filteredText; // Chỉ giữ lại ký tự chữ
            }
        }

        private void txtDanToc_TextChange(object sender, EventArgs e)
        {
            string inputText = txtDanToc.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là chữ không
            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // Cho phép chữ cái và khoảng trắng
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là chữ
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Dân tộc không nhập kí tự số hoặc ký tự đặc biệt!");
                txtDanToc.Text = filteredText; // Chỉ giữ lại ký tự chữ
                txtDanToc.SelectionStart = txtDanToc.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtDanToc.Text = filteredText; // Chỉ giữ lại ký tự chữ
            }
        }

        private void txtTinhTrangSK_TextChange(object sender, EventArgs e)
        {
            string inputText = txtTinhTrangSK.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là chữ không
            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // Cho phép chữ cái và khoảng trắng
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là chữ
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Tình trạng sức khỏe không nhập kí tự số hoặc ký tự đặc biệt!");
                txtTinhTrangSK.Text = filteredText; // Chỉ giữ lại ký tự chữ
                txtTinhTrangSK.SelectionStart = txtTinhTrangSK.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtTinhTrangSK.Text = filteredText; // Chỉ giữ lại ký tự chữ
            }
        }

        private void txtHoTen1_TextChange(object sender, EventArgs e)
        {
            string inputText = txtHoTen1.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là chữ không
            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // Cho phép chữ cái và khoảng trắng
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là chữ
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Họ tên không nhập kí tự số hoặc ký tự đặc biệt!");
                txtHoTen1.Text = filteredText; // Chỉ giữ lại ký tự chữ
                txtHoTen1.SelectionStart = txtHoTen1.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtHoTen1.Text = filteredText; // Chỉ giữ lại ký tự chữ
            }
        }

        private void txtHoTen2_TextChange(object sender, EventArgs e)
        {
            string inputText = txtHoTen2.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là chữ không
            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // Cho phép chữ cái và khoảng trắng
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là chữ
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Họ tên không nhập kí tự số hoặc ký tự đặc biệt!");
                txtHoTen2.Text = filteredText; // Chỉ giữ lại ký tự chữ
                txtHoTen2.SelectionStart = txtHoTen2.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtHoTen2.Text = filteredText; // Chỉ giữ lại ký tự chữ
            }
        }

        private void txtNgheNghiep1_TextChange(object sender, EventArgs e)
        {
            string inputText = txtNgheNghiep1.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là chữ không
            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // Cho phép chữ cái và khoảng trắng
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là chữ
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Nghề nghiệp không nhập kí tự số hoặc ký tự đặc biệt!");
                txtNgheNghiep1.Text = filteredText; // Chỉ giữ lại ký tự chữ
                txtNgheNghiep1.SelectionStart = txtNgheNghiep1.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtNgheNghiep1.Text = filteredText; // Chỉ giữ lại ký tự chữ
            }
        }

        private void txtNgheNghiep2_TextChange(object sender, EventArgs e)
        {
            string inputText = txtNgheNghiep2.Text;
            string filteredText = "";

            // Lặp qua từng ký tự và kiểm tra xem có phải là chữ không
            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // Cho phép chữ cái và khoảng trắng
                {
                    filteredText += c; // Thêm ký tự vào filteredText nếu là chữ
                }
            }

            // Nếu có ký tự không hợp lệ
            if (inputText.Length != filteredText.Length)
            {
                CustomMessageBox.Show(this.ParentForm, "Nghề nghiệp không nhập kí tự số hoặc ký tự đặc biệt!");
                txtNgheNghiep2.Text = filteredText; // Chỉ giữ lại ký tự chữ
                txtNgheNghiep2.SelectionStart = txtNgheNghiep2.Text.Length; // Đặt con trỏ ở cuối
            }
            else
            {
                txtNgheNghiep2.Text = filteredText; // Chỉ giữ lại ký tự chữ
            }
        }

        private bool kiemTraEmailHopLe(string email)
        {
            // Biểu thức chính quy để kiểm tra định dạng email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool kiemTraSDTHopLe(string phoneNumber)
        {
            // Biểu thức chính quy để kiểm tra định dạng số điện thoại (ví dụ: 10 chữ số)
            string phonePattern = @"^\d{10}$"; // Điều chỉnh nếu cần (ví dụ: cho số điện thoại quốc tế)
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCanNang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
