using System;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryId)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryId) VALUES (@productName, @price, @categoryID);",
                new {productName = name, Price = price, CategoryID = categoryId });
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }

        public void UpdateProductName(int productId, string updatedName)
        {
            _connection.Execute("UPDATE Products SET Name = @updatedName WHERE ProductId = @productId;",
                new { productId = productId, updatedName = updatedName });
        }

        public void DeleteProduct(int productId)
        {
            _connection.Execute("DELETE FROM products WHERE ProductId = @productId;",
                new { productId = productId });
            _connection.Execute("DELETE FROM sales WHERE ProductId = @productId;", 
                new { productId = productId });
            _connection.Execute("DELETE FROM reviews WHERE ProductId = @productId;", 
                new { productId = productId });
        }

            // public void InsertDepartment(string newDepartmentName)
            // {
            //     _connection.Execute("INSERT INTO Departments (Name) VALUES (@departmentName);",
            //         new { departmentName = newDepartmentName });
            // }
        }
    }
