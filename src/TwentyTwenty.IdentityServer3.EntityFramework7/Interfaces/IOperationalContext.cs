using Microsoft.Data.Entity;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces
{
    public interface IOperationalContext<TKey> : IDisposable
        where TKey : IEquatable<TKey>
    {
        DbSet<Consent<TKey>> Consents { get; set; }

        DbSet<Token<TKey>> Tokens { get; set; }
    }
}