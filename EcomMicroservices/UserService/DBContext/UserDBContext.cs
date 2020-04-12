using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using UserService.Models;

namespace UserService.DBContext
{
    public class UserDBContext
    {
        public string ConnectionString { get; set; }

        public UserDBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }   

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<User> GetUsers()
        {
            List<User> list = new List<User>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from users", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            name = reader["name"].ToString(),
                            age = Convert.ToInt32(reader["age"]),
                            email = reader["email"].ToString(),
                        });
                    }
                }
            }
            return list;
        }
    }
}
