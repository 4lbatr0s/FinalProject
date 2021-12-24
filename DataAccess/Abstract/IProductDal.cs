using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //IEntityDal: Exact place where we do database operations: CRUD etc.
    public interface IProductDal:IEntityRepository<Product>
    {
        ////An interface's operations are default public. But not itself.
        //List<Product> GetAll(); 
        //void Add(Product product); //interfaces methods are default public.
        //void Update(Product product);
        //void Delete(Product product);

        //List<Product> GetAllByCategory(int categoryId);
    }
}
