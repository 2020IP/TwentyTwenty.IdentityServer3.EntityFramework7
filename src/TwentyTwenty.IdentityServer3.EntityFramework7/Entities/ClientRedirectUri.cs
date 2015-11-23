using System;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class ClientRedirectUri
    {
        public virtual Guid Id { get; set; }

        public virtual string Uri { get; set; }

        public virtual Client Client { get; set; }
    }
}