using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{


    class Program
    {
        static void AddProduct(Product product)
        {
            Console.WriteLine("Input product info.");
            Console.Write("Name:");
            product.Name = Console.ReadLine();
            Console.Write("Price:");
            decimal.TryParse(Console.ReadLine(), out decimal price);
            product.Price = price;
            product.toString();
        }
        static void AddEmployee(Employee employee)
        {
            Console.WriteLine("Input employee info.");
            Console.Write("Name:");
            employee.Name = Console.ReadLine();
            Console.Write("Surename:");
            employee.Surename = Console.ReadLine();
            Console.Write("Birth date (dd.mm.yyyy):");
            DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthdate);
            employee.BirthDate = birthdate.Date;
            Console.Write("Salary:");
            decimal.TryParse(Console.ReadLine(), out decimal salary);
            employee.Salary = salary;
            employee.toString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input the maximum number of workers");
            int.TryParse(Console.ReadLine(), out int maxEmp);
            Console.WriteLine("Input the maximum number of products");
            int.TryParse(Console.ReadLine(), out int maxProd);
            int EmpCount = 0;
            int ProdCount = 0;
            Console.WriteLine("Insert factory name");
            Factory factory = new Factory(Console.ReadLine(), maxEmp, maxProd);
            while (EmpCount < maxEmp)
            {
                Console.WriteLine("Do you want to add an employee?");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        Employee employee = new Employee();
                        AddEmployee(employee);
                        Console.WriteLine("Employee added. Confirm?");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            factory.addEmployee(employee);
                            EmpCount++;
                        }
                        else Console.WriteLine("Canceled.");
                        continue;
                    case "n":
                        break;
                    default:
                        continue;
                }
                break;
            }
            while (ProdCount < maxProd)
            {
                Console.WriteLine("Do you want to add a product?");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        Product product = new Product();
                        AddProduct(product);
                        Console.WriteLine("Product added. Confirm?");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            factory.addProduct(product);
                            ProdCount++;
                        }
                        else Console.WriteLine("Canceled.");
                        continue;
                    case "n":
                        break;
                    default:
                        continue;
                }
                break;
            }
        }
    }
}

