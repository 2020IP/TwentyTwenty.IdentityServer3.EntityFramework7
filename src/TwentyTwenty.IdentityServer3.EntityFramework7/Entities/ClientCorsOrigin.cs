using System;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class ClientCorsOrigin
    {
        public virtual Guid Id { get; set; }

        public virtual string Origin { get; set; }

        public virtual Client Client { get; set; }
    }
}