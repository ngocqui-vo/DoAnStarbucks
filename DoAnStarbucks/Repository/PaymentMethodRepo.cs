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
    internal class PaymentMethodRepo
    {
        SqlConnection connection = Connect.GetConnection();

        public List<PaymentMethod> GetAll()
        {
            List<PaymentMethod> list = new List<PaymentMethod>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ReadPaymentMethod";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    PaymentMethod position = new PaymentMethod();
                    position.ID = reader["payment_method_id"].ToString();
                    position.Name = reader["payment_method_name"].ToString();
                    list.Add(position);
                }
            }
            connection.Close();
            return list;
        }
        public PaymentMethod GetByID(string id)
        {
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetOpeningHours";
            cmd.Parameters.AddWithValue("@payment_method_id", id);
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                return null;

            reader.Read();

            PaymentMethod paymentMethod = new PaymentMethod();
            paymentMethod.ID = reader["payment_method_id"].ToString();
            paymentMethod.Name = reader["payment_method_name"].ToString();
            connection.Close();
            return paymentMethod;
        }
        public void Add(PaymentMethod paymentMethod)
        {
            connection.Open();

            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreatePaymentMethod";

                cmd.Parameters.AddWithValue("@payment_method_id", paymentMethod.ID);
                cmd.Parameters.AddWithValue("@payment_method_name", paymentMethod.Name);
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
        public void Update(PaymentMethod paymentMethod)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdatePaymentMethod";
            cmd.Parameters.AddWithValue("@payment_method_id", paymentMethod.ID);
            cmd.Parameters.AddWithValue("@payment_method_name", paymentMethod.Name);

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
                cmd.CommandText = "sp_DeletePaymentMethod";
                cmd.Parameters.AddWithValue("@payment_method_id", id);
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
