using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{ 
    //this interface is especially for void methods.
    public interface IResult
    {
        bool Success { get; } //readonly.
        string Message { get; } 
    }
}
