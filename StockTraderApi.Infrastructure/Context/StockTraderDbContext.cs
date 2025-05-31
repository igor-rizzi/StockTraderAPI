using Microsoft.EntityFrameworkCore;
using StockTraderApi.Domain.Entities;
using System.Reflection;

namespace StockTraderApi.Infrastructure.Context
{
    public class StockTraderDbContext : DbContext
    {
        public StockTraderDbContext(DbContextOptions<StockTraderDbContext> options)
            : base(options)
        {

        }

        public DbSet<Trade> Trades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
