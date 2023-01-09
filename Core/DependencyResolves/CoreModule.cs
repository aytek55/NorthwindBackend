using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolves
{
    /// <summary>
    /// Artık Startup kısmında servise ekleyeceğim modulleri buradan merkezi olarak ekleyebilirim.
    /// services.AddMemoryCache(); yazdığımda services den sonraki referanslara ulaşamadım bu yüzden CoreModule kullanımından şimdilik vazgeçtim.
    /// services.AddMemoryCache(); kodumu Startup a yazacağım.
    /// </summary>
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();

            // dependency resolver...
           // services.AddSingleton<ICacheService, MemoryCacheManager>();


            //  User.ClaimRoles() ClaimRoles u extent etmiştik. User nesnesi Claimsten gelir ancak sadece MVC de geliyordu.
            // Core ve Business projelerine Aspnetcore.Http paketini yükledik ve HttpContextAccessor ü çözümledik.

            // HttpContext.User.---   erişebilmek için token ı göndermek gerek.
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Stopwatch ekledim
            services.AddSingleton<Stopwatch>();

        //    services.AddSingleton<ILogDal, DpLogDal>();
        }
    }
}
