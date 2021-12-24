using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    interface IServiceRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //delegate., filter =null : bring all the data otherwise, bring filtered data.  
        ///delegate.//this expression helps us to create filterings in the 
        ////Manager class of the related Entity. For instance, return _productDal.GetAll(p => p.ProductId == 2); 
        ////Therefore we removed the GetAllByCategory(int categoryId); function because we can pass this filterin to our GetAll 
        T Get(Expression<Func<T, bool>> filter);
        
        void Add(T entity); //interfaces methods are default public.
        void Update(T entity);
        void Delete(T entity);
        
        //List<T> Get
    }
}
