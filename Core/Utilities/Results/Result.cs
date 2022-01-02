using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
     
        public bool Success { get; }

        public string Message { get; }

        //pass the Success parameter to the constructor with only Success parameter. 
        //With this way we will make two constructor work at a time. 
        public Result(bool Success, string Message):this(Success) //we can set readonly values in constructor functions.
        {
            this.Message = Message;
        }

        //For example: we can return not success and message but only success or otherwise around.
        public Result(bool Success) // we want to create different methods for different calls we may write in the ProductManager class.
        { 
            this.Success = Success;
        }

        public Result(string Message)
        {
            this.Message = Message;
        }
    }
}
