using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;
using Xunit;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.IntegrationTests
{
    public class ClientConfigurationDbContextTests
    {
        private const string ConfigConnectionStringName = "Config";
        private DbContextOptions _options;

        public ClientConfigurationDbContextTests()
        {
            var builder = new DbContextOptionsBuilder<ClientConfigurationContext>();
            builder.UseInMemoryDatabase();
            _options = builder.Options;
        }

        [Fact]
        public void CanAddAndDeleteClientScopes()
        {
            using (var db = new ClientConfigurationContext(_options))
            {
                db.Clients.Add(new Client
                {
                    ClientId = "test-client-scopes",
                    ClientName = "Test Client"
                });

                db.SaveChanges();
            }

            using (var db = new ClientConfigurationContext(_options))
            {
                var client = db.Clients.First();

                client.AllowedScopes = new HashSet<ClientScope>();
                client.AllowedScopes.Add(new ClientScope
                {
                    Scope = "test"
                });

                db.SaveChanges();
            }

            using (var db = new ClientConfigurationContext(_options))
            {
                var client = db.Clients
                    .Include(e => e.AllowedScopes)
                    .First();
                var scope = client.AllowedScopes.First();

                client.AllowedScopes.Remove(scope);

                db.SaveChanges();
            }

            using (var db = new ClientConfigurationContext(_options))
            {
                var client = db.Clients
                    .Include(e => e.AllowedScopes)
                    .First();

                Assert.Equal(0, client.AllowedScopes.Count());
            }
        }

        [Fact]
        public void CanAddAndDeleteClientRedirectUri()
        {
            using (var db = new ClientConfigurationContext(_options))
            {
                db.Clients.Add(new Client
                {
                    ClientId = "test-client",
                    ClientName = "Test Client"
                });

                db.SaveChanges();
            }

            using (var db = new ClientConfigurationContext(_options))
            {
                var client = db.Clients                    
                    .First();

                client.RedirectUris = new HashSet<ClientRedirectUri>();
                client.RedirectUris.Add(new ClientRedirectUri
                {
                    Uri = "https://redirect-uri-1"
                });

                db.SaveChanges();
            }

            using (var db = new ClientConfigurationContext(_options))
            {
                var client = db.Clients
                    .Include(e => e.RedirectUris)
                    .First();
                var redirectUri = client.RedirectUris.First();

                client.RedirectUris.Remove(redirectUri);

                db.SaveChanges();
            }

            using (var db = new ClientConfigurationContext(_options))
            {
                var client = db.Clients
                    .Include(e => e.RedirectUris)
                    .First();

                Assert.Equal(0, client.RedirectUris.Count());
            }
        }
    }
}
