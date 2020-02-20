using System;
using System.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    public class Startup
    {
        static void Main()
        {
            int id = int.Parse(Console.ReadLine());

            const string CONNECTION_STRING = "Server=B5400\\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";
            
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string uspGetOlder = "EXEC usp_GetOlder @id";

                using(SqlCommand command = new SqlCommand(uspGetOlder, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];

                            Console.WriteLine($"{name} - {age} years old");
                        }
                    }
                }

            }
        }
    }
}
