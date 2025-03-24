using BUL;
using DTO;
using System;
using System.Data;
using System.Data.Sql;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmCauHinh : Form
    {
        CauHinhBUL bul;
        public FrmCauHinh()
        {
            InitializeComponent();

            bul = new CauHinhBUL();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SaveConfig(cbo_Servername.Text, txt_Username.Text, txt_Password.Text, cbo_Database.Text);
            this.Hide();
        }


        // load servername ở GUI vì ko lq đến db nên kh cần xử lý bên DAL
        public DataTable getServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        public DataTable getDatabase(string servername, string user, string pass)
        {
            CauHinhDTO dto = new CauHinhDTO() { ServerName = servername, User = user, Password = pass, DatabaseName = string.Empty };
            return bul.GetDatabase(dto);
        }

        public void SaveConfig(string servername, string user, string pass, string dbname)
        {
            CauHinhDTO dto = new CauHinhDTO() { ServerName = servername, User = user, Password = pass, DatabaseName = dbname };
            bul.Save(dto);
        }

        private void cbo_Servername_DropDown(object sender, EventArgs e)
        {
            cbo_Servername.DataSource = getServerName();
            cbo_Servername.DisplayMember = "Servername";
        }

        private void cbo_Database_DropDown(object sender, EventArgs e)
        {
            DataTable dt = getDatabase(cbo_Servername.Text, txt_Username.Text, txt_Password.Text);
            if (dt != null)
            {
                cbo_Database.DataSource = dt;
                cbo_Database.DisplayMember = "name";
            }
            else
                MessageBox.Show("Thông tin kết nối không chính xác");
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbo_Servername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Khi người dùng nhấn Enter
            {
                string userInput = cbo_Servername.Text;
                if (!string.IsNullOrEmpty(userInput) && !cbo_Servername.Items.Contains(userInput))
                {
                    cbo_Servername.Items.Add(userInput); // Thêm giá trị vào danh sách
                    cbo_Servername.SelectedItem = userInput; // Chọn luôn giá trị vừa nhập
                }
                e.Handled = true; // Ngăn chặn xử lý mặc định của Enter
            }
        }

        private void FrmCauHinh_Load(object sender, EventArgs e)
        {

        }
    }
}
