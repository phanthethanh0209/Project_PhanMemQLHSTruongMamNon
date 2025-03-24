using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDSTatCaLopHoc : Form
    {
        NamHocBUL namHocBUL;
        KhoiLopBUL khoiLopBUL;
        LopHocBUL lopHocBUL;
        HocSinhBUL hocSinhBUL;
        GiaoVienBUL giaoVienBUL;
        PhanCongBUL phanCongBUL;

        private bool isLoaded = false;

        public FrmDSTatCaLopHoc()
        {
            InitializeComponent();

            namHocBUL = new NamHocBUL();
            khoiLopBUL = new KhoiLopBUL();
            lopHocBUL = new LopHocBUL();
            hocSinhBUL = new HocSinhBUL();
            giaoVienBUL = new GiaoVienBUL();
            phanCongBUL = new PhanCongBUL();
            loadCboNamHoc();

            // Kiểm tra nếu có dữ liệu, chọn mục cuối cùng
            //Năm hiện tại
            if (cboNamHoc.Items.Count > 0)
            {
                cboNamHoc.SelectedIndex = cboNamHoc.Items.Count - 1; // Chọn mục cuối
            }

        }


        private void loadCboNamHoc()
        {
            cboNamHoc.DataSource = namHocBUL.layTatCaNamHoc();
            cboNamHoc.ValueMember = "MaNamHoc";
            cboNamHoc.DisplayMember = "TenNamHoc";
            isLoaded = true;
        }

        void loadTreeView(string maNamHoc)
        {
            // Xóa các node hiện có trong TreeView để tránh chồng chéo khi load lại
            treeViewDSHocSinh.Nodes.Clear();

            // Lấy danh sách khối lớp dựa vào mã năm học
            List<KhoiLopDTO> danhSachKhoiLop = khoiLopBUL.layKhoiLopTrongNam(maNamHoc);

            foreach (KhoiLopDTO khoiLop in danhSachKhoiLop)
            {
                // Tạo một node cấp 1 cho từng khối lớp
                TreeNode nodeKhoi = new TreeNode(khoiLop.TenKhoi); // hoặc tùy vào tên thuộc tính của khối lớp
                nodeKhoi.Tag = khoiLop.MaKhoi; // Lưu mã khối vào Tag để dễ truy xuất

                // Lấy danh sách lớp học dựa vào mã khối và năm học
                List<LopHocDTO> danhSachLopHoc = lopHocBUL.layLopHocTheoKeHoach(khoiLop.MaKhoi, maNamHoc);

                foreach (LopHocDTO lopHoc in danhSachLopHoc)
                {
                    // Tạo một node cấp 2 cho từng lớp học trong khối
                    TreeNode nodeLop = new TreeNode(lopHoc.TenLop); // hoặc tùy vào tên thuộc tính của lớp học
                    nodeLop.Tag = lopHoc.MaLop; // Lưu mã lớp vào Tag

                    // Thêm node lớp vào node khối
                    nodeKhoi.Nodes.Add(nodeLop);
                }

                // Thêm node khối vào TreeView
                treeViewDSHocSinh.Nodes.Add(nodeKhoi);
            }

            // Mở rộng TreeView để hiển thị tất cả các node
            treeViewDSHocSinh.ExpandAll();
        }

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {

                string maNamHoc = cboNamHoc.SelectedValue.ToString();

                loadTreeView(maNamHoc);
            }

        }

        private void treeViewDSHocSinh_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (dgvGV.Rows.Count > 0)
            {
                dgvGV.DataSource = null;
                dgvGV.Rows.Clear();
            }


            if (dgvDsHS.Rows.Count > 0)
            {
                dgvDsHS.DataSource = null;
                dgvDsHS.Rows.Clear();
            }

            // Kiểm tra nếu node được click là node cấp 2 (lớp) không có node con
            if (e.Node.Level == 1 && e.Node.Nodes.Count == 0)
            {
                string maLop = e.Node.Tag.ToString();

                //Lấy thông tin lớp học
                LopHocDTO lopHoc = lopHocBUL.getLopHocTheoMa(maLop);
                lbMaLop.Text = lopHoc.MaLop;
                lbTenLop.Text = lopHoc.TenLop;

                loadDGVDsGV();
                loadDGVDsHocSinh();

                lbSiSo.Text = dgvDsHS.RowCount.ToString();
            }

        }



        void loadDGVDsGV()
        {
            dgvGV.AutoGenerateColumns = false;
            dgvGV.AllowUserToAddRows = false;
            if (dgvGV.Rows.Count > 0)
                dgvGV.Rows.Clear();
            dgvGV.DataSource = giaoVienBUL.layTatCaGVTheoMalop(lbMaLop.Text);
        }

        void loadDGVDsHocSinh()
        {
            dgvDsHS.AutoGenerateColumns = false;
            dgvDsHS.AllowUserToAddRows = false;
            if (dgvDsHS.Rows.Count > 0)
                dgvDsHS.Rows.Clear();
            dgvDsHS.DataSource = hocSinhBUL.layTatCaHocSinhTheoMaLopCoQuocTich(lbMaLop.Text);
        }

        private void FrmDSTatCaLopHoc_Load(object sender, EventArgs e)
        {

        }

        private TreeNode _previousNode = null;
        private void HighlightSelectedNode(TreeNode node)
        {
            // Đặt lại màu cho node trước
            if (_previousNode != null)
            {
                _previousNode.ForeColor = treeViewDSHocSinh.ForeColor;
            }

            // Đặt màu cho node mới được chọn
            if (node != null)
            {
                node.ForeColor = Color.Blue;
                _previousNode = node;
            }
        }
        private void treeViewDSHocSinh_AfterSelect(object sender, TreeViewEventArgs e)
        {
            HighlightSelectedNode(e.Node);
        }
    }
}
