using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class Consent
    {
        public virtual string Subject { get; set; }
        
        public virtual string ClientId { get; set; }

        public virtual string Scopes { get; set; }
    }
}