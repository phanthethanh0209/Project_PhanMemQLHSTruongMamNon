using Aspose.Words;
using BUL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDanhGiaThang : Form
    {
        HocSinhBUL hocSinhBUL;
        NamHocBUL namHocBUL;
        LopHocBUL lopHocBUL;
        DanhGiaTuanBUL danhGiaTuanBUL;
        DanhGiaThangBUL danhGiaThangBUL;
        PhanCongBUL phanCongBUL;
        KhoiLopBUL khoiLopBUL;
        GiaoVienBUL giaoVienBUL;

        string maND;
        public FrmDanhGiaThang(string maND)
        {
            InitializeComponent();
            hocSinhBUL = new HocSinhBUL();
            namHocBUL = new NamHocBUL();
            lopHocBUL = new LopHocBUL();
            danhGiaTuanBUL = new DanhGiaTuanBUL();
            danhGiaThangBUL = new DanhGiaThangBUL();
            phanCongBUL = new PhanCongBUL();
            khoiLopBUL = new KhoiLopBUL();
            giaoVienBUL = new GiaoVienBUL();
            this.maND = maND;
        }

        private void FrmDanhGiaThang_Load(object sender, EventArgs e)
        {
            txtNoiDungDG.Multiline = true;        // Cho phép nhập nhiều dòng
            txtNoiDungDG.ScrollBars = ScrollBars.Vertical; // Hiển thị thanh cuộn dọc
            txtNoiDungDG.WordWrap = true;

            //Lấy năm học mới nhất
            string namHoc = DateTime.Now.Year.ToString();
            NamHocDTO nam = namHocBUL.layNamHocMoi();
            if (nam != null)
            {
                lbNamHoc.Text = nam.TenNamHoc;
                maNamHoc = nam.MaNamHoc;
            }


            //Lấy lớp học của giáo viên
            string maGV = maND;
            PhanCongDTO p = phanCongBUL.layLopGVDayTrongNamHT(maGV, nam.MaNamHoc);
            LopHocDTO lop = lopHocBUL.getLopHocTheoMa(p.MaLop);
            lbLopHoc.Text = lop.TenLop;
            maLop = lop.MaLop;

            //Lấy khối lớp của giáo viên
            KhoiLopDTO k = khoiLopBUL.layTenKhoiTheoMa(lop.MaKhoi);
            lbKhoiLop.Text = k.TenKhoi;

            loadCboThang();
            loadTreeView();

            //Enable
            txtNoiDungDG.Enabled = false;
            btnTaoDG.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXemDGTuan1.Enabled = false;
            btnXemDGTuan2.Enabled = false;
            btnXemDGTuan3.Enabled = false;
            btnXemDGTuan4.Enabled = false;

            //Load tháng hiện tại
            cboThang.SelectedIndex = DateTime.Now.Month - 1;

        }

        string maLop;
        string maNamHoc;
        string tacVu = "Xem";
        string danhGiaTuan1;
        string danhGiaTuan2;
        string danhGiaTuan3;
        string danhGiaTuan4;

        void loadCboThang()
        {
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add("Tháng " + i);
            }
        }

        //void loadTreeView()
        //{
        //    treeViewDSHocSinh.Nodes.Clear();

        //    // Tạo một node cấp 1 
        //    TreeNode nodeLop = new TreeNode(lbLopHoc.Text);
        //    //nodeLop.Tag = khoiLop.MaKhoi;

        //    // Lấy danh sách học sinh dựa vào mã lớp
        //    var danhSachHocSinh = hocSinhBUL.layTatCaHocSinhTheoMaLop(maLop);

        //    foreach (var hocSinh in danhSachHocSinh)
        //    {
        //        // Tạo một node cấp 2
        //        TreeNode nodeHS = new TreeNode(hocSinh.HoTen);
        //        nodeHS.Tag = hocSinh.MaHS;

        //        // Thêm node lớp vào node khối
        //        nodeLop.Nodes.Add(nodeHS);
        //    }

        //    // Thêm node lớp vào TreeView
        //    treeViewDSHocSinh.Nodes.Add(nodeLop);

        //    // Mở rộng TreeView để hiển thị tất cả các node
        //    treeViewDSHocSinh.ExpandAll();
        //}

        void loadTreeView()
        {
            treeViewDSHocSinh.Nodes.Clear();

            // Tạo một node cấp 1 
            TreeNode nodeLop = new TreeNode(lbLopHoc.Text);
            //nodeLop.Tag = khoiLop.MaKhoi;

            // Lấy danh sách học sinh dựa vào mã lớp
            List<HocSinhDTO> danhSachHocSinh = hocSinhBUL.layTatCaHocSinhTheoMaLop(maLop);

            foreach (HocSinhDTO hocSinh in danhSachHocSinh)
            {
                // Tạo một node cấp 2
                TreeNode nodeHS = new TreeNode(hocSinh.HoTen);
                nodeHS.Tag = hocSinh.MaHS;

                List<DanhGiaThangDTO> dsHSDaDG = danhGiaThangBUL.layDSHSDaDanhGia(maLop, int.Parse(cboThang.SelectedIndex.ToString()) + 1);
                foreach (DanhGiaThangDTO hs in dsHSDaDG)
                {
                    if (hocSinh.MaHS == hs.MaHS)
                        nodeHS.ForeColor = Color.Gray;
                }
                // Thêm node lớp vào node khối
                nodeLop.Nodes.Add(nodeHS);
            }

            // Thêm node lớp vào TreeView
            treeViewDSHocSinh.Nodes.Add(nodeLop);

            // Mở rộng TreeView để hiển thị tất cả các node
            treeViewDSHocSinh.ExpandAll();
        }

        bool kiemTraDayDu()
        {
            if (cboThang.SelectedIndex < 0)
            {
                CustomMessageBox.Show(this.ParentForm, "Hãy chọn tháng");
                return false;
            }
            else if (lbMaHS.Text == null)
            {
                CustomMessageBox.Show(this.ParentForm, "Bạn chưa chọn học sinh");
                return false;

            }
            else if (lbLopHoc.Text == null)
            {
                CustomMessageBox.Show(this.ParentForm, "Bạn chưa có lớp");
                return false;

            }
            return true;
        }

        void hienThiDanhGia()
        {
            if (kiemTraDayDu() && danhGiaTuanBUL.demSoTuanDanhGia(maLop, lbMaHS.Text, int.Parse(cboThang.SelectedIndex.ToString()) + 1) >= 1)
            {
                //Xem thông tin đánh giá (nếu đã đánh giá)
                DanhGiaTuanDTO dgTuan1 = danhGiaTuanBUL.layThongTinDanhGiaTuanCua1HS(maLop, lbMaHS.Text, 1, int.Parse(cboThang.SelectedIndex.ToString()) + 1);
                DanhGiaTuanDTO dgTuan2 = danhGiaTuanBUL.layThongTinDanhGiaTuanCua1HS(maLop, lbMaHS.Text, 2, int.Parse(cboThang.SelectedIndex.ToString()) + 1);
                DanhGiaTuanDTO dgTuan3 = danhGiaTuanBUL.layThongTinDanhGiaTuanCua1HS(maLop, lbMaHS.Text, 3, int.Parse(cboThang.SelectedIndex.ToString()) + 1);
                DanhGiaTuanDTO dgTuan4 = danhGiaTuanBUL.layThongTinDanhGiaTuanCua1HS(maLop, lbMaHS.Text, 4, int.Parse(cboThang.SelectedIndex.ToString()) + 1);

                int soPhieuBeNgoan = danhGiaTuanBUL.demDatPhieuBeNgoan(maLop, lbMaHS.Text, int.Parse(cboThang.SelectedIndex.ToString()) + 1);
                lbSoPhieu.Text = soPhieuBeNgoan.ToString();

                //Hiển thị nội dung đánh giá tuần
                danhGiaTuan1 = dgTuan1.NoiDung;
                danhGiaTuan2 = dgTuan2.NoiDung;
                danhGiaTuan3 = dgTuan3.NoiDung;
                danhGiaTuan4 = dgTuan4.NoiDung;

                if (danhGiaTuan1 != null) { btnXemDGTuan1.Enabled = true; }
                else { btnXemDGTuan1.Enabled = false; }
                if (danhGiaTuan2 != null) { btnXemDGTuan2.Enabled = true; }
                else { btnXemDGTuan2.Enabled = false; }
                if (danhGiaTuan3 != null) { btnXemDGTuan3.Enabled = true; }
                else { btnXemDGTuan3.Enabled = false; }
                if (danhGiaTuan4 != null) { btnXemDGTuan4.Enabled = true; }
                else { btnXemDGTuan4.Enabled = false; }

                //Hiển thị Phiếu bé ngoan
                if (dgTuan1.DatPhieuBeNgoan == 1)
                {
                    UploadHinh("Upload\\Images\\phieuBeNgoan.jpg", lbHinh1);
                }
                else
                {
                    UploadHinh("Upload\\Images\\phieuBeChuaNgoan.jpg", lbHinh1);
                }

                if (dgTuan2.DatPhieuBeNgoan == 1)
                {
                    UploadHinh("Upload\\Images\\phieuBeNgoan.jpg", lbHinh2);
                }
                else
                {
                    UploadHinh("Upload\\Images\\phieuBeChuaNgoan.jpg", lbHinh2);
                }

                if (dgTuan3.DatPhieuBeNgoan == 1)
                {
                    UploadHinh("Upload\\Images\\phieuBeNgoan.jpg", lbHinh3);
                }
                else
                {
                    UploadHinh("Upload\\Images\\phieuBeChuaNgoan.jpg", lbHinh3);
                }

                if (dgTuan4.DatPhieuBeNgoan == 1)
                {
                    UploadHinh("Upload\\Images\\phieuBeNgoan.jpg", lbHinh4);
                }
                else
                {
                    UploadHinh("Upload\\Images\\phieuBeChuaNgoan.jpg", lbHinh4);
                }

                //Xem nội dung đánh giá tháng
                DanhGiaThangDTO dgThang = danhGiaThangBUL.layThongTinDanhGiaThangCua1HS(maLop, lbMaHS.Text, int.Parse(cboThang.SelectedIndex.ToString()) + 1);
                if (dgThang.MaHS != null)
                {
                    if (dgThang.DatPhieuChauNgoanBH == 1)
                    {
                        ckChon.Checked = true;
                        UploadHinh("Upload\\Images\\phieuChauNgoanBH.jpg", lbPhieuChauNgoanBH);
                    }
                    else
                    {
                        ckChon.Checked = false;
                        UploadHinh("Upload\\Images\\phieuKhongPhaiChauBH.jpg", lbPhieuChauNgoanBH);
                    }
                    txtNoiDungDG.Text = dgThang.NoiDung;
                    lbMaDanhGia.Text = dgThang.MaDanhGiaThang;
                }
                else //Hiện nút tạo (nếu chưa đánh giá và đã đánh giá đủ 4 tuần)
                {
                    if (danhGiaTuanBUL.demSoTuanDanhGia(maLop, lbMaHS.Text, int.Parse(cboThang.SelectedIndex.ToString()) + 1) == 4)
                        btnTaoDG.Enabled = true;
                    lbMaDanhGia.Text = "...";

                }
            }
            else
            {
                UploadHinh("Upload\\Images\\phieuBeChuaNgoan.jpg", lbHinh1);
                UploadHinh("Upload\\Images\\phieuBeChuaNgoan.jpg", lbHinh2);
                UploadHinh("Upload\\Images\\phieuBeChuaNgoan.jpg", lbHinh3);
                UploadHinh("Upload\\Images\\phieuBeChuaNgoan.jpg", lbHinh4);
                btnXemDGTuan1.Enabled = false;
                btnXemDGTuan2.Enabled = false;
                btnXemDGTuan3.Enabled = false;
                btnXemDGTuan4.Enabled = false;

                UploadHinh("Upload\\Images\\phieuKhongPhaiChauBH.jpg", lbPhieuChauNgoanBH);
                txtNoiDungDG.Text = "";
                txtNoiDungDG.Enabled = false;
                ckChon.Checked = false;
                btnTaoDG.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                lbMaDanhGia.Text = "...";
                lbSoPhieu.Text = "...";

            }
        }


        private void treeViewDSHocSinh_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ckChon.Checked = false;
            ckChon.Enabled = false;
            txtNoiDungDG.Text = string.Empty;
            lbMaHS.Text = "";
            lbTenHS.Text = "";
            UploadHinh("Upload\\Images\\phieuKhongPhaiChauBH.jpg", lbPhieuChauNgoanBH);
            btnTaoDG.Enabled = false;

            // Kiểm tra nếu node được click là node cấp 2 (lớp) không có node con
            if (e.Node.Level == 1 && e.Node.Nodes.Count == 0)
            {
                //Xem thông tin 1 học sinh
                lbMaHS.Text = e.Node.Tag.ToString();
                lbTenHS.Text = e.Node.Text.ToString();

                hienThiDanhGia();
            }
            else
            {
                //btnPhanCong.Enabled = false;
            }
        }

        private void btnXemDGTuan1_Click(object sender, EventArgs e)
        {
            CustomMessageBox.Show(this.ParentForm, danhGiaTuan1, "Nội dung đánh giá");
        }

        private void btnXemDGTuan2_Click(object sender, EventArgs e)
        {
            CustomMessageBox.Show(this.ParentForm, danhGiaTuan2, "Nội dung đánh giá");
        }

        private void btnXemDGTuan3_Click(object sender, EventArgs e)
        {
            CustomMessageBox.Show(this.ParentForm, danhGiaTuan3, "Nội dung đánh giá");
        }

        private void btnXemDGTuan4_Click(object sender, EventArgs e)
        {
            CustomMessageBox.Show(this.ParentForm, danhGiaTuan4, "Nội dung đánh giá");
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTreeView();
            if (kiemTraDayDu() == false)
            {
                CustomMessageBox.Show(this.ParentForm, "Hãy chọn học sinh");
            }
            else
            {
                hienThiDanhGia();
            }
            btnInPhieu.Enabled = false;

            // ktra có ít nhất 1 hs đánh giá thì kh hiện nút in
            List<DanhGiaThangDTO> lstDT = danhGiaThangBUL.layDSHSDaDanhGia(maLop, cboThang.SelectedIndex + 1);
            if (lstDT.Count > 0)
            {
                btnInPhieu.Enabled = true;
            }
        }

        private void btnTaoDG_Click(object sender, EventArgs e)
        {
            //Kiểm tra đã đánh giá đủ 4 tuần chưa, trước khi đánh giá tháng

            tacVu = "Them";
            lbMaDanhGia.Text = danhGiaThangBUL.TaoMaDanhGiaThang(int.Parse(cboThang.SelectedIndex.ToString()) + 1, maNamHoc, lbMaHS.Text);

            xetPhieuChauNgoanBacHo();
            txtNoiDungDG.Enabled = true;

            //Enable
            btnLuu.Enabled = true;
            btnTaoDG.Enabled = false;
            btnHuy.Enabled = true;



        }

        void xetPhieuChauNgoanBacHo()
        {
            if (int.Parse(lbSoPhieu.Text) == 4)
            {
                ckChon.Checked = true;
                UploadHinh("Upload\\Images\\phieuChauNgoanBH.jpg", lbPhieuChauNgoanBH);
            }
            else
            {
                ckChon.Checked = false;
                UploadHinh("Upload\\Images\\phieuKhongPhaiChauBH.jpg", lbPhieuChauNgoanBH);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult r = CustomMessageBox.Show(this.ParentForm, "Bạn có chắc chắn muốn lưu đánh giá ?", "Xác nhận", MessageDialogIcon.Question, MessageDialogButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                if (tacVu == "Them" && kiemTraDayDu() && danhGiaTuanBUL.demSoTuanDanhGia(maLop, lbMaHS.Text, int.Parse(cboThang.SelectedIndex.ToString()) + 1) == 4)
                {
                    int datPhieuChauNgoanBH = ckChon.Checked ? 1 : 0;
                    DanhGiaThangDTO dg = new DanhGiaThangDTO(lbMaDanhGia.Text, maLop, lbMaHS.Text, int.Parse(cboThang.SelectedIndex.ToString()) + 1, datPhieuChauNgoanBH, txtNoiDungDG.Text);
                    if (danhGiaThangBUL.Insert(dg))
                    {
                        loadTreeView();
                        CustomMessageBox.Show(this.ParentForm, "Đánh giá thành công");
                        btnLuu.Enabled = false;
                        btnHuy.Enabled = true;
                        btnTaoDG.Enabled = false;

                    }
                    else
                    {
                        CustomMessageBox.Show(this.ParentForm, "Đánh giá thất bại");
                    }

                    // ktra có ít nhất 1 hs đánh giá thì kh hiện nút in
                    List<DanhGiaThangDTO> lstDT = danhGiaThangBUL.layDSHSDaDanhGia(maLop, cboThang.SelectedIndex + 1);
                    if (lstDT.Count > 0)
                    {
                        btnInPhieu.Enabled = true;
                    }
                }
            }
        }


        // Hàm để upload và hiển thị hình ảnh
        void UploadHinh(string hinh, Guna2PictureBox lbHinh)
        {
            try
            {
                // Tạo đối tượng Image từ file hình ảnh
                Image selectedImage = Image.FromFile(hinh);

                lbHinh.Image = selectedImage;

                lbHinh.Image = new Bitmap(selectedImage, new Size(lbHinh.Width, lbHinh.Height));
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(this.ParentForm, "Lỗi khi hiển thị hình ảnh: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtNoiDungDG.Text = "";
            txtNoiDungDG.Enabled = false;
            ckChon.Checked = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnTaoDG.Enabled = true;
            UploadHinh("Upload\\Images\\phieuKhongPhaiChauBH.jpg", lbPhieuChauNgoanBH);
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<DanhGiaThangDTO> dsdg = danhGiaThangBUL.layDSHSDatPhieu(maLop, cboThang.SelectedIndex + 1);
            DateTime homNay = DateTime.Now;

            // Đường dẫn đầy đủ đến template
            //string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template\\Mau_ChauNgoanBacHo.doc");
            string fullPath = "Template\\Mau_ChauNgoanBacHo.doc"; // dg dẫn tương đối

            //Document baoCao = new Document(); // Tài liệu chính để lưu tất cả các trang
            Document baoCao = null; // Tài liệu chính để lưu tất cả các trang

            try
            {
                // Nạp file mẫu ban đầu
                foreach (DanhGiaThangDTO hs in dsdg)
                {
                    // Tạo một bản sao của template cho mỗi học sinh
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Document baoCaoHS = new Document(fullPath);

                        // Lấy thông tin của học sinh
                        HocSinhDTO h = hocSinhBUL.layThongTinMotHocSinh(hs.MaHS);
                        PhanCongDTO p = phanCongBUL.layGVPhuTrachTheoLop(maLop);
                        GiaoVienDTO gv = giaoVienBUL.layThongTinMotGV(p.MaGV);

                        // Điền thông tin cố định lên mẫu
                        baoCaoHS.MailMerge.Execute(new[] { "Ho_Ten" }, new[] { h.HoTen });
                        baoCaoHS.MailMerge.Execute(new[] { "NoiDung" }, new[] { hs.NoiDung });
                        baoCaoHS.MailMerge.Execute(new[] { "Ngay_Thang_Nam" }, new[] { string.Format("TP.HCM, ngày {0} tháng {1} năm {2}", homNay.Day, homNay.Month, homNay.Year) });
                        baoCaoHS.MailMerge.Execute(new[] { "TenNamHoc" }, new[] { lbNamHoc.Text });
                        baoCaoHS.MailMerge.Execute(new[] { "Ten_Lop" }, new[] { lbLopHoc.Text });
                        baoCaoHS.MailMerge.Execute(new[] { "TenGV" }, new[] { gv.TenGV });
                        baoCaoHS.MailMerge.Execute(new[] { "ChucVu" }, new[] { "Giáo viên " + p.VaiTro });

                        // Lưu tài liệu học sinh vào MemoryStream
                        baoCaoHS.Save(ms, SaveFormat.Docx);

                        // Tải lại tài liệu từ MemoryStream vào Document và thêm vào tài liệu chính
                        //ms.Position = 0; // Đặt lại vị trí của stream về đầu
                        //baoCao.AppendDocument(new Document(ms), ImportFormatMode.KeepSourceFormatting);

                        //baoCao.AppendDocument(baoCaoHS, ImportFormatMode.KeepSourceFormatting);
                        // Khởi tạo baoCao với tài liệu đầu tiên
                        if (baoCao == null)
                        {
                            baoCao = baoCaoHS.Clone();
                        }
                        else
                        {
                            // Thêm tài liệu của học sinh hiện tại vào baoCao
                            baoCao.AppendDocument(baoCaoHS, ImportFormatMode.KeepSourceFormatting);
                        }
                    }
                }
            }
            catch (Aspose.Words.FileCorruptedException ex)
            {
                CustomMessageBox.Show(this.ParentForm, "Tệp có vẻ bị hỏng hoặc không thể đọc được. Chi tiết lỗi: " + ex.Message);
            }

            // Lưu file đã hoàn thiện với thông tin của tất cả học sinh
            baoCao?.SaveAndOpenFile("PhieuChauNgoanBacHo\\PhieuChauNgoanBacHo_Thang" + homNay.Month + ".docx");
        }




    }
}
