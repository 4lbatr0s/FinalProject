using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic constraint . 
    //class: that means T could be a referance type, not only classes.This is a well known wrong.
    public interface IEntityRepository<T> where T:class, IEntity, new() //T could be a reference type but in the borders of the Entity.
    {                                                          //new() = T should be newable, IEntity is an interface, therefore it cannot.
    
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //delegate., filter =null : bring all the data otherwise, bring filtered data.  
        //delegate.//this expression helps us to create filterings in the 
        //Manager class of the related Entity. For instance, return _productDal.GetAll(p => p.ProductId == 2); 
        //Therefore we removed the GetAllByCategory(int categoryId); function because we can pass this filterin to our GetAll 
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity); //interfaces methods are default public.
        void Update(T entity);
        void Delete(T entity);

    }
}
