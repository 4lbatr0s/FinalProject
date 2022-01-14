using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules //no need for NO EMPTY CLASS rules here in Utilities.
    {
        public static IResult Run(params IResult[] logics) //we well pass our business rule functions to this function as parameters.  
        {
           foreach(var logic in logics)
            {
                if(!logic.Success)
                {
                    return logic; //if logic doesn't fit, return it.
                }
            }

            return null; //if there is not any error, do not return anything.
        }
    }
}
