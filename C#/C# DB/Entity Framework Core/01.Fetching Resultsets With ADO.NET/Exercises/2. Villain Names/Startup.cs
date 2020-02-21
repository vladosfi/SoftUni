using System;
using System.Data.SqlClient;

namespace Villain_Names
{
    public class Startup
    {
        static void Main()
        {
            const string CONNECTION_STRING = "Server=B5400\\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string sqlQuery = @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                        FROM Villains AS v 
                                        JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                    GROUP BY v.Id, v.Name 
                                      HAVING COUNT(mv.VillainId) > 3 
                                    ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string minionName = (string)reader[0];
                        int minionsCount = (int)reader[1];

                        Console.WriteLine($"{minionName} - {minionsCount}");
                    }
                }
            }

        }
    }
}
