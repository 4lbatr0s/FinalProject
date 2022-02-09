using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation) //your method.
        {
            //here, you're basically creating a template
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed(); //execute your method(for example ProductManager.AddTransactionalTest())
                    transactionScope.Complete();//if you don't get any exceptions, complete.
                }
                catch (Exception e)
                {
                    transactionScope.Dispose(); //if  you get an exception, dispose the process, throw error.
                    throw;
                }
            }
        }
    }
}
