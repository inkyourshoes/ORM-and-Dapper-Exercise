
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperProductRepository(conn);
            
            //CREATE PRODUCT
            // repo.CreateProduct("FIDGET", 28, 1);
            
            var products = repo.GetAllProducts();

            // var repo = new DapperDepartmentRepository(conn);
            // var departments = repo.GetAllDepartments();

            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.CategoryId}) ({prod.Name}");
            }
            // repo = new DapperProductRepository(conn);
            // repo.DeleteProduct(940);
            // repo.DeleteProduct(941);
            // repo.DeleteProduct(942);
            // repo.DeleteProduct(943);
            // repo.DeleteProduct(944);
            // repo.DeleteProduct(945);
            // repo.DeleteProduct(946);

            
        }
    }
}

