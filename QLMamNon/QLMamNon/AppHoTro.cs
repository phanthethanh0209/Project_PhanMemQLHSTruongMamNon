using System;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class AppHoTro : Form
    {
        public AppHoTro()
        {
            InitializeComponent();
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            FrmKeTien frm = new FrmKeTien();
            frm.Show();
            this.Hide();
        }
    }
}
