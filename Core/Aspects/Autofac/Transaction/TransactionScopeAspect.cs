using Castle.DynamicProxy;
using Core.Utilities.Interceptors.Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    // Hatayı benim hata sınıfıma göndermek için tekrar hata atıyorum.
                    //throw new TransactionException(e.Message, e.InnerException);
                    throw;
                }
            }
        }
    }
}
