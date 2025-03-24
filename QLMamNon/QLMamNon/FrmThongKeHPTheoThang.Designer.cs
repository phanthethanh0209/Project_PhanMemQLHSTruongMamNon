namespace QLMamNon
{
    partial class FrmThongKeHPTheoThang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.dgvThongKe = new Guna.UI2.WinForms.Guna2DataGridView();
            this.TenKhoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienDaThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienChuaThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuGroupBox2 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bunifuGroupBox1 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.ChartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bunifuButton21 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnXemDSHS = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.cboThang = new Bunifu.UI.WinForms.BunifuDropdown();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboNamHoc = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuGroupBox4 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.bunifuGroupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.bunifuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartThongKe)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            this.bunifuGroupBox4.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvThongKe
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvThongKe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThongKe.ColumnHeadersHeight = 40;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenKhoi,
            this.TenLop,
            this.TienHP,
            this.TienDaThu,
            this.TienChuaThu,
            this.Thang});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThongKe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThongKe.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongKe.Location = new System.Drawing.Point(8, 31);
            this.dgvThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersVisible = false;
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 40;
            this.dgvThongKe.Size = new System.Drawing.Size(682, 491);
            this.dgvThongKe.TabIndex = 88;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThongKe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThongKe.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKe.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongKe.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.dgvThongKe.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThongKe.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThongKe.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThongKe.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongKe.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvThongKe.ThemeStyle.ReadOnly = true;
            this.dgvThongKe.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKe.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongKe.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThongKe.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvThongKe.ThemeStyle.RowsStyle.Height = 40;
            this.dgvThongKe.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongKe.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // TenKhoi
            // 
            this.TenKhoi.DataPropertyName = "TenKhoi";
            this.TenKhoi.HeaderText = "Khối lớp";
            this.TenKhoi.MinimumWidth = 6;
            this.TenKhoi.Name = "TenKhoi";
            this.TenKhoi.ReadOnly = true;
            // 
            // TenLop
            // 
            this.TenLop.DataPropertyName = "TenLop";
            this.TenLop.HeaderText = "Lớp học";
            this.TenLop.MinimumWidth = 6;
            this.TenLop.Name = "TenLop";
            this.TenLop.ReadOnly = true;
            // 
            // TienHP
            // 
            this.TienHP.DataPropertyName = "TienHP";
            this.TienHP.HeaderText = "Học phí";
            this.TienHP.MinimumWidth = 6;
            this.TienHP.Name = "TienHP";
            this.TienHP.ReadOnly = true;
            // 
            // TienDaThu
            // 
            this.TienDaThu.DataPropertyName = "TienDaThu";
            this.TienDaThu.HeaderText = "Đã thu";
            this.TienDaThu.MinimumWidth = 6;
            this.TienDaThu.Name = "TienDaThu";
            this.TienDaThu.ReadOnly = true;
            // 
            // TienChuaThu
            // 
            this.TienChuaThu.DataPropertyName = "TienChuaThu";
            this.TienChuaThu.HeaderText = "Chưa thu";
            this.TienChuaThu.MinimumWidth = 6;
            this.TienChuaThu.Name = "TienChuaThu";
            this.TienChuaThu.ReadOnly = true;
            // 
            // Thang
            // 
            this.Thang.DataPropertyName = "Thang";
            this.Thang.HeaderText = "Thang";
            this.Thang.MinimumWidth = 6;
            this.Thang.Name = "Thang";
            this.Thang.ReadOnly = true;
            this.Thang.Visible = false;
            // 
            // bunifuGroupBox2
            // 
            this.bunifuGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuGroupBox2.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuGroupBox2.BorderRadius = 1;
            this.bunifuGroupBox2.BorderThickness = 1;
            this.bunifuGroupBox2.Controls.Add(this.dgvThongKe);
            this.bunifuGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuGroupBox2.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox2.LabelIndent = 10;
            this.bunifuGroupBox2.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox2.Location = new System.Drawing.Point(3, 2);
            this.bunifuGroupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuGroupBox2.Name = "bunifuGroupBox2";
            this.bunifuGroupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuGroupBox2.Size = new System.Drawing.Size(704, 528);
            this.bunifuGroupBox2.TabIndex = 65;
            this.bunifuGroupBox2.TabStop = false;
            this.bunifuGroupBox2.Text = "Danh sách học phí theo tháng";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(335, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(813, 49);
            this.label2.TabIndex = 85;
            this.label2.Text = "THỐNG KÊ THU HỌC PHÍ THEO THÁNG";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.bunifuGroupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bunifuGroupBox2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 209);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1420, 532);
            this.tableLayoutPanel1.TabIndex = 87;
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuGroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuGroupBox1.BorderRadius = 1;
            this.bunifuGroupBox1.BorderThickness = 1;
            this.bunifuGroupBox1.Controls.Add(this.ChartThongKe);
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuGroupBox1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox1.LabelIndent = 10;
            this.bunifuGroupBox1.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox1.Location = new System.Drawing.Point(713, 2);
            this.bunifuGroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuGroupBox1.Size = new System.Drawing.Size(704, 528);
            this.bunifuGroupBox1.TabIndex = 66;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Biểu đồ thống kê";
            // 
            // ChartThongKe
            // 
            this.ChartThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.ChartThongKe.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartThongKe.Legends.Add(legend1);
            this.ChartThongKe.Location = new System.Drawing.Point(3, 28);
            this.ChartThongKe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChartThongKe.Name = "ChartThongKe";
            this.ChartThongKe.Size = new System.Drawing.Size(699, 498);
            this.ChartThongKe.TabIndex = 88;
            this.ChartThongKe.Text = "chart1";
            // 
            // bunifuButton21
            // 
            this.bunifuButton21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuButton21.BorderRadius = 15;
            this.bunifuButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton21.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bunifuButton21.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bunifuButton21.DisabledState.FillColor = System.Drawing.Color.Gray;
            this.bunifuButton21.DisabledState.FillColor2 = System.Drawing.Color.Silver;
            this.bunifuButton21.DisabledState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton21.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bunifuButton21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuButton21.ForeColor = System.Drawing.Color.White;
            this.bunifuButton21.Image = global::QLMamNon.Properties.Resources.Print;
            this.bunifuButton21.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuButton21.Location = new System.Drawing.Point(1168, 3);
            this.bunifuButton21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuButton21.Name = "bunifuButton21";
            this.bunifuButton21.Size = new System.Drawing.Size(230, 45);
            this.bunifuButton21.TabIndex = 79;
            this.bunifuButton21.Text = "In báo cáo";
            this.bunifuButton21.Click += new System.EventHandler(this.bunifuButton21_Click);
            // 
            // btnXemDSHS
            // 
            this.btnXemDSHS.BorderRadius = 15;
            this.btnXemDSHS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemDSHS.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXemDSHS.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXemDSHS.DisabledState.FillColor = System.Drawing.Color.DarkGray;
            this.btnXemDSHS.DisabledState.FillColor2 = System.Drawing.Color.Silver;
            this.btnXemDSHS.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnXemDSHS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXemDSHS.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnXemDSHS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemDSHS.ForeColor = System.Drawing.Color.White;
            this.btnXemDSHS.Image = global::QLMamNon.Properties.Resources.Static_Views;
            this.btnXemDSHS.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnXemDSHS.Location = new System.Drawing.Point(935, 2);
            this.btnXemDSHS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXemDSHS.Name = "btnXemDSHS";
            this.btnXemDSHS.Size = new System.Drawing.Size(227, 48);
            this.btnXemDSHS.TabIndex = 81;
            this.btnXemDSHS.Text = "Xem doanh thu";
            this.btnXemDSHS.Click += new System.EventHandler(this.btnXemDSHS_Click);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel10.ColumnCount = 6;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.Controls.Add(this.cboThang, 3, 0);
            this.tableLayoutPanel10.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.cboNamHoc, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.bunifuButton21, 5, 0);
            this.tableLayoutPanel10.Controls.Add(this.btnXemDSHS, 4, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(8, 31);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(1401, 52);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // cboThang
            // 
            this.cboThang.BackColor = System.Drawing.Color.Transparent;
            this.cboThang.BackgroundColor = System.Drawing.Color.White;
            this.cboThang.BorderColor = System.Drawing.Color.Silver;
            this.cboThang.BorderRadius = 1;
            this.cboThang.Color = System.Drawing.Color.Silver;
            this.cboThang.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cboThang.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboThang.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboThang.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboThang.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cboThang.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cboThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboThang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboThang.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cboThang.FillDropDown = true;
            this.cboThang.FillIndicator = false;
            this.cboThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboThang.ForeColor = System.Drawing.Color.Black;
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Icon = null;
            this.cboThang.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cboThang.IndicatorColor = System.Drawing.Color.DarkGray;
            this.cboThang.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cboThang.IndicatorThickness = 2;
            this.cboThang.IsDropdownOpened = false;
            this.cboThang.ItemBackColor = System.Drawing.Color.White;
            this.cboThang.ItemBorderColor = System.Drawing.Color.White;
            this.cboThang.ItemForeColor = System.Drawing.Color.Black;
            this.cboThang.ItemHeight = 26;
            this.cboThang.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cboThang.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cboThang.ItemTopMargin = 3;
            this.cboThang.Location = new System.Drawing.Point(702, 5);
            this.cboThang.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(227, 32);
            this.cboThang.TabIndex = 83;
            this.cboThang.Text = null;
            this.cboThang.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cboThang.TextLeftMargin = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(544, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 82;
            this.label1.Text = "Tháng";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(64, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 25);
            this.label9.TabIndex = 49;
            this.label9.Text = "Năm học";
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.BackColor = System.Drawing.Color.Transparent;
            this.cboNamHoc.BackgroundColor = System.Drawing.Color.White;
            this.cboNamHoc.BorderColor = System.Drawing.Color.Silver;
            this.cboNamHoc.BorderRadius = 1;
            this.cboNamHoc.Color = System.Drawing.Color.Silver;
            this.cboNamHoc.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cboNamHoc.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboNamHoc.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboNamHoc.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboNamHoc.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cboNamHoc.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cboNamHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNamHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNamHoc.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cboNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamHoc.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cboNamHoc.FillDropDown = true;
            this.cboNamHoc.FillIndicator = false;
            this.cboNamHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboNamHoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNamHoc.ForeColor = System.Drawing.Color.Black;
            this.cboNamHoc.FormattingEnabled = true;
            this.cboNamHoc.Icon = null;
            this.cboNamHoc.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cboNamHoc.IndicatorColor = System.Drawing.Color.DarkGray;
            this.cboNamHoc.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cboNamHoc.IndicatorThickness = 2;
            this.cboNamHoc.IsDropdownOpened = false;
            this.cboNamHoc.ItemBackColor = System.Drawing.Color.White;
            this.cboNamHoc.ItemBorderColor = System.Drawing.Color.White;
            this.cboNamHoc.ItemForeColor = System.Drawing.Color.Black;
            this.cboNamHoc.ItemHeight = 26;
            this.cboNamHoc.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cboNamHoc.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cboNamHoc.ItemTopMargin = 3;
            this.cboNamHoc.Location = new System.Drawing.Point(236, 5);
            this.cboNamHoc.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(227, 32);
            this.cboNamHoc.TabIndex = 58;
            this.cboNamHoc.Text = null;
            this.cboNamHoc.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cboNamHoc.TextLeftMargin = 5;
            // 
            // bunifuGroupBox4
            // 
            this.bunifuGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuGroupBox4.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuGroupBox4.BorderRadius = 1;
            this.bunifuGroupBox4.BorderThickness = 1;
            this.bunifuGroupBox4.Controls.Add(this.tableLayoutPanel10);
            this.bunifuGroupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuGroupBox4.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox4.LabelIndent = 10;
            this.bunifuGroupBox4.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox4.Location = new System.Drawing.Point(3, 2);
            this.bunifuGroupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuGroupBox4.Name = "bunifuGroupBox4";
            this.bunifuGroupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuGroupBox4.Size = new System.Drawing.Size(1414, 91);
            this.bunifuGroupBox4.TabIndex = 0;
            this.bunifuGroupBox4.TabStop = false;
            this.bunifuGroupBox4.Text = "Thống kê học phí";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel9.Controls.Add(this.bunifuGroupBox4, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(14, 88);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1420, 101);
            this.tableLayoutPanel9.TabIndex = 86;
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientButton1.BorderRadius = 15;
            this.guna2GradientButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.Gray;
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.Silver;
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2GradientButton1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.Image = global::QLMamNon.Properties.Resources.Replace;
            this.guna2GradientButton1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2GradientButton1.Location = new System.Drawing.Point(3, 3);
            this.guna2GradientButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(240, 45);
            this.guna2GradientButton1.TabIndex = 96;
            this.guna2GradientButton1.Text = "Biểu đồ ngang";
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // guna2GradientButton2
            // 
            this.guna2GradientButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientButton2.BorderRadius = 15;
            this.guna2GradientButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.Gray;
            this.guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.Silver;
            this.guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2GradientButton2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton2.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.Image = global::QLMamNon.Properties.Resources.Replace;
            this.guna2GradientButton2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2GradientButton2.Location = new System.Drawing.Point(249, 3);
            this.guna2GradientButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GradientButton2.Name = "guna2GradientButton2";
            this.guna2GradientButton2.Size = new System.Drawing.Size(240, 45);
            this.guna2GradientButton2.TabIndex = 97;
            this.guna2GradientButton2.Text = "Biểu đồ dọc";
            this.guna2GradientButton2.Click += new System.EventHandler(this.guna2GradientButton2_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Controls.Add(this.guna2GradientButton1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.guna2GradientButton2, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(942, 758);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(492, 52);
            this.tableLayoutPanel3.TabIndex = 89;
            // 
            // FrmThongKeHPTheoThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 824);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel9);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmThongKeHPTheoThang";
            this.Text = "FrmThongKeHPTheoThang";
            this.Load += new System.EventHandler(this.FrmThongKeHPTheoThang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.bunifuGroupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.bunifuGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartThongKe)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.bunifuGroupBox4.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView dgvThongKe;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2GradientButton bunifuButton21;
        private Guna.UI2.WinForms.Guna2GradientButton btnXemDSHS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label9;
        private Bunifu.UI.WinForms.BunifuDropdown cboNamHoc;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private Bunifu.UI.WinForms.BunifuDropdown cboThang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienDaThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienChuaThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thang;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartThongKe;
    }
}