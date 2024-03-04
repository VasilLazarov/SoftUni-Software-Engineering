using Microsoft.Data.SqlClient;
using System.Text;

namespace Exercise_1
{
    public class Program
    {
        static async Task Main()
        {
            await using (SqlConnection sqlConnection = new(Config.ConnectionString))
            {
                await sqlConnection.OpenAsync();
                //Console.WriteLine("Connected to DB successfully");

                //Exercise 2
                //string result = await GetAllVillainsWithMoreThan3MinionsAsync(sqlConnection);

                //Exercise 3
                //string result = await GetVillianNameAndHisMinionsAsync(sqlConnection);

                //Exercise 4
                string result = await AddMinionToDatabaseAsync(sqlConnection);







                Console.WriteLine(result);
            }
        }

        //Exercise 2 function
        static async Task<string> GetAllVillainsWithMoreThan3MinionsAsync(SqlConnection sqlConnection)
        {
            StringBuilder result = new();
            await using (SqlCommand sqlCommand = new(SqlQueries.GetAllVillainsWithMoreThan3Minions, sqlConnection))
            {
                await using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                {
                    while (await sqlDataReader.ReadAsync())
                    {
                        string name = sqlDataReader[0].ToString();
                        int count = int.Parse(sqlDataReader[1].ToString());
                        result.AppendLine($"{name} - {count}");
                    }
                }
            }
            return result.ToString().Trim();
        }

        //Exercise 3 function
        static async Task<string> GetVillianNameAndHisMinionsAsync(SqlConnection sqlConnection)
        {
            StringBuilder result = new();

            int id = int.Parse(Console.ReadLine());

            await using (SqlCommand sqlCommand = new(SqlQueries.GetVillainNameById, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);
                try
                {
                    string villianName = sqlCommand.ExecuteScalar().ToString();
                    result.AppendLine($"Villian: {villianName}");
                }
                catch
                {
                    result.AppendLine($"No villain with ID {id} exists in the database.");
                    return result.ToString().Trim();
                }
            }
            await using (SqlCommand sqlCommand = new(SqlQueries.GetVillainMinions, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);

                await using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                {
                    //bool dontHaveMinions = true;
                    if (!sqlDataReader.HasRows)
                    {
                        result.AppendLine("(no minions)");
                        return result.ToString().Trim();
                    }
                    while(await sqlDataReader.ReadAsync())
                    {
                        //dontHaveMinions = false;
                        long number = (long)sqlDataReader[0];
                        string minionName = sqlDataReader[1].ToString();
                        int minionAge = (int)sqlDataReader[2];
                        result.AppendLine($"{number}. {minionName} {minionAge}");
                    }
                    /*
                    if (dontHaveMinions)
                    {
                        result.AppendLine("(no minions)");
                        return result.ToString().Trim();
                    }
                    */
                }
            }
            return result.ToString().Trim();
        }

        //Exercise 4 function
        static async Task<string> AddMinionToDatabaseAsync(SqlConnection sqlConnection)
        {
            StringBuilder result = new();
            string[] minionInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] villainInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];
            string villainName = villainInfo[1];

            //check town - exist or need to add
            using (SqlTransaction transaction = (SqlTransaction)await sqlConnection.BeginTransactionAsync())
            {
                try
                {
                    int townId = await GetTownId(sqlConnection, result, minionTown, transaction);
                    int villainId = await GetVillainId(sqlConnection, result, villainName, transaction);
                    int minionId = await CreateMinionAndGetHisId(sqlConnection, minionName, minionAge, townId, transaction);

                    //Console.WriteLine($"TownId: {townId}, VillainId: {villainId}, MinionId: {minionId}");

                    await SetVillainForNewMinionInMappingTable(sqlConnection, minionId, villainId, transaction);
                    result.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                    //await transaction.CommitAsync();
                    await transaction.RollbackAsync();
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(e);
                }
            }

