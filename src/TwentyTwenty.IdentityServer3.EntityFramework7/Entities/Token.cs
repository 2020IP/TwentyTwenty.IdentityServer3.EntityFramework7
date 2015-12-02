﻿using System;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class Token
    {
        public virtual string Key { get; set; }
        
        public virtual TokenType TokenType { get; set; }

        public virtual string SubjectId { get; set; }

        public virtual string ClientId { get; set; }
        
        public virtual string JsonCode { get; set; }

        public virtual DateTime Expiry { get; set; }
    }
}