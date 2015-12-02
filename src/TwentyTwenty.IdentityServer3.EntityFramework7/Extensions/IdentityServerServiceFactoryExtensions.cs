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
        public static IdentityServerServiceFactory RegisterOperationalServices(this IdentityServerServiceFactory factory, Func<OperationalContext> contextResolver)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (contextResolver == null) throw new ArgumentNullException("contextResolver");
            //services.ThrowIfOperationalServicesNotRegistered();

            factory.Register(new Registration<OperationalContext>(r => contextResolver()));

            factory.AuthorizationCodeStore = new Registration<IAuthorizationCodeStore, AuthorizationCodeStore>();
            factory.TokenHandleStore = new Registration<ITokenHandleStore, TokenHandleStore>();
            factory.ConsentStore = new Registration<IConsentStore, ConsentStore>();
            factory.RefreshTokenStore = new Registration<IRefreshTokenStore, RefreshTokenStore>();

            return factory;
        }
        
        public static IdentityServerServiceFactory RegisterClientStore<TKey>(this IdentityServerServiceFactory factory, Func<ClientConfigurationContext<TKey>> contextResolver)
            where TKey : IEquatable<TKey>
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (contextResolver == null) throw new ArgumentNullException("contextResolver");
            
            factory.Register(new Registration<ClientConfigurationContext<TKey>>(r => contextResolver()));

            factory.ClientStore = new Registration<IClientStore, ClientStore<TKey>>();
            factory.CorsPolicyService = new Registration<ICorsPolicyService, ClientConfigurationCorsPolicyService<TKey>>();

            return factory;
        }

        public static IdentityServerServiceFactory RegisterScopeStore<TKey>(this IdentityServerServiceFactory factory, Func<ScopeConfigurationContext<TKey>> contextResolver)
            where TKey : IEquatable<TKey>
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (contextResolver == null) throw new ArgumentNullException("contextResolver");
            //services.ThrowIfScopeContextNotRegistered();

            factory.Register(new Registration<ScopeConfigurationContext<TKey>>(r => contextResolver()));

            factory.ScopeStore = new Registration<IScopeStore, ScopeStore<TKey>>();

            return factory;
        }

        private static Registration<T> GetRegistration<T>(this IServiceProvider services) where T : class
        {
            return new Registration<T>(resolver => services.GetService<T>());
        }
    }
}