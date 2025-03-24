using BUL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmGuiMail : Form
    {
        NguoiDungBUL nguoiDungBUL;
        PhanLopBUL phanlopBUL;
        NamHocBUL namHocBUL;
        GiaoVienBUL giaoVienBUL;
        HocSinhBUL hocSinhBUL;
        KeHoachBUL keHoachBUL;
        PhuHuynhBUL phuHuynhBUL;
        PhieuHocPhiBUL phieuHocPhiBUL;
        LopHocBUL lopHocBUL;

        string malop, maND, maNH, tenlop;
        string tienAn, tienHP;
        int thang;
        bool mailNhapHoc = true;

        public FrmGuiMail(string maLop, string maNH, string maND, string tenlop)
        {
            InitializeComponent();

            phanlopBUL = new PhanLopBUL();
            namHocBUL = new NamHocBUL();
            giaoVienBUL = new GiaoVienBUL();
            hocSinhBUL = new HocSinhBUL();
            keHoachBUL = new KeHoachBUL();
            nguoiDungBUL = new NguoiDungBUL();
            phuHuynhBUL = new PhuHuynhBUL();

            this.malop = maLop;
            this.maND = maND;
            this.maNH = maNH;
            this.tenlop = tenlop;
        }
        public FrmGuiMail(string maLop, string tenlop, string maNH, string maND, string tienAn, string tienHP, int thang)
        {
            InitializeComponent();

            hocSinhBUL = new HocSinhBUL();
            phuHuynhBUL = new PhuHuynhBUL();
            phieuHocPhiBUL = new PhieuHocPhiBUL();
            namHocBUL = new NamHocBUL();
            lopHocBUL = new LopHocBUL();

            this.maND = maND;
            this.tienAn = tienAn;
            this.tienHP = tienHP;
            this.thang = thang;
            this.malop = maLop;
            this.tenlop = tenlop;
            this.maNH = maNH;

            mailNhapHoc = false;
        }

        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void btnGuiMail_Click(object sender, System.EventArgs e)
        {
            string to = "";
            string subject, content;
            //to = "truonglebaotran12a192021@gmail.com";
            //to = "phanthethanh0209@gmail.com";
            EmailSender email = new EmailSender(txtEmail.Text, txtMatKhau.Text);

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    //< strong >{ tenNVGui}</ strong >< br >
                    //            { chucVu}< br >
                    if (mailNhapHoc)
                    {
                        List<PhanLopDTO> lst = phanlopBUL.layTatCaHocSinhTheoMaLop(malop);

                        string tenHocSinh = "";
                        string ngaySinh = "";
                        string giaoVien = "";
                        string tenNVGui = "";
                        string chucVu = "";
                        string ngayBatDau = "";

                        string lopHoc = tenlop;
                        string thoiGianHoc = "<strong>Sáng:</strong> 7h – 11h30, <strong>Chiều:</strong> 14h – 17h30";
                        string diaChiTruong = "83 Thủ Khoa Huân, Phường 1, Tân An, Long An";
                        foreach (PhanLopDTO p in lst)
                        {
                            // tt hocsinh
                            HocSinhDTO hs = hocSinhBUL.layThongTinMotHocSinh(p.MaHS);
                            tenHocSinh = hs.HoTen;
                            ngaySinh = hs.NgaySinh.ToString("dd/MM/yyyy");

                            // tt giaovien
                            GiaoVienDTO gv = giaoVienBUL.layGVPhuTrachTheoLop(p.MaLop);
                            giaoVien = gv.TenGV;

                            // tt nhanvien
                            NguoiDungDTO nd = nguoiDungBUL.layThongTinTheoMa(maND);
                            tenNVGui = nd.HoTen;
                            chucVu = nd.ChucVu;

                            NamHocDTO nh = namHocBUL.layThongTinCua1NamHoc(maNH);
                            ngayBatDau = nh.NgayDB.ToString("dd/MM/yyyy");

                            PhuHuynhDTO ph = phuHuynhBUL.layThongTinMotPhuHuynh(hs.MaPH1);
                            to = ph.Email;

                            subject = "Giấy Báo Nhập Học - Thông Tin Lớp Học";
                            content = $@"
                        <html>
                        <head>
                            <style>
                                body {{
                                    font-family: Arial, sans-serif;
                                    line-height: 1.6;
                                    color: #000000;
                                }}
                                h2 {{
                                    color: #2c3e50;
                                    text-align: center;
                                }}
                                .section-title {{
                                    font-weight: bold;
                                    margin-top: 20px;
                                }}
                                .info-list {{
                                    margin-left: 20px;
                                }}
                                .footer {{
                                    margin-top: 30px;
                                    font-size: 13px;
                                }}
                                .im {{
                                    color: #000000;
                                }}

                            </style>
                        </head>
                        <body>
                            <h2>Thông Báo Nhập Học</h2>

                            <p>Kính gửi Quý Phụ Huynh,</p>
                            <p>Trường Mầm non 1 - 6 xin trân trọng thông báo thông tin nhập học của học sinh như sau:</p>

                            <div class='section-title'>Thông tin học sinh:</div>
                            <ul class='info-list'>
                                <li><strong>Họ và tên:</strong> {tenHocSinh}</li>
                                <li><strong>Ngày sinh:</strong> {ngaySinh}</li>
                                <li><strong>Lớp được phân:</strong> {lopHoc}</li>
                            </ul>

                            <div class='section-title'>Thông tin lớp học:</div>
                            <ul class='info-list'>
                                <li><strong>Giáo viên phụ trách:</strong> {giaoVien}</li>
                                <li><strong>Ngày bắt đầu học:</strong> {ngayBatDau}</li>
                                <li><strong>Thời gian học:</strong> {thoiGianHoc}</li>
                                <li><strong>Địa điểm:</strong> {diaChiTruong}</li>
                            </ul>

                            <p>Quý Phụ Huynh vui lòng đưa học sinh đến trường theo thời gian và địa điểm đã nêu. Nếu có bất kỳ thay đổi nào về thông tin cá nhân của học sinh (như địa chỉ, số điện thoại liên hệ), xin vui lòng cập nhật với nhà trường.</p>

                            <p class='section-title'>Liên hệ hỗ trợ:</p>
                            <ul class='info-list'>
                                <li><strong>Phòng tuyển sinh:</strong> 0123456789</li>
                                <li><strong>Email hỗ trợ:</strong> phthanhvote.info@gmail.com</li>
                            </ul>

                            <p class='footer'>
                                Trân trọng,<br>
                                <strong>Ban Quản Lý Nhà Trường</strong><br>
                                Trường Mầm non 1 - 6
                            </p>
                        </body>
                        </html>
                    ";

                            if (!email.SendEmail(to, subject, content, true))
                            {
                                throw new Exception("Gửi mail thất bại!");
                            }
                        }
                    }
                    else
                    {
                        string tenHS, soNgayHoc, tongTien, hanChot, tenNH;
                        List<PhieuHocPhiDTO> lstPhieu = phieuHocPhiBUL.layPhieuHocPhiVaTTCuaTatCaHS(malop, thang);
                        foreach (PhieuHocPhiDTO p in lstPhieu)
                        {
                            HocSinhDTO hs = hocSinhBUL.layThongTinMotHocSinh(p.MaHS);
                            tenHS = hs.HoTen;

                            soNgayHoc = p.SoNgayHSHoc.ToString();
                            tongTien = p.TongTien.ToString("N0");
                            hanChot = p.NgayLapPhieu.AddDays(10).ToString("dd/MM/yyyy");

                            NamHocDTO n = namHocBUL.layThongTinCua1NamHoc(maNH);
                            tenNH = n.TenNamHoc;

                            PhuHuynhDTO ph = phuHuynhBUL.layThongTinMotPhuHuynh(hs.MaPH1);
                            to = ph.Email;

                            subject = "Thông báo đóng học phí";
                            content = $@"
                                <html>
                                <head>
                                    <style>
                                        body {{
                                            font-family: Arial, sans-serif;
                                            line-height: 1.6;
                                            color: #333;
                                            margin: 0;
                                            padding: 0;
                                            background-color: #f9f9f9;
                                        }}
                                        .container {{
                                            max-width: 600px;
                                            margin: 20px auto;
                                            padding: 20px;
                                            background: #fff;
                                            border-radius: 8px;
                                            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                                        }}
                                        .header {{
                                            text-align: center;
                                            background: #4CAF50;
                                            color: #fff;
                                            padding: 15px 0;
                                            border-radius: 8px 8px 0 0;
                                        }}
                                        .header h1 {{
                                            margin: 0;
                                            font-size: 24px;
                                        }}
                                        .content {{
                                            padding: 20px;
                                        }}
                                        .content p {{
                                            margin: 0 0 15px;
                                        }}
                                        .content .highlight {{
                                            color: #d9534f;
                                            font-weight: bold;
                                        }}
                                        .footer {{
                                            text-align: center;
                                            font-size: 14px;
                                            color: #888;
                                            margin-top: 20px;
                                        }}
                                    </style>
                                </head>
                                <body>
                                    <div class=""container"">
                                        <div class=""header"">
                                            <h1>Thông Báo Học Phí</h1>
                                        </div>
                                        <div class=""content"">
                                            <p>Kính gửi quý phụ huynh,</p>
                                            <p>Nhà trường xin thông báo quý phụ huynh về việc đóng tiền học phí và tiền ăn cho học sinh <span class=""highlight"">{tenHS}</span> học lớp {tenlop} trong tháng {thang} năm học {tenNH}</p>
                                            <p><b>Thông tin chi tiết:</b></p>
                                            <ul>
                                                <li><b>Học phí:</b> <span class=""highlight"">{tienHP}</span></li>
                                                <li><b>Tiền ăn:</b> <span class=""highlight"">{tienAn} x {soNgayHoc}</span></li>
                                                <li><b>Tổng cộng:</b> <span class=""highlight"">{tongTien} VNĐ</span></li>
                                            </ul>
                                            <p>Hạn chót để hoàn thành thanh toán là: <span class=""highlight"">{hanChot}</span>.</p>
                                            <p>Quý phụ huynh có thể thực hiện thanh toán tại:</p>
                                            <ul>
                                                <li>Phòng kế toán nhà trường.</li>
                                                <li>
                                                    Hoặc chuyển khoản qua ngân hàng:
                                                    <ul>
                                                        <li><strong>Ngân hàng:</strong> Sacombank.</li>
                                                        <li><strong>Số tài khoản:</strong> 4127250073357896</li>
                                                        <li><strong>Chủ tài khoản:</strong> Trường Mầm Non 1 - 6</li>
                                                        <li><strong>Nội dung chuyển khoản:</strong> [Họ Tên Học Sinh] - Học phí tháng {thang}</li>
                                                    </ul>
                                                </li>
                                            </ul>
                                            <p>Việc hoàn thành nghĩa vụ tài chính đúng hạn sẽ giúp đảm bảo các hoạt động học tập và chăm sóc của nhà trường được duy trì tốt nhất.</p>
                                            <p>Xin cảm ơn sự phối hợp của quý phụ huynh!</p>
                                        </div>
                                        <div class=""footer"">
                                            <p>Trân trọng,<br>Ban Quản Lý Nhà Trường</p>
                                        </div>
                                    </div>
                                </body>
                                </html>
                            ";

                            if (!email.SendEmail(to, subject, content, true))
                            {
                                throw new Exception("Gửi mail thất bại!");
                            }
                        }
                    }

                    scope.Complete();
                    CustomMessageBox.Show(this, "Gửi mail thành công", "Email", MessageDialogIcon.Information);
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(this, ex.Message, "Lỗi gửi mail", MessageDialogIcon.Error);
                }
            }
        }

        private void FrmGuiMail_Load(object sender, EventArgs e)
        {

        }
    }
}
