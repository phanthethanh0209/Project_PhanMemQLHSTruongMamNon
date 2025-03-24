using BUL;
using Guna.UI2.WinForms;
using QLMamNon.UC_Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmMain : Form
    {
        private string maND;
        PhanQuyenBUL phanQuyenBUL;
        NguoiDung_NhomNguoiDungBUL nD_NhomNDBUL;
        public bool isThoat = true;
        Guna2MessageDialog message;


        public FrmMain(string MaND, string gioiTinh)
        {
            InitializeComponent();

            message = new Guna2MessageDialog();
            message.Style = MessageDialogStyle.Light;
            message.Parent = this;

            phanQuyenBUL = new PhanQuyenBUL();
            nD_NhomNDBUL = new NguoiDung_NhomNguoiDungBUL();

            maND = MaND;

            CollapseMenu();
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(98, 102, 244);//Border color

            foreach (Guna2Button menuButton in panelMenu.Controls.OfType<Guna2Button>())
            {
                menuButton.MouseEnter += Button_MouseEnter;
                menuButton.MouseLeave += Button_MouseLeave;
                menuButton.Click += Button_Click;
            }


            //PHÂN QUYỀN
            bool enabled = false;
            // bool enabled = false;
            List<string> lstMaNhom = nD_NhomNDBUL.layDSMaNhomTuTenTK(maND);
            foreach (string maNhom in lstMaNhom)
            {
                DataTable dsQuyen = phanQuyenBUL.layDSTenMH(maNhom);
                foreach (DataRow mh in dsQuyen.Rows)
                {
                    enabled = true;
                    FindMenuPhanQuyen(panelMenu, mh[3].ToString(), enabled); //mh[4] là tên màn hình

                }
            }

            txtTenDN.Text = "Xin chào " + MaND;
            if (gioiTinh == "Nam")
            {
                txtTenDN.IconRight = Properties.Resources.User_Male;
            }
            else
            {
                txtTenDN.IconRight = Properties.Resources.Cloud_account_login_female;
            }

        }




        // Hàm duyệt các button menu cấp 1
        private void FindMenuPhanQuyen(Panel mnuItems, string pScreenName, bool pEnable)
        {
            foreach (Control menu in mnuItems.Controls)
            {
                if (menu is Guna2Button buttonMenu)
                {
                    if (buttonMenu.ContextMenuStrip is Guna2ContextMenuStrip guna2MenuStrip)
                    {
                        // Duyệt qua các item trong ContextMenuStrip (cấp 2 trở đi)
                        FindMenuPhanQuyen2(guna2MenuStrip.Items, pScreenName, pEnable);

                        // Cập nhật quyền cho button dựa trên trạng thái của các mục trong ContextMenuStrip
                        buttonMenu.Enabled = CheckAllMenuChildVisible(guna2MenuStrip.Items);
                        buttonMenu.Visible = buttonMenu.Enabled; // Chỉ hiển thị button nếu nó được bật
                    }
                    else if (string.Equals(pScreenName, buttonMenu.Tag as string))
                    {
                        // Nếu không có Guna2ContextMenuStrip, kiểm tra và cập nhật quyền cho buttonMenu
                        buttonMenu.Enabled = pEnable;
                        buttonMenu.Visible = pEnable;
                    }

                }

            }
        }

        // Hàm đệ quy để duyệt các menu con từ cấp 2 trở đi
        private void FindMenuPhanQuyen2(ToolStripItemCollection mnuItems, string pScreenName, bool pEnable)
        {
            foreach (ToolStripItem menu in mnuItems)
            {
                // Kiểm tra nếu là ToolStripMenuItem và có DropDownItems (menu con)
                if (menu is ToolStripMenuItem menuItem)
                {
                    // Nếu menu có các item con, đệ quy kiểm tra các item con này
                    if (menuItem.DropDownItems.Count > 0)
                    {
                        FindMenuPhanQuyen2(menuItem.DropDownItems, pScreenName, pEnable);

                        // Cập nhật trạng thái Enabled và Visible cho ToolStripMenuItem
                        menuItem.Enabled = CheckAllMenuChildVisible(menuItem.DropDownItems);
                        menuItem.Visible = menuItem.Enabled; // Mục cha chỉ hiển thị nếu có mục con nào được bật
                    }

                    // Nếu pScreenName khớp với Tag của menuItem, cập nhật quyền cho menuItem
                    else if (string.Equals(pScreenName, menuItem.Tag as string))
                    {
                        menuItem.Enabled = pEnable;
                        menuItem.Visible = pEnable;
                    }
                }
            }
        }

        // Hàm kiểm tra tất cả các item con trong một menu có Visible hay không
        private bool CheckAllMenuChildVisible(ToolStripItemCollection mnuItems)
        {
            // Kiểm tra các mục con trong menu, nếu có ít nhất một mục con được bật, trả về true
            foreach (ToolStripItem menuItem in mnuItems)
            {
                if (menuItem is ToolStripMenuItem item)
                {
                    if (item.Enabled)
                    {
                        return true;
                    }
                }
                else if (menuItem is ToolStripSeparator)
                {
                    // Bỏ qua các ToolStripSeparator (dấu phân cách)
                    continue;
                }
            }
            return false;
        }












        //Fields
        private int borderSize = 2;
        private Size formSize;

        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            formSize = this.ClientSize;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        //Private methods
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200) //Collapse menu
            {
                panelMenu.Width = 100;
                //bunifuPictureBox1.Visible = false;
                //btnMenu.Dock = DockStyle.Top;
                //btnMenu.Anchor = AnchorStyles.None;
                btnMenu.Left = (panelMenu.Width / 2) - 25;
                foreach (Guna2Button menuButton in panelMenu.Controls.OfType<Guna2Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = HorizontalAlignment.Center;
                    //menuButton.IconLeftAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                panelMenu.Width = 230;
                //bunifuPictureBox1.Visible = true;
                //btnMenu.Dock = DockStyle.None;
                btnMenu.Left = panelMenu.Width - 50;
                foreach (Guna2Button menuButton in panelMenu.Controls.OfType<Guna2Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    //menuButton.IconLeftAlign = ContentAlignment.MiddleLeft;
                    menuButton.ImageAlign = HorizontalAlignment.Left;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void Open_DropdownMenu(ContextMenuStrip dropdownMenu, object sender)
        {
            Control control = (Control)sender;
            dropdownMenu.VisibleChanged += new EventHandler((sender2, ev)
                => DropdownMenu_VisibleChanged(sender2, ev, control));
            dropdownMenu.Show(control, control.Width, 0);
        }

        private void DropdownMenu_VisibleChanged(object sender2, EventArgs ev, Control control)
        {
            ContextMenuStrip dropdownMenu = (ContextMenuStrip)sender2;
            if (dropdownMenu.Visible)
            {
                control.BackColor = Color.FromArgb(159, 161, 224);
            }
            else
            {
                control.BackColor = Color.FromArgb(98, 102, 224);
            }
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(MenuItemHeThong, sender);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isThoat)
            {
                message.Buttons = MessageDialogButtons.YesNo;
                message.Icon = MessageDialogIcon.Question;
                DialogResult result = message.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận");
                if (result == DialogResult.Yes)
                {
                    isThoat = false;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true; // Hủy sự kiện đóng Form
                }
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmNguoiDung());
        }

        private void btnNhomND_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmNhomNguoiDung());
        }

        private void btnManHinh_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDMManHinh());
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmPhanQuyen());
        }

        private void btnVaiTro_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmND_NhomND());
        }

        private void btnHocSinh_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmHoSoHocSinh());
        }

        private void btnPhanLop_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmPhanLop(maND));
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDiemDanh(maND));
        }

        private void btnDGTuan_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDanhGia(maND));
        }

        private void btnLapPhieuHP_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmLapPhieuHocPhi(maND));
        }

        private void btnThanhToanHP_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmThanhToanHocPhi(maND));
        }

        private void btnThanhToanHD_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDangKyHoatDong(maND));
        }

        private void btnKeHoach_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmLapKeHoach());
        }


        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmPhanCong());
        }

        private void btnHoatDong_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmHoatDongNgoaiKhoa());
        }

        private void btnPhongHoc_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmPhongHoc());
        }

        private Guna2Button activeButton = null; // Lưu nút đang được chọn

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            if (button != activeButton) // Chỉ thay đổi màu nếu không phải nút đang chọn
                button.FillColor = Color.Transparent;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            if (button != activeButton) // Chỉ trả về màu mặc định nếu không phải nút đang chọn
                button.FillColor = Color.Transparent;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Reset màu của nút cũ
            if (activeButton != null)
                activeButton.FillColor = Color.Transparent; // reset màu nút

            // Cập nhật nút mới
            activeButton = sender as Guna2Button;
            activeButton.FillColor = Color.FromArgb(135, 137, 255); // Màu khi được chọn
        }

        private void btnDanhGiaThang_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDanhGiaThang(maND));

        }

        private void btnDanhGiaNamHoc_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDanhGiaCuoiNam(maND));
        }

        private void btnDSLopHoc_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDSTatCaLopHoc());
        }

        private void btnDSHocSinh_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmHocSinhTheoLop(maND));
        }

        private void btnTKHocPhi_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmThongKeBaoCaoHPTheoNam());
        }

        private void btnTKDoanhThuHD_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmThongKeDoanhThuHoatDong());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(MenuItemThongKe, sender);
        }

        public event EventHandler DangXuat;

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            message.Buttons = MessageDialogButtons.YesNo;
            message.Icon = MessageDialogIcon.Question;
            DialogResult result = message.Show("Bạn có muốn đăng xuất?", "Xác nhận");
            if (result == DialogResult.Yes)
            {
                isThoat = false;
                DangXuat(this, new EventArgs());
            }
        }

        private void btnHocPhiThang_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmThongKeHPTheoThang());
        }

        private void btnKhenThuong_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmThongKeHSKhenThuong());
        }

        private void btnTKKhuVuc_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmTiLeHSKhuVuc());
        }



        //private async void ShowLoadingForm(Form f)
        //{
        //    Guna2WinProgressIndicator indicator = new Guna2WinProgressIndicator();
        //    indicator.Size = new Size(60, 60);
        //    indicator.Location = new Point(20, 20);
        //    indicator.CircleSize = 1.5f;
        //    indicator.BackColor = TransparencyKey;

        //    f.Controls.Add(indicator);
        //    f.Show();

        //    await Task.Delay(5000); // Mô phỏng thời gian tải dữ liệu
        //    f.Close();
        //}

    }
}
