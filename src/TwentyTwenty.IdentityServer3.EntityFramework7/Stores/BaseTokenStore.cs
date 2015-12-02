using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using Microsoft.Data.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;
using TwentyTwenty.IdentityServer3.EntityFramework7.Serialization;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Stores
{
    // TODO: FindAsync is slated to be back in the RTM of 7.0. 
    //      For how, Where and FirstOrDefaultAsync will have to make due
    public abstract class BaseTokenStore<TEntity, TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        protected readonly OperationalContext<TKey> context;
        protected readonly TokenType tokenType;
        protected readonly IScopeStore scopeStore;
        private readonly IClientStore clientStore;

        protected IClientStore ClientStore
        {
            get
            {
                return clientStore;
            }
        }

        protected BaseTokenStore(OperationalContext<TKey> context, TokenType tokenType, IScopeStore scopeStore, IClientStore clientStore)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (scopeStore == null) throw new ArgumentNullException("scopeStore");
            if (clientStore == null) throw new ArgumentNullException("clientStore");

            this.context = context;
            this.tokenType = tokenType;
            this.scopeStore = scopeStore;
            this.clientStore = clientStore;
        }

        JsonSerializerSettings GetJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new ClaimConverter());
            settings.Converters.Add(new ClaimsPrincipalConverter());
            settings.Converters.Add(new ClientConverter(ClientStore));
            settings.Converters.Add(new ScopeConverter(scopeStore));
            return settings;
        }

        protected string ConvertToJson(TEntity value)
        {
            return JsonConvert.SerializeObject(value, GetJsonSerializerSettings());
        }

        protected TEntity ConvertFromJson(string json)
        {
            return JsonConvert.DeserializeObject<TEntity>(json, GetJsonSerializerSettings());
        }

        public async Task<TEntity> GetAsync(string key)
        {
            var token = await context.Tokens
                .Where(x => x.Key == key && x.TokenType == tokenType)
                .FirstOrDefaultAsync();

            if (token == null || token.Expiry < DateTimeOffset.UtcNow)
            {
                return null;
            }

            return ConvertFromJson(token.JsonCode);
        }

        public async Task RemoveAsync(string key)
        {
            var token = await context.Tokens
                .Where(x => x.Key == key && x.TokenType == tokenType)
                .FirstOrDefaultAsync();

            if (token != null)
            {
                context.Tokens.Remove(token);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ITokenMetadata>> GetAllAsync(string subject)
        {
            var tokens = await context.Tokens.Where(x =>
                x.SubjectId == subject &&
                x.TokenType == tokenType).ToArrayAsync();

            var results = tokens.Select(x => ConvertFromJson(x.JsonCode)).ToArray();
            return results.Cast<ITokenMetadata>();
        }

        public async Task RevokeAsync(string subject, string client)
        {
            var found = context.Tokens.Where(x =>
                x.SubjectId == subject &&
                x.ClientId == client &&
                x.TokenType == tokenType).ToArray();

            context.Tokens.RemoveRange(found);
            await context.SaveChangesAsync();
        }

        public abstract Task StoreAsync(string key, TEntity value);
    }
}