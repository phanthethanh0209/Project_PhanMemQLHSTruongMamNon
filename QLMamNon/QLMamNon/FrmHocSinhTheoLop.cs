using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmHocSinhTheoLop : Form
    {
        HoSoHocSinhBUL hoSoHSBUL = new HoSoHocSinhBUL();
        HocSinhBUL hocSinhBUL = new HocSinhBUL();
        PhuHuynhBUL phuHuynhBUL = new PhuHuynhBUL();
        NamHocBUL namHocBUL = new NamHocBUL();
        PhanCongBUL phanCongBUL = new PhanCongBUL();
        LopHocBUL lopHocBUL = new LopHocBUL();
        KhoiLopBUL khoiLopBUL = new KhoiLopBUL();
        GiaoVienBUL gvBUL = new GiaoVienBUL();
        string maND;
        public FrmHocSinhTheoLop(string maND)
        {
            InitializeComponent();
            //txtNamSinh2.KeyPress += new KeyPressEventHandler(txtNamSinh2_KeyPress);
            this.maND = maND;

        }

        void loadTreeView()
        {
            treeViewDSHocSinh.Nodes.Clear();

            // Tạo một node cấp 1 
            TreeNode nodeLop = new TreeNode(lbLopHoc.Text);
            //nodeLop.Tag = khoiLop.MaKhoi;

            // Lấy danh sách học sinh dựa vào mã lớp
            List<HocSinhDTO> danhSachHocSinh = hocSinhBUL.layTatCaHocSinhTheoMaLop(lbMaLop.Text);

            foreach (HocSinhDTO hocSinh in danhSachHocSinh)
            {
                // Tạo một node cấp 2
                TreeNode nodeHS = new TreeNode(hocSinh.HoTen);
                nodeHS.Tag = hocSinh.MaHS;

                // Thêm node lớp vào node khối
                nodeLop.Nodes.Add(nodeHS);
            }

            // Thêm node lớp vào TreeView
            treeViewDSHocSinh.Nodes.Add(nodeLop);

            // Mở rộng TreeView để hiển thị tất cả các node
            treeViewDSHocSinh.ExpandAll();
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
                    lbGioiTinh.Text = hs.GioiTinh;
                    txtNgaySinh.Text = hs.NgaySinh.ToString();
                    txtChoOHienNay.Text = hs.DiaChi;
                    txtChieuCao.Text = hs.ChieuCao.ToString();

                    string hinhanh = "Upload\\Images\\" + hs.HinhAnh;
                    UploadHinh(hinhanh);

                    txtCanNang.Text = hs.CanNang.ToString();
                    txtGhiChu.Text = hs.GhiChu;

                    txtMaDinhDanh.Text = hoSo.MaDinhDanh;
                    txtQuocTich.Text = hoSo.QuocTich;
                    txtDanToc.Text = hoSo.DanToc;
                    txtTonGiao.Text = hoSo.TonGiao;
                    txtQueQuan.Text = hoSo.QueQuan;
                    txtNoiSinh.Text = hoSo.NoiSinh;
                    txtTinhTrangSK.Text = hoSo.TinhTrangSucKhoe;


                    txtHoTen1.Text = ph1.HoTen;
                    lbGioiTinh1.Text = ph1.GioiTinh;
                    txtNamSinh1.Text = ph1.NamSinh.ToString();
                    txtDiaChi1.Text = ph1.DiaChiCQ;
                    txtNgheNghiep1.Text = ph1.NgheNghiep;
                    txtDienThoai1.Text = ph1.DienThoai;
                    txtEmail1.Text = ph1.Email;
                    txtQuanHe1.Text = ph1.QuanHe;

                    txtHoTen2.Text = ph2.HoTen;
                    lbGioiTinh2.Text = ph2.GioiTinh;
                    txtNamSinh2.Text = ph2.NamSinh.ToString();
                    txtDiaChi2.Text = ph2.DiaChiCQ;
                    txtNgheNghiep2.Text = ph2.NgheNghiep;
                    txtDienThoai2.Text = ph2.DienThoai;
                    txtEmail2.Text = ph2.Email;
                    txtQuanHe2.Text = ph2.QuanHe;

                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin học sinh.");
                }
            }
        }


        private void FrmHoSoHocSinh_Load(object sender, EventArgs e)
        {
            //Lấy năm học mới nhất
            NamHocDTO nam = namHocBUL.layNamHocMoi();
            if (nam != null)
            {
                lbNamHoc.Text = nam.TenNamHoc;

                //Lấy lớp học của giáo viên
                string maGV = maND;
                PhanCongDTO p = phanCongBUL.layLopGVDayTrongNamHT(maGV, nam.MaNamHoc);
                LopHocDTO lop = lopHocBUL.getLopHocTheoMa(p.MaLop);
                lbLopHoc.Text = lop.TenLop;
                lbMaLop.Text = lop.MaLop;
                lbSiSo.Text = lop.SiSo.ToString();

                //Lấy khối lớp của giáo viên
                KhoiLopDTO k = khoiLopBUL.layTenKhoiTheoMa(lop.MaKhoi);
                lbKhoiLop.Text = k.TenKhoi;

                loadTreeView();
            }

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



        // Hàm để upload và hiển thị hình ảnh
        void UploadHinh(string hinh)
        {
            try
            {
                // Tạo đối tượng Image từ file hình ảnh
                Image selectedImage = Image.FromFile(hinh);

                // Hiển thị hình ảnh lên BunifuImageButton
                txtHinhAnh.Image = selectedImage;

                // Nếu muốn thay đổi kích thước của hình ảnh để phù hợp với kích thước của button:
                txtHinhAnh.Image = new Bitmap(selectedImage, new Size(txtHinhAnh.Width, txtHinhAnh.Height));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị hình ảnh: " + ex.Message);
            }
        }

        private void treeViewDSHocSinh_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Kiểm tra nếu node được click là node cấp 2 (lớp) không có node con
            if (e.Node.Level == 1 && e.Node.Nodes.Count == 0)
            {
                //Xem thông tin 1 học sinh
                //lbTenHS.Text = e.Node.Text.ToString();

                HienThiThongTinHocSinh(e.Node.Tag.ToString());

            }

        }

        private void treeViewDSHocSinh_AfterSelect(object sender, TreeViewEventArgs e)
        {
            HighlightSelectedNode(e.Node);
        }

        private void btnInW_Click(object sender, EventArgs e)
        {
            //xuất ra word
            DataTable tbl_DSLop = new DataTable();
            tbl_DSLop.Columns.Add("TenHS", typeof(string));
            tbl_DSLop.Columns.Add("NgaySinh", typeof(string));
            tbl_DSLop.Columns.Add("GioiTinh", typeof(string));
            tbl_DSLop.Columns.Add("DiaChi", typeof(string));
            List<HocSinhDTO> danhSachHocSinh = hocSinhBUL.layTatCaHocSinhTheoMaLop(lbMaLop.Text);
            foreach (HocSinhDTO hs in danhSachHocSinh)
            {
                tbl_DSLop.Rows.Add(hs.HoTen, hs.NgaySinh.ToString("dd/MM/yyyy"), hs.GioiTinh, hs.DiaChi);
            }
            // Thêm cột STT vào đầu bảng và gán giá trị tự tăng
            DataColumn col = new DataColumn("STT", typeof(int));
            tbl_DSLop.Columns.Add(col);
            col.SetOrdinal(0);
            for (int i = 0; i < tbl_DSLop.Rows.Count; ++i)
            {
                tbl_DSLop.Rows[i]["STT"] = i + 1;
            }


            DataTable tbl_DSGV = new DataTable();
            tbl_DSGV.Columns.Add("TenGV", typeof(string));
            tbl_DSGV.Columns.Add("SDT", typeof(string));
            tbl_DSGV.Columns.Add("Email", typeof(string));
            List<PhanCongDTO> danhsachGV = phanCongBUL.layGVDaPhanCongTheoLop(lbMaLop.Text);
            foreach (PhanCongDTO hs in danhsachGV)
            {
                GiaoVienDTO gv = gvBUL.layThongTinMotGV(hs.MaGV);
                //tbl_DSGV.Rows.Add(gv.TenGV, gv.DienThoai, gv.Email);
                string formattedPhone = "\u200B" + gv.DienThoai; // Thêm ký tự invisible
                tbl_DSGV.Rows.Add(gv.TenGV, formattedPhone, gv.Email);
            }
            // Thêm cột STT vào đầu bảng và gán giá trị tự tăng
            DataColumn col2 = new DataColumn("STT", typeof(int));
            tbl_DSGV.Columns.Add(col2);
            col2.SetOrdinal(0);
            for (int i = 0; i < tbl_DSGV.Rows.Count; ++i)
            {
                tbl_DSLop.Rows[i]["STT"] = i + 1;
            }


            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("ngayht", DateTime.Now.Day.ToString());
            dic.Add("thanght", DateTime.Now.Month.ToString());
            dic.Add("namht", DateTime.Now.Year.ToString());
            dic.Add("namhoc", lbNamHoc.Text);
            dic.Add("tenlop", lbLopHoc.Text);

            // Đường dẫn file Template mình để, còn true là mở file word lên
            WordExport wd = new WordExport(Application.StartupPath + "/Template/DSLopHoc.dotx", true);

            // In các Field
            wd.WriteFields(dic);
            wd.WriteTable(tbl_DSGV, 1);
            wd.WriteTable(tbl_DSLop, 2);

            MessageBox.Show("Xuất file word thành công!!!");
        }


    }
}
