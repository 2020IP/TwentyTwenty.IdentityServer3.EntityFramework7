using IdentityServer3.Core.Services;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using Models = IdentityServer3.Core.Models;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Stores
{
    // TODO: FindAsync is slated to be back in the RTM of 7.0. 
    //      For how, Where and FirstOrDefaultAsync will have to make due
    public class ConsentStore : IConsentStore
    {
        private readonly OperationalDbContext context;

        public ConsentStore(OperationalDbContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            this.context = context;
        }

        public async Task<Models.Consent> LoadAsync(string subject, string client)
        {
            var found = await context.Consents
                .Where(x => x.Subject == subject && x.ClientId == client)
                .FirstOrDefaultAsync();

            if (found == null)
            {
                return null;
            }

            var result = new Models.Consent
            {
                Subject = found.Subject,
                ClientId = found.ClientId,
                Scopes = ParseScopes(found.Scopes)
            };

            return result;
        }

        public async Task UpdateAsync(Models.Consent consent)
        {
            var item = await context.Consents
                .Where(x => x.Subject == consent.Subject && x.ClientId == consent.ClientId)
                .FirstOrDefaultAsync();

            if (item == null)
            {
                item = new Entities.Consent
                {
                    Subject = consent.Subject,
                    ClientId = consent.ClientId
                };
                context.Consents.Add(item);
            }

            if (consent.Scopes == null || !consent.Scopes.Any())
            {
                context.Consents.Remove(item);
            }

            item.Scopes = StringifyScopes(consent.Scopes);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Consent>> LoadAllAsync(string subject)
        {
            var found = await context.Consents
                .Where(x => x.Subject == subject).ToArrayAsync();

            var results = found.Select(x => new Models.Consent
            {
                Subject = x.Subject,
                ClientId = x.ClientId,
                Scopes = ParseScopes(x.Scopes)
            });

            return results.ToArray().AsEnumerable();
        }

        private IEnumerable<string> ParseScopes(string scopes)
        {
            if (scopes == null || String.IsNullOrWhiteSpace(scopes))
            {
                return Enumerable.Empty<string>();
            }

            return scopes.Split(',');
        }

        private string StringifyScopes(IEnumerable<string> scopes)
        {
            if (scopes == null || !scopes.Any())
            {
                return null;
            }

            return scopes.Aggregate((s1, s2) => s1 + "," + s2);
        }

        public async Task RevokeAsync(string subject, string client)
        {
            var found = await context.Consents
                .Where(x => x.Subject == subject && x.ClientId == client)
                .FirstOrDefaultAsync();

            if (found != null)
            {
                context.Consents.Remove(found);
                await context.SaveChangesAsync();
            }
        }
    }
}