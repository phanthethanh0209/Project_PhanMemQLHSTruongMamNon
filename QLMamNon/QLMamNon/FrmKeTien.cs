using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmKeTien : Form
    {
        public FrmKeTien()
        {
            InitializeComponent();
        }

        private void TienMat()
        {
            // Lấy giá trị từ các Label tương ứng với mệnh giá
            string gia500 = label2.Text;
            string gia200 = label3.Text.Trim();
            string gia100 = label5.Text.Trim();
            string gia50 = label4.Text.Trim();
            string gia20 = label9.Text.Trim();
            string gia10 = label8.Text.Trim();
            string gia5 = label7.Text.Trim();
            string gia2 = label6.Text.Trim();
            string gia1 = label11.Text.Trim();
            string TongTienMat = lb_tongTienMat.Text.Trim();

            // Tính tổng tiền cho mỗi mệnh giá
            TinhTien(gia500, txt_500, lb_500);
            TinhTien(gia200, txt_200, lb_200);
            TinhTien(gia100, txt_100, lb_100);
            TinhTien(gia50, txt_50, lb_50);
            TinhTien(gia20, txt_20, lb_20);
            TinhTien(gia10, txt_10, lb_10);
            TinhTien(gia5, txt_5, lb_5);
            TinhTien(gia2, txt_2, lb_2);
            TinhTien(gia1, txt_1, lb_1);
        }

        private void TinhTien(string giaText, TextBox txtSoLuong, Label lbKetQua)
        {
            if (decimal.TryParse(giaText.Replace(",", ""), out decimal gia))
            {
                // Kiểm tra giá trị số lượng nhập vào
                if (int.TryParse(txtSoLuong.Text, out int soLuong))
                {
                    decimal soTien = gia * soLuong;

                    lbKetQua.Text = soTien.ToString() + " VND";
                }
            }
        }

        private void TinhTongTienMat()
        {
            // Khởi tạo biến để tính tổng tiền
            decimal tongTien = 0;

            // Cộng tổng giá trị của từng label kết quả
            tongTien += LayGiaTriLabel(lb_500);
            tongTien += LayGiaTriLabel(lb_200);
            tongTien += LayGiaTriLabel(lb_100);
            tongTien += LayGiaTriLabel(lb_50);
            tongTien += LayGiaTriLabel(lb_20);
            tongTien += LayGiaTriLabel(lb_10);
            tongTien += LayGiaTriLabel(lb_5);
            tongTien += LayGiaTriLabel(lb_2);
            tongTien += LayGiaTriLabel(lb_1);

            // Hiển thị tổng tiền vào Label lb_tongTienMat
            lb_tongTienMat.Text = tongTien.ToString("N3") + " VND";
        }



        // Hàm lấy giá trị từ Label và chuyển đổi thành số
        private decimal LayGiaTriLabel(Label lb)
        {
            // Nếu giá trị của label là một số hợp lệ
            if (decimal.TryParse(lb.Text.Replace(",", "").Replace(" VND", ""), out decimal giaTri))
            {
                return giaTri;
            }
            return 0;
        }

        private void txt_500_TextChanged(object sender, System.EventArgs e)
        {
            TienMat();
            TinhTongTienMat();
        }

        private void txt_200_TextChanged(object sender, System.EventArgs e)
        {
            TienMat();
            TinhTongTienMat();
        }

        private void txt_100_TextChanged(object sender, System.EventArgs e)
        {
            TienMat();
            TinhTongTienMat();
        }

        private void txt_50_TextChanged(object sender, System.EventArgs e)
        {
            TienMat();
            TinhTongTienMat();
        }

        private void txt_20_TextChanged(object sender, System.EventArgs e)
        {
            TienMat();
            TinhTongTienMat();
        }

        private void txt_10_TextChanged(object sender, System.EventArgs e)
        {
            TienMat();
            TinhTongTienMat();
        }

        private void txt_5_TextChanged(object sender, System.EventArgs e)
        {
            TienMat();
            TinhTongTienMat();
        }

        private void txt_2_TextChanged(object sender, System.EventArgs e)
        {
            TienMat();
            TinhTongTienMat();
        }

        private void txt_1_TextChanged(object sender, System.EventArgs e)
        {
            TienMat();
            TinhTongTienMat();
        }

        private void TongTienMoMo()
        {
            double total = 0;

            // Kiểm tra xem cột thứ 1 có tồn tại và có giá trị hợp lệ
            if (dgv_momo.Columns.Count > 1)  // Đảm bảo có ít nhất 2 cột
            {
                // Duyệt qua từng hàng trong DataGridView
                foreach (DataGridViewRow row in dgv_momo.Rows)
                {
                    // Kiểm tra nếu ô trong cột cần tính tổng có giá trị hợp lệ
                    if (row.Cells[1].Value != null)
                    {
                        double value;
                        // Chuyển giá trị trong ô thành số và cộng vào tổng
                        if (double.TryParse(row.Cells[1].Value.ToString(), out value))
                        {
                            total += value;
                        }
                    }
                }

                // Hiển thị tổng vào Label
                lb_TongTienMomo.Text = "Tổng: " + total.ToString("N2");
            }
            else
            {
                // Nếu không có đủ cột, hiển thị thông báo hoặc xử lý khác
                lb_TongTienMomo.Text = "Không đủ cột để tính tổng!";
            }
        }



        private void txt_momo_TextChanged(object sender, System.EventArgs e)
        {
            TongTienMoMo();
        }

        private void txt_momo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgv_momo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                // Gọi hàm tính tổng để cập nhật Label
                TongTienMoMo();
            }
        }

        private void FrmKeTien_Load(object sender, System.EventArgs e)
        {
            if (dgv_momo.Columns.Count == 0)
            {
                dgv_momo.Columns.Add("Column1", "Số tiền"); // Thêm cột cho số tiền
            }

            dgv_momo.CellValueChanged += new DataGridViewCellEventHandler(dgv_momo_CellValueChanged);
        }

        private void txt_momo_Enter(object sender, System.EventArgs e)
        {
            // Kiểm tra xem giá trị nhập vào có hợp lệ không
            double value;
            if (double.TryParse(txt_momo.Text, out value))
            {
                // Thêm vào cột đúng (giả sử bạn thêm vào cột số tiền, cột 1)
                dgv_momo.Rows.Add(txt_momo.Text);

                // Cập nhật lại tổng
                TongTienMoMo();

                // Xóa nội dung textbox và focus lại
                txt_momo.Clear();
                txt_momo.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
