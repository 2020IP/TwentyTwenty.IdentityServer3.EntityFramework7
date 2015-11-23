using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts
{
    public class ScopeConfigurationDbContext : BaseDbContext
    {
        public DbSet<Scope> Scopes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scope>()
                .ToTable(EfConstants.TableNames.Scope);
            
                
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

        

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Scope>()
        //        .ToTable(EfConstants.TableNames.Scope, Schema)
        //        .HasMany(x => x.ScopeClaims).WithRequired(x => x.Scope).WillCascadeOnDelete();

        //    modelBuilder.Entity<ScopeClaim>().ToTable(EfConstants.TableNames.ScopeClaim, Schema);
        //}
    }
}
