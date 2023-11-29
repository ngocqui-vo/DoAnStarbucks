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
    internal class ProductTypeRepo
    {
        SqlConnection connection = Connect.GetConnection();

        public List<ProductType> GetAll()
        {
            List<ProductType> list = new List<ProductType>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ReadProductType";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ProductType productType = new ProductType();
                    productType.ID = reader["product_type_id"].ToString();
                    productType.Name = reader["name"].ToString();
                    list.Add(productType);
                }
            }
            connection.Close();
            return list;
        }
        public ProductType GetByID(string id)
        {
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetOpeningHours";
            cmd.Parameters.AddWithValue("@product_type_id", id);
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                return null;

            reader.Read();

            ProductType productType = new ProductType();
            productType.ID = reader["product_type_id"].ToString();
            productType.Name = reader["name"].ToString();
            connection.Close();
            return productType;
        }
        public void Add(ProductType productType)
        {
            connection.Open();

            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreateProductType";

                cmd.Parameters.AddWithValue("@product_type_id", productType.ID);
                cmd.Parameters.AddWithValue("@name", productType.Name);
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
        public void Update(ProductType productType)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateProductType";
            cmd.Parameters.AddWithValue("@product_type_id", productType.ID);
            cmd.Parameters.AddWithValue("@name", productType.Name);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(string id)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteProductType";
                cmd.Parameters.AddWithValue("@product_type_id", id);
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
    }
}
