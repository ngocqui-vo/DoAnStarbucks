using DoAnStarbucks.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnStarbucks.Repository
{
    internal class OpeningHoursRepo
    {
        SqlConnection connection = Connect.GetConnection();

        public List<OpeningHour> GetAll()
        {         
            List<OpeningHour> list = new List<OpeningHour>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllOpeningHours";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {                  
                    OpeningHour op = new OpeningHour();
                    op.ID = reader["opening_hours_id"].ToString();
                    op.OpenHours = reader["opening_hours"].ToString();
                    list.Add(op);
                }
            }
            connection.Close();
            return list;
        }
        public OpeningHour GetByID(string id)
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

            OpeningHour op = new OpeningHour();
            op.ID = reader["opening_hours_id"].ToString();
            op.OpenHours = reader["opening_hours"].ToString();
            connection.Close();
            return op;
        }
        public void Add(OpeningHour openingHours)
        {
            connection.Open();
            
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_CreateOpeningHours";

            cmd.Parameters.AddWithValue("@opening_hours_id", openingHours.ID);
            cmd.Parameters.AddWithValue("@opening_hours", openingHours.OpenHours);
            cmd.ExecuteNonQuery();
                      
            connection.Close();
        }
        public void Update(OpeningHour openingHours)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateOpeningHours";
            cmd.Parameters.AddWithValue("@opening_hours_id", openingHours.ID);
            cmd.Parameters.AddWithValue("@opening_hours", openingHours.OpenHours);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(string id)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_DeleteOpeningHours";
            cmd.Parameters.AddWithValue("@opening_hours_id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
