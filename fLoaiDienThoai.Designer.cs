namespace project_quanlybanhang
{
    partial class fLoaiDienThoai
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label maLMTLabel;
            System.Windows.Forms.Label tenLMTLabel;
            System.Windows.Forms.Label label3;
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewLoaiDienThoai = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maLDTTextBox = new System.Windows.Forms.TextBox();
            this.tenLDTTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxMoTa = new System.Windows.Forms.TextBox();
            this.buttonChinhSua = new System.Windows.Forms.ToolStripButton();
            this.lOAIMAYTINHBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.buttonXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.buttonThem = new System.Windows.Forms.ToolStripButton();
            maLMTLabel = new System.Windows.Forms.Label();
            tenLMTLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoaiDienThoai)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lOAIMAYTINHBindingNavigator)).BeginInit();
            this.lOAIMAYTINHBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // maLMTLabel
            // 
            maLMTLabel.AutoSize = true;
            maLMTLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            maLMTLabel.Location = new System.Drawing.Point(11, 49);
            maLMTLabel.Name = "maLMTLabel";
            maLMTLabel.Size = new System.Drawing.Size(91, 29);
            maLMTLabel.TabIndex = 1;
            maLMTLabel.Text = "Mã loại";
            // 
            // tenLMTLabel
            // 
            tenLMTLabel.AutoSize = true;
            tenLMTLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            tenLMTLabel.Location = new System.Drawing.Point(11, 169);
            tenLMTLabel.Name = "tenLMTLabel";
            tenLMTLabel.Size = new System.Drawing.Size(101, 29);
            tenLMTLabel.TabIndex = 3;
            tenLMTLabel.Text = "Tên loại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            label3.Location = new System.Drawing.Point(11, 279);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 29);
            label3.TabIndex = 3;
            label3.Text = "Mô tả";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.textBoxTimKiem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1253, 52);
            this.panel1.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1013, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Mã loại",
            "Tên loại"});
            this.comboBox1.Location = new System.Drawing.Point(267, 10);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 33);
            this.comboBox1.TabIndex = 2;
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxTimKiem.Location = new System.Drawing.Point(685, 6);
            this.textBoxTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTimKiem.Multiline = true;
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(299, 37);
            this.textBoxTimKiem.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(71, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tìm kiếm theo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(480, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập thông tin";
            // 
            // dataGridViewLoaiDienThoai
            // 
            this.dataGridViewLoaiDienThoai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLoaiDienThoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLoaiDienThoai.Location = new System.Drawing.Point(37, 36);
            this.dataGridViewLoaiDienThoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewLoaiDienThoai.Name = "dataGridViewLoaiDienThoai";
            this.dataGridViewLoaiDienThoai.RowHeadersWidth = 51;
            this.dataGridViewLoaiDienThoai.RowTemplate.Height = 24;
            this.dataGridViewLoaiDienThoai.Size = new System.Drawing.Size(723, 386);
            this.dataGridViewLoaiDienThoai.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewLoaiDienThoai);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(467, 90);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(803, 430);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách";
            // 
            // maLDTTextBox
            // 
            this.maLDTTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.maLDTTextBox.Location = new System.Drawing.Point(16, 94);
            this.maLDTTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maLDTTextBox.Name = "maLDTTextBox";
            this.maLDTTextBox.Size = new System.Drawing.Size(359, 34);
            this.maLDTTextBox.TabIndex = 0;
            // 
            // tenLDTTextBox
            // 
            this.tenLDTTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tenLDTTextBox.Location = new System.Drawing.Point(16, 216);
            this.tenLDTTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tenLDTTextBox.Name = "tenLDTTextBox";
            this.tenLDTTextBox.Size = new System.Drawing.Size(359, 34);
            this.tenLDTTextBox.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Controls.Add(tenLMTLabel);
            this.groupBox2.Controls.Add(this.textBoxMoTa);
            this.groupBox2.Controls.Add(this.tenLDTTextBox);
            this.groupBox2.Controls.Add(maLMTLabel);
            this.groupBox2.Controls.Add(this.maLDTTextBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(43, 90);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(401, 384);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin ";
            // 
            // textBoxMoTa
            // 
            this.textBoxMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxMoTa.Location = new System.Drawing.Point(16, 321);
            this.textBoxMoTa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMoTa.Name = "textBoxMoTa";
            this.textBoxMoTa.Size = new System.Drawing.Size(359, 34);
            this.textBoxMoTa.TabIndex = 2;
            // 
            // buttonChinhSua
            // 
            this.buttonChinhSua.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonChinhSua.Image = global::project_quanlybanhang.Properties.Resources.Save;
            this.buttonChinhSua.Name = "buttonChinhSua";
            this.buttonChinhSua.Size = new System.Drawing.Size(91, 42);
            this.buttonChinhSua.Text = "Sửa";
            this.buttonChinhSua.Click += new System.EventHandler(this.buttonChinhSua_Click);
            // 
            // lOAIMAYTINHBindingNavigator
            // 
            this.lOAIMAYTINHBindingNavigator.AddNewItem = null;
            this.lOAIMAYTINHBindingNavigator.CountItem = null;
            this.lOAIMAYTINHBindingNavigator.DeleteItem = null;
            this.lOAIMAYTINHBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.lOAIMAYTINHBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.lOAIMAYTINHBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.lOAIMAYTINHBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonThem,
            this.toolStripLabel3,
            this.buttonChinhSua,
            this.toolStripLabel1,
            this.buttonXoa,
            this.toolStripLabel2,
            this.toolStripButton1});
            this.lOAIMAYTINHBindingNavigator.Location = new System.Drawing.Point(187, 582);
            this.lOAIMAYTINHBindingNavigator.MoveFirstItem = null;
            this.lOAIMAYTINHBindingNavigator.MoveLastItem = null;
            this.lOAIMAYTINHBindingNavigator.MoveNextItem = null;
            this.lOAIMAYTINHBindingNavigator.MovePreviousItem = null;
            this.lOAIMAYTINHBindingNavigator.Name = "lOAIMAYTINHBindingNavigator";
            this.lOAIMAYTINHBindingNavigator.PositionItem = null;
            this.lOAIMAYTINHBindingNavigator.Size = new System.Drawing.Size(640, 45);
            this.lOAIMAYTINHBindingNavigator.TabIndex = 0;
            this.lOAIMAYTINHBindingNavigator.Text = "bindingNavigator1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(69, 42);
            this.toolStripLabel3.Text = "               ";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 42);
            this.toolStripLabel1.Text = "               ";
            // 
            // buttonXoa
            // 
            this.buttonXoa.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXoa.Image = global::project_quanlybanhang.Properties.Resources.xóa;
            this.buttonXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(91, 42);
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(69, 42);
            this.toolStripLabel2.Text = "               ";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.toolStripButton1.Image = global::project_quanlybanhang.Properties.Resources.stop;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(94, 42);
            this.toolStripButton1.Text = "Hủy";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThem.Image = global::project_quanlybanhang.Properties.Resources.Thêm_1;
            this.buttonThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(115, 42);
            this.buttonThem.Text = "Thêm";
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // fLoaiDienThoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1253, 674);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lOAIMAYTINHBindingNavigator);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fLoaiDienThoai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fLoaiDienThoai";
            this.Load += new System.EventHandler(this.fLoaimaytinh_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoaiDienThoai)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lOAIMAYTINHBindingNavigator)).EndInit();
            this.lOAIMAYTINHBindingNavigator.ResumeLayout(false);
            this.lOAIMAYTINHBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewLoaiDienThoai;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox maLDTTextBox;
        private System.Windows.Forms.TextBox tenLDTTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton buttonChinhSua;
        private System.Windows.Forms.BindingNavigator lOAIMAYTINHBindingNavigator;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton buttonXoa;
        private System.Windows.Forms.TextBox textBoxMoTa;
        private System.Windows.Forms.ToolStripButton buttonThem;
    }
}