using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTraderApi.Domain.Entities;

namespace StockTraderApi.Infrastructure.Context.Configuration
{
    public class TradeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.CodigoTrade)
                .HasColumnName("CodigoTrade")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.UserId);

            builder.Property(t => t.StockSymbol)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(t => t.OperationType)
                .IsRequired();

            builder.Property(t => t.Quantity);

            builder.Property(t => t.PricePerUnit)
                .HasPrecision(18, 7);

            builder.Property(t => t.TotalAmount)
                .HasPrecision(18, 7);

            builder.Property(t => t.TradeDate);

            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasIndex(t => t.CodigoTrade)
               .HasDatabaseName("IX_Trade_CodigoTrade");

            builder.HasIndex(t => t.UserId)
              .HasDatabaseName("IX_Trade_UserId");
        }
    }
}
