using DoAnStarbucks.Models;
using DoAnStarbucks.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnStarbucks
{
    public partial class ProductForm : Form
    {
        ProductTypeRepo productTypeRepo = new ProductTypeRepo();
        ProductRepo productRepo = new ProductRepo();
        public ProductForm()
        {
            InitializeComponent();

            
        }
        private string imagePath;

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;

                // Hiển thị hình ảnh trong PictureBox
                picProductImage.Image = Image.FromFile(imagePath);
            }


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var product = new Product();
            product.ID = txtID.Text;
            product.Name = txtName.Text;
            product.Description = txtDescription.Text;
            product.Price = decimal.Parse(txtPrice.Text);
            product.ProductTypeID = cbProductType.SelectedValue.ToString();
            UploadImage(product);
            productRepo.Add(product);
            picProductImage.Image = null;
            LoadProduct();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var product = new Product();
            product.ID = txtID.Text;
            product.Name = txtName.Text;
            product.Description = txtDescription.Text;
            product.Price = decimal.Parse(txtPrice.Text);
            product.ProductTypeID = cbProductType.SelectedValue.ToString();
            UploadImage(product);
            productRepo.Update(product);
            LoadProduct();
        }
        private void UploadImage(Product product)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                // Tạo một thư mục để lưu trữ hình ảnh nếu nó chưa tồn tại
                string saveDirectory = Path.Combine(Application.StartupPath, "SavedImages");
                Directory.CreateDirectory(saveDirectory);

                // Tạo một tên tệp duy nhất cho hình ảnh (có thể sử dụng Guid)
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imagePath);
                product.Image = uniqueFileName;
                // Tạo đường dẫn đầy đủ cho tệp mới
                string savePath = Path.Combine(saveDirectory, uniqueFileName);

                // Sao chép hình ảnh đến thư mục lưu trữ
                File.Copy(imagePath, savePath);
                imagePath = "";
            }
        }
        private void RemoveImage(string imageName)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                string file = Path.Combine(Application.StartupPath, "SavedImages", imageName);
               
                picProductImage.Image = null;
                //dgvSP.SelectedRows[0];
                File.Delete(file);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            var product = productRepo.Get(txtID.Text);
            productRepo.Delete(product.ID);
            LoadProduct();
            //RemoveImage(product.Image);                      
        }

        private void dgvSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = dgvSP.Rows[e.RowIndex];
                string id = row.Cells["ID"].Value.ToString();
                var product = productRepo.Get(id);
                txtID.Text = product.ID;
                txtName.Text = product.Name;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString();
                cbProductType.Text = product.ProductType.Name;
                
                picProductImage.Image = Image.FromFile(Path.Combine(Application.StartupPath, "SavedImages", product.Image));
                
                
            } 
            catch (Exception) { }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            dgvSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            InitProductTypeComboBox();
            LoadProduct();
        }
        private void LoadProduct()
        {
            var products = productRepo.GetAll();
            var bindingList = products.Select(item =>
            {
                
                Image image = Image.FromFile(Path.Combine(Application.StartupPath,"SavedImages",item.Image));
                return new
                {
                    item.ID,
                    item.Name,
                    item.Price,
                    item.Description,
                    ProductType = item.ProductType.Name,
                    Image = image
                };
            }).ToList();
            dgvSP.DataSource = bindingList;


            dgvSP.Columns["Name"].HeaderText = "Tên sản phẩm";
            dgvSP.Columns["Price"].HeaderText = "Giá";
            dgvSP.Columns["Description"].HeaderText = "Mô tả";
            dgvSP.Columns["ProductType"].HeaderText = "Loại sản phẩm";
            dgvSP.Columns["Image"].HeaderText = "Hình ảnh";

            var imageCoumn = dgvSP.Columns["Image"] as DataGridViewImageColumn;
            imageCoumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            
        }

        private void InitProductTypeComboBox()
        {
            var productTypes = productTypeRepo.GetAll();
            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();
            foreach (var item in productTypes)
            {
                keyValuePairs.Add(new KeyValuePair<string, string>(item.ID, item.Name));
            }
            cbProductType.DataSource = new BindingSource(keyValuePairs, null);
            cbProductType.DisplayMember = "Value";
            cbProductType.ValueMember = "Key";
        }

        
    }
}
