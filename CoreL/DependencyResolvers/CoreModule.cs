using CoreL.CrossCuttingConcerns.Cashing;
using CoreL.CrossCuttingConcerns.Cashing.Microsoft;
using CoreL.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();//Bu hazır bir injection arka planda hazır bir ICacheManager instance(instıns) üretiyor
            serviceCollection.AddSingleton<IHttpContextAccessor,HttpContextAccessor >();
            serviceCollection.AddSingleton<ICacheManager, MemoryCasheManager>();//Redise geççeksen redis ytazman yerli olır
        }
    }
}
