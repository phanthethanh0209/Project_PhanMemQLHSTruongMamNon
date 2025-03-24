using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace QLMamNon
{
    public class MessageBoxCustome : Guna2MessageDialog
    {
        public MessageBoxCustome()
        {
            // Thiết lập các giá trị mặc định
            this.Style = MessageDialogStyle.Light;
            this.Buttons = MessageDialogButtons.OK;
            this.Icon = MessageDialogIcon.Information;
        }

        // Thêm phương thức tiện dụng để gọi nhanh
        public DialogResult ShowError(string message, string title = "Thông Báo")
        {
            this.Buttons = MessageDialogButtons.OK;
            this.Icon = MessageDialogIcon.Error;
            return this.Show(message, title);
        }

        public DialogResult ShowWarning(string message, string title = "Thông báo")
        {
            this.Buttons = MessageDialogButtons.OK;
            this.Icon = MessageDialogIcon.Warning;
            return this.Show(message, title);
        }

        public DialogResult ShowSuccess(string message, string title = "Thành Công")
        {
            this.Buttons = MessageDialogButtons.OK;
            this.Icon = MessageDialogIcon.Information;
            return this.Show(message, title);
        }

        public DialogResult ShowFail(string message, string title = "Thất bại")
        {
            this.Buttons = MessageDialogButtons.OK;
            this.Icon = MessageDialogIcon.Error;
            return this.Show(message, title);
        }

        public DialogResult ShowQuestion(string message, string title = "Xác Nhận")
        {
            this.Buttons = MessageDialogButtons.YesNo;
            this.Icon = MessageDialogIcon.Information;
            return this.Show(message, title);
        }
    }
}
