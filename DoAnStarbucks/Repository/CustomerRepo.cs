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
    internal class CustomerRepo
    {
        SqlConnection connection = Connect.GetConnection();
        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ReadCustomer";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.ID = reader["customer_id"].ToString();
                    customer.Name = reader["name"].ToString();
                    customer.Address = reader["address"].ToString();
                    customer.Phone = reader["phone"].ToString();
                    customer.Email = reader["email"].ToString();
                    customer.CustomerTypeID = reader["customer_type_id"].ToString();
                    customer.CustomerType = new CustomerType();
                    customer.CustomerType.Name = reader["customer_type_name"].ToString();

                    list.Add(customer);
                }
            }
            connection.Close();
            return list;
        }

        public void Add(Customer customer)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreateCustomer";

                cmd.Parameters.AddWithValue("@customer_id", customer.ID);
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@address", customer.Address);
                cmd.Parameters.AddWithValue("@phone", customer.Phone);
                cmd.Parameters.AddWithValue("@email", customer.Email);
                cmd.Parameters.AddWithValue("@customer_type_id", customer.CustomerTypeID);

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
                cmd.CommandText = "sp_DeleteCustomer";
                cmd.Parameters.AddWithValue("@customer_id", id);
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
        public void Update(Customer customer)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateCustomer";
            cmd.Parameters.AddWithValue("@customer_id", customer.ID);
            cmd.Parameters.AddWithValue("@name", customer.Name);
            cmd.Parameters.AddWithValue("@address", customer.Address);
            cmd.Parameters.AddWithValue("@phone", customer.Phone);
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@customer_type_id", customer.CustomerTypeID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
