using Exercise_2;
using Microsoft.Data.SqlClient;


using (SqlConnection sqlConnection = new(Config.ConnectionString))
{
    await sqlConnection.OpenAsync();

}
