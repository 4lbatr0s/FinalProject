using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product> //A validator for the Product Object, with the same logic, we can use this method for our DTO's too.
    {
        public ProductValidator() //rules goes into a constructor.
        {
            RuleFor(p => p.ProductName).MinimumLength(2); //product's name lenght should be min 2 
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty(); 
            RuleFor(p => p.UnitPrice).GreaterThan(0); //there are so many functions in the FluentValidator library.
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 1); //if it's a drink, minimum value should be 11

            //We can create our own Rules with our own functions.

            RuleFor(p => p.ProductName).Must(StartsWithA).WithMessage("Product names must start with an A"); ///write a function that detemines whether name starts with an 'a' or not.
                                                                                    
        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
