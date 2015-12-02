using Microsoft.Data.Entity;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces
{
    public interface IScopeConfigurationContext<TKey> : IDisposable
        where TKey : IEquatable<TKey>
    {
        DbSet<Scope<TKey>> Scopes { get; set; }
    }
}