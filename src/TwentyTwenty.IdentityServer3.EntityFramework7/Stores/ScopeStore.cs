using IdentityServer3.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = IdentityServer3.Core.Models;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using Microsoft.Data.Entity;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Stores
{
    public class ScopeStore : IScopeStore
    {
        private readonly ScopeConfigurationDbContext _context;

        public ScopeStore(ScopeConfigurationDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        public async Task<IEnumerable<Models.Scope>> FindScopesAsync(IEnumerable<string> scopeNames)
        {
            var scopes = _context.Scopes
                .Include(e => e.ScopeClaims)
                .AsQueryable();

            if (scopeNames != null && scopeNames.Any())
            {
                scopes = scopes.Where(e => scopeNames.Contains(e.Name));
            }

            var list = await scopes.ToListAsync();
            return list.Select(e => e.ToModel());
        }

        public async Task<IEnumerable<Models.Scope>> GetScopesAsync(bool publicOnly = true)
        {
            var scopes = _context.Scopes
                .Include(e => e.ScopeClaims)
                .AsQueryable();

            if (publicOnly)
            {
                scopes = scopes.Where(e => e.ShowInDiscoveryDocument);
            }

            var list = await scopes.ToListAsync();
            return list.Select(x => x.ToModel());
        }
    }
}