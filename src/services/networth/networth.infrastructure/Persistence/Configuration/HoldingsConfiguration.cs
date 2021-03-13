using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworthDomain.Entities;

namespace NetworthInfrastructure.Persistence.Configuration
{
    public class HoldingsConfiguration : IEntityTypeConfiguration<Holding>
    {
        public void Configure(EntityTypeBuilder<Holding> builder)
        {
            builder.Ignore(e => e.HoldingDetails);
        }
    }
}
