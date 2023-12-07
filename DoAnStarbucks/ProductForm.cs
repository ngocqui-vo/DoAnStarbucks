using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnStarbucks
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();

            
        }
        List<String> loaisp = new List<string>
        {
            "loai 1", "loai 2", "loai 3"
        };

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            foreach (string loai in loaisp)
            {
                TabPage tabPage = new TabPage();
                tabPage.Text = loai;
                tabSP.TabPages.Add(tabPage);
            }
        }
    }
}
