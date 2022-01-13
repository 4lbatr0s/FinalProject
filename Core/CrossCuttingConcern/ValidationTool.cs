using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern
{
    public static class ValidationTool
    {
       public static void Validate(IValidator validator, object entity) //validator : ProductValidator, ProductValidator is an AbstractValidator and AbstractValidator inherits from IValidator. Therefore IValidator references ProductValidator.
        {
            var context = new ValidationContext<object>(entity); //work with an object(because everything is an object), and product is our current parameter.
            var result = validator.Validate(context); //IValidator involves a method call
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
