using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            NorthwindContext northwindContext = new NorthwindContext();

            foreach (var item in northwindContext.Products)
            {
                Console.WriteLine(item.ProductName);
                                
            }
        }
    }
}
