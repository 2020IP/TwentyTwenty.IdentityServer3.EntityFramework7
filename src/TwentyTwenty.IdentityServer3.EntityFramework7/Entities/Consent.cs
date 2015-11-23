using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class Consent
    {
        [Key, Column(Order = 0)]
        public virtual string Subject { get; set; }

        [Key, Column(Order = 1)]
        public virtual string ClientId { get; set; }

        public virtual string Scopes { get; set; }
    }
}