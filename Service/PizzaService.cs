using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using System.Data.SqlClient;
using Dapper;
using Pizzas.API.Controllers;
using Pizzas.API.Helpers;


namespace Pizzas.API.Services
{
    public class BD{

        public static List<Pizza> GetAll(){
            List<Pizza> ListaPizzas;
            string sp="sp_GetAll";
            using(SqlConnection BD=BD.GetConnection()){
                BD.Execute(sp,commandType:commandType.StoredProcedure);
            }
            return ListaPizzas;
        }    

        public static Pizza GetById(int Id){
            Pizza MiId=null;
            string sp="sp_GetById";
            using(SqlConnection BD=BD.GetConnection()){
                BD.Execute(sp,new{Id=Id},commandType:commandType.StoredProcedure);
            }
            return MiId;
        }
        
        public static Pizza Create(Pizza Pizza){
            string sp="sp_Create";
            using(SqlConnection BD=BD.GetConnection()){
                BD.Execute(sp,new{Nombre=Pizza.Nombre, LibreGluten=Pizza.LibreGluten, Importe=Pizza.Importe,Descripcion=Pizza.Descripcion},commandType:commandType.StoredProcedure);
            }
            return new Pizza();
        }
        public static Pizza Update(int Id, Pizza Pizza){
            string sp="sp_Update";
            using(SqlConnection BD=BD.GetConnection()){
                BD.Execute(sp,new{Nombre=Pizza.Nombre, LibreGluten=Pizza.LibreGluten, Importe=Pizza.Importe,Descripcion=Pizza.Descripcion,IdPizza=Id},commandType:commandType.StoredProcedure);
            }
            return new Pizza(); 
        }
        public static Pizza DeleteById(int Id){
            string sp="sp_Delete";
            using(SqlConnection BD=BD.GetConnection()){
                BD.Execute(sp,new{Id=Id},commandType:commandType.StoredProcedure);
            }
            return new Pizza(); 
        }
    }
}