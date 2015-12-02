using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using Microsoft.Data.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Stores
{
    // TODO: FindAsync is slated to be back in the RTM of 7.0. 
    //      For how, Where and FirstOrDefaultAsync will have to make due
    public class RefreshTokenStore<TKey> : BaseTokenStore<RefreshToken, TKey>, IRefreshTokenStore
            where TKey : IEquatable<TKey>
    {
        public RefreshTokenStore(OperationalContext<TKey> context, IScopeStore scopeStore, IClientStore clientStore)
            : base(context, TokenType.RefreshToken, scopeStore, clientStore)
        {
        }

        public override async Task StoreAsync(string key, RefreshToken value)
        {
            var token = await context.Tokens
                .Where(x => x.Key == key && x.TokenType == tokenType)
                .FirstOrDefaultAsync();

            if (token == null)
            {
                token = new Entities.Token<TKey>
                {
                    Key = key,
                    SubjectId = value.SubjectId,
                    ClientId = value.ClientId,
                    JsonCode = ConvertToJson(value),
                    TokenType = tokenType
                };
                context.Tokens.Add(token);
            }

            token.Expiry = DateTimeOffset.UtcNow.AddSeconds(value.LifeTime);
            await context.SaveChangesAsync();
        }
    }
}