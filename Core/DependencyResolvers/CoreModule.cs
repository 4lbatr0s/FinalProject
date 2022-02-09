using Core.CrossCuttingConcern.Caching;
using Core.CrossCuttingConcern.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //it's a handy Injection, creates an ICacheManager istance on the background.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //context that created for each request.
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();//tomorrow by just changing MemoryCacheManager to AnotherCacheManager, we can completely change our caching service.
            serviceCollection.AddSingleton<Stopwatch>(); //it's got use for PerformanceAspect.
        } 
    }
}
