using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, Castle.DynamicProxy.IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //retrieve all class attributes
               (true).ToList();
            var methodAttributes = type.GetMethod(method.Name) //retrieve all method attributes
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList(); 
            classAttributes.AddRange(methodAttributes); //add method attributes to class attributes list.
           /* classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));*/ //involve all log actions to system automatically.
             
            return classAttributes.OrderBy(x => x.Priority).ToArray(); //return attributes by priority number 


        }
    }
}
