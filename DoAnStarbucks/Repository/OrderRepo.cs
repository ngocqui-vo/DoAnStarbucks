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
    internal class OrderRepo
    {
        SqlConnection connection = Connect.GetConnection();
        public List<Order> GetAll()
        {
            List<Order> list = new List<Order>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllBranches";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Order order = new Order();
                    order.ID = reader["order_id"].ToString();
                    order.OrderDateTime = DateTime.Parse(reader["order_date_time"].ToString());
                    order.TotalValue = decimal.Parse(reader["total_value"].ToString());
                    order.CustomerID = reader["customer_id"].ToString();
                    order.EmployeeID = reader["employee_id"].ToString();
                    order.PaymentMethodID = reader["payment_method_id"].ToString();

                    order.Customer = new Customer();
                    order.Customer.ID = order.CustomerID;

                    order.PaymentMethod = new PaymentMethod();
                    order.PaymentMethod.ID = order.PaymentMethodID;

                    order.Employee = new Employee();
                    order.Employee.ID = order.EmployeeID;

                    list.Add(order);
                }
            }
            connection.Close();
            return list;
        }
        public Order GetOrderDetail(Order order)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select od.*, p.name as 'product_name', p.price as 'product_price' from OrderDetails od " +
                "join Products p on od.product_id = p.product_id " +
                "where order_id = @order_id";
            cmd.Parameters.AddWithValue("@order_id", order.ID);
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.OrderID = reader["order_id"].ToString();
                    orderDetails.ProductID = reader["product_id"].ToString();
                    orderDetails.Product = new Product();
                    orderDetails.Product.Name = reader["product_name"].ToString();
                    orderDetails.Product.Price = decimal.Parse(reader["product_price"].ToString());
                    orderDetailsList.Add(orderDetails);
                }
            }
            order.OrderDetails = orderDetailsList;
            return order;
        }
        public void AddOrderDetails(OrderDetails orderDetails)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into OrderDetails " +
                "values (@order_id,@product_id,@quantity,@total_value)";
            cmd.Parameters.AddWithValue("@order_id", orderDetails.OrderID);
            cmd.Parameters.AddWithValue("@product_id", orderDetails.ProductID);
            cmd.Parameters.AddWithValue("@quantity", orderDetails.Quantity);
            cmd.Parameters.AddWithValue("@total_value", orderDetails.TotalValue);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public Order Add(Order order)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreateOrders";

                cmd.Parameters.AddWithValue("@order_date_time", order.OrderDateTime);
                cmd.Parameters.AddWithValue("@total_value", order.TotalValue);
                cmd.Parameters.AddWithValue("@status", order.Status);
                
                cmd.Parameters.AddWithValue("@employee_id", order.EmployeeID);
                cmd.Parameters.AddWithValue("@payment_method_id", order.PaymentMethodID);

                if (string.IsNullOrEmpty(order.CustomerID) || order.CustomerID == "Không")
                    cmd.Parameters.AddWithValue("@customer_id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@customer_id", order.CustomerID);


                var reader = cmd.ExecuteReader();
                Order orderInserted = new Order();
                reader.Read();
                orderInserted.ID = reader["order_id"].ToString();
                orderInserted.OrderDateTime = DateTime.Parse(reader["order_date_time"].ToString());
                orderInserted.Status = reader["status"].ToString();
                orderInserted.TotalValue = decimal.Parse(reader["total_value"].ToString());
                
                orderInserted.CustomerID = reader["customer_id"].ToString();
                orderInserted.EmployeeID = reader["employee_id"].ToString();
                orderInserted.PaymentMethodID = reader["payment_method_id"].ToString();
                connection.Close();
                return orderInserted;
            }
            catch (Exception)
            {
                connection.Close();
                MessageBox.Show("Thêm thất bại! Hãy đảm bảo không trùng ID", "Lỗi", MessageBoxButtons.OK);
                return null;
            }
           
        }

        public void Delete(string id)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteOrders";
                cmd.Parameters.AddWithValue("@order_id", id);
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
        public void Update(Branch branch)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateBranch";
            cmd.Parameters.AddWithValue("@branch_id", branch.ID);
            cmd.Parameters.AddWithValue("@name", branch.Name);
            cmd.Parameters.AddWithValue("@address", branch.Address);
            cmd.Parameters.AddWithValue("@phone", branch.Phone);
            cmd.Parameters.AddWithValue("@email", branch.Email);
            cmd.Parameters.AddWithValue("@opening_hours_id", branch.OpeningHourID);
            if (string.IsNullOrEmpty(branch.ManagerID) || branch.ManagerID == "Không")
                cmd.Parameters.AddWithValue("@manager_id", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@manager_id", branch.ManagerID);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
