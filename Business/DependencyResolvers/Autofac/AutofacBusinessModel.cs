 
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModel : Module //you are an Autofac module. By telling this, we get the enviroment to implement IoC transformations we've made in Startup.cs!
    { 
        protected override void Load(ContainerBuilder builder) //IES, Docker , this is the function that is going to get invoked  
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); //add.Singleton<> same, create ProductManager instance if someone makes a request for an IProductService.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();


                
            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); //From the executed program

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() //find the implemented interfaces which are above (IProduct,ICategory etc..)
                .EnableInterfaceInterceptors(new ProxyGenerationOptions() 
                {               //AspectInterceptorSelector works before every class declaration. It assess if there are any aspects for that class [...] is an Aspect, it is an attribute. 
                    Selector = new AspectInterceptorSelector() //Have AspectInterceptorSelector executed for the implemented interfaces. 
                }).SingleInstance();
        }
    }
}