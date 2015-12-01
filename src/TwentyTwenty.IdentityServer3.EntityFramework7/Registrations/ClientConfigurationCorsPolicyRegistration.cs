using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using TwentyTwenty.IdentityServer3.EntityFramework7.Services;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Registrations
{
    public class ClientConfigurationCorsPolicyRegistration : 
        Registration<ICorsPolicyService, ClientConfigurationCorsPolicyService>
    {
        public ClientConfigurationCorsPolicyRegistration(IServiceProvider provider)
        {
            if (provider == null) throw new ArgumentNullException("provider");

            AdditionalRegistrations.Add(new Registration<ClientConfigurationContext>(resolver => provider.GetService<ClientConfigurationContext>()));
        }
    }
}