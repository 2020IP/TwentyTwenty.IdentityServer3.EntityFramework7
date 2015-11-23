using System;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class ClientScope
    {
        public virtual Guid Id { get; set; }

        public virtual string Scope { get; set; }

        public virtual Client Client { get; set; }
    }
}