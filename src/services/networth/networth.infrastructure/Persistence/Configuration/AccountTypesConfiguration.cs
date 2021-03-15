using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworthDomain.Entities;
using NetworthDomain.Enums;

namespace NetworthInfrastructure.Persistence.Configuration
{
    public class AccountTypesConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.HasKey(e => e.Value);

            builder.Property(t => t.Value)
                .IsRequired();
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        }

        public static void SeedData(ModelBuilder builder)
        {
            builder.Entity<AccountType>().HasData(AccountType.Rrsp);
            builder.Entity<AccountType>().HasData(AccountType.Tfsa);
            builder.Entity<AccountType>().HasData(AccountType.Lira);
            builder.Entity<AccountType>().HasData(AccountType.Taxable);
        }
    }
}
