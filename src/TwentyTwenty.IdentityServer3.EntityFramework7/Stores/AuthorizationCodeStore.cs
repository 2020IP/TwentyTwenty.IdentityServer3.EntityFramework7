using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using System;
using System.Threading.Tasks;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Stores
{
    public class AuthorizationCodeStore<TKey> : BaseTokenStore<AuthorizationCode, TKey>, IAuthorizationCodeStore
            where TKey : IEquatable<TKey>
    {
        public AuthorizationCodeStore(OperationalContext<TKey> context, IScopeStore scopeStore, IClientStore clientStore)
            : base(context, TokenType.AuthorizationCode, scopeStore, clientStore)
        {
        }

        public override async Task StoreAsync(string key, AuthorizationCode code)
        {
            var efCode = new Entities.Token<TKey>
            {
                Key = key,
                SubjectId = code.SubjectId,
                ClientId = code.ClientId,
                JsonCode = ConvertToJson(code),
                Expiry = DateTimeOffset.UtcNow.AddSeconds(code.Client.AuthorizationCodeLifetime),
                TokenType = this.tokenType
            };

            context.Tokens.Add(efCode);
            await context.SaveChangesAsync();
        }
    }
}