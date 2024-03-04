using Microsoft.Data.SqlClient;
//this works corectly
//string connectionString = "Server=PC-VAT\\SQLEXPRESS;Database=SoftUni;Trusted_Connection=True;TrustServerCertificate=True";


//try other
string connectionString = "Server=PC-VAT\\SQLEXPRESS;Database=SoftUni;Integrated Security=true;TrustServerCertificate=True";

//Demo 1
/*using (SqlConnection sqlConnection = new SqlConnection(connectionString))
{
    sqlConnection.Open();
    string query = "SELECT COUNT(*) FROM Employees";

    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
    {
        int count = (int)sqlCommand.ExecuteScalar();

        Console.WriteLine($"Employees count: {count}");
    }
}*/

//Demo 2
/*using (SqlConnection sqlConnection = new SqlConnection(connectionString))
{
    sqlConnection.Open();
    string query = "SELECT FirstName, LastName, Salary FROM Employees WHERE Salary > @salaryParam";

    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
    {
        sqlCommand.Parameters.AddWithValue("@salaryParam", 70000);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        while(sqlDataReader.Read())
        {
            string firstName = sqlDataReader[0].ToString();
            string lastName = sqlDataReader[1].ToString();
            /* - can find columns by name or number from query position
            string firstName = sqlDataReader["FirstName"].ToString();
            string lastName = sqlDataReader["LastName"].ToString();
            *-/
            //string salarytest = sqlDataReader["Salary"].ToString();
            decimal salary = decimal.Parse(sqlDataReader[2].ToString());

            Console.WriteLine($"{firstName} {lastName} - {salary:f2}");
        }
    }
}*/

//Demo 3 - same as Demo 2 but with new simple sintaxis(but not better for me, other is easy for read and understand and is more readable), and get * with query and find columns by names
/*using SqlConnection sqlConnection = new SqlConnection(connectionString);
    sqlConnection.Open();
    string query = "SELECT * FROM Employees WHERE Salary > @salaryParam";

using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@salaryParam", 70000);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        while (sqlDataReader.Read())
        {
            string firstName = sqlDataReader["FirstName"].ToString();
            string lastName = sqlDataReader["LastName"].ToString();
            
            string salary = sqlDataReader["Salary"].ToString();

            Console.WriteLine($"{firstName} {lastName} - {salary:f2}");
        }
*/
//Demo 4 - same as Demo 2 but we can use async methods - this is better
using (SqlConnection sqlConnection = new SqlConnection(connectionString))
{
    await sqlConnection.OpenAsync();
    string query = "SELECT FirstName, LastName, Salary FROM Employees WHERE Salary > @salaryParam";

    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
    {
        sqlCommand.Parameters.AddWithValue("@salaryParam", 70000);
        using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
        {
            while (await sqlDataReader.ReadAsync())
            {
                string firstName = sqlDataReader[0].ToString();
                string lastName = sqlDataReader[1].ToString();
                decimal salary = decimal.Parse(sqlDataReader[2].ToString());

                Console.WriteLine($"{firstName} {lastName} - {salary:f2}");
            }
        }
    }
}