using Business.Constants;
using Castle.DynamicProxy;
using Core.CrossCuttingConcern;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.IoC;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; // In API, foreach person that sent a request, we create a HTTPContext

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //in <Entity>Manager.cs file, we pass strings args to our Aspects, same goes for the SecuredOperation too. 
                                       //therefore, we split the strings by the comma and create an array of string values.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); //we get the IHttpContextAccessor's properties and methods, it comes from DependencyInjection.

        }

        //Execute the SecuredOperation aspect right before the function( Add, Delete etc...) 
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
