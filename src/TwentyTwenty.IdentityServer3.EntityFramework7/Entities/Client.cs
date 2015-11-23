using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class Client
    {
        //public Client()
        //{
        //    ClientSecrets = new HashSet<ClientSecret>();
        //    RedirectUris = new HashSet<ClientRedirectUri>();
        //    PostLogoutRedirectUris = new HashSet<ClientPostLogoutRedirectUri>();
        //    AllowedScopes = new HashSet<ClientScope>();
        //    IdentityProviderRestrictions = new HashSet<ClientProviderRestriction>();
        //    Claims = new HashSet<ClientClaim>();
        //    AllowedCustomGrantTypes = new HashSet<ClientCustomGrantType>();
        //    AllowedCorsOrigins = new HashSet<ClientCorsOrigin>();
        //}

        public virtual Guid Id { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual string ClientId { get; set; }

        public virtual ICollection<ClientSecret> ClientSecrets { get; set; }

        public virtual string ClientName { get; set; }

        public virtual string ClientUri { get; set; }

        public virtual string LogoUri { get; set; }

        public virtual bool RequireConsent { get; set; }

        public virtual bool AllowRememberConsent { get; set; }

        public virtual Flows Flow { get; set; }

        public virtual bool AllowClientCredentialsOnly { get; set; }

        public virtual ICollection<ClientRedirectUri> RedirectUris { get; set; }

        public virtual ICollection<ClientPostLogoutRedirectUri> PostLogoutRedirectUris { get; set; }

        public virtual bool AllowAccessToAllScopes { get; set; }

        public virtual ICollection<ClientScope> AllowedScopes { get; set; }

        // Seconds
        [Range(0, Int32.MaxValue)]
        public virtual int IdentityTokenLifetime { get; set; }

        [Range(0, Int32.MaxValue)]
        public virtual int AccessTokenLifetime { get; set; }

        [Range(0, Int32.MaxValue)]
        public virtual int AuthorizationCodeLifetime { get; set; }

        [Range(0, Int32.MaxValue)]
        public virtual int AbsoluteRefreshTokenLifetime { get; set; }

        [Range(0, Int32.MaxValue)]
        public virtual int SlidingRefreshTokenLifetime { get; set; }

        public virtual TokenUsage RefreshTokenUsage { get; set; }

        public virtual bool UpdateAccessTokenOnRefresh { get; set; }

        public virtual TokenExpiration RefreshTokenExpiration { get; set; }

        public virtual AccessTokenType AccessTokenType { get; set; }

        public virtual bool EnableLocalLogin { get; set; }

        public virtual ICollection<ClientProviderRestriction> IdentityProviderRestrictions { get; set; }

        public virtual bool IncludeJwtId { get; set; }

        public virtual ICollection<ClientClaim> Claims { get; set; }

        public virtual bool AlwaysSendClientClaims { get; set; }

        public virtual bool PrefixClientClaims { get; set; }

        public virtual bool AllowAccessToAllGrantTypes { get; set; }

        public virtual ICollection<ClientCustomGrantType> AllowedCustomGrantTypes { get; set; }

        public virtual ICollection<ClientCorsOrigin> AllowedCorsOrigins { get; set; }
    }
}