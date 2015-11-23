using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.Data.Entity.Infrastructure;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using TwentyTwenty.IdentityServer3.EntityFramework7.Services;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Registrations
{
    public class ClientConfigurationCorsPolicyRegistration : Registration<ICorsPolicyService, ClientConfigurationCorsPolicyService>
    {
        public ClientConfigurationCorsPolicyRegistration(DbContextOptions options)
        {
            if (options == null) throw new ArgumentNullException("options");

            AdditionalRegistrations.Add(new Registration<ClientConfigurationDbContext>(resolver => new ClientConfigurationDbContext(options)));
        }
    }
}