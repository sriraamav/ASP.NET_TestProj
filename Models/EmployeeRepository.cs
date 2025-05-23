using MySql.Data.MySqlClient;
using System.Data;

namespace WebApplication1.Models
{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        // READ all using stored procedure
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("GetAllEmployees", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"] as string ?? "",
                                Phone = reader["phone"] as string ?? "",
                                Address = reader["address"] as string ?? "",
                                Email = reader["email"] as string ?? ""
                            });
                        }
                    }
                }
            }

            return employees;
        }

        // CREATE using stored procedure
        public void AddEmployee(Employee emp)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("AddEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@emp_id", emp.Id);
                    cmd.Parameters.AddWithValue("@emp_name", emp.Name);
                    cmd.Parameters.AddWithValue("@emp_phone", emp.Phone);
                    cmd.Parameters.AddWithValue("@emp_address", emp.Address);
                    cmd.Parameters.AddWithValue("@emp_email", emp.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // READ one by ID 

        public Employee? GetEmployeeById(int id)
        {
            Employee? emp = null;

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("GetEmployeeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@emp_id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            emp = new Employee
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"] as string ?? "",
                                Phone = reader["phone"] as string ?? "",
                                Address = reader["address"] as string ?? "",
                                Email = reader["email"] as string ?? ""
                            };
                        }
                    }
                }
            }

            return emp;
        }


        // UPDATE using stored procedure
        public void EditEmployee(Employee emp)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("EditEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@emp_id", emp.Id);
                    cmd.Parameters.AddWithValue("@emp_name", emp.Name);
                    cmd.Parameters.AddWithValue("@emp_phone", emp.Phone);
                    cmd.Parameters.AddWithValue("@emp_address", emp.Address);
                    cmd.Parameters.AddWithValue("@emp_email", emp.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // DELETE using stored procedure
        public void DeleteEmployee(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DeleteEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@emp_id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
