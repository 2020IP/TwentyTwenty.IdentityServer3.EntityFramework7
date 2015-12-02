using System;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class Consent<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual string Subject { get; set; }
        
        public virtual string ClientId { get; set; }

        public virtual string Scopes { get; set; }
    }
}