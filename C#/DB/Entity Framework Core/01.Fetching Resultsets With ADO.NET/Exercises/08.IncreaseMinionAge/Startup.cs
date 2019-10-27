using System;
using System.Data.SqlClient;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    public class Startup
    {
        static void Main()
        {
            int[] minionIds = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            const string CONNECTION_STRING = "Server=B5400\\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";


            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                for (int i = 0; i < minionIds.Length; i++)
                {
                    UpdateMinionsById(minionIds[i], connection);
                }

                SelectMinions(connection);
            }
        }

        private static void SelectMinions(SqlConnection connection)
        {
            string sqlQuery = @"SELECT Name, Age FROM Minions";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string minionName = (string)reader[0];
                        int minionAge = (int)reader[1];

                        Console.WriteLine($"{minionName} {minionAge}");
                    }
                }
            }
        }

        private static void UpdateMinionsById(int id, SqlConnection connection)
        {
            string sqlQuery = @"UPDATE Minions
                                       SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                     WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
