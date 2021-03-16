using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworthDomain.Enums;

namespace NetworthInfrastructure.Persistence.Configuration
{
    public class InstitutionsConfiguration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.ToTable("Institutions");
            builder.HasKey(e => e.Value);

            builder.Property(t => t.Value)
                .IsRequired();
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        }

        public static void SeedData(ModelBuilder builder)
        {
            builder.Entity<Institution>().HasData(Institution.Questrade);
            builder.Entity<Institution>().HasData(Institution.Wealthsimple);
        }
    }
}