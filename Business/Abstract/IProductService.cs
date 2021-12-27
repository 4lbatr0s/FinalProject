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
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetAllByUnitPrice(decimal min, decimal max);

        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<ProductDetailDto> GetProductDetails();

    }
    
}
