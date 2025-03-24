using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmXemKhoanThu : Form
    {
        NamHocBUL namHocBUL = new NamHocBUL();
        KhoanThuBUL ktBUL;
        // string maNH;
        string namHienTai;
        bool loadXong = false;
        public FrmXemKhoanThu()
        {
            InitializeComponent();


            ktBUL = new KhoanThuBUL();
        }

        private void FrmThemKhoanThu_Load(object sender, EventArgs e)
        {

            loadCboNamHoc();
            loadXong = true;
            //Enable
            bool laNamHienTai = cboNH.SelectedValue.ToString() == namHienTai; //true

            //if(loadXong)
            //{
            //    if (kiemTraKhoanThuDaTao()) // Đã tạo khoản thu
            //    {
            //        //btnXoa.Enabled = laNamHienTai;
            //        //btnTaoKhoanThu.Enabled = false;
            //        txtTienAn.Enabled = false;
            //        txtHocPhi.Enabled = false;
            //        btnHuy.Enabled = false;
            //    }
            //    else // Chưa tạo khoản thu
            //    {
            //        //btnXoa.Enabled = false;
            //        //btnTaoKhoanThu.Enabled = laNamHienTai;
            //        txtTienAn.Enabled = laNamHienTai;
            //        txtHocPhi.Enabled = laNamHienTai;
            //        btnHuy.Enabled = laNamHienTai;
            //    }
            //}    
            txtTienAn.Enabled = false;
            txtHocPhi.Enabled = false;


        }

        void loadCboNamHoc()
        {
            cboNH.DataSource = namHocBUL.layTatCaNamHoc();
            cboNH.DisplayMember = "TenNamHoc";
            cboNH.ValueMember = "MaNamHoc";
            loadXong = true;


            //Chọn năm học hiện tại
            NamHocDTO nh = namHocBUL.layNamHocMoi();
            if (nh.MaNamHoc != null)
            {
                cboNH.SelectedValue = nh.MaNamHoc;
                namHienTai = nh.MaNamHoc;
            }
        }

        private void btnTaoKhoanThu_Click(object sender, EventArgs e)
        {


            //int them = 0;
            //if(txtTienAn.Text.Length > 0 && txtHocPhi.Text.Length > 0 && cboNH.SelectedIndex > 0)
            //{
            //    KhoanThuDTO kt1 = new KhoanThuDTO(ktBUL.TaoMaKhoanThu(cboNH.SelectedValue.ToString()), cboNH.SelectedValue.ToString(), "Tiền ăn", double.Parse(txtTienAn.Text.ToString()));
            //    if (ktBUL.Insert(kt1))
            //        them += 1;
            //    KhoanThuDTO kt2 = new KhoanThuDTO(ktBUL.TaoMaKhoanThu(cboNH.SelectedValue.ToString()), cboNH.SelectedValue.ToString(), "Học phí", double.Parse(txtHocPhi.Text.ToString()));
            //    if (ktBUL.Insert(kt2))
            //        them += 1;
            //    if (them == 2)
            //    {
            //        //Enable
            //        btnTaoKhoanThu.Enabled = false;
            //        btnHuy.Enabled = false;
            //        txtTienAn.Enabled = false;
            //        txtHocPhi.Enabled = false;
            //        btnXoa.Enabled = true;
            //        MessageBox.Show("Thêm khoản thu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            //    }
            //    else
            //    {
            //        //Enable
            //        btnTaoKhoanThu.Enabled = true;
            //        btnHuy.Enabled = true;
            //        txtTienAn.Enabled = true;
            //        txtHocPhi.Enabled = true;
            //        btnXoa.Enabled = false;
            //        txtTienAn.Text = "";
            //        txtHocPhi.Text = "";
            //        MessageBox.Show("Thêm khoản thu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            //    }
            //}
            //else
            //{
            //    //Enable
            //    btnTaoKhoanThu.Enabled = true;
            //    btnHuy.Enabled = true;
            //    txtTienAn.Enabled = true;
            //    txtHocPhi.Enabled = true;
            //    btnXoa.Enabled = false;
            //    txtTienAn.Text = "";
            //    txtHocPhi.Text = "";
            //    MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            //}
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //txtTienAn.Text = "";
            //txtHocPhi.Text = "";
            this.Close();

        }

        //bool kiemTraKhoanThuDaTao()
        //{
        //    if (ktBUL.layTatCaKhoanThuTrongNamHoc(cboNH.SelectedValue.ToString()).Count > 0)
        //        return true;
        //    return false;
        //}


        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            //string inputText = txtHocPhi.Text;
            //string filteredText = "";

            //// Lặp qua từng ký tự và kiểm tra xem có phải là số không
            //foreach (char c in inputText)
            //{
            //    if (char.IsDigit(c))
            //    {
            //        filteredText += c; // Thêm ký tự vào filteredText nếu là số
            //    }
            //}

            //// Nếu có ký tự không hợp lệ
            //if (inputText.Length != filteredText.Length)
            //{
            //    MessageBox.Show("Số tiền không hợp lệ!");
            //    txtHocPhi.Text = filteredText;
            //    txtHocPhi.SelectionStart = txtHocPhi.Text.Length; // Đặt con trỏ ở cuối
            //}
            //else
            //{
            //    txtHocPhi.Text = filteredText; // Chỉ giữ lại ký tự số
            //}
        }

        private void cboNH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTienAn.Clear();
            txtHocPhi.Clear();
            if (loadXong && cboNH.SelectedIndex >= 0)
            {

                //đã tạo rồi --> nếu là năm hiện tại được xóa, ko dc thêm, năm cũ ko được xóa, ko dc thêm  
                //chưa tạo --> là năm hiện tại thì được tạo mới, ko xóa, năm cũ ko dc tạo mới, ko dc xóa
                // bool laNamHienTai = cboNH.SelectedValue.ToString() == namHienTai; //true

                //if (kiemTraKhoanThuDaTao()) // Đã tạo khoản thu
                //{
                //    btnXoa.Enabled = laNamHienTai;
                //    btnTaoKhoanThu.Enabled = false;
                //    txtTienAn.Enabled = false;
                //    txtHocPhi.Enabled = false;
                //    btnHuy.Enabled = false;
                //}
                //else // Chưa tạo khoản thu
                //{
                //    btnXoa.Enabled = false;
                //    btnTaoKhoanThu.Enabled = laNamHienTai;
                //    txtTienAn.Enabled = laNamHienTai;
                //    txtHocPhi.Enabled = laNamHienTai;
                //    btnHuy.Enabled = laNamHienTai;
                //}


                //Hiển thị khoản thu của năm học cũ
                List<KhoanThuDTO> kthus = ktBUL.layTatCaKhoanThuTrongNamHoc(cboNH.SelectedValue.ToString());
                if (kthus.Count > 0)
                {
                    foreach (KhoanThuDTO kt in kthus)
                    {
                        if (kt.TenKhoanThu == "Tiền ăn")
                            txtTienAn.Text = kt.SoTien.ToString();
                        if (kt.TenKhoanThu == "Học phí")
                            txtHocPhi.Text = kt.SoTien.ToString();
                    }
                }

            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //List<KhoanThuDTO> kthus = ktBUL.layTatCaKhoanThuTrongNamHoc(cboNH.SelectedValue.ToString());
            //if (kthus.Count > 0)
            //{
            //    foreach (KhoanThuDTO kt in kthus)
            //    {
            //        if(ktBUL.Delete(kt.MaKhoanThu))
            //            MessageBox.Show("Xóa thành công");
            //        else
            //            MessageBox.Show("Không thể xóa khoản thu đã được áp dụng");

            //    }
            //}  
        }
    }
}
