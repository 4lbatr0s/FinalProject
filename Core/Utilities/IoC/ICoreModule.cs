using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //same servicecollection build, we have in Startup.cs file, instead of Startup.cs 
        //we'll handle our general purpose IoC here.
        void Load(IServiceCollection serviceCollection); //it will load dependencies.
    }
}
