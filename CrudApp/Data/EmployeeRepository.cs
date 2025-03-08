using CrudApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace CrudApp.Data
{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Mendapatkan semua karyawan
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Employees";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Department = reader["Department"].ToString(),
                        Salary = Convert.ToDecimal(reader["Salary"]),
                        HireDate = Convert.ToDateTime(reader["HireDate"])
                    };

                    employees.Add(employee);
                }

                reader.Close();
            }

            return employees;
        }

        // Mendapatkan karyawan berdasarkan ID
        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Employees WHERE EmployeeId = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    employee = new Employee
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Department = reader["Department"].ToString(),
                        Salary = Convert.ToDecimal(reader["Salary"]),
                        HireDate = Convert.ToDateTime(reader["HireDate"])
                    };
                }

                reader.Close();
            }

            return employee;
        }

        // Menambahkan karyawan baru
        public int CreateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Employees (Name, Email, Department, Salary, HireDate) 
                                VALUES (@Name, @Email, @Department, @Salary, @HireDate);
                                SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@HireDate", employee.HireDate);

                connection.Open();
                int newId = Convert.ToInt32(command.ExecuteScalar());

                return newId;
            }
        }

        // Mengupdate data karyawan
        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Employees SET 
                                Name = @Name, 
                                Email = @Email, 
                                Department = @Department, 
                                Salary = @Salary, 
                                HireDate = @HireDate 
                                WHERE EmployeeId = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", employee.EmployeeId);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@HireDate", employee.HireDate);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        // Menghapus karyawan
        public bool DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Employees WHERE EmployeeId = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
    }
}