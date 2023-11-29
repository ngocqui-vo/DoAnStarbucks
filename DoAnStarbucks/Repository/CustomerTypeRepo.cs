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
    internal class CustomerTypeRepo
    {
        SqlConnection connection = Connect.GetConnection();

        public List<CustomerType> GetAll()
        {
            List<CustomerType> list = new List<CustomerType>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ReadCustomerType";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CustomerType productType = new CustomerType();
                    productType.ID = reader["customer_type_id"].ToString();
                    productType.Name = reader["customer_type_name"].ToString();
                    list.Add(productType);
                }
            }
            connection.Close();
            return list;
        }
        public CustomerType GetByID(string id)
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

            CustomerType productType = new CustomerType();
            productType.ID = reader["customer_type_id"].ToString();
            productType.Name = reader["customer_type_name"].ToString();
            connection.Close();
            return productType;
        }
        public void Add(CustomerType productType)
        {
            connection.Open();

            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreateCustomerType";

                cmd.Parameters.AddWithValue("@customer_type_id", productType.ID);
                cmd.Parameters.AddWithValue("@customer_type_name", productType.Name);
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
        public void Update(CustomerType productType)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateCustomerType";
            cmd.Parameters.AddWithValue("@customer_type_id", productType.ID);
            cmd.Parameters.AddWithValue("@customer_type_name", productType.Name);

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
                cmd.CommandText = "sp_DeleteCustomerType";
                cmd.Parameters.AddWithValue("@customer_type_id", id);
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
