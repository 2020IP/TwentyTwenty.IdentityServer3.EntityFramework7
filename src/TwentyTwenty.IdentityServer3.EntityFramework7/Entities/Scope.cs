using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class Scope
    {
        public virtual Guid Id { get; set; }
        public virtual bool Enabled { get; set; }
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Required { get; set; }
        public virtual bool Emphasize { get; set; }
        public virtual int Type { get; set; }
        public virtual ICollection<ScopeClaim> ScopeClaims { get; set; }
        public virtual bool IncludeAllClaimsForUser { get; set; }
        public virtual string ClaimsRule { get; set; }
        public virtual bool ShowInDiscoveryDocument { get; set; }

    }
}