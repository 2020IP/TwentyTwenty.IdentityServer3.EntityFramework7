using Microsoft.Data.Entity;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces
{
    public interface IClientConfigurationDbContext
    {
        DbSet<Client> Clients { get; set; }
    }
}