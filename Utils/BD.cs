using System.Data.SqlClient;
using Dapper;
using Pizzas.API.Helpers;
using Microsoft.Extensions.Configuration;
namespace Pizzas.API.Controllers
{
    public class basededatos {
        public static SqlConnection GetConnection(){
            SqlConnection db;
            string connectionString;
            connectionString = ConfigurationHelper.GetConfiguration().GetValue<string>("DatabaseSettings: ConnectionString");
            connectionString = @"Server=LAPTOP-6QJF0RRL\SQLEXPRESS; DataBase=DAI-Pizzas; Trusted_Connection=True" ;
            db= new SqlConnection(connectionString);
            return db;
        }
    }
}