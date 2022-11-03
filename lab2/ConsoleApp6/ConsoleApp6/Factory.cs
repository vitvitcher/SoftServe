using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Factory
    {
        string Name;
        int EmployeeCount = 0;
        int ProductCount = 0;
        Employee[] Empoyees;
        Product[] Products;
        public Factory(string name, int MaxEmp, int MaxProducts)
        {
            Name = name;
            Empoyees = new Employee[MaxEmp];
            Products = new Product[MaxProducts];
        }
        public void addEmployee(Employee empoyee)
        {
            EmployeeCount++;
            Empoyees.Append(empoyee);
        }
        public void addProduct(Product product)
        {
            ProductCount++;
            Products.Append(product);
        }

        public void toString()
        {
            Console.WriteLine($"Factory name: {Name}" +
                $"Workers count: {EmployeeCount}" +
                $"");
        }
        public decimal TotalSalary()
        {
            decimal total = 0;
            foreach (var worker in Empoyees)
            {
                total += worker.Salary;
            }
            return total;
        }
        public decimal AvgSalary()
        {
            return TotalSalary() / EmployeeCount;
        }
        public decimal GDP()
        {
            decimal totalProdPrice = 0;
            foreach(var product in Products)
            {
                totalProdPrice += product.Price;
            }
            return totalProdPrice / EmployeeCount;
        }
    }
}
