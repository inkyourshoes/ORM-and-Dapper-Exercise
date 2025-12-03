using System.Data;
using System.IO;
using System.Transactions;
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

            string connString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException();
            

            IDbConnection connection = new MySqlConnection(connString);

            var repo = new DapperProductRepository(connection);
            repo.CreateProduct("New Test Product", 100, 1);
            var products = repo.GetAllProducts();
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductId} {prod.Name} {prod.Price}");
            }

            // var repo = new DapperDepartmentRepository(conn);
            // var departments = repo.GetAllDepartments();
            // foreach (var department in departments)
            // {
            //     Console.WriteLine($"{department.DepartmentId} {department.Name}");
            // }
        }
    }
}
