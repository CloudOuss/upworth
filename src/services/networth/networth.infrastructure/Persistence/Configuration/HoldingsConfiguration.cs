using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworthDomain.Entities;
using NetworthDomain.Enums;

namespace NetworthInfrastructure.Persistence.Configuration
{
    public class HoldingsConfiguration : IEntityTypeConfiguration<Holding>
    {
        public void Configure(EntityTypeBuilder<Holding> builder)
        {
            builder
                .HasOne<Currency>()
                .WithMany()
                .HasForeignKey(p => p.CurrencyId);

            
            builder.Ignore(e => e.Currency);
            builder.Ignore(e => e.HoldingDetails);
            builder.Ignore(e => e.DomainEvents);
            builder.Ignore(e => e.CostBasis);
            builder.Ignore(e => e.MarketValue);
            builder.Ignore(e => e.GainLoss);
            builder.Ignore(e => e.GainLossPercent);
        }
    }
}
