using System;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class ClientProviderRestriction
    {
        public virtual Guid Id { get; set; }

        public virtual string Provider { get; set; }

        public virtual Client Client { get; set; }
    }
}