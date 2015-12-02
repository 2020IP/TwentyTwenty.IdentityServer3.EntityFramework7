using IdentityServer3.Core.Services;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces;
using TwentyTwenty.IdentityServer3.EntityFramework7.Services;
using TwentyTwenty.IdentityServer3.EntityFramework7.Stores;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityEFOperationalServices<TKey>(this IServiceCollection services)
            where TKey : IEquatable<TKey>
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddTransient<IOperationalContext<TKey>, OperationalContext<TKey>>()
                .AddTransient<ITokenHandleStore, TokenHandleStore<TKey>>()
                .AddTransient<IAuthorizationCodeStore, AuthorizationCodeStore<TKey>>()
                .AddTransient<IConsentStore, ConsentStore<TKey>>()
                .AddTransient<IRefreshTokenStore, RefreshTokenStore<TKey>>();
        }

        public static IServiceCollection AddIdentityEFClientConfigurationServices<TKey>(this IServiceCollection services)
            where TKey : IEquatable<TKey>
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddTransient<IClientConfigurationContext<TKey>, ClientConfigurationContext<TKey>>()
                .AddTransient<IClientStore, ClientStore<TKey>>()
                .AddTransient<ICorsPolicyService, ClientConfigurationCorsPolicyService<TKey>>();
        }

        public static IServiceCollection AddIdentityEFScopeConfigurationServices<TKey>(this IServiceCollection services)
            where TKey : IEquatable<TKey>
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddTransient<IScopeConfigurationContext<TKey>, ScopeConfigurationContext<TKey>>()
                .AddTransient<IScopeStore, ScopeStore<TKey>>();
        }

        public static IServiceCollection AddIdentityEFServices<TKey>(this IServiceCollection services)
            where TKey : IEquatable<TKey>
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddIdentityEFOperationalServices<TKey>()
                .AddIdentityEFClientConfigurationServices<TKey>()
                .AddIdentityEFScopeConfigurationServices<TKey>();
        }

        public static IServiceCollection AddIdentityEFServices(this IServiceCollection services)
        {
            return services.AddIdentityEFServices<Guid>();
        }
    }
}