using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace QLMamNon
{
    public partial class FrmNguoiDung : Form
    {
        NguoiDungBUL bul = new NguoiDungBUL();
        GiaoVienBUL giaovienbul = new GiaoVienBUL();
        NhomNguoiDungBUL nhomNguoiDungBUL = new NhomNguoiDungBUL();
        NguoiDung_NhomNguoiDungBUL nd_nhomnd = new NguoiDung_NhomNguoiDungBUL();
        public FrmNguoiDung()
        {
            InitializeComponent();
        }
        string tacVu = "";
        private int trangThai = 0;
        private void FrmNguoiDung_Load(object sender, EventArgs e)
        {
            dgvNguoiDung.AutoGenerateColumns = false;
            dgvNguoiDung.AllowUserToAddRows = false;
            dgvNguoiDung.ReadOnly = true;
            loadData();
            cboChucVu.Items.Add("Giáo Viên");
            //cboChucVu.Items.Add("Giáo Viên Hỗ Trợ");
            cboChucVu.Items.Add("Nhân Viên Văn Phòng");
            cboChucVu.Items.Add("Kế Toán");

            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            Resbtt(false);
            hideButton(true);
        }

        public void loadData()
        {
            dgvNguoiDung.DataSource = bul.getAll();
        }

        private void hideButton(bool t)
        {
            btnHuy.Enabled = !t;
            btnLuu.Enabled = !t;
            btnSua.Enabled = t;
            btnThem.Enabled = t;
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            Clear();
            hideButton(true);
        }
        private void Clear()
        {
            txtMaND.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtHoTen.Clear();
            txtMatKhau.Clear();
            txtEmail.Clear();
            txtTenTK.Clear();
            cboGioiTinh.SelectedIndex = -1;
            cboChucVu.SelectedIndex = -1;
            txtNoiDaoTao.Clear();
            txtMaGV.Clear();
            txtTrinhDo.Clear();
            txtChuyenMon.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            tacVu = "Them";
            Resbtt(true);
            hideButton(false);
            Clear();
            txtMaND.Text = bul.TaoMaND();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Resbtt(false);
            Clear();
            hideButton(true);
        }

        private void Resbtt(bool t)
        {
            txtHoTen.Enabled = t;
            txtEmail.Enabled = t;
            txtTenTK.Enabled = t;
            txtMatKhau.Enabled = t;
            txtDiaChi.Enabled = t;
            txtDienThoai.Enabled = t;
            cboChucVu.Enabled = t;
            cboGioiTinh.Enabled = t;
            txtTrinhDo.Enabled = t;
            txtChuyenMon.Enabled = t;
            txtNoiDaoTao.Enabled = t;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ktNhap())
            {
                string maND = txtMaND.Text.Trim().ToString();
                string tenTK = txtTenTK.Text.Trim().ToString();
                string matKhau = txtMatKhau.Text.Trim().ToString();
                int trangThai = ckbTrangThai.Checked ? 1 : 0;
                string hoTen = txtHoTen.Text.Trim().ToString();
                string dienThoai = txtDienThoai.Text.Trim().ToString();
                string diaChi = txtDiaChi.Text.Trim().ToString();
                string gioiTinh = cboGioiTinh.SelectedItem.ToString();
                DateTime ngaySinh = dtpNgaySinh.Value;
                string chucVu = cboChucVu.SelectedItem.ToString();
                string email = txtEmail.Text.Trim().ToString();
                string maGV = txtMaGV.Text.Trim().ToString();
                string trinhDo = txtTrinhDo.Text.Trim().ToString();
                string noiDaoTao = txtNoiDaoTao.Text.Trim().ToString();
                string chuyenMon = txtChuyenMon.Text.Trim().ToString();
                NguoiDungDTO nguoidung = new NguoiDungDTO(maND, tenTK, matKhau, trangThai, hoTen, dienThoai, diaChi, gioiTinh, ngaySinh, chucVu, email);
                GiaoVienDTO nguoidunggv = new GiaoVienDTO(maGV, trinhDo, chuyenMon, noiDaoTao, gioiTinh, hoTen);
                if (tacVu == "Them")
                {
                    if (cboChucVu.SelectedItem == "Giáo Viên")
                    {
                        if (string.IsNullOrEmpty(trinhDo) || string.IsNullOrEmpty(chuyenMon) || string.IsNullOrEmpty(noiDaoTao))
                        {
                            CustomMessageBox.Show(this.ParentForm, "Hãy nhập đầy đủ thông tin giáo viên!");
                            return;
                        }
                    }

                    bool kp = bul.InsertUser(nguoidung);
                    if (kp == true)
                    {
                        if (cboChucVu.SelectedItem == "Giáo Viên")
                        {
                            bool kpgv = giaovienbul.InsertUser(nguoidunggv);
                            if (kpgv == true)
                            {
                                Resbtt(false);
                                MessageBox.Show("Them thanh cong");
                            }
                            else
                                MessageBox.Show("Them that bai");
                        }

                        // thêm quyền cho các nhân viên
                        List<NhomNguoiDungDTO> lstQuyen = nhomNguoiDungBUL.getAll();
                        foreach (NhomNguoiDungDTO p in lstQuyen)
                        {
                            if (cboChucVu.SelectedItem.ToString() != "Giáo Viên" && p.TenNhom.ToLower().Contains(cboChucVu.SelectedItem.ToString().ToLower()))
                            {
                                NguoiDung_NhomNguoiDungDTO nd = new NguoiDung_NhomNguoiDungDTO(nguoidung.MaND, p.MaNhom, null);
                                nd_nhomnd.themND_NhomND(nd);
                            }
                        }
                    }
                }
                else if (tacVu == "Sua")
                {
                    bool kp = bul.UpdateUser(nguoidung);
                    if (cboChucVu.SelectedItem == "Giáo Viên")
                    {
                        if (giaovienbul.isExit(maND) == 1)
                        {
                            bool kp1 = giaovienbul.UpdateUser(nguoidunggv);
                        }
                        else
                        {
                            bool kpgv = giaovienbul.InsertUser(nguoidunggv);
                        }
                    }

                    if (kp == true)
                    {
                        MessageBox.Show("Sua thanh cong");
                        Resbtt(false);
                        Clear();
                    }

                    else
                        MessageBox.Show("Sua that bai");
                }

                loadData();
                hideButton(true);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tacVu = "Sua";
            hideButton(false);
            Resbtt(true);
        }

        private void ckbHoatDong_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (ckbTrangThai.Checked)
            {
                // Nếu được chọn
                trangThai = 1;
            }
            else
            {
                // Nếu không được chọn
                trangThai = 0;
            }
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguoiDung.Rows[e.RowIndex];

                txtMaND.Text = row.Cells["MaND"].Value?.ToString();
                NguoiDungDTO dTO = bul.layThongTinTheoMa(txtMaND.Text);
                txtTenTK.Text = dTO.TenTK;
                txtMatKhau.Text = dTO.MatKhau;
                txtDiaChi.Text = dTO.DiaChi;
                txtDienThoai.Text = dTO.DienThoai;
                txtEmail.Text = dTO.Email;
                txtHoTen.Text = dTO.HoTen;
                cboChucVu.SelectedItem = dTO.ChucVu;
                cboGioiTinh.SelectedItem = dTO.GioiTinh;
                dtpNgaySinh.Text = dTO.NgaySinh.ToString();
                ckbTrangThai.Checked = dTO.TrangThai == 1 ? true : false;
                GiaoVienDTO dto2 = giaovienbul.layThongTinGV(txtMaND.Text);
                txtMaGV.Text = dTO.MaND;
                txtChuyenMon.Text = dto2.ChuyenMon;
                txtNoiDaoTao.Text = dto2.NoiDaoTao;
                txtTrinhDo.Text = dto2.TrinhDo;

                tacVu = "Xem";
            }
        }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChucVu.SelectedItem == "Giáo Viên")
            {
                txtMaGV.Text = txtMaND.Text;
                txtTrinhDo.Enabled = true;
                txtChuyenMon.Enabled = true;
                txtNoiDaoTao.Enabled = true;
            }
            else
            {
                txtTrinhDo.Enabled = false;
                txtChuyenMon.Enabled = false;
                txtNoiDaoTao.Enabled = false;
            }

        }

        private bool ktNhap()
        {
            if (txtTenTK.Text == "")
            {
                MessageBox.Show("Hãy nhập tên tài khoản!");
                txtTenTK.Focus();
                return false;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Hãy nhập mật khẩu!");
                txtMatKhau.Focus();
                return false;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Hãy nhập mật khẩu!");
                txtHoTen.Focus();
                return false;
            }
            if (cboChucVu.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy chọn chức vụ!");
                cboChucVu.Focus();
                return false;
            }
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Hãy nhập số điện thoại!");
                txtDienThoai.Focus();
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Hãy nhập địa chỉ!");
                txtDiaChi.Focus();
                return false;
            }
            if (cboGioiTinh.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy chọn giới tính!");
                cboGioiTinh.Focus();
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Hãy nhập email!");
                txtEmail.Focus();
                return false;
            }
            return true;
        }
        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Loại bỏ ký tự không hợp lệ
            }
        }

        private void txtHoTen_Leave(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim(); // Lấy giá trị từ TextBox

            // Biểu thức regex: Chỉ cho phép chữ cái (bao gồm dấu) và dấu cách
            string pattern = @"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơĂÂÊÔƠƯĂắằẳẵặấầẩẫậđẻẽẹềếệểễỉịọỏốồổỗộớờởỡợụủứừửữựỳỵỷỹý\s]+$";

            if (!Regex.IsMatch(hoTen, pattern))
            {
                MessageBox.Show("Họ tên không được chứa số hoặc ký tự đặc biệt!");
                txtHoTen.Focus();
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            //string ISmatKhau = txtMatKhau.Text;
            //string message = ValidatePassword(ISmatKhau);

            //if (!string.IsNullOrEmpty(message))
            //{
            //    MessageBox.Show(message, "Mật khẩu không hợp lệ!");
            //    txtMatKhau.Focus();
            //}
        }

        private string ValidatePassword(string ISmatKhau)
        {
            // Điều kiện 1: Độ dài ít nhất 8 ký tự
            if (ISmatKhau.Length < 8)
            {
                return "Mật khẩu phải có ít nhất 8 ký tự.";
            }

            // Điều kiện 2: Phải chứa ít nhất một chữ cái hoa
            if (!ISmatKhau.Any(char.IsUpper))
            {
                return "Mật khẩu phải chứa ít nhất một chữ cái viết hoa.";
            }

            // Điều kiện 3: Phải chứa ít nhất một chữ cái thường
            if (!ISmatKhau.Any(char.IsLower))
            {
                return "Mật khẩu phải chứa ít nhất một chữ cái viết thường.";
            }

            // Điều kiện 4: Phải chứa ít nhất một chữ số
            if (!ISmatKhau.Any(char.IsDigit))
            {
                return "Mật khẩu phải chứa ít nhất một chữ số.";
            }

            // Điều kiện 5: Phải chứa ít nhất một ký tự đặc biệt
            if (!ISmatKhau.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return "Mật khẩu phải chứa ít nhất một ký tự đặc biệt (VD: @, #, $, ...).";
            }

            return string.Empty; // Mật khẩu hợp lệ
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // Biểu thức chính quy để kiểm tra định dạng email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại!");
                txtEmail.Focus();
            }
        }

        private void txtMatKhau_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tacVu == "Xem") return;

            string ISmatKhau = txtMatKhau.Text;
            string message = ValidatePassword(ISmatKhau);

            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Mật khẩu không hợp lệ!");
                txtMatKhau.Focus();
            }
        }
        public static bool IsPhoneNumberValid(string phoneNumber)
        {
            // Biểu thức chính quy (regex) để kiểm tra số điện thoại
            // Chỉ chấp nhận các số từ 0-9, bắt đầu bằng 0, và có độ dài từ 10-11 ký tự
            string pattern = @"^0\d{9,10}$";

            return Regex.IsMatch(phoneNumber, pattern);
        }
        private void txtDienThoai_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true; // Loại bỏ ký tự không hợp lệ
            //}
            //else if (txtDienThoai.TextLength < 10 || txtDienThoai.TextLength > 11)
            //{
            //    MessageBox.Show("Số điện thoại phải có độ dài từ 10 đến 11 số!");
            //}
        }

        private void txtDienThoai_Leave(object sender, EventArgs e)
        {
            if (txtDienThoai.TextLength < 10 || txtDienThoai.TextLength > 11)
            {
                MessageBox.Show("Số điện thoại phải có độ dài từ 10 đến 11 số!");
            }
            else if (!IsPhoneNumberValid(txtDienThoai.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập lại.");
            }
        }
    }
}
