using BUL;
using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDoiMatKhau : Form
    {
        NguoiDungBUL NguoiDungBUL;
        Guna2MessageDialog message;

        public FrmDoiMatKhau()
        {
            InitializeComponent();

            NguoiDungBUL = new NguoiDungBUL();
            message = new Guna2MessageDialog();
            message.Style = MessageDialogStyle.Light;
            message.Parent = this;
        }

        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void btnXacNhan_Click(object sender, System.EventArgs e)
        {
            string tentk = txtTenTK.Text;
            string matkhaucu = txtMatKhauCu.Text;
            string matkhaumoi = txtMatKhauMoi.Text;
            string nhaplai = txtNhaLaiMK.Text;

            if (tentk.Length > 0 && matkhaucu.Length > 0 && matkhaumoi.Length > 0 && nhaplai.Length > 0)
            {
                if (!nhaplai.Equals(matkhaumoi))
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Show("Nhập lại mật khẩu không khớp!", "Thông Báo");
                    return;
                }

                bool kq = NguoiDungBUL.doiMatKhau(tentk, MaHoa.EncryptMD5(txtMatKhauCu.Text), txtMatKhauMoi.Text);
                if (!kq)
                {
                    message.Buttons = MessageDialogButtons.OK;
                    message.Icon = MessageDialogIcon.Error;
                    message.Show("Tên tài khoàn hoặc mật khẩu không đúng!", "Thông Báo");
                    return;
                }

                message.Icon = MessageDialogIcon.Information;
                message.Show("Đổi mật khẩu thành công!", "Thông Báo");
                this.Hide();
            }
            else
            {
                message.Buttons = MessageDialogButtons.OK;
                message.Icon = MessageDialogIcon.Error;
                message.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo");
            }
        }
    }
}
