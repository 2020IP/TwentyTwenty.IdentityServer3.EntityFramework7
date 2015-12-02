﻿using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using System;
using System.Threading.Tasks;
using TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Stores
{
    public class TokenHandleStore : BaseTokenStore<Token>, ITokenHandleStore
    {
        public TokenHandleStore(OperationalContext context, IScopeStore scopeStore, IClientStore clientStore)
            : base(context, Entities.TokenType.TokenHandle, scopeStore, clientStore)
        {
        }

        public override async Task StoreAsync(string key, Token value)
        {
            var efToken = new Entities.Token
            {
                Key = key,
                SubjectId = value.SubjectId,
                ClientId = value.ClientId,
                JsonCode = ConvertToJson(value),
                Expiry = DateTime.UtcNow.AddSeconds(value.Lifetime),
                TokenType = this._tokenType
            };

            _context.Tokens.Add(efToken);
            await _context.SaveChangesAsync();
        }
    }
}