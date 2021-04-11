using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworthDomain.Enums;

namespace NetworthInfrastructure.Persistence.Configuration
{
    public class CurrenciesConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currencies");
            builder.HasKey(e => e.Value);

            builder.Property(t => t.Value)
                .IsRequired();
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        }

        public static void SeedData(ModelBuilder builder)
        {
            builder.Entity<Currency>().HasData(Currency.Usd);
            builder.Entity<Currency>().HasData(Currency.Cad);
        }
    }
}
