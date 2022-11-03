using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{

    public class Employee
    {
        public string Name { set; get; }
        public string Surename { set; get; }
        public DateTime BirthDate { set; get; }
        public decimal Salary { set; get; }
        public void toString()
        {
            Console.WriteLine($"Employee's full name: {Name} {Surename}" +
                $"Birth date: {BirthDate.Date}" +
                $"Salary: {Salary}");
        }
    }
}

