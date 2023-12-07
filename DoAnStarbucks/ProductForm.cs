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
       

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            //saveFileDialogImage.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp|GIF Image|*.gif";
            //if (saveFileDialogImage.ShowDialog() == DialogResult.OK)
            //{
            //    string filePath = saveFileDialogImage.FileName;

            //    // Lưu hình ảnh xuống đĩa
            //    picProductImage.Image.Save(filePath);

            //    MessageBox.Show("Hình ảnh đã được lưu thành công!");
            //}

        }
    }
}
