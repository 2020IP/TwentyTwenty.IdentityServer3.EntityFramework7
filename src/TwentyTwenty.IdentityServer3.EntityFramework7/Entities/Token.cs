using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class Token
    {
        [Key, Column(Order = 0)]
        public virtual string Key { get; set; }

        [Key, Column(Order = 1)]
        public virtual TokenType TokenType { get; set; }

        public virtual string SubjectId { get; set; }

        public virtual string ClientId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public virtual string JsonCode { get; set; }

        public virtual DateTimeOffset Expiry { get; set; }
    }
}