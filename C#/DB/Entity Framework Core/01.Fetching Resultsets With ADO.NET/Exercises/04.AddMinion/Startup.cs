using System;
using System.Data.SqlClient;

namespace _04.AddMinion
{
    public class Startup
    {
        static void Main()
        {
            //1. Read info
            string[] minionInfo = Console.ReadLine().Split();
            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];

            string[] villainInfo = Console.ReadLine().Split();
            string villainName = villainInfo[1];

            const string CONNECTION_STRING = "Server=B5400\\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";

            
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                //2. Check town
                string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";
                string paramName = "townName";

                int? townId = GetByName(townName, townIdQuery, paramName, connection);

                if (townId is null)
                {
                    AddTown(connection, townName);
                    Console.WriteLine($"Town {townName} was added to the database.");
                }

                townId = GetByName(townName, townIdQuery, paramName, connection);

                //3. Add minion
                AddMinion(connection, minionName, minionAge, townId);

                //4. Check villain 
                string villainIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";
                paramName = "Name";

                int? villainId = GetByName(villainName, villainIdQuery, paramName, connection);

                if (villainId is null)
                {
                    AddVillain(connection, villainName);
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                villainId = GetByName(villainName, villainIdQuery, paramName, connection);

                string minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";
                paramName = "Name";

                int? minionId = GetByName(minionName, minionIdQuery,paramName , connection);


                //5. Add record in mapping table
                AddMinionVillain(villainId, minionId, connection);
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static void AddMinionVillain(int? villainId, int? minionId, SqlConnection connection)
        {
            string insertMinionVillainQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using (SqlCommand command = new SqlCommand(insertMinionVillainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", minionId);

                command.ExecuteNonQuery();
            }
        }

        private static void AddVillain(SqlConnection connection, string villainName)
        {
            string insertVillainSql = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

            using (SqlCommand command = new SqlCommand(insertVillainSql, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);
                
                command.ExecuteNonQuery();
            }
        }

        private static void AddMinion(SqlConnection connection, string minionName, int minionAge, int? townId)
        {
            string insertMinionSql = "INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";
            
            using(SqlCommand command = new SqlCommand(insertMinionSql, connection))
            {
                command.Parameters.AddWithValue("@nam", minionName);
                command.Parameters.AddWithValue("@age", minionAge);
                command.Parameters.AddWithValue("@townId", townId);

                command.ExecuteNonQuery();
            }
        }

        private static int? GetByName(string name, string query, string paramName, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue($"@{paramName}", name);

                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddTown(SqlConnection connection, string townName)
        {
            string insertTown = "INSERT INTO Towns (Name) VALUES (@townName)";

            using(SqlCommand command = new SqlCommand(insertTown, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                command.ExecuteNonQuery();
            }
        }
    }
}
