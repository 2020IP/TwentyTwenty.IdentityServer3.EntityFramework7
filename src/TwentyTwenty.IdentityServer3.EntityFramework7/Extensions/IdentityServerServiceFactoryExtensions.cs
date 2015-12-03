using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using TwentyTwenty.IdentityServer3.EntityFramework7.Services;
using TwentyTwenty.IdentityServer3.EntityFramework7.Stores;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Extensions
{
    public static class IdentityServerServiceFactoryExtensions
    {
        public static IdentityServerServiceFactory RegisterOperationalStores(this IdentityServerServiceFactory factory, IServiceProvider services)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (services == null) throw new ArgumentNullException("services");

            factory.Register(services.GetRegistration<OperationalContext>());

            factory.AuthorizationCodeStore = services.GetRegistration<IAuthorizationCodeStore>();
            factory.TokenHandleStore = services.GetRegistration<ITokenHandleStore>();
            factory.ConsentStore = services.GetRegistration<IConsentStore>();
            factory.RefreshTokenStore = services.GetRegistration<IRefreshTokenStore>();

            return factory;
        }
        
        public static IdentityServerServiceFactory RegisterClientStore<TKey>(this IdentityServerServiceFactory factory, IServiceProvider services)
            where TKey : IEquatable<TKey>
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (services == null) throw new ArgumentNullException("services");

            factory.Register(services.GetRegistration<ClientConfigurationContext<TKey>>());
            
            factory.ClientStore = services.GetRegistration<IClientStore>();
            factory.CorsPolicyService = new Registration<ICorsPolicyService, ClientConfigurationCorsPolicyService<TKey>>();

            return factory;
        }

        public static IdentityServerServiceFactory RegisterScopeStore<TKey>(this IdentityServerServiceFactory factory, IServiceProvider services)
            where TKey : IEquatable<TKey>
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (services == null) throw new ArgumentNullException("services");

            factory.Register(services.GetRegistration<ScopeConfigurationContext<TKey>>());

            factory.ScopeStore = services.GetRegistration<IScopeStore>();

            return factory;
        }

        private static Registration<T> GetRegistration<T>(this IServiceProvider services) where T : class
        {
            return new Registration<T>(resolver => services.GetRequiredService<T>());
        }
    }
}