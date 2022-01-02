using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        //use methods below as services.
        IDataResults<List<Product>> GetAll(); //we cannot change List to IResult because we cannot return values.
        //T in IDataResults is equal to List<> structure.
        IDataResults<List<Product>> GetAllByCategoryId(int id);
        IDataResults<List<Product>> GetAllByUnitPrice(decimal min, decimal max);

        IDataResults<Product> GetById(int id);

        IResult Add(Product product); //don't return void anymore, return IResult.
        IResult Update(Product product);
        IResult Delete(Product product);

        IDataResults<List<ProductDetailDto>> GetProductDetails();

    }
    
}
