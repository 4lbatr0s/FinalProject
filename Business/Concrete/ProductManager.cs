using Business.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        InMemoryProductDal _inMemoryProductDal; //we want to access data.

        public ProductManager(InMemoryProductDal inMemoryProductDal)
        {
            _inMemoryProductDal = inMemoryProductDal;
        }

        public void Add(Product product)
        {
            _inMemoryProductDal.Add(product);
        }

        public void Delete(Product product)
        {
            _inMemoryProductDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            //Business Codes.
            var allProducts = _inMemoryProductDal.GetAll();
            return allProducts;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            var allProductsByCategoryId = _inMemoryProductDal.GetAllByCategory(categoryId);
            return allProductsByCategoryId;
        }

        public void Update(Product product)
        {
            _inMemoryProductDal.Update(product);
        }
    }
}
