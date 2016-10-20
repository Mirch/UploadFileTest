using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Core;

namespace DataAccessLayer
{

    public class UserDB
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public void Add(string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "INSERT INTO Users (Name) VALUES (@name)";
                    command.Parameters.AddWithValue("name", name);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public User Get(int id)
        {
            User result = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SELECT * FROM Users WHERE id = @id";
                    command.Parameters.AddWithValue("id", id);
                    var reader = command.ExecuteReader();

                    reader.Read();
                    string name = reader.GetString(reader.GetOrdinal("name"));
                    result = new User(name);
                }

            }
            return result;
        }


    }
}
