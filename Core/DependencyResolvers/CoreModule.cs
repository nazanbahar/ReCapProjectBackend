using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            //serviceCollection'a AddMemoryCache Eklemek
            serviceCollection.AddMemoryCache();  // //Hazır Bir Injection MemoryCache
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Used technology change : Added--> RedisCacheManager(), deleted:MemoryCacheManager>();
            //serviceCollection.AddSingleton<ICacheManager, RedisCacheManager>();
            //This is Microsft's own implementation!
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            //performance için stopwatch için eklemek
            serviceCollection.AddSingleton<Stopwatch>();

        }
    }
}
