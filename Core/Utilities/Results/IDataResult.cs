using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult //T : return type. IDataResults is already an IResult inheritance for we need IResult's message and return values.
    {
         T Data {get;}

    }
}
