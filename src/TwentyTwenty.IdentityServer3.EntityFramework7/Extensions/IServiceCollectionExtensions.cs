﻿using IdentityServer3.Core.Services;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.Services;
using TwentyTwenty.IdentityServer3.EntityFramework7.Stores;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityEFOperationalServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddTransient<ITokenHandleStore, TokenHandleStore>()
                .AddTransient<IAuthorizationCodeStore, AuthorizationCodeStore>()
                .AddTransient<IConsentStore, ConsentStore>()
                .AddTransient<IRefreshTokenStore, RefreshTokenStore>();
        }

        public static IServiceCollection AddIdentityEFClientConfigurationServices<TKey>(this IServiceCollection services)
            where TKey : IEquatable<TKey>
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddTransient<IClientStore, ClientStore<TKey>>()
                .AddTransient<ICorsPolicyService, ClientConfigurationCorsPolicyService<TKey>>();
        }

        public static IServiceCollection AddIdentityEFScopeConfigurationServices<TKey>(this IServiceCollection services)
            where TKey : IEquatable<TKey>
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddTransient<IScopeStore, ScopeStore<TKey>>();
        }

        public static IServiceCollection AddIdentityEFServices<TKey>(this IServiceCollection services)
            where TKey : IEquatable<TKey>
        {
            if (services == null) throw new ArgumentNullException("services");

            return services
                .AddIdentityEFOperationalServices()
                .AddIdentityEFClientConfigurationServices<TKey>()
                .AddIdentityEFScopeConfigurationServices<TKey>();
        }

        public static IServiceCollection AddIdentityEFServices(this IServiceCollection services)
        {
            return services.AddIdentityEFServices<Guid>();
        }
    }
}