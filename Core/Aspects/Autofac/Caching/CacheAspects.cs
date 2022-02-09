using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //ReflectedType: Namespace+Classname, for instance: FinalProject.Business.IProductService 
            //innvocation.Method.Name: GetAll 
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList(); //Put method's(for instance GetAll) into a List.
           //create key.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; //?? if exists add x, else add <Null>
            if (_cacheManager.IsAdd(key)) //check if key already exists.
            {
                invocation.ReturnValue = _cacheManager.Get(key); //if exits, return without executing the method, add function from cacheManager into ReturnValue
                return;
            }
            invocation.Proceed();//if it doesn't exist, keep going
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //execute the method, go to database, fetch the value, put it into the cache. 
        }
    }
}
