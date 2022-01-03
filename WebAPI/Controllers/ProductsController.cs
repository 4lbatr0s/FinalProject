using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled:gevşek bağımlılık, soyut yapıya bağımlılık.
        IProductService _productService; //naming convention

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _productService.GetAll();
            if(result.Success)
            {
                //return Ok(result.Data); //if result returns true, then return 200 status code and the data.
                return Ok(result); //returs message too.
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult Post(Product product) //clients request passess here.
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result); // data itself, Add method returns IResult not IDataResult.
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
