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
    internal class EmployeeRepo
    {
        SqlConnection connection = Connect.GetConnection();
        public List<Employee> GetAll()
        {
            var list = new List<Employee>();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllEmployee";

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var employee = new Employee();
                    employee.ID = reader["employee_id"].ToString();
                    employee.Name = reader["name"].ToString();
                    employee.Address = reader["address"].ToString();
                    employee.Phone = reader["phone"].ToString();
                    employee.Email = reader["email"].ToString();
                    employee.Salary = double.Parse(reader["salary"].ToString());

                    employee.BrandID = reader["branch_id"].ToString();
                    employee.Branch = new Branch();
                    employee.Branch.ID = employee.BrandID;
                    employee.Branch.Name = reader["branch_name"].ToString();

                    employee.PositionID = reader["position_id"].ToString();
                    employee.Position = new Position();
                    employee.Position.ID = employee.PositionID;
                    employee.Position.Name = reader["position_name"].ToString();

                    list.Add(employee);
                }
            }
            connection.Close();
            return list;
        }
        public Employee GetEmployee(string id)
        {
            Employee employee = new Employee();

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetEmployee";
            cmd.Parameters.AddWithValue("@employee_id", id);
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                
                employee.ID = reader["employee_id"].ToString();
                employee.Name = reader["name"].ToString();
                employee.Address = reader["address"].ToString();
                employee.Phone = reader["phone"].ToString();
                employee.Email = reader["email"].ToString();
                employee.Salary = double.Parse(reader["salary"].ToString());

                employee.BrandID = reader["branch_id"].ToString();
                employee.Branch = new Branch();
                employee.Branch.ID = employee.BrandID;
                employee.Branch.Name = reader["branch_name"].ToString();
                employee.Branch.Address = reader["branch_address"].ToString();

                employee.PositionID = reader["position_id"].ToString();
                employee.Position = new Position();
                employee.Position.ID = employee.PositionID;
                employee.Position.Name = reader["position_name"].ToString();
                
            }
            connection.Close();
            return employee;
        }

        public void Add(Employee employee)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreateEmployee";

                cmd.Parameters.AddWithValue("@employee_id", employee.ID);
                cmd.Parameters.AddWithValue("@name", employee.Name);
                cmd.Parameters.AddWithValue("@address", employee.Address);
                cmd.Parameters.AddWithValue("@phone", employee.Phone);
                cmd.Parameters.AddWithValue("@email", employee.Email);
                cmd.Parameters.AddWithValue("@salary", employee.Salary);
                cmd.Parameters.AddWithValue("@branch_id", employee.BrandID);
                cmd.Parameters.AddWithValue("@position_id", employee.PositionID);
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
        public void Update(Employee employee)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateEmployee";
            cmd.Parameters.AddWithValue("@employee_id", employee.ID);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@address", employee.Address);
            cmd.Parameters.AddWithValue("@phone", employee.Phone);
            cmd.Parameters.AddWithValue("@email", employee.Email);
            cmd.Parameters.AddWithValue("@salary", employee.Salary);
            cmd.Parameters.AddWithValue("@branch_id", employee.BrandID);
            cmd.Parameters.AddWithValue("@position_id", employee.PositionID);

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
                cmd.CommandText = "sp_DeleteEmployee";
                cmd.Parameters.AddWithValue("@employee_id", id);
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
