using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
namespace Pizzas.API.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=A-LUM-13; DataBase=DAI-Pizzas; Trusted_Connection=True;";

        public static Pizza GetById(int Id){
            Pizza MiId=null;
            string sql="SELECT * FROM Pizzas WHERE Id=@pId";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                MiId=BD.QueryFirstOrDefault<Pizza>(sql,new{pId=Id});
            }
            return MiId;
        }
        
        public static Pizza Create(int Id){
            Pizza MiId=null;
            string sql="SELECT * FROM Pizzas WHERE Id=@pId";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                MiId=BD.QueryFirstOrDefault<Pizza>(sql,new{pId=Id});
            }
            return MiId;
        }

    }
}