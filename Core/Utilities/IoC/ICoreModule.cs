using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    // Business de yaptığım çözümlemeler iş katmanıma ait operasyonları çözümlüyordu.
    // Burada ise Projemdeki çözümlemeleri yapacağım (ICash için MemoryCash veya ...Cash gibi)
    public interface ICoreModule
    {

        void Load(IServiceCollection services);
    }
}
