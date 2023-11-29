namespace DoAnStarbucks
{
    partial class PromotionForm
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
            this.lbTenKhuyenMai = new System.Windows.Forms.Label();
            this.lbBatDau = new System.Windows.Forms.Label();
            this.lbKetThuc = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbMieuTa = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lbLoaiSp = new System.Windows.Forms.Label();
            this.cbProductType = new System.Windows.Forms.ComboBox();
            this.labelID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.dgvPromotion = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotion)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTenKhuyenMai
            // 
            this.lbTenKhuyenMai.AutoSize = true;
            this.lbTenKhuyenMai.Location = new System.Drawing.Point(46, 127);
            this.lbTenKhuyenMai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTenKhuyenMai.Name = "lbTenKhuyenMai";
            this.lbTenKhuyenMai.Size = new System.Drawing.Size(85, 13);
            this.lbTenKhuyenMai.TabIndex = 1;
            this.lbTenKhuyenMai.Text = "Tên Khuyến Mãi";
            // 
            // lbBatDau
            // 
            this.lbBatDau.AutoSize = true;
            this.lbBatDau.Location = new System.Drawing.Point(46, 196);
            this.lbBatDau.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBatDau.Name = "lbBatDau";
            this.lbBatDau.Size = new System.Drawing.Size(74, 13);
            this.lbBatDau.TabIndex = 1;
            this.lbBatDau.Text = "Ngày Bắt Đầu";
            // 
            // lbKetThuc
            // 
            this.lbKetThuc.AutoSize = true;
            this.lbKetThuc.Location = new System.Drawing.Point(46, 236);
            this.lbKetThuc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbKetThuc.Name = "lbKetThuc";
            this.lbKetThuc.Size = new System.Drawing.Size(82, 13);
            this.lbKetThuc.TabIndex = 1;
            this.lbKetThuc.Text = "Ngày Kết Thúc ";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(138, 269);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(151, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(138, 124);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 20);
            this.txtName.TabIndex = 2;
            // 
            // lbMieuTa
            // 
            this.lbMieuTa.AutoSize = true;
            this.lbMieuTa.Location = new System.Drawing.Point(46, 272);
            this.lbMieuTa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMieuTa.Name = "lbMieuTa";
            this.lbMieuTa.Size = new System.Drawing.Size(46, 13);
            this.lbMieuTa.TabIndex = 1;
            this.lbMieuTa.Text = "Miêu Tả";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(138, 191);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(151, 20);
            this.dtpStart.TabIndex = 3;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(138, 231);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(151, 20);
            this.dtpEnd.TabIndex = 3;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(212, 347);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(72, 24);
            this.btnXoa.TabIndex = 66;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(134, 348);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(2);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(74, 23);
            this.btnCapNhat.TabIndex = 65;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(62, 350);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(68, 21);
            this.btnThem.TabIndex = 64;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lbLoaiSp
            // 
            this.lbLoaiSp.AutoSize = true;
            this.lbLoaiSp.Location = new System.Drawing.Point(46, 306);
            this.lbLoaiSp.Name = "lbLoaiSp";
            this.lbLoaiSp.Size = new System.Drawing.Size(76, 13);
            this.lbLoaiSp.TabIndex = 67;
            this.lbLoaiSp.Text = "Loại sản phẩm";
            // 
            // cbProductType
            // 
            this.cbProductType.FormattingEnabled = true;
            this.cbProductType.Location = new System.Drawing.Point(138, 303);
            this.cbProductType.Name = "cbProductType";
            this.cbProductType.Size = new System.Drawing.Size(151, 21);
            this.cbProductType.TabIndex = 68;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(47, 91);
            this.labelID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 92;
            this.labelID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(138, 88);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(151, 20);
            this.txtID.TabIndex = 91;
            // 
            // dgvPromotion
            // 
            this.dgvPromotion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromotion.Location = new System.Drawing.Point(323, 88);
            this.dgvPromotion.Name = "dgvPromotion";
            this.dgvPromotion.Size = new System.Drawing.Size(772, 354);
            this.dgvPromotion.TabIndex = 93;
            this.dgvPromotion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPromotion_CellContentClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkGreen;
            this.label9.Location = new System.Drawing.Point(84, 33);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 17);
            this.label9.TabIndex = 95;
            this.label9.Text = "Thông tin khuyến mãi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(567, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 17);
            this.label4.TabIndex = 94;
            this.label4.Text = "Danh sách khuyến mãi";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(138, 158);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(151, 20);
            this.txtValue.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 161);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "% khuyến mãi";
            // 
            // PromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 492);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvPromotion);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.cbProductType);
            this.Controls.Add(this.lbLoaiSp);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lbMieuTa);
            this.Controls.Add(this.lbKetThuc);
            this.Controls.Add(this.lbBatDau);
            this.Controls.Add(this.lbTenKhuyenMai);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PromotionForm";
            this.Text = "Khuyến Mãi";
            this.Load += new System.EventHandler(this.PromotionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTenKhuyenMai;
        private System.Windows.Forms.Label lbBatDau;
        private System.Windows.Forms.Label lbKetThuc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lbMieuTa;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lbLoaiSp;
        private System.Windows.Forms.ComboBox cbProductType;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DataGridView dgvPromotion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label1;
    }
}