using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //we want to access data.

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
    
        public IResult Add(Product product)
        {
            if(product.ProductName.Length<2)
            {
                //magic string
                return new ErrorResult(Messages.ProductNameInvalid);
            }
             //else is not necissary, because if block involves a return value.
             _productDal.Add(product);
              return new SuccessResult(Messages.ProductAdded); // You don't have to pass the true parameter, because you've already created that in the Result class.
              //return new SuccessResult(); //this'd work fine as well.
       

        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new Result(true, "deleted");

        }

        IDataResults <List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorResult();
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), true, "All values");
        }


        public IDataResults<List<Product>> GetAllByCategoryId(int id)
        {
            return new DataResult<List<Product>>(_productDal.GetAll(product => product.ProductId == id), true, "Products fetched by category ids");
        }

        public IDataResults<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new DataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice>= min && p.UnitPrice <= max), true, "Products fetched by unit prices");
        }

        public IDataResults<Product> GetById(int id)
        {
            return new DataResult<Product>(_productDal.Get(p => p.ProductId == id), true, "Product fetched by id");
        }

        public IDataResults<List<ProductDetailDto>> GetProductDetails()
        {
            return new DataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), true, "Fetched product details");
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new Result();
        }

        
    }
}
