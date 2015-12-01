using Microsoft.Data.Entity;
using System;
using System.Threading.Tasks;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces
{
    public interface IOperationalContext : IDisposable
    {
        DbSet<Consent> Consents { get; set; }

        DbSet<Token> Tokens { get; set; }
    }
}