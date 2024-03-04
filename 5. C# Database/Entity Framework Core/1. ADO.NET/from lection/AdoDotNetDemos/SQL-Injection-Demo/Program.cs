using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

string connectionString = "Server=PC-VAT\\SQLEXPRESS;Database=MyFirstDB;Integrated Security=true;TrustServerCertificate=True";

using (SqlConnection sqlConnection = new SqlConnection(connectionString))
{
    await sqlConnection.OpenAsync();
    string username = Console.ReadLine();
    string password = Console.ReadLine();

    //bonus hashed password - in lection is without hashing
    using (SHA256 sha256Hasher = SHA256.Create())
    {
        password = String.Concat(sha256Hasher.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(v => v.ToString("x2")));

        Console.WriteLine(password);
    }
    //end bonus

    //how to make better - hackers cant make sql injection
    string query = $"SELECT Id FROM Users " +
                   $"WHERE Username = @usernameParam " +
                   $"AND [Password] = @passwordParam";


    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
    {
        sqlCommand.Parameters.AddWithValue("@usernameParam", username);
        sqlCommand.Parameters.AddWithValue("@passwordParam", password);
        int? id = (int?)(await sqlCommand.ExecuteScalarAsync());
        if (id != null && id > 0)
        {
            Console.WriteLine($"You are user with Id: {id}");
        }
        else
        {
            Console.WriteLine($"Invalid username or password!");
        }
    }

    //problem - hackers can make sql injectin
    /*
    string query = $"SELECT Id FROM Users " + 
                   $"WHERE Username = '{username}' " + 
                   $"AND [Password] = '{password}'";
    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
    {
        int? id = (int?)(await sqlCommand.ExecuteScalarAsync());
        if(id != null && id > 0)
        {
            Console.WriteLine($"You are user with Id: {id}");
        }
        else
        {
            Console.WriteLine($"Invalid username or password!");
        }
    }*/
}
