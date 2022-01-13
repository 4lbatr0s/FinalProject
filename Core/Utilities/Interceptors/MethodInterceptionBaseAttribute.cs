using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor //IInterceptor comes from Autofac Castle.DynamicProxy
    {
        public int Priority { get; set; } //which attribute should work first.

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
