using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts
{
    public class ClientConfigurationDbContext : BaseDbContext
    {
        public ClientConfigurationDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .ToTable(EfConstants.TableNames.Client, Schema)
                .HasIndex(e => e.ClientId).IsUnique();
            modelBuilder.Entity<Client>()
                .Property(e => e.ClientId).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Client>()
                .Property(e => e.ClientName).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Client>()
                .Property(e => e.ClientUri).HasMaxLength(2000);

            modelBuilder.Entity<ClientClaim>()
                .ToTable(EfConstants.TableNames.ClientClaim, Schema)
                .Property(e => e.Type).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<ClientClaim>()
                .Property(e => e.Value).IsRequired().HasMaxLength(250);

            modelBuilder.Entity<ClientCorsOrigin>()
                .ToTable(EfConstants.TableNames.ClientCorsOrigin, Schema)
                .Property(e => e.Origin).IsRequired().HasMaxLength(150);

            modelBuilder.Entity<ClientCustomGrantType>()
                .ToTable(EfConstants.TableNames.ClientCustomGrantType, Schema)
                .Property(e => e.GrantType).IsRequired().HasMaxLength(250);

            modelBuilder.Entity<ClientPostLogoutRedirectUri>()
                .ToTable(EfConstants.TableNames.ClientPostLogoutRedirectUri, Schema)
                .Property(e => e.Uri).IsRequired().HasMaxLength(2000);

            modelBuilder.Entity<ClientProviderRestriction>()
                .ToTable(EfConstants.TableNames.ClientProviderRestriction, Schema)
                .Property(e => e.Provider).IsRequired().HasMaxLength(200);

            modelBuilder.Entity<ClientRedirectUri>()
                .ToTable(EfConstants.TableNames.ClientRedirectUri, Schema)
                .Property(e => e.Uri).IsRequired().HasMaxLength(2000);

            modelBuilder.Entity<ClientScope>()
                .ToTable(EfConstants.TableNames.ClientScopes, Schema)
                .Property(e => e.Scope).IsRequired().HasMaxLength(200);

            modelBuilder.Entity<ClientSecret>()
                .ToTable(EfConstants.TableNames.ClientSecret, Schema)
                .Property(e => e.Value).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<ClientSecret>()
                .Property(e => e.Type).HasMaxLength(250);
            modelBuilder.Entity<ClientSecret>()
                .Property(e => e.Description).HasMaxLength(2000);
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
