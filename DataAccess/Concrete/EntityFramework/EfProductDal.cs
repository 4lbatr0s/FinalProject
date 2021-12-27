using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Notes on this implementation: EfEntityRepositoryBase<Product, NorthwindContext>...
    //...includes the exact methods and object that IProductDal interface is asking for.They work together.
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            //we need to access context, or we cannot create Linq queries.
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products //join categories with products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId //join by categoryid
                             select new ProductDetailDto 
                             { ProductId = p.ProductId, ProductName = p.ProductName,
                               CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock 
                             };
                //create a new productdetaildto and get it's values from the joinned objects. 
                //ProductId in the new ProductDetailDto object is equal to ProductId from the joined value.
                return result.ToList(); //Because result value is actually is an IQueryable.
            
            }

        }
    }
}
