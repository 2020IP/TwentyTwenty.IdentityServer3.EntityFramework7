using System;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class ClientClaim
    {
        public virtual Guid Id { get; set; }

        public virtual string Type { get; set; }

        public virtual string Value { get; set; }

        public virtual Client Client { get; set; }
    }
}