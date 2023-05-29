using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

public class DapperContext
{
    string connectionString = "Server=Localhost; port= 5432; database=Quotes; User Id= postgres; password= 23022002";
    public DapperContext()
    {

    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
}