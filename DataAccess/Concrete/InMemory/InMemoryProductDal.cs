using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //_products: global variable naming standart.

        public InMemoryProductDal() //creates a _products when you start the program.
        {

            _products = new List<Product> {
                new Product
                {
                    ProductId = 1, ProductName = "Bardak", UnitPrice=15, UnitsInStock = 15, CategoryId = 1
                },
                new Product
                {
                    ProductId = 2, ProductName = "Kamera", UnitPrice=500, UnitsInStock = 3, CategoryId = 1
                },
                new Product
                {
                    ProductId = 3, ProductName = "Telefon", UnitPrice=1500, UnitsInStock = 2, CategoryId = 2
                },
                new Product
                {
                    ProductId = 4, ProductName = "Klavye", UnitPrice=150, UnitsInStock = 65, CategoryId = 2
                },
                new Product
                {
                    ProductId = 5, ProductName = "Fare", UnitPrice=85, UnitsInStock = 1, CategoryId = 2
                }

            };
        }
                                                       
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ : Language Integrated Query.
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //p=> means for every p in the _products.
            //singleordefault: returns one element 

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {   //SQL WHERE == LINQ Where.
            var productsByCategoryId = _products.Where(p => p.CategoryId == categoryId).ToList(); //similar to filter() function in the JS
            return productsByCategoryId;
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //productToUpdate points out the same referance as the found value does.
                     
            productToUpdate.ProductName = product.ProductName; //therefore, when a value in the referance value of productToUpdate changes, it changes the values of the found value too.
            productToUpdate.CategoryId = product.CategoryId; 
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
                
        }
    }
}
