using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category> //You are an CategoryDal, inhereted from IEntityRepository in the Category type.
    {
       
    }
}

//Code Refactoring: Making code better.