            return result.ToString().Trim();
        }
        private static async Task<int> GetTownId(SqlConnection sqlConnection, StringBuilder result, string minionTown, SqlTransaction transaction)
        {
            using (SqlCommand getTownIdCmd = new(SqlQueries.GetTownIdByName, sqlConnection))
            {
                getTownIdCmd.Transaction = transaction;
                getTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

                int? townId = (int?)await getTownIdCmd.ExecuteScalarAsync();
                if (!townId.HasValue)
                {
                    using (SqlCommand addNewTownCmd = new(SqlQueries.AddNewTown, sqlConnection))
                    {
                        addNewTownCmd.Transaction = transaction;
                        addNewTownCmd.Parameters.AddWithValue("@townName", minionTown);
                        await addNewTownCmd.ExecuteNonQueryAsync();
                        //await transaction.CommitAsync();
                    }
                    townId = (int?)await getTownIdCmd.ExecuteScalarAsync();
                    result.AppendLine($"Town {minionTown} was added to the database.");
                }
                return townId.Value;
            }
        }
        private static async Task<int> GetVillainId(SqlConnection sqlConnection, StringBuilder result, string villainName, SqlTransaction transaction)
        {
            using (SqlCommand getVillainIdCmd = new(SqlQueries.GetVillainIdByName, sqlConnection))
            {
                getVillainIdCmd.Transaction = transaction;
                getVillainIdCmd.Parameters.AddWithValue("@villainName", villainName);

                int? villainId = (int?)await getVillainIdCmd.ExecuteScalarAsync();
                if (!villainId.HasValue)
                {
                    using (SqlCommand addNewVillainCmd = new(SqlQueries.AddNewVillain, sqlConnection))
                    {
                        addNewVillainCmd.Transaction = transaction;
                        addNewVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                        await addNewVillainCmd.ExecuteNonQueryAsync();
                        //await transaction.CommitAsync();
                    }
                    villainId = (int?)await getVillainIdCmd.ExecuteScalarAsync();
                    result.AppendLine($"Villain {villainName} was added to the database.");
                }
                return villainId.Value;
            }
        }
        private static async Task<int> CreateMinionAndGetHisId(SqlConnection sqlConnection, string minionName, int minionAge, int townId, SqlTransaction transaction)
        {
            using (SqlCommand addNewMinionCmd = new(SqlQueries.AddNewMinion, sqlConnection))
            {
                addNewMinionCmd.Transaction = transaction;
                addNewMinionCmd.Parameters.AddWithValue("@name", minionName);
                addNewMinionCmd.Parameters.AddWithValue("@age", minionAge);
                addNewMinionCmd.Parameters.AddWithValue("@townId", townId);
                await addNewMinionCmd.ExecuteNonQueryAsync();
                //await transaction.CommitAsync();
            }
            using (SqlCommand getMinionIdCmd = new(SqlQueries.GetMinionIdByNameAgeAndTownId, sqlConnection))
            {
                getMinionIdCmd.Transaction = transaction;
                //getMinionIdCmd.Parameters.AddWithValue("@name", minionName);
                //getMinionIdCmd.Parameters.AddWithValue("@age", minionAge);
                //getMinionIdCmd.Parameters.AddWithValue("@townId", townId);
                AddParametersToSqlCommand(getMinionIdCmd, "@name", minionName);
                AddParametersToSqlCommand(getMinionIdCmd, "@age", minionAge);
                AddParametersToSqlCommand(getMinionIdCmd, "@townId", townId);

                int minionId = (int)await getMinionIdCmd.ExecuteScalarAsync();
                
                return minionId;
            }
        }
        private static async Task SetVillainForNewMinionInMappingTable(SqlConnection sqlConnection, int minionId, int villainId, SqlTransaction transaction)
        {
            using (SqlCommand setVillainForNewMinion = new(SqlQueries.SetVillainForNewMinionInMappingTable, sqlConnection))
            {
                setVillainForNewMinion.Transaction = transaction;
                setVillainForNewMinion.Parameters.AddWithValue("@minionId", minionId);
                setVillainForNewMinion.Parameters.AddWithValue("@villainId", villainId);

                await setVillainForNewMinion.ExecuteNonQueryAsync();
            }
        }

        private static void AddParametersToSqlCommand(SqlCommand command, string paramName, int value)
        {
            command.Parameters.AddWithValue(paramName, value);
        }
        private static void AddParametersToSqlCommand(SqlCommand command, string paramName, string value)
        {
            command.Parameters.AddWithValue(paramName, value);
        }

        //Exercise 5



    }
}