using System;
using System.Data.SqlClient;

namespace _03.MinionNames
{
    public class Startup
    {
        static void Main()
        {
            int minionId = int.Parse(Console.ReadLine());

            const string CONNECTION_STRING = "Server=B5400\\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                string sqlQuery = "SELECT Name FROM Villains WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", minionId);

                    string vilainName = (string)command.ExecuteScalar();

                    if (vilainName is null)
                    {
                        Console.WriteLine($"No villain with ID {minionId} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {vilainName}");
                }


                string sqlSelect = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                using (SqlCommand command = new SqlCommand(sqlSelect, connection))
                {
                    command.Parameters.AddWithValue("@Id", minionId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long rowNum = (long)reader[0];
                            string minionName = (string)reader[1];
                            int minionAge = (int)reader[2];

                            Console.WriteLine($"{rowNum}. {minionName} {minionAge}");
                        }

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }                        
                }
            }
        }
    }
}
