using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Product
    {
        public string Name { set; get; }
        public DateTime ManufacturingDate { get; }
        enum CategoryType{
            Cereal,
            LaundryDetergent,
            BottledJuice,
            Cheese,
            CannedSouop
        }
        public decimal Price { set; get; }
        public Product()
        {
            ManufacturingDate = DateTime.Now;
        }
        public void toString()
        {
            Console.WriteLine($"Product name: {Name}" +
                $"Manufacturing date: {ManufacturingDate}" +
                $"Category: " +
                $"Price: {Price}");
        }
    }
}

