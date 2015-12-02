using Microsoft.Data.Entity;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces
{
    public interface IClientConfigurationContext<TKey> : IDisposable
        where TKey : IEquatable<TKey>
    {
        DbSet<Client<TKey>> Clients { get; set; }
    }
}