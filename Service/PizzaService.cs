using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

using Pizzas.API.Models;
using Pizzas.API.Utils;
using Pizzas.API.Helpers;

namespace Pizzas.API.Services{
    public class PizzasServices{
            public static List<Pizza> GetAll(){





            
    











public static List<Pizza> GetAll(){
            List<Pizza> ListaPizzas;
            string sql="SELECT * FROM Pizzas";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                ListaPizzas=BD.Query<Pizza>(sql).ToList();
            }
            return ListaPizzas;
        }    

        public static Pizza GetById(int Id){
            Pizza MiId=null;
            string sql="SELECT * FROM Pizzas WHERE Id=@pId";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                MiId=BD.QueryFirstOrDefault<Pizza>(sql,new{pId=Id});
            }
            return MiId;
        }
        
        public static Pizza Create(Pizza Pizza){
            string sql="INSERT INTO Pizzas (Nombre,LibreGluten,Importe,Descripcion) Values(@pNombre, @pLibreGluten, @pImporte, @pDescripcion);";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                BD.Execute(sql,new{pNombre=Pizza.Nombre,pLibreGluten=Pizza.LibreGluten,pImporte=Pizza.Importe,pDescripcion=Pizza.Descripcion});
            }
            return new Pizza();
        }
        public static Pizza Update(int Id, Pizza Pizza){
            string sql="UPDATE Pizzas SET  Nombre=@pNombre, LibreGluten=@pLibreGluten, Importe=@pImporte, Descripcion=@pDescripcion WHERE id=@pid";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                BD.Execute(sql,new{pId=Id,pNombre=Pizza.Nombre,pLibreGluten=Pizza.LibreGluten,pImporte=Pizza.Importe,pDescripcion=Pizza.Descripcion});
            }
            return new Pizza(); 
        }
        public static Pizza DeleteById(int Id){
            string sql="DELETE FROM Pizzas WHERE Id=@pid";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                BD.Execute(sql,new{pId=Id});
            }
            return new Pizza(); 
        }
    }