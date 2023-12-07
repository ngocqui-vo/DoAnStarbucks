using DoAnStarbucks.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DoAnStarbucks.Repository
{
    internal class BranchRepo
    {
        SqlConnection connection = Connect.GetConnection();
        public List<Branch> GetAll()
        {
            List<Branch> list = new List<Branch>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllBranches";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Branch branch = new Branch();
                    branch.ID = reader["branch_id"].ToString();
                    branch.Name = reader["name"].ToString();
                    branch.Address = reader["address"].ToString();
                    branch.Phone = reader["phone"].ToString();
                    branch.Email = reader["email"].ToString();
                    branch.OpeningHourID = reader["opening_hours_id"].ToString();

                    branch.OpeningHour = new OpeningHour();
                    branch.OpeningHour.ID = branch.OpeningHourID;

                    branch.OpeningHour.OpenHours = reader["opening_hours"].ToString();
                    branch.ManagerID = reader["manager_id"].ToString();

                    list.Add(branch);
                }
            }
            connection.Close();
            return list;
        }

        public void Add(Branch branch)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreateBranch";

                cmd.Parameters.AddWithValue("branch_id", branch.ID);
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
                cmd.CommandText = "sp_DeleteBranch";
                cmd.Parameters.AddWithValue("@branch_id", id);
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
