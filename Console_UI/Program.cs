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
            //ProductTest();
            //CategoryTest();

            EfProductDal efProductDal = new EfProductDal();
            ProductManager productManager = new ProductManager(efProductDal);

            var result = productManager.GetProductDetails();
            if(result.Success)
            {
                foreach (var prod in result.Data)
                {
                    Console.WriteLine("Product Name: {0},  Category Name: {1}", prod.ProductName, prod.CategoryName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            EfProductDal efProductDal = new EfProductDal();
            ProductManager productManager = new ProductManager(efProductDal);
            //foreach(var product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            foreach (var prod in productManager.GetAll().Data)
            {
                Console.WriteLine(prod.ProductName);
            }

            foreach (var prod in productManager.GetAllByCategoryId(50).Data)
            {
                Console.WriteLine("{0}, price: {1}", prod.ProductName, prod.UnitPrice);
            }

            foreach (var prod in productManager.GetAllByUnitPrice(50, 100).Data)
            {
                Console.WriteLine("{0}, price: {1}", prod.ProductName, prod.UnitPrice);
            }
        }
    }
}
