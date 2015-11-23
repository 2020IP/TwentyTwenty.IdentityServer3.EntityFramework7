using IdentityServer3.Core.Models;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts
{
    public class ClientConfigurationDbContext : BaseDbContext
    {
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scope>()
                .ToTable(EfConstants.TableNames.Client);
        }

        //protected override void ConfigureChildCollections()
        //{
        //    this.Set<Client>().Local.CollectionChanged +=
        //        delegate (object sender, NotifyCollectionChangedEventArgs e)
        //        {
        //            if (e.Action == NotifyCollectionChangedAction.Add)
        //            {
        //                foreach (Client item in e.NewItems)
        //                {
        //                    RegisterDeleteOnRemove(item.ClientSecrets);
        //                    RegisterDeleteOnRemove(item.RedirectUris);
        //                    RegisterDeleteOnRemove(item.PostLogoutRedirectUris);
        //                    RegisterDeleteOnRemove(item.AllowedScopes);
        //                    RegisterDeleteOnRemove(item.IdentityProviderRestrictions);
        //                    RegisterDeleteOnRemove(item.Claims);
        //                    RegisterDeleteOnRemove(item.AllowedCustomGrantTypes);
        //                    RegisterDeleteOnRemove(item.AllowedCorsOrigins);
        //                }
        //            }
        //        };
        //}



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Client>()
        //        .ToTable(EfConstants.TableNames.Client, Schema);
        //    modelBuilder.Entity<Client>()
        //        .HasMany(x => x.ClientSecrets).WithRequired(x => x.Client).WillCascadeOnDelete();
        //    modelBuilder.Entity<Client>()
        //        .HasMany(x => x.RedirectUris).WithRequired(x => x.Client).WillCascadeOnDelete();
        //    modelBuilder.Entity<Client>()
        //        .HasMany(x => x.PostLogoutRedirectUris).WithRequired(x => x.Client).WillCascadeOnDelete();
        //    modelBuilder.Entity<Client>()
        //        .HasMany(x => x.AllowedScopes).WithRequired(x => x.Client).WillCascadeOnDelete();
        //    modelBuilder.Entity<Client>()
        //        .HasMany(x => x.IdentityProviderRestrictions).WithRequired(x => x.Client).WillCascadeOnDelete();
        //    modelBuilder.Entity<Client>()
        //        .HasMany(x => x.Claims).WithRequired(x => x.Client).WillCascadeOnDelete();
        //    modelBuilder.Entity<Client>()
        //        .HasMany(x => x.AllowedCustomGrantTypes).WithRequired(x => x.Client).WillCascadeOnDelete();
        //    modelBuilder.Entity<Client>()
        //        .HasMany(x => x.AllowedCorsOrigins).WithRequired(x => x.Client).WillCascadeOnDelete();

        //    modelBuilder.Entity<ClientSecret>().ToTable(EfConstants.TableNames.ClientSecret, Schema);
        //    modelBuilder.Entity<ClientRedirectUri>().ToTable(EfConstants.TableNames.ClientRedirectUri, Schema);
        //    modelBuilder.Entity<ClientPostLogoutRedirectUri>().ToTable(EfConstants.TableNames.ClientPostLogoutRedirectUri, Schema);
        //    modelBuilder.Entity<ClientScope>().ToTable(EfConstants.TableNames.ClientScopes, Schema);
        //    modelBuilder.Entity<ClientIdPRestriction>().ToTable(EfConstants.TableNames.ClientIdPRestriction, Schema);
        //    modelBuilder.Entity<ClientClaim>().ToTable(EfConstants.TableNames.ClientClaim, Schema);
        //    modelBuilder.Entity<ClientCustomGrantType>().ToTable(EfConstants.TableNames.ClientCustomGrantType, Schema);
        //    modelBuilder.Entity<ClientCorsOrigin>().ToTable(EfConstants.TableNames.ClientCorsOrigin, Schema);
        //}
    }
}
