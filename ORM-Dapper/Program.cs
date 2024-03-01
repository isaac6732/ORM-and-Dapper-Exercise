using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

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
           
            #region Department
            var departmentRepo =  new DapperDepartmentRepository(conn);

            departmentRepo.InsertDepartment("Yes my Department");

            var departments = departmentRepo.GetAllDeparments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
                

            }
            #endregion

            var productRepository = new DapperProductRepository(conn);
            var products = productRepository.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
