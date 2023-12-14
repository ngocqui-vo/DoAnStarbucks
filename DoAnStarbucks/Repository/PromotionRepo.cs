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
    internal class PromotionRepo
    {
        SqlConnection connection = Connect.GetConnection();
        public List<Promotion> GetAll()
        {
            List<Promotion> list = new List<Promotion>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ReadPromotion";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Promotion promotion = new Promotion();
                    promotion.ID = reader["promotion_id"].ToString();
                    promotion.Code = reader["promotion_code"].ToString();
                    promotion.PromotionValue = float.Parse(reader["promotion_value"].ToString());
                    promotion.UseNumber = int.Parse(reader["use_number"].ToString());
                    promotion.StartDate = DateTime.Parse(reader["start_date"].ToString());
                    promotion.EndDate = DateTime.Parse(reader["end_date"].ToString());
                    promotion.Description = reader["promotion_description"].ToString();
                    promotion.ProductID = reader["product_id"].ToString();
                    promotion.Product = new Product();
                    promotion.Product.Name = reader["product_name"].ToString();

                    list.Add(promotion);
                }
            }
            connection.Close();
            return list;
        }
        public Promotion Get(string code)
        {
            Promotion promotion = new Promotion();
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select pm.*, p.name as 'product_name' from Promotion pm " +
                "join Products p on p.product_id = pm.product_id where promotion_code = @promotion_code";
            cmd.Parameters.AddWithValue("@promotion_code", code);

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                    
                promotion.ID = reader["promotion_id"].ToString();
                promotion.Code = reader["promotion_code"].ToString();
                promotion.PromotionValue = float.Parse(reader["promotion_value"].ToString());
                promotion.UseNumber = int.Parse(reader["use_number"].ToString());
                promotion.StartDate = DateTime.Parse(reader["start_date"].ToString());
                promotion.EndDate = DateTime.Parse(reader["end_date"].ToString());
                promotion.Description = reader["promotion_description"].ToString();
                promotion.ProductID = reader["product_id"].ToString();
                promotion.Product = new Product();
                promotion.Product.Name = reader["product_name"].ToString();               
            }
            connection.Close();
            return promotion;
        }

        public void Add(Promotion promotion)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreatePromotion";

                cmd.Parameters.AddWithValue("@promotion_id", promotion.ID);
                cmd.Parameters.AddWithValue("@promotion_code", promotion.Code);
                cmd.Parameters.AddWithValue("@use_number", promotion.UseNumber);
                cmd.Parameters.AddWithValue("@promotion_value", promotion.PromotionValue);
                cmd.Parameters.AddWithValue("@start_date", promotion.StartDate.ToShortDateString());
                cmd.Parameters.AddWithValue("@end_date", promotion.EndDate.ToShortDateString());
                cmd.Parameters.AddWithValue("@promotion_description", promotion.Description);
                cmd.Parameters.AddWithValue("@product_id", promotion.ProductID);          

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
        public void Update(Promotion promotion)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdatePromotion";
            cmd.Parameters.AddWithValue("@promotion_id", promotion.ID);
            cmd.Parameters.AddWithValue("@promotion_code", promotion.Code);
            cmd.Parameters.AddWithValue("@use_number", promotion.UseNumber);
            cmd.Parameters.AddWithValue("@promotion_value", promotion.PromotionValue);
            cmd.Parameters.AddWithValue("@start_date", promotion.StartDate.ToShortDateString());
            cmd.Parameters.AddWithValue("@end_date", promotion.EndDate.ToShortDateString());
            cmd.Parameters.AddWithValue("@promotion_description", promotion.Description);
            cmd.Parameters.AddWithValue("@product_id", promotion.ProductID);
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
                cmd.CommandText = "sp_DeletePromotion";
                cmd.Parameters.AddWithValue("@promotion_id", id);
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
        public void DecreseUseNumber(string code)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Promotion " +
                    "set use_number = use_number - 1 " +
                    "where promotion_code = @promotion_code";
                cmd.Parameters.AddWithValue("@promotion_code", code);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Cập nhật thất bại!\n" + e, "Lỗi", MessageBoxButtons.OK);
            }
            finally
            {
                connection.Close();
            }
        }
        
    }
}