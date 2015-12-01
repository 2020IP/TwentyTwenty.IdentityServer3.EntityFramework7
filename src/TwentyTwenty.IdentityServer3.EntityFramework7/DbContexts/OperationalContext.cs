using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using TwentyTwenty.IdentityServer3.EntityFramework7.Entities;
using TwentyTwenty.IdentityServer3.EntityFramework7.Interfaces;

namespace TwentyTwenty.IdentityServer3.EntityFramework7.DbContexts
{
    public class OperationalContext : BaseContext, IOperationalDbContext
    {
        public OperationalContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Consent> Consents { get; set; }

        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Consent>()
                .ToTable(EfConstants.TableNames.Consent)                
                .Property(e => e.Subject).HasMaxLength(200);
            modelBuilder.Entity<Consent>()
                .ToTable(EfConstants.TableNames.Consent)
                .Property(e => e.ClientId).HasMaxLength(200);
            modelBuilder.Entity<Consent>()
                .ToTable(EfConstants.TableNames.Consent)
                .Property(e => e.Scopes).IsRequired().HasMaxLength(2000);
            modelBuilder.Entity<Consent>()
                .HasKey(e => new { e.Subject, e.ClientId });

            modelBuilder.Entity<Token>()
                .ToTable(EfConstants.TableNames.Token)
                .Property(e => e.SubjectId).HasMaxLength(200);
            modelBuilder.Entity<Token>()
                .Property(e => e.ClientId).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Token>()
                .Property(e => e.JsonCode).IsRequired().HasColumnType("varchar(max)");
            modelBuilder.Entity<Token>()
                .Property(e => e.Expiry).IsRequired();
            modelBuilder.Entity<Token>()
                .HasKey(e => new { e.Key, e.TokenType });
        }
    }
}