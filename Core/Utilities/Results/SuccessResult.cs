using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message):base(true, message) //make constructor with true and message parameters work in the Result 
        { }

        public SuccessResult():base(true) //do not send message make constructor with only bool parameter works in the Result class.
        { }

    
    }
}
