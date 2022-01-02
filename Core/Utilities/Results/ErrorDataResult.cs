using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    
        public class ErrorDataResult<T> : DataResult<T>
        {
            public ErrorDataResult(T data, string message) : base(data, false, message) //process results with T data, it is failed and there is a message.
            {

            }

            public ErrorDataResult(T data) : base(data, false)//do not return any messages.
            {

            }

            //when we don't use data and want to return the default value of the data.
            public ErrorDataResult(string message) : base(default, false, message)
            {

            }

            //default with no message.
            public ErrorDataResult() : base(default, false)
            {

            }
        }
}
