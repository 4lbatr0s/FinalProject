using Core.Entities;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    //Notes for IEntityRepositoryBase: IEntityRepository<TEntity> because IEntityRepository holds a parameter with the type of T, now our T is TEntity.I
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> //give an entity and a context, I'll work with them.
        where TEntity : class, IEntity, new() //
        where TContext : DbContext, new() //we use the phrase DatabaseContext context = new DatabaseContext(); structure in data access layer. 
    {
        public void Add(TEntity entity)
        {
            //the parameters we pass to the using functions are collected by garbage collector right away, because the usage of the Context is expensive.
            //IDisposable pattern implementation of c#.
            using (TContext context = new TContext()) //what this function saying is: collect this memory occupation right away after initialization of the Context object.
            {
                var addedEntity = context.Entry(entity); //catch the reference.
                addedEntity.State = EntityState.Added; //add this entity to database
                context.SaveChanges(); //save changes.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //catch the reference address.
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                //set : yerleş, mekan edin.
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //Set<Product> == settle on the Product table of the database, and fetch all the values.
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //catch the reference address.
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
