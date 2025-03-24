using DTO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLMamNon.UC_Control
{
    public partial class KeHoach_UC : UserControl
    {
        public KeHoach_UC()
        {
            InitializeComponent();
        }

        private string tenKhoi;
        private string tongHS;
        private string siSoTD;
        private string siSoTT;
        private string soLopMo;
        private List<LopHocDTO> dsLop;

        public string TenKhoi { get => tenKhoi; set { tenKhoi = value; gbKhoi.Text = tenKhoi; } }
        public string TongHS { get => tongHS; set { tongHS = value; lbTonghs.Text = tongHS; } }
        public string SiSoTD { get => siSoTD; set { siSoTD = value; lbSisotoida.Text = siSoTD; } }
        public string SiSoTT { get => siSoTT; set { siSoTT = value; lbSisoTT.Text = siSoTT; } }
        public string SoLopMo { get => soLopMo; set { soLopMo = value; lbSolopmo.Text = soLopMo; } }
        //public List<LopHocDTO> DsLop { get => dsLop; set { dsLop = value; dgvDSLop.DataSource = dsLop; } }
        public List<LopHocDTO> DsLop
        {
            get => dsLop;
            set
            {
                dsLop = value;
                dgvDSLop.AutoGenerateColumns = false;
                dgvDSLop.DataSource = null; // Đảm bảo làm mới DataGridView
                dgvDSLop.DataSource = dsLop;
                AddSTTColumn(); // Gọi hàm thêm cột STT
            }
        }

        private void AddSTTColumn()
        {
            // Kiểm tra nếu cột STT đã tồn tại, tránh thêm trùng lặp
            if (!dgvDSLop.Columns.Contains("STT"))
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    HeaderText = "STT",
                    ReadOnly = true // Không cho phép chỉnh sửa
                };
                dgvDSLop.Columns.Insert(0, sttColumn); // Thêm cột vào vị trí đầu tiên
            }

            // Đăng ký sự kiện tính toán STT sau khi dữ liệu được load
            dgvDSLop.DataBindingComplete += (s, e) =>
            {
                for (int i = 0; i < dgvDSLop.Rows.Count; i++)
                {
                    dgvDSLop.Rows[i].Cells["STT"].Value = i + 1; // Gán số thứ tự
                }
            };
        }

        private void dgvDSLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
