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
    internal class PositionRepo
    {
        SqlConnection connection = Connect.GetConnection();

        public List<Position> GetAll()
        {
            List<Position> list = new List<Position>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllPosition";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Position position = new Position();
                    position.ID = reader["position_id"].ToString();
                    position.Name = reader["name"].ToString();
                    list.Add(position);
                }
            }
            connection.Close();
            return list;
        }
        public Position GetByID(string id)
        {
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetOpeningHours";
            cmd.Parameters.AddWithValue("@opening_hours_id", id);
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                return null;

            reader.Read();

            Position position = new Position();
            position.ID = reader["opening_hours_id"].ToString();
            position.Name = reader["opening_hours"].ToString();
            connection.Close();
            return position;
        }
        public void Add(Position position)
        {
            connection.Open();

            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreatePosition";

                cmd.Parameters.AddWithValue("@position_id", position.ID);
                cmd.Parameters.AddWithValue("@name", position.Name);
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
        public void Update(Position position)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdatePosition";
            cmd.Parameters.AddWithValue("@position_id", position.ID);
            cmd.Parameters.AddWithValue("@name", position.Name);
          
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
                cmd.CommandText = "sp_DeletePosition";
                cmd.Parameters.AddWithValue("@position_id", id);
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
