 using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;

namespace Console_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            EfProductDal efProductDal = new EfProductDal();
            ProductManager productManager = new ProductManager(efProductDal);
            //foreach(var product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            foreach(var prod in productManager.GetAll())
            {
                Console.WriteLine(prod.ProductName);
            }

            foreach (var prod in productManager.GetAllByCategoryId(50))
            {
                Console.WriteLine("{0}, price: {1}", prod.ProductName, prod.UnitPrice);
            }

            foreach (var prod in productManager.GetAllByUnitPrice(50, 100))
            {
                Console.WriteLine("{0}, price: {1}", prod.ProductName, prod.UnitPrice);
            }
        }
    }
}
