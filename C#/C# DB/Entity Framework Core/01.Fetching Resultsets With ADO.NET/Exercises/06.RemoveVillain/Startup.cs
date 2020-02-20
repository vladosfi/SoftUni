using System;
using System.Data.SqlClient;

namespace _06.RemoveVillain
{
    public class Startup
    {
        static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());

            const string CONNECTION_STRING = "Server=B5400\\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                
                string villainName = GetVillainName(villainId, connection);

                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                DeleteMinionsVillainsById(villainId, connection);
                Console.WriteLine($"{villainName} was deleted.");

                int? releasedMinionsCount = DeleteVillainById(villainId, connection);

                Console.WriteLine($"{releasedMinionsCount} minions were released.");
            }
        }

        private static int? DeleteVillainById(int villainId, SqlConnection connection)
        {
            string villainNameQuery = @"DELETE FROM Villains
                                               WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(villainNameQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                return (int?)command.ExecuteNonQuery();
            }
        }

        private static void DeleteMinionsVillainsById(int villainId, SqlConnection connection)
        {
            string villainNameQuery = @"DELETE FROM MinionsVillains 
                                              WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(villainNameQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                command.ExecuteNonQuery();
            }
        }

        private static string GetVillainName(int villainId, SqlConnection connection)
        {
            string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(villainNameQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                return (string)command.ExecuteScalar();
            }
        }
    }
}
