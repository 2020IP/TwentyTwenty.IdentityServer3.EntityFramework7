//using Microsoft.Data.Entity;
//using Microsoft.Data.Entity.Infrastructure;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;

//namespace TwentyTwenty.IdentityServer3.EntityFramework7.Extensions
//{
//    public static class EntityFrameworkServicesBuilderExtensions
//    {
//        public static EntityFrameworkServicesBuilder AddClientConfigurationContext<TContext, TKey>(this EntityFrameworkServicesBuilder builder, Action<DbContextOptionsBuilder> options = null)
//            where TContext : ClientConfigurationContext<TKey>
//            where TKey : IEquatable<TKey>
//        {            
//            builder.AddDbContext<TContext>(options);

//            builder.GetInfrastructure()
//                .AddScoped<ClientConfigurationContext<TKey>>(p => p.GetService<TContext>());

//            return builder;
//        }

//        public static EntityFrameworkServicesBuilder AddScopeConfigurationContext<TContext, TKey>(this EntityFrameworkServicesBuilder builder, Action<DbContextOptionsBuilder> options = null)
//            where TContext : ScopeConfigurationContext<TKey>
//            where TKey : IEquatable<TKey>
//        {
//            builder.AddDbContext<TContext>(options);

//            builder.GetInfrastructure()
//                .AddScoped<ScopeConfigurationContext<TKey>>(p => p.GetService<TContext>());

//            return builder;
//        }
//    }
//}
