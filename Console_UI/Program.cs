 using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace Console_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManger = new ProductManager(new InMemoryProductDal());

            foreach(var product in productManger.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
