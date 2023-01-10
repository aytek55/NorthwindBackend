using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Cashing;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.Aspects.Autofac.Caching
{
    public  class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheService _cacheService;
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheService.IsAdded(key))
            {
                invocation.ReturnValue = _cacheService.Get(key);
                return;
                
            }
            invocation.Proceed();
            _cacheService.Add(key,invocation.ReturnValue,_duration);

            //// Cache kontrolü yapılacak metod ismini ve full ismini alıyorum
            //var methodName = string.Format($"{invocation.TargetType.FullName}.{invocation.MethodInvocationTarget.Name}");

            //// Cache parametreli eklenmiş ise parametreleri getiriyorum.
            //var arguments = JsonConvert.SerializeObject(invocation.Arguments);


            //// burada metodun çağırılma keyini oluşturuyorum.
            //// Example: ProductManager.GetList(int categoryID) burada metot  ProductManager.GetList(12)  şeklinde çağırılırsa benim key im "ProductManager.GetList(12)" olur. 
            //var key = $"{methodName}({arguments})";

            //// Cache de bu key ile çağırılan metodun verileri varsa, cache den okuyup döndür.
            //if (_cacheService.IsAdded(key))
            //{
            //    invocation.ReturnValue = _cacheService.Get(key);
            //    return;
            //}
            //// eğer cache lenmemiş ise metot normal çalıştırılsın.
            //invocation.Proceed();

            ////daha sonra metodun çektiği veriler ache e eklensin.
            //_cacheService.Add(key, invocation.ReturnValue, _duration);
        }


    }
}
