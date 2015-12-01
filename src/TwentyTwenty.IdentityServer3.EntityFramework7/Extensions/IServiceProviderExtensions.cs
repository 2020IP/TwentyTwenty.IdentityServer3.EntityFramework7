using IdentityServer3.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Extensions
{
    internal static class IServiceProviderExtensions
    {
        public static void ThrowIfOperationalServicesNotRegistered(this IServiceProvider services)
        {
            if (services.GetService(typeof(IAuthorizationCodeStore)) == null)
            {
                throw new InvalidOperationException("Must add Operational services to DependencyInjection container before calling RegisterOperationalServices");
            }
        }

        public static void ThrowIfClientConfigurationServicesNotRegistered(this IServiceProvider services)
        {
            if (services.GetService(typeof(IClientStore)) == null)
            {
                throw new InvalidOperationException("Must add ClientConfiguration services to DependencyInjection container before calling RegisterClientConfigurationServices");
            }
        }

        public static void ThrowIfScopeConfigurationServicesNotRegistered(this IServiceProvider services)
        {
            if (services.GetService(typeof(IScopeStore)) == null)
            {
                throw new InvalidOperationException("Must add ScopeConfiguration services to DependencyInjection container before calling RegisterScopeConfigurationServices");
            }
        }
    }
}