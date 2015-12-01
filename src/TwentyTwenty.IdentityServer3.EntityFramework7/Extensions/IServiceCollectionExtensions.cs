using IdentityServer3.Core.Services;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces;
using TwentyTwenty.IdentityServer3.EntityFramework7.Stores;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityEFOperationalServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddTransient<IOperationalDbContext, OperationalContext>()
                .AddTransient<ITokenHandleStore, TokenHandleStore>()
                .AddTransient<IAuthorizationCodeStore, AuthorizationCodeStore>()
                .AddTransient<IConsentStore, ConsentStore>()
                .AddTransient<IRefreshTokenStore, RefreshTokenStore>();
        }

        public static IServiceCollection AddIdentityEFClientConfigurationServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddTransient<IClientConfigurationDbContext, ClientConfigurationContext>()
                .AddTransient<IClientStore, ClientStore>();
        }

        public static IServiceCollection AddIdentityEFScopeConfigurationServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddTransient<IScopeConfigurationDbContext, ScopeConfigurationContext>()
                .AddTransient<IScopeStore, ScopeStore>();
        }

        public static IServiceCollection AddIdentityEFServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddIdentityEFOperationalServices()
                .AddIdentityEFClientConfigurationServices()
                .AddIdentityEFScopeConfigurationServices();
        }
    }
}