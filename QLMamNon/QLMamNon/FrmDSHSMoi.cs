using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmDSHSMoi : Form
    {
        public FrmDSHSMoi()
        {
            InitializeComponent();
        }

        HocSinhBUL hocsinhBul = new HocSinhBUL();
        public List<HocSinhDTO> dsHSDangPhanLop;
        public int siSoConLai;
        public string soTuoi;

        public FrmDSHSMoi(List<HocSinhDTO> lstHSDangPhanLop, int siSoQuyDinh, string soTuoi)
        {
            InitializeComponent();
            siSoConLai = siSoQuyDinh;
            dsHSDangPhanLop = lstHSDangPhanLop;
            this.soTuoi = soTuoi;

            lbSiSoConThieu.Text = siSoConLai.ToString();
        }

        private void FrmLayHSMoi_Load(object sender, EventArgs e)
        {
            lbDoTuoi.Text = soTuoi.ToString();

            dgvDSHS.AllowUserToAddRows = false;
            btnChonHS.Enabled = false;

            dgvDSHS.AutoGenerateColumns = false;

            if (soTuoi == "1-2") //truyền vô năm học nữa nha
            {
                dgvDSHS.DataSource = hocsinhBul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(1, 2, dsHSDangPhanLop);
            }
            else if (soTuoi == "3")
            {
                dgvDSHS.DataSource = hocsinhBul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(3, 3, dsHSDangPhanLop);
            }
            else if (soTuoi == "4")
            {
                dgvDSHS.DataSource = hocsinhBul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(4, 4, dsHSDangPhanLop);
            }
            else if (soTuoi == "5")
            {
                dgvDSHS.DataSource = hocsinhBul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(5, 5, dsHSDangPhanLop);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            //dgv.AutoGenerateColumns = false;
            //if (cboDoTuoi.Text == "1 tuổi") //truyền vô năm học nữa nha
            //{
            //    dgv.DataSource = hocsinhBul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(1, 2, dsHSDangPhanLop);
            //}
            //else if (cboDoTuoi.Text == "2 tuổi")
            //{
            //    dgv.DataSource = hocsinhBul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(2, 3, dsHSDangPhanLop);
            //}
            //else if (cboDoTuoi.Text == "3 tuổi")
            //{
            //    dgv.DataSource = hocsinhBul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(3, 4, dsHSDangPhanLop);
            //}
            //else if (cboDoTuoi.Text == "4-5 tuổi")
            //{
            //    dgv.DataSource = hocsinhBul.layTatCaHocSinhTheoDoTuoiVaChuaPhanLop(4, 6, dsHSDangPhanLop);
            //}
            //else
            //{
            //    CustomMessageBox.Show(this,"Hãy chọn độ tuổi thích hợp");
            //}

        }

        private void btnChonHS_Click(object sender, EventArgs e)
        {
            List<HocSinhDTO> danhSachHSChon = new List<HocSinhDTO>();

            foreach (DataGridViewRow row in dgvDSHS.Rows)
            {
                // Kiểm tra nếu ô checkbox được đánh dấu
                if (Convert.ToBoolean(row.Cells[5].Value))
                {
                    string maHS = row.Cells["MaHS"].Value.ToString();
                    string tenHS = row.Cells["HoTen"].Value.ToString();
                    DateTime ngaySinh = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                    string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                    string diaChi = row.Cells["DiaChi"].Value.ToString();
                    HocSinhDTO hocsinh = new HocSinhDTO(maHS, tenHS, gioiTinh, ngaySinh, diaChi);
                    danhSachHSChon.Add(hocsinh);
                }
            }

            // Đếm số lượng học sinh đã chọn
            if (danhSachHSChon.Count <= siSoConLai)
            {
                FrmPhanLop frmPhanLop = (FrmPhanLop)this.Owner;
                frmPhanLop.hienThiDgv(danhSachHSChon);
                this.Close();
            }
            else
            {
                CustomMessageBox.Show(this, "Số lượng học sinh nhiều hơn sỉ số lớp quy định", "Thông báo");
            }
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra cột checkbox và hàng hợp lệ
            if (e.RowIndex >= 0 && dgvDSHS.Columns[e.ColumnIndex].Name == "ChonHS")
            {
                int count = 0;
                bool isAnyRowSelected = false;
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvDSHS.Rows[e.RowIndex].Cells["ChonHS"];

                if (checkBoxCell.Value == null || !(bool)checkBoxCell.Value)
                {
                    checkBoxCell.Value = true; // Gán giá trị true khi tick
                }
                else
                {
                    checkBoxCell.Value = false; // Gán giá trị false khi bỏ tick
                }

                dgvDSHS.EndEdit(); // Kết thúc chỉnh sửa để cập nhật giá trị ngay lập tức
                                   // Kiểm tra từng dòng
                foreach (DataGridViewRow row in dgvDSHS.Rows)
                {
                    if (row.Cells["ChonHS"] is DataGridViewCheckBoxCell checkBoxCell2)
                    {
                        // Chuyển đổi giá trị checkbox (null sẽ được coi là false)
                        bool isChecked = Convert.ToBoolean(checkBoxCell2.Value);

                        // Đếm số lượng học sinh được tick
                        if (isChecked)
                        {
                            count++;

                            // Nếu vượt quá giới hạn, hiển thị thông báo và reset giá trị checkbox hiện tại
                            if (count > siSoConLai)
                            {
                                CustomMessageBox.Show(this, "Đã đạt đủ số lượng học sinh!", "Thông Báo");
                                //dgvDSHS.CancelEdit(); // Hủy chỉnh sửa giá trị checkbox đang click
                                checkBoxCell.Value = false;
                                return; // Thoát ngay khi vượt giới hạn
                            }
                        }
                    }
                }

                // Cập nhật trạng thái nút (chỉ kích hoạt nếu có ít nhất một checkbox được tick)
                isAnyRowSelected = count > 0;
                btnChonHS.Enabled = isAnyRowSelected;
            }
        }

        private void cboDoTuoi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
