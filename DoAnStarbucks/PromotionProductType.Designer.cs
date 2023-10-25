namespace DoAnStarbucks
{
    partial class PromotionProductType
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
            this.lbSanPham = new System.Windows.Forms.Label();
            this.lbKhuyenMai = new System.Windows.Forms.Label();
            this.tbSanPham = new System.Windows.Forms.TextBox();
            this.tbKhuyenMai = new System.Windows.Forms.TextBox();
            this.btwiew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSanPham
            // 
            this.lbSanPham.AutoSize = true;
            this.lbSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSanPham.Location = new System.Drawing.Point(122, 86);
            this.lbSanPham.Name = "lbSanPham";
            this.lbSanPham.Size = new System.Drawing.Size(104, 25);
            this.lbSanPham.TabIndex = 0;
            this.lbSanPham.Text = "Sản Phẩm";
            // 
            // lbKhuyenMai
            // 
            this.lbKhuyenMai.AutoSize = true;
            this.lbKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKhuyenMai.Location = new System.Drawing.Point(109, 127);
            this.lbKhuyenMai.Name = "lbKhuyenMai";
            this.lbKhuyenMai.Size = new System.Drawing.Size(117, 25);
            this.lbKhuyenMai.TabIndex = 0;
            this.lbKhuyenMai.Text = "Khuyến Mãi";
            // 
            // tbSanPham
            // 
            this.tbSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSanPham.Location = new System.Drawing.Point(243, 80);
            this.tbSanPham.Name = "tbSanPham";
            this.tbSanPham.Size = new System.Drawing.Size(235, 34);
            this.tbSanPham.TabIndex = 1;
            // 
            // tbKhuyenMai
            // 
            this.tbKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKhuyenMai.Location = new System.Drawing.Point(243, 127);
            this.tbKhuyenMai.Name = "tbKhuyenMai";
            this.tbKhuyenMai.Size = new System.Drawing.Size(235, 34);
            this.tbKhuyenMai.TabIndex = 1;
            // 
            // btwiew
            // 
            this.btwiew.Location = new System.Drawing.Point(312, 182);
            this.btwiew.Name = "btwiew";
            this.btwiew.Size = new System.Drawing.Size(91, 61);
            this.btwiew.TabIndex = 2;
            this.btwiew.Text = "Xem";
            this.btwiew.UseVisualStyleBackColor = true;
            // 
            // PromotionProductType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 540);
            this.Controls.Add(this.btwiew);
            this.Controls.Add(this.tbKhuyenMai);
            this.Controls.Add(this.tbSanPham);
            this.Controls.Add(this.lbKhuyenMai);
            this.Controls.Add(this.lbSanPham);
            this.Name = "PromotionProductType";
            this.Text = "PromotionProductType";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSanPham;
        private System.Windows.Forms.Label lbKhuyenMai;
        private System.Windows.Forms.TextBox tbSanPham;
        private System.Windows.Forms.TextBox tbKhuyenMai;
        private System.Windows.Forms.Button btwiew;
    }
}