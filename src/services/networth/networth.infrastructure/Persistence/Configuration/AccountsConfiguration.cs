using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworthDomain.Entities;
using NetworthDomain.Enums;

namespace NetworthInfrastructure.Persistence.Configuration
{
    public class AccountsConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasOne<AccountType>()
                .WithMany()
                .HasForeignKey(p => p.AccountTypeId);
            builder
                .HasOne<Institution>()
                .WithMany()
                .HasForeignKey(p => p.InstitutionId);

            builder.Ignore(e => e.AccountType);
            builder.Ignore(e => e.Institution);
            builder.Ignore(e => e.Holdings);
            builder.Ignore(e => e.DomainEvents);
        }
    }
}
