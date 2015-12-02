using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using System;
using System.Threading.Tasks;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Stores
{
    public class TokenHandleStore<TKey> : BaseTokenStore<Token, TKey>, ITokenHandleStore
            where TKey : IEquatable<TKey>
    {
        public TokenHandleStore(OperationalContext<TKey> context, IScopeStore scopeStore, IClientStore clientStore)
            : base(context, Entities.TokenType.TokenHandle, scopeStore, clientStore)
        {
        }

        public override async Task StoreAsync(string key, Token value)
        {
            var efToken = new Entities.Token<TKey>
            {
                Key = key,
                SubjectId = value.SubjectId,
                ClientId = value.ClientId,
                JsonCode = ConvertToJson(value),
                Expiry = DateTimeOffset.UtcNow.AddSeconds(value.Lifetime),
                TokenType = this.tokenType
            };

            context.Tokens.Add(efToken);
            await context.SaveChangesAsync();
        }
    }
}