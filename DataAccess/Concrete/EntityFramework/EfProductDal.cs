using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //the parameters we pass to the using functions are collected by garbage collector right away, because the usage of the Context is expensive.
            //IDisposable pattern implementation of c#.
            using (NorthwindContext context = new NorthwindContext()) //what this function saying is: collect this memory occupation right away after initialization of the Context object.
            {
                var addedEntity = context.Entry(entity); //catch the reference.
                addedEntity.State = EntityState.Added; //add this entity to database
                context.SaveChanges(); //save changes.
            }
        }

        public void Delete(Product entity)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //catch the reference address.
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //set : yerleş, mekan edin.
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                //Set<Product> == settle on the Product table of the database, and fetch all the values.
                return filter == null ? context.Set<Product>().ToList():context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //catch the reference address.
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
