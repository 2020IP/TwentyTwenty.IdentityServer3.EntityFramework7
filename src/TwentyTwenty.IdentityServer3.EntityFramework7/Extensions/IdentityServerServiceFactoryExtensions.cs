using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.Registrations;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Extensions
{
    public static class IdentityServerServiceFactoryExtensions
    {
        public static void RegisterOperationalServices(this IdentityServerServiceFactory factory, IServiceProvider services)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (services == null) throw new ArgumentNullException("services");
            services.ThrowIfOperationalServicesNotRegistered();
            
            factory.AuthorizationCodeStore = services.GetRegistration<IAuthorizationCodeStore>();
            factory.TokenHandleStore = services.GetRegistration<ITokenHandleStore>();
            factory.ConsentStore = services.GetRegistration<IConsentStore>();
            factory.RefreshTokenStore = services.GetRegistration<IRefreshTokenStore>();
        }

        public static void RegisterConfigurationServices(this IdentityServerServiceFactory factory, IServiceProvider services)
        {
            factory.RegisterClientStore(services);
            factory.RegisterScopeStore(services);
        }

        public static void RegisterClientStore(this IdentityServerServiceFactory factory, IServiceProvider services)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (services == null) throw new ArgumentNullException("services");
            services.ThrowIfClientConfigurationServicesNotRegistered();
            
            factory.ClientStore = services.GetRegistration<IClientStore>();
            factory.CorsPolicyService = new ClientConfigurationCorsPolicyRegistration(services);
        }

        public static void RegisterScopeStore(this IdentityServerServiceFactory factory, IServiceProvider services)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (services == null) throw new ArgumentNullException("services");
            services.ThrowIfScopeConfigurationServicesNotRegistered();
            
            factory.ScopeStore = services.GetRegistration<IScopeStore>();
        }

        private static Registration<T> GetRegistration<T>(this IServiceProvider services) where T : class
        {
            return new Registration<T>(resolver => services.GetRequiredService<T>());
        }
    }
}