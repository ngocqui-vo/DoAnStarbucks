using DoAnStarbucks.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnStarbucks.Repository
{
    internal class ProductRepo
    {
        SqlConnection connection = Connect.GetConnection();
        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ReadProduct";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = reader["product_id"].ToString();
                    product.Name = reader["name"].ToString();
                    product.Price = decimal.Parse(reader["price"].ToString());
                    product.Description = reader["description"].ToString();
                    product.Image = reader["image"].ToString();
                    product.ProductTypeID = reader["product_type_id"].ToString();
                    product.ProductType = new ProductType();
                    product.ProductType.Name = reader["product_type_name"].ToString();

                    list.Add(product);
                }
            }
            connection.Close();
            return list;
        }
        public List<Product> GetAllWithType(string typeID)
        {
            List<Product> list = new List<Product>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetProductWithType";
            cmd.Parameters.AddWithValue("@product_type_id", typeID);

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = reader["product_id"].ToString();
                    product.Name = reader["name"].ToString();
                    product.Price = decimal.Parse(reader["price"].ToString());
                    product.Description = reader["description"].ToString();
                    product.Image = reader["image"].ToString();
                    product.ProductTypeID = reader["product_type_id"].ToString();
                    product.ProductType = new ProductType();
                    product.ProductType.Name = reader["product_type_name"].ToString();

                    list.Add(product);
                }
            }
            connection.Close();
            return list;
        }
        public Product Get(string id)
        {
            Product product = new Product();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ReadProductById";
            cmd.Parameters.AddWithValue("@product_id", id);

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                
                product.ID = reader["product_id"].ToString();
                product.Name = reader["name"].ToString();
                product.Price = decimal.Parse(reader["price"].ToString());
                product.Description = reader["description"].ToString();
                product.Image = reader["image"].ToString();
                product.ProductTypeID = reader["product_type_id"].ToString();
                product.ProductType = new ProductType();
                product.ProductType.ID = product.ProductTypeID;
                product.ProductType.Name = reader["product_type_name"].ToString();
                
            }
            connection.Close();
            return product;
        }

        public void Add(Product product)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreateProduct";

                cmd.Parameters.AddWithValue("@product_id", product.ID);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@image", product.Image);
                cmd.Parameters.AddWithValue("@product_type_id", product.ProductTypeID);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại! Hãy đảm bảo không trùng ID", "Lỗi", MessageBoxButtons.OK);
            }
            finally
            {
                connection.Close();
            }
        }

        public void Delete(string id)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteProduct";
                cmd.Parameters.AddWithValue("@product_id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK);
            }
            finally
            {
                connection.Close();
            }
        }
        public void Update(Product product)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateProduct";
            cmd.Parameters.AddWithValue("@product_id", product.ID);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@description", product.Description);
            if (product.Image == null)
                cmd.Parameters.AddWithValue("@image", "notfound.jpg");
            else
                cmd.Parameters.AddWithValue("@image", product.Image);
            cmd.Parameters.AddWithValue("@product_type_id", product.ProductTypeID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
