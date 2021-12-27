using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {   
        ////We want to minimize our dependency to entity framework, therefore we use ICategoryDal 
        
        ICategoryDal _categoryDal; //we call efcategorydal by using ICategoryDal.

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        //Select * from Categories WHERE CategoryId = 3

        public List<Category> GetById(int categoryId)
        {
            return _categoryDal.GetAll(c => c.CategoryId == categoryId);
        }
    }
}
