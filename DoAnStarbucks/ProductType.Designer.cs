namespace DoAnStarbucks
{
    partial class ProductType
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
            this.lbLoaiSp = new System.Windows.Forms.Label();
            this.lbSanPham = new System.Windows.Forms.Label();
            this.lbTen = new System.Windows.Forms.Label();
            this.tbSanPham = new System.Windows.Forms.TextBox();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbLoaiSp
            // 
            this.lbLoaiSp.AutoSize = true;
            this.lbLoaiSp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoaiSp.Location = new System.Drawing.Point(321, 75);
            this.lbLoaiSp.Name = "lbLoaiSp";
            this.lbLoaiSp.Size = new System.Drawing.Size(175, 29);
            this.lbLoaiSp.TabIndex = 0;
            this.lbLoaiSp.Text = "Loại Sản Phẩm";
            // 
            // lbSanPham
            // 
            this.lbSanPham.AutoSize = true;
            this.lbSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSanPham.Location = new System.Drawing.Point(167, 128);
            this.lbSanPham.Name = "lbSanPham";
            this.lbSanPham.Size = new System.Drawing.Size(123, 29);
            this.lbSanPham.TabIndex = 1;
            this.lbSanPham.Text = "Sản Phẩm";
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTen.Location = new System.Drawing.Point(203, 168);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(56, 29);
            this.lbTen.TabIndex = 1;
            this.lbTen.Text = "Tên";
            this.lbTen.Click += new System.EventHandler(this.lbTen_Click);
            // 
            // tbSanPham
            // 
            this.tbSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSanPham.Location = new System.Drawing.Point(307, 127);
            this.tbSanPham.Name = "tbSanPham";
            this.tbSanPham.Size = new System.Drawing.Size(254, 30);
            this.tbSanPham.TabIndex = 2;
            // 
            // tbTen
            // 
            this.tbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTen.Location = new System.Drawing.Point(307, 167);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(254, 30);
            this.tbTen.TabIndex = 2;
            // 
            // ProductType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 598);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.tbSanPham);
            this.Controls.Add(this.lbTen);
            this.Controls.Add(this.lbSanPham);
            this.Controls.Add(this.lbLoaiSp);
            this.Name = "ProductType";
            this.Text = "ProductType";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLoaiSp;
        private System.Windows.Forms.Label lbSanPham;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.TextBox tbSanPham;
        private System.Windows.Forms.TextBox tbTen;
    }
}