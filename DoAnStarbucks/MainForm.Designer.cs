namespace DoAnStarbucks
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.chiNhánhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýChiNhánhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giờLàmViệcCửaHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loạiKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đặtMónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loạiSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khuyếnMãiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phươngThứcThanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbGioiThieu = new System.Windows.Forms.Label();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiNhánhToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.nhânViênToolStripMenuItem,
            this.sảnPhẩmToolStripMenuItem,
            this.khuyếnMãiToolStripMenuItem,
            this.báoCáoToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem,
            this.phươngThứcThanhToánToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuMain.Size = new System.Drawing.Size(877, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // chiNhánhToolStripMenuItem
            // 
            this.chiNhánhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýChiNhánhToolStripMenuItem,
            this.giờLàmViệcCửaHàngToolStripMenuItem});
            this.chiNhánhToolStripMenuItem.Name = "chiNhánhToolStripMenuItem";
            this.chiNhánhToolStripMenuItem.Size = new System.Drawing.Size(74, 22);
            this.chiNhánhToolStripMenuItem.Text = "Chi nhánh";
            // 
            // quảnLýChiNhánhToolStripMenuItem
            // 
            this.quảnLýChiNhánhToolStripMenuItem.Name = "quảnLýChiNhánhToolStripMenuItem";
            this.quảnLýChiNhánhToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.quảnLýChiNhánhToolStripMenuItem.Text = "Quản lý chi nhánh";
            this.quảnLýChiNhánhToolStripMenuItem.Click += new System.EventHandler(this.quảnLýChiNhánhToolStripMenuItem_Click);
            // 
            // giờLàmViệcCửaHàngToolStripMenuItem
            // 
            this.giờLàmViệcCửaHàngToolStripMenuItem.Name = "giờLàmViệcCửaHàngToolStripMenuItem";
            this.giờLàmViệcCửaHàngToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.giờLàmViệcCửaHàngToolStripMenuItem.Text = "Giờ làm việc cửa hàng";
            this.giờLàmViệcCửaHàngToolStripMenuItem.Click += new System.EventHandler(this.giờLàmViệcCửaHàngToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loạiKháchHàngToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.đặtMónToolStripMenuItem});
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            // 
            // loạiKháchHàngToolStripMenuItem
            // 
            this.loạiKháchHàngToolStripMenuItem.Name = "loạiKháchHàngToolStripMenuItem";
            this.loạiKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loạiKháchHàngToolStripMenuItem.Text = "Loại khách hàng";
            this.loạiKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.loạiKháchHàngToolStripMenuItem_Click);
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý khách hàng";
            this.quảnLýKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKháchHàngToolStripMenuItem_Click);
            // 
            // đặtMónToolStripMenuItem
            // 
            this.đặtMónToolStripMenuItem.Name = "đặtMónToolStripMenuItem";
            this.đặtMónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.đặtMónToolStripMenuItem.Text = "Đặt món";
            this.đặtMónToolStripMenuItem.Click += new System.EventHandler(this.đặtMónToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcVụToolStripMenuItem,
            this.quảnLýNhânViênToolStripMenuItem});
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(73, 22);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            // 
            // chứcVụToolStripMenuItem
            // 
            this.chứcVụToolStripMenuItem.Name = "chứcVụToolStripMenuItem";
            this.chứcVụToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.chứcVụToolStripMenuItem.Text = "Chức vụ";
            this.chứcVụToolStripMenuItem.Click += new System.EventHandler(this.chứcVụToolStripMenuItem_Click);
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản lý nhân viên";
            this.quảnLýNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loạiSảnPhẩmToolStripMenuItem,
            this.quảnLýSảnPhẩmToolStripMenuItem});
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(72, 22);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản phẩm";
            // 
            // loạiSảnPhẩmToolStripMenuItem
            // 
            this.loạiSảnPhẩmToolStripMenuItem.Name = "loạiSảnPhẩmToolStripMenuItem";
            this.loạiSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loạiSảnPhẩmToolStripMenuItem.Text = "Loại sản phẩm";
            this.loạiSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.loạiSảnPhẩmToolStripMenuItem_Click);
            // 
            // quảnLýSảnPhẩmToolStripMenuItem
            // 
            this.quảnLýSảnPhẩmToolStripMenuItem.Name = "quảnLýSảnPhẩmToolStripMenuItem";
            this.quảnLýSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quảnLýSảnPhẩmToolStripMenuItem.Text = "Quản lý sản phẩm";
            this.quảnLýSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýSảnPhẩmToolStripMenuItem_Click);
            // 
            // khuyếnMãiToolStripMenuItem
            // 
            this.khuyếnMãiToolStripMenuItem.Name = "khuyếnMãiToolStripMenuItem";
            this.khuyếnMãiToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
            this.khuyếnMãiToolStripMenuItem.Text = "Khuyến mãi";
            this.khuyếnMãiToolStripMenuItem.Click += new System.EventHandler(this.khuyếnMãiToolStripMenuItem_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doanhThuToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.doanhThuToolStripMenuItem.Text = "Doanh thu";
            this.doanhThuToolStripMenuItem.Click += new System.EventHandler(this.doanhThuToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(69, 22);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // phươngThứcThanhToánToolStripMenuItem
            // 
            this.phươngThứcThanhToánToolStripMenuItem.Name = "phươngThứcThanhToánToolStripMenuItem";
            this.phươngThứcThanhToánToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.phươngThứcThanhToánToolStripMenuItem.Text = "Phương thức thanh toán";
            this.phươngThứcThanhToánToolStripMenuItem.Click += new System.EventHandler(this.phươngThứcThanhToánToolStripMenuItem_Click);
            // 
            // lbGioiThieu
            // 
            this.lbGioiThieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbGioiThieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGioiThieu.ForeColor = System.Drawing.Color.Black;
            this.lbGioiThieu.Location = new System.Drawing.Point(0, 24);
            this.lbGioiThieu.Name = "lbGioiThieu";
            this.lbGioiThieu.Size = new System.Drawing.Size(877, 39);
            this.lbGioiThieu.TabIndex = 1;
            this.lbGioiThieu.Text = "Phần mềm quản lý chuỗi cà phê StarBuck";
            this.lbGioiThieu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(877, 513);
            this.Controls.Add(this.lbGioiThieu);
            this.Controls.Add(this.menuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.Text = "Trang Chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.Label lbGioiThieu;
        private System.Windows.Forms.ToolStripMenuItem chiNhánhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýChiNhánhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giờLàmViệcCửaHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khuyếnMãiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loạiKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chứcVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loạiSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đặtMónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phươngThứcThanhToánToolStripMenuItem;
    }
}