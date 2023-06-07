using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.loC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect :MethodInterception
    {
        readonly string _pattern;
        readonly ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager =ServiceTool.ServiceProvider.GetRequiredService<ICacheManager>(); 
        }

        protected override void OnSuccess(IInvocation ınvocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }

    }
}
