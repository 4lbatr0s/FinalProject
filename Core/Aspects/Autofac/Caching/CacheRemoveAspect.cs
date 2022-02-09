using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    //WHEN CacheRemoveAspect works ? When you update/delete/change your data. 
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }


        //explanation: For instance, in ProductManager.cs file, use Add() method and add a new product.
        //Do not remove the former CacheAspect until our Add() method throws an extension. 
        //Because we only remove CacheAspect when there is a change taking place in our data.
        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
