using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        // Mevcut provider a erişim.
        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// bu yapı ile .net core un kendi servislerine de erişebiliyorum.
        /// Örnek kullanım 
        /// IAbstract _abstract = ServiceTool.ServiceProvider.GetService<IAbstract>();
        /// Sistemde default olarak IAbstract soyut sınıfına karşılık hangi somut sınıf belirtilmişse onu döndürür.
        /// Default değerler BusinessModule ve CoreModule de mevcut.
        /// Default dışında başka bir class kullanmak istiyorsak şu şekilde kullanmamız gerek 
        /// IAbstract _abstract = new MyConcreteClass();
        /// Tabi buradaki MyConcreteClass IAbstract tan türtilmiş olmalı.
        /// </summary>
        /// <param name="service"> Start up daki IServiceCollection ı bulur.</param>
        /// <returns></returns>
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
