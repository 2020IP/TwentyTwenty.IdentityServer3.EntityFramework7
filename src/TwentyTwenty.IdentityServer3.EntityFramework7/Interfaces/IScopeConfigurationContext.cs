using Microsoft.Data.Entity;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces
{
    public interface IScopeConfigurationContext : IDisposable
    {
        DbSet<Scope> Scopes { get; set; }
    }
}