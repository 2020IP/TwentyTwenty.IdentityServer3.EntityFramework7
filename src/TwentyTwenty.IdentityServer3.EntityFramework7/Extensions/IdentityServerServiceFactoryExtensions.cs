using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.Data.Entity.Infrastructure;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces;
using TwentyTwenty.IdentityServer3.EntityFramework7.Registrations;
using TwentyTwenty.IdentityServer3.EntityFramework7.Stores;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Extensions
{
    public static class IdentityServerServiceFactoryExtensions
    {
        public static void RegisterOperationalServices(this IdentityServerServiceFactory factory, DbContextOptions options)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (options == null) throw new ArgumentNullException("options");

            factory.Register(new Registration<IOperationalDbContext>(resolver => new OperationalContext(options)));
            factory.AuthorizationCodeStore = new Registration<IAuthorizationCodeStore, AuthorizationCodeStore>();
            factory.TokenHandleStore = new Registration<ITokenHandleStore, TokenHandleStore>();
            factory.ConsentStore = new Registration<IConsentStore, ConsentStore>();
            factory.RefreshTokenStore = new Registration<IRefreshTokenStore, RefreshTokenStore>();
        }

        public static void RegisterConfigurationServices(this IdentityServerServiceFactory factory, DbContextOptions options)
        {
            factory.RegisterClientStore(options);
            factory.RegisterScopeStore(options);
        }

        public static void RegisterClientStore(this IdentityServerServiceFactory factory, DbContextOptions options)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (options == null) throw new ArgumentNullException("options");

            factory.Register(new Registration<IClientConfigurationDbContext>(resolver => new ClientConfigurationContext(options)));
            factory.ClientStore = new Registration<IClientStore, ClientStore>();
            factory.CorsPolicyService = new ClientConfigurationCorsPolicyRegistration(options);
        }

        public static void RegisterScopeStore(this IdentityServerServiceFactory factory, DbContextOptions options)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            if (options == null) throw new ArgumentNullException("options");

            factory.Register(new Registration<IScopeConfigurationDbContext>(resolver => new ScopeConfigurationContext(options)));
            factory.ScopeStore = new Registration<IScopeStore, ScopeStore>();
        }
    }
}