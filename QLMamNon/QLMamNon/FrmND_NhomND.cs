using BUL;
using DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace QLMamNon
{
    public partial class FrmND_NhomND : Form
    {
        public FrmND_NhomND()
        {
            InitializeComponent();
        }


        NhomNguoiDungBUL nhomNDBul;
        NguoiDungBUL nguoiDungBul;
        NguoiDung_NhomNguoiDungBUL nD_NhomNdBul;

        private List<NguoiDungDTO> lstNguoiDung;
        private List<NguoiDung_NhomNguoiDungDTO> lstND_NhomND;

        private void FrmND_NhomND_Load(object sender, System.EventArgs e)
        {
            nhomNDBul = new NhomNguoiDungBUL();
            nD_NhomNdBul = new NguoiDung_NhomNguoiDungBUL();
            nguoiDungBul = new NguoiDungBUL();

            loadDgvNguoiDung();
            loadCboNhomNguoiDung();
            cboNhomND.SelectedIndex = -1;
            dgvNguoiDungTrongNhom.DataSource = null;
            dgvNguoiDung.DataSource = null;
        }

        void loadCboNhomNguoiDung()
        {
            cboNhomND.DataSource = nhomNDBul.getAll();
            cboNhomND.ValueMember = "MaNhom";
            cboNhomND.DisplayMember = "TenNhom";
        }

        void loadDgvNguoiDung()
        {
            dgvNguoiDungTrongNhom.AutoGenerateColumns = false;

            //lưu vào list trước khi lưu vào datagridview
            if (cboNhomND.SelectedIndex != -1)
            {
                lstNguoiDung = nguoiDungBul.layNDConHoatDongVaKoCoTrongNhom(cboNhomND.SelectedValue.ToString());
                dgvNguoiDung.DataSource = new BindingList<NguoiDungDTO>(lstNguoiDung);
            }

            if (dgvNguoiDung.Columns.Contains("MatKhau"))
                dgvNguoiDung.Columns.Remove("MatKhau");

            if (dgvNguoiDung.Columns.Contains("TrangThai"))
                dgvNguoiDung.Columns.Remove("TrangThai");

        }


        void loadDgvNguoiDungTrongNhom()
        {
            dgvNguoiDung.AutoGenerateColumns = false;

            if (cboNhomND.SelectedIndex != -1)
            {
                //lưu vào list trước khi lưu vào datagridview
                lstND_NhomND = nD_NhomNdBul.layNguoiDungTheoMaNhom(cboNhomND.SelectedValue.ToString());
                dgvNguoiDungTrongNhom.DataSource = new BindingList<NguoiDung_NhomNguoiDungDTO>(lstND_NhomND);
            }


        }





        private void btnThem_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (cboNhomND.SelectedIndex != -1 && dgvNguoiDung.SelectedRows.Count != 0)
                {
                    string maND = dgvNguoiDung.SelectedRows[0].Cells[0].Value.ToString();
                    string maNhom = cboNhomND.SelectedValue.ToString();
                    NguoiDung_NhomNguoiDungDTO dto = new NguoiDung_NhomNguoiDungDTO( maND, maNhom, txtGhiChu.Text);
                    if (nD_NhomNdBul.themND_NhomND(dto))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //xóa dòng đó ra khỏi datagridview
                        lstNguoiDung.RemoveAt(dgvNguoiDung.SelectedRows[0].Index);
                        dgvNguoiDung.DataSource = new BindingList<NguoiDungDTO>(lstNguoiDung);
                    }
                    else
                        MessageBox.Show("Thêm không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    loadDgvNguoiDungTrongNhom();
                    loadDgvNguoiDung();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin");
                }
            }


        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (cboNhomND.SelectedIndex != -1 && dgvNguoiDungTrongNhom.SelectedRows.Count != 0)
                {
                    string maND = dgvNguoiDungTrongNhom.SelectedRows[0].Cells[1].Value.ToString();
                    string maNhom = cboNhomND.SelectedValue.ToString();
                    NguoiDung_NhomNguoiDungDTO dto = new NguoiDung_NhomNguoiDungDTO(maND, maNhom, txtGhiChu.Text);
                    if (nD_NhomNdBul.xoaND_NhomND(dto))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //xóa dòng đó ra khỏi datagridview
                        lstND_NhomND.RemoveAt(dgvNguoiDungTrongNhom.SelectedRows[0].Index);
                        dgvNguoiDungTrongNhom.DataSource = new BindingList<NguoiDung_NhomNguoiDungDTO>(lstND_NhomND);
                    }
                    else
                        MessageBox.Show("Xóa không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    loadDgvNguoiDungTrongNhom();
                    loadDgvNguoiDung();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin");
                }
            }
        }

        private void cboNhomND_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboNhomND.SelectedIndex != -1)
            {
                loadDgvNguoiDungTrongNhom();
                loadDgvNguoiDung();
            }
        }
    }
}
