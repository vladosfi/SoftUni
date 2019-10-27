using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05.ChangeTownNamesCasing
{
    public class Startup
    {
        static void Main()
        {
            string countryName = Console.ReadLine();

            const string CONNECTION_STRING = "Server=B5400\\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                
                int townsAffectedCount = UpdateTowns(countryName, connection);

                if (townsAffectedCount > 0)
                {
                    Console.WriteLine($"{townsAffectedCount} town names were affected.");

                    List<string> townsAffected =  GetAffectedTowns(countryName, connection);

                    Console.Write("[");
                    Console.Write(string.Join(",",townsAffected));
                    Console.WriteLine("]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
        }

        private static List<string> GetAffectedTowns(string countryName, SqlConnection connection)
        {
            string affectedTownsQuery = @" SELECT t.Name 
                                           FROM Towns as t
                                           JOIN Countries AS c ON c.Id = t.CountryCode
                                          WHERE c.Name = @countryName";

            using(SqlCommand command = new SqlCommand(affectedTownsQuery, connection))
            {
                List<string> affectedTownNames = new List<string>();
                command.Parameters.AddWithValue("@countryName", countryName);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        affectedTownNames.Add((string)reader[0]);
                    }
                }

                return affectedTownNames;
            }
        }

        private static int UpdateTowns(string countryName, SqlConnection connection)
        {
            string updateQuery = @"UPDATE Towns
                                          SET Name = UPPER(Name)
                                        WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);

                return command.ExecuteNonQuery();
            }
        }
    }
}
