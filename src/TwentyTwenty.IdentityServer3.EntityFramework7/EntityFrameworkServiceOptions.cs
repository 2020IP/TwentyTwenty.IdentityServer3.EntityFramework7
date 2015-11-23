using Microsoft.Data.Entity.Infrastructure;

namespace TwentyTwenty.IdentityServer3.EntityFramework7
{
    public class EntityFrameworkServiceOptions
    {
        public DbContextOptions Options { get; set; }

        public string Schema { get; set; }
    }
}