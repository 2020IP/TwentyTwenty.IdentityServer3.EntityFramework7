using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using System;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;
using TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts
{
    public class ScopeConfigurationContext<TKey> : BaseContext, IScopeConfigurationContext<TKey>
        where TKey : IEquatable<TKey>
    {
        public ScopeConfigurationContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Scope<TKey>> Scopes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScopeClaim<TKey>>(b =>
            {
                b.ToTable(EfConstants.TableNames.ScopeClaim);
                b.Property(e => e.Name).IsRequired().HasMaxLength(200);
                b.Property(e => e.Description).HasMaxLength(1000);
            });
                
            modelBuilder.Entity<Scope<TKey>>(b =>
            {
                b.ToTable(EfConstants.TableNames.Scope);
                b.HasMany(e => e.ScopeClaims).WithOne(e => e.Scope).OnDelete(DeleteBehavior.Cascade);                
                b.Property(e => e.Name).IsRequired().HasMaxLength(200);
                b.Property(e => e.DisplayName).HasMaxLength(200);
                b.Property(e => e.Description).HasMaxLength(1000);
                b.Property(e => e.ClaimsRule).HasMaxLength(200);
            });
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