﻿using System;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Entities
{
    public class ClientSecret<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual Guid Id { get; set; }

        public virtual string Value { get; set; }

        public string Type { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTimeOffset? Expiration { get; set; }

        public virtual Client<TKey> Client { get; set; }
    }
}