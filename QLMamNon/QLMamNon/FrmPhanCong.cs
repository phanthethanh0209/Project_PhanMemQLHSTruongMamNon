using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmPhanCong : Form
    {
        NamHocBUL namHocBUL;
        KhoiLopBUL khoiLopBUL;
        LopHocBUL lopHocBUL;
        HocSinhBUL hocSinhBUL;
        GiaoVienBUL giaoVienBUL;
        PhanCongBUL phanCongBUL;
        NguoiDung_NhomNguoiDungBUL nguoiDung_NhomNguoiDung;
        NhomNguoiDungBUL nhomNguoiDungBUL;
        NguoiDungBUL nguoiDungBUL;

        string namHT = "";

        MessageBoxCustome message;
        public FrmPhanCong()
        {
            InitializeComponent();
            message = new MessageBoxCustome();


            namHocBUL = new NamHocBUL();
            khoiLopBUL = new KhoiLopBUL();
            lopHocBUL = new LopHocBUL();
            hocSinhBUL = new HocSinhBUL();
            giaoVienBUL = new GiaoVienBUL();
            phanCongBUL = new PhanCongBUL();
            nhomNguoiDungBUL = new NhomNguoiDungBUL();
            nguoiDung_NhomNguoiDung = new NguoiDung_NhomNguoiDungBUL();
            nguoiDungBUL = new NguoiDungBUL();

            loadCboNamHoc();

            cboVaiTro.Enabled = false;

            // Kiểm tra nếu có dữ liệu, chọn mục cuối cùng
            //Năm hiện tại
            if (cboNamHoc.Items.Count > 0)
            {
                cboNamHoc.SelectedIndex = cboNamHoc.Items.Count - 1; // Chọn mục cuối
                namHT = cboNamHoc.SelectedValue.ToString();
            }
            isNamHT = true;
            //btnPhanCong.Enabled = false;
        }

        private bool isLoaded = false;
        private bool isNamHT = true;

        List<PhanCongDTO> lstChuaPC = new List<PhanCongDTO>();
        List<PhanCongDTO> lstDaPC = new List<PhanCongDTO>();
        List<PhanCongDTO> lstCanXoa = new List<PhanCongDTO>();

        string maGVChuaPCChon;
        string maGVDaPCChon;
        private void loadCboNamHoc()
        {
            cboNamHoc.DataSource = namHocBUL.layTatCaNamHoc();
            cboNamHoc.ValueMember = "MaNamHoc";
            cboNamHoc.DisplayMember = "TenNamHoc";

            // Đặt cờ là true sau khi đã load xong dữ liệu
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

                    // Lấy danh sách giáo viên được phân công trong lớp
                    List<GiaoVienDTO> danhSachGiaoVien = giaoVienBUL.layTatCaGVTheoMalop(lopHoc.MaLop);

                    foreach (GiaoVienDTO giaoVien in danhSachGiaoVien)
                    {
                        // Tạo một node cấp 3 cho từng giáo viên
                        TreeNode nodeGiaoVien = new TreeNode(giaoVien.TenGV); // hoặc tùy vào tên thuộc tính của giáo viên
                        nodeGiaoVien.Tag = giaoVien.MaGV; // Lưu mã giáo viên vào Tag

                        nodeGiaoVien.ForeColor = Color.DeepSkyBlue;
                        if (giaoVien.VaiTro == "Giáo viên phụ trách")
                        {
                            nodeGiaoVien.ForeColor = Color.Red;
                        }

                        // Thêm node giáo viên vào node lớp
                        nodeLop.Nodes.Add(nodeGiaoVien);
                    }

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

                if (maNamHoc != namHT)
                    isNamHT = false;

                if (isNamHT)
                {
                    //ẨN HIỆN
                    btnXemDSHS.Enabled = true;
                    btnPCong.Enabled = true;
                    btn_reload.Enabled = true;
                }
                else
                {
                    //ẨN HIỆN
                    btnXemDSHS.Enabled = true;
                    btnPCong.Enabled = false;
                    btn_reload.Enabled = false;

                }
            }

        }

        private void treeViewDSHocSinh_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (dgvDSGVPhanCong.Rows.Count > 0)
            {
                dgvDSGVPhanCong.DataSource = null;
                dgvDSGVPhanCong.Rows.Clear();
            }

            xoaTextBox();

            if (e.Node.Level == 2)
            {
                nodeTree = true;
                return;
            }

            // Kiểm tra nếu node được click là node cấp 2 (lớp) không có node con
            if (e.Node.Level == 1)
            {
                nodeTree = false;

                string maLop = e.Node.Tag.ToString();

                //Lấy thông tin lớp học
                LopHocDTO lopHoc = lopHocBUL.getLopHocTheoMa(maLop);
                lbMaLop.Text = lopHoc.MaLop;
                lbTenLop.Text = lopHoc.TenLop;
                lbSiSo.Text = lopHoc.SiSo.ToString();


                //Lấy danh sách gv của lớp đó
                lstDaPC = phanCongBUL.layGVDaPhanCongTheoLop(lbMaLop.Text);
                loadDGVDaPC();

                //ẨN HIỆN
                btnXemDSHS.Enabled = true;
                btnPCong.Enabled = true;
            }
            else
            {
                btnXemDSHS.Enabled = false;
                btnPCong.Enabled = false;
            }

            if (isNamHT)
            {
                //ẨN HIỆN
                btnXemDSHS.Enabled = true;
                btnPCong.Enabled = true;
                btn_reload.Enabled = true;
            }
            else
            {
                //ẨN HIỆN
                btnXemDSHS.Enabled = true;
                btnPCong.Enabled = false;
                btn_reload.Enabled = false;

            }

        }

        private void FrmPhanCong_Load(object sender, EventArgs e)
        {
            cboVaiTro.Items.Add("Giáo viên phụ trách");
            cboVaiTro.Items.Add("Giáo viên hỗ trợ");

            btnThem.Enabled = false;
            btn_luu.Enabled = false;
            btnXoa.Enabled = false;
            btnPCong.Enabled = false;
            btnXemDSHS.Enabled = false;

            NamHocDTO nh = namHocBUL.layNamHocMoi();

            lstChuaPC = phanCongBUL.layGVChuaPhanCongTrongNam(nh.MaNamHoc);
            loadDGVChuaPC();

        }


        private TreeNode _previousNode = null;
        bool nodeTree = false;
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


        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVaiTro.SelectedIndex >= 0)
            {

                //if (dgvDSGVChuaPC.Rows.Count > 0)
                //{
                //    dgvDSGVChuaPC.Rows.Clear();
                //}
                //if (cboVaiTro.SelectedIndex >= 0)
                //{
                //    lstChuaPC = phanCongBUL.layGVChuaPhanCongTheoVaiTro(cboVaiTro.Text, lbMaLop.Text);
                //    loadDGVChuaPC();

                //}
            }
        }

        void xoaTextBox()
        {
            lbMaGV.Text = string.Empty;
            lbTenGV.Text = string.Empty;
            lbNgaySinh.Text = string.Empty;
            lbGioiTinh.Text = string.Empty;
            lbNgaySinh.Text = string.Empty;
            lbTrinhDo.Text = string.Empty;
            lbNoiDaoTao.Text = string.Empty;
            lbEmailllll.Text = string.Empty;
            lbDienThoai.Text = string.Empty;
            lbTenTK.Text = string.Empty;

        }
        private void btnPCong_Click(object sender, EventArgs e)
        {
            btnPCong.Enabled = false;
            cboVaiTro.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btn_luu.Enabled = true;

        }


        void loadDGVChuaPC()
        {
            dgvDSGVChuaPC.AutoGenerateColumns = false;
            dgvDSGVChuaPC.AllowUserToAddRows = false;
            if (dgvDSGVChuaPC.Rows.Count > 0)
                dgvDSGVChuaPC.Rows.Clear();
            foreach (PhanCongDTO giaoVien in lstChuaPC)
            {
                dgvDSGVChuaPC.Rows.Add(giaoVien.MaGV, giaoVien.HoTen, giaoVien.GioiTinh);

            }
        }

        void loadDGVDaPC()
        {
            dgvDSGVPhanCong.AutoGenerateColumns = false;
            dgvDSGVPhanCong.AllowUserToAddRows = false;
            if (dgvDSGVPhanCong.Rows.Count > 0)
                dgvDSGVPhanCong.Rows.Clear();
            foreach (PhanCongDTO giaoVien in lstDaPC)
            {
                dgvDSGVPhanCong.Rows.Add(giaoVien.MaGV, giaoVien.HoTen, giaoVien.GioiTinh, giaoVien.VaiTro);
            }
            //dgvDSGVPhanCong.DataSource = lstDaPC;
        }


        bool kiemTraGVPhuTrachDaCo(string vaiTro)
        {
            if (vaiTro == "Giáo viên phụ trách")
            {
                foreach (PhanCongDTO pc in lstDaPC)
                {
                    if (pc.VaiTro == "Giáo viên phụ trách")
                    {
                        message.Parent = this.ParentForm;
                        message.ShowError("Lớp đã có giáo viên phụ trách");
                        return true;
                    }
                }
            }

            return false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboVaiTro.SelectedIndex < 0)
            {
                message.Parent = this.ParentForm;
                message.ShowError("Hãy chọn vai trò cho giáo viên!");
                return;
            }

            if (maGVChuaPCChon != null && maGVChuaPCChon.Length > 0)
            {
                foreach (PhanCongDTO gv in lstChuaPC)
                {
                    if (gv.MaGV == maGVChuaPCChon && kiemTraGVPhuTrachDaCo(cboVaiTro.Text) == false)
                    {
                        lstChuaPC.Remove(gv);
                        gv.VaiTro = cboVaiTro.Text;
                        gv.MaLop = lbMaLop.Text;

                        lstDaPC.Add(gv);
                        //nếu nó nằm trng lstXoa thfi xóa ra
                        List<PhanCongDTO> lstCanXoaCu = new List<PhanCongDTO>(lstCanXoa);
                        foreach (PhanCongDTO pc in lstCanXoaCu)
                        {
                            if (pc.MaGV == maGVChuaPCChon)
                            {
                                lstCanXoa.Remove(pc);
                            }
                        }

                        xoaTextBox();

                        loadDGVChuaPC();
                        loadDGVDaPC();
                        cboVaiTro.SelectedIndex = -1;

                        break;
                    }
                }

            }
        }

        private void dgvDSGVChuaPC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDSGVChuaPC.Rows[e.RowIndex];
                maGVChuaPCChon = selectedRow.Cells["MaGV"].Value.ToString();
                lbMaGV.Text = selectedRow.Cells["MaGV"].Value.ToString();
                lbTenGV.Text = selectedRow.Cells["TenGV"].Value.ToString();
                lbGioiTinh.Text = selectedRow.Cells["GioiTinh"].Value.ToString();

                GiaoVienDTO gv = giaoVienBUL.layThongTinMotGV(lbMaGV.Text);
                lbNgaySinh.Text = gv.NgaySinh.ToString();
                lbTrinhDo.Text = gv.TrinhDo;
                lbNoiDaoTao.Text = gv.NoiDaoTao;
                lbEmailllll.Text = gv.Email;
                lbDienThoai.Text = gv.DienThoai;

                NguoiDungDTO nd = nguoiDungBUL.layThongTinTheoMa(gv.MaGV);
                lbTenTK.Text = nd.TenTK;

                //cboVaiTro.Enabled = false;
            }
        }

        private void dgvDSGVPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDSGVPhanCong.Rows[e.RowIndex];
                maGVDaPCChon = selectedRow.Cells["MaGV2"].Value.ToString();
                lbMaGV.Text = selectedRow.Cells["MaGV2"].Value.ToString();
                lbTenGV.Text = selectedRow.Cells["TenGV2"].Value.ToString();
                lbGioiTinh.Text = selectedRow.Cells["GioiTinh2"].Value.ToString();

                GiaoVienDTO gv = giaoVienBUL.layThongTinMotGV(lbMaGV.Text);
                lbNgaySinh.Text = gv.NgaySinh.ToString();
                lbTrinhDo.Text = gv.TrinhDo;
                lbNoiDaoTao.Text = gv.NoiDaoTao;
                lbEmailllll.Text = gv.Email;
                lbDienThoai.Text = gv.DienThoai;
                //cboVaiTro.Enabled = false;
                cboVaiTro.SelectedText = gv.VaiTro;

                NguoiDungDTO nd = nguoiDungBUL.layThongTinTheoMa(gv.MaGV);
                lbTenTK.Text = nd.TenTK;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maGVDaPCChon != null && maGVDaPCChon.Length > 0)
            {
                foreach (PhanCongDTO gv in lstDaPC)
                {
                    if (gv.MaGV == maGVDaPCChon)
                    {
                        lstDaPC.Remove(gv);
                        lstChuaPC.Add(gv);
                        lstCanXoa.Add(gv);
                        loadDGVChuaPC();
                        loadDGVDaPC();
                        break;
                    }
                }

            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (dgvDSGVPhanCong.RowCount >= 2)
            {
                if (!lstDaPC.Exists(t => t.VaiTro == "Giáo viên phụ trách"))
                {
                    message.Parent = this.ParentForm;
                    message.ShowError("Lớp chưa có giáo viên phụ trách!");
                    return;
                }


                message.Parent = this.ParentForm;
                DialogResult r = message.ShowQuestion("Bạn có muốn lưu phân công?");
                if (r == DialogResult.Yes)
                {
                    foreach (PhanCongDTO pc in lstDaPC)
                    {

                        if ((phanCongBUL.ktraGVChuaPhanCong(pc.MaLop, pc.MaGV) && phanCongBUL.Insert(pc)) || phanCongBUL.ktraGVChuaPhanCong(pc.MaLop, pc.MaGV) == false)
                        {
                            // thêm quyền cho gv
                            List<NhomNguoiDungDTO> lstQuyen = nhomNguoiDungBUL.getAll();
                            foreach (NhomNguoiDungDTO p in lstQuyen)
                            {
                                if (p.TenNhom.Contains("phụ trách") && pc.VaiTro.Contains("phụ trách"))
                                {
                                    NguoiDung_NhomNguoiDungDTO nd = new NguoiDung_NhomNguoiDungDTO(pc.MaGV, p.MaNhom, null);
                                    nguoiDung_NhomNguoiDung.themND_NhomND(nd);
                                }
                                else if (p.TenNhom.Contains("hỗ trợ") && pc.VaiTro.Contains("hỗ trợ"))
                                {
                                    NguoiDung_NhomNguoiDungDTO nd = new NguoiDung_NhomNguoiDungDTO(pc.MaGV, p.MaNhom, null);
                                    nguoiDung_NhomNguoiDung.themND_NhomND(nd);
                                }

                            }

                            //thành công
                            btnPCong.Enabled = true;
                            xoaTextBox();
                            btnThem.Enabled = false;
                            btnXoa.Enabled = false;

                            btn_luu.Enabled = false;
                        }
                        else
                        {
                            message.Parent = this.ParentForm;
                            message.ShowError("Phân công thất bại");
                            //btnPCong.Enabled = true;
                            xoaTextBox();
                            //btnThem.Enabled = false;
                            //btnXoa.Enabled = false;
                            return;
                        }

                    }

                    foreach (PhanCongDTO pc in lstCanXoa)
                    {
                        if ((phanCongBUL.ktraGVChuaPhanCong(pc.MaLop, pc.MaGV) == false && phanCongBUL.Delete(pc)) || phanCongBUL.ktraGVChuaPhanCong(pc.MaLop, pc.MaGV) == true)
                        {
                            List<NhomNguoiDungDTO> lstQuyen = nhomNguoiDungBUL.getAll();
                            foreach (NhomNguoiDungDTO p in lstQuyen)
                            {
                                if (p.TenNhom.Contains("phụ trách") && pc.VaiTro.Contains("phụ trách"))
                                {
                                    NguoiDung_NhomNguoiDungDTO nd = new NguoiDung_NhomNguoiDungDTO(pc.MaGV, p.MaNhom, null);
                                    nguoiDung_NhomNguoiDung.xoaND_NhomND(nd);
                                }
                                else if (p.TenNhom.Contains("hỗ trợ") && pc.VaiTro.Contains("hỗ trợ"))
                                {
                                    NguoiDung_NhomNguoiDungDTO nd = new NguoiDung_NhomNguoiDungDTO(pc.MaGV, p.MaNhom, null);
                                    nguoiDung_NhomNguoiDung.xoaND_NhomND(nd);
                                }
                            }

                            //thành công
                            btnPCong.Enabled = true;
                            xoaTextBox();
                            btnThem.Enabled = false;
                            btnXoa.Enabled = false;
                        }
                        else
                        {
                            message.Parent = this.ParentForm;
                            message.ShowError("Phân công thất bại");
                            btnPCong.Enabled = true;
                            xoaTextBox();
                            btnThem.Enabled = false;
                            btnXoa.Enabled = false;
                            return;
                        }

                    }

                    message.Parent = this.ParentForm;
                    message.ShowSuccess("Phân công thành công");
                    loadTreeView(cboNamHoc.SelectedValue.ToString());
                }
            }
            else
            {
                message.Parent = this.ParentForm;
                message.ShowError("Hãy phân công ít nhất 2 giáo viên");

            }
        }


        private void btn_reload_Click(object sender, EventArgs e)
        {
            lstDaPC = phanCongBUL.layGVDaPhanCongTheoLop(lbMaLop.Text);
            //lstChuaPC = phanCongBUL.layGVChuaPhanCongTheoVaiTro(cboVaiTro.Text, lbMaLop.Text);
            NamHocDTO nh = namHocBUL.layNamHocMoi();
            lstChuaPC = phanCongBUL.layGVChuaPhanCongTrongNam(nh.MaNamHoc);
            lstCanXoa.Clear();
            xoaTextBox();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btn_luu.Enabled = false;
            loadDGVDaPC();
            loadDGVChuaPC();

            cboVaiTro.Enabled = false;
            cboVaiTro.SelectedIndex = -1;

            btnPCong.Enabled = true;
        }

        private void btnXemDSHS_Click(object sender, EventArgs e)
        {
            if (lbMaLop.Text.Length > 0)
            {
                FrmDsHocSinhTheoLop frm = new FrmDsHocSinhTheoLop(lbMaLop.Text);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void treeViewDSHocSinh_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (nodeTree)
                return;
            HighlightSelectedNode(e.Node);
            nodeTree = false;
        }
    }
}
