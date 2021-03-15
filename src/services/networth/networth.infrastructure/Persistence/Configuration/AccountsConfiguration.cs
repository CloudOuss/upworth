using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworthDomain.Entities;

namespace NetworthInfrastructure.Persistence.Configuration
{
    public class AccountsConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Ignore(e => e.Holdings);
            builder.Ignore(e => e.DomainEvents);
        }
    }
}
