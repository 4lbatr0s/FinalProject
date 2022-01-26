using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data,true,message) //process results with T data, it is successfull and there is a message.
        {

        }

        public SuccessDataResult(T data) : base(data, true)//do not return any messages.
        {

        }

        //when we don't use data and want to return the default value of the data.
        public SuccessDataResult(string message):base(default,true,message)
        {

        }

        //default with no message.
        public SuccessDataResult(IDataResult<Entities.Concrete.User> userToCheck) :base(default,true) 
        {

        }
    }
}
