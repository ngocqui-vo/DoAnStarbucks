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
                    promotion.Name = reader["promotion_name"].ToString();
                    promotion.PromotionValue = reader["promotion_value"].ToString();
                    promotion.StartDate = DateTime.Parse(reader["start_date"].ToString());
                    promotion.EndDate = DateTime.Parse(reader["end_date"].ToString());
                    promotion.Description = reader["promotion_description"].ToString();
                    promotion.ProductTypeID = reader["product_type_id"].ToString();
                    promotion.ProductType = new ProductType();
                    promotion.ProductType.Name = reader["product_type_name"].ToString();

                    list.Add(promotion);
                }
            }
            connection.Close();
            return list;
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
                cmd.Parameters.AddWithValue("@promotion_name", promotion.Name);
                cmd.Parameters.AddWithValue("@promotion_value", promotion.PromotionValue);
                cmd.Parameters.AddWithValue("@start_date", promotion.StartDate.ToShortDateString());
                cmd.Parameters.AddWithValue("@end_date", promotion.EndDate.ToShortDateString());
                cmd.Parameters.AddWithValue("@promotion_description", promotion.Description);
                cmd.Parameters.AddWithValue("@product_type_id", promotion.ProductTypeID);          

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
            cmd.Parameters.AddWithValue("@promotion_name", promotion.Name);
            cmd.Parameters.AddWithValue("@promotion_value", promotion.PromotionValue);
            cmd.Parameters.AddWithValue("@start_date", promotion.StartDate.ToShortDateString());
            cmd.Parameters.AddWithValue("@end_date", promotion.EndDate.ToShortDateString());
            cmd.Parameters.AddWithValue("@promotion_description", promotion.Description);
            cmd.Parameters.AddWithValue("@product_type_id", promotion.ProductTypeID);
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
        
    }
}
