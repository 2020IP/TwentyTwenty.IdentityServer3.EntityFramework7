using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;
using TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts
{
    public class ScopeConfigurationDbContext : BaseDbContext, IScopeConfigurationDbContext
    {
        public ScopeConfigurationDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Scope> Scopes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScopeClaim>()
                .ToTable(EfConstants.TableNames.ScopeClaim)
                .Property(e => e.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<ScopeClaim>()
                .Property(e => e.Description).HasMaxLength(1000);

            modelBuilder.Entity<Scope>()
                .ToTable(EfConstants.TableNames.Scope)
                .HasMany(e => e.ScopeClaims).WithOne(e => e.Scope).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Scope>()
                .Property(e => e.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Scope>()
                .Property(e => e.DisplayName).HasMaxLength(200);
            modelBuilder.Entity<Scope>()
                .Property(e => e.Description).HasMaxLength(1000);
            modelBuilder.Entity<Scope>()
                .Property(e => e.ClaimsRule).HasMaxLength(200);

        }
        //protected override void ConfigureChildCollections()
        //{
        //    this.Set<Scope>().Local.CollectionChanged +=
        //        delegate (object sender, NotifyCollectionChangedEventArgs e)
        //        {
        //            if (e.Action == NotifyCollectionChangedAction.Add)
        //            {
        //                foreach (Scope item in e.NewItems)
        //                {
        //                    RegisterDeleteOnRemove(item.ScopeClaims);
        //                }
        //            }
        //        };
        //}
        
    }
}