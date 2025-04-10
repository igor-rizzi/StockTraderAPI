using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockTraderApi.Infrastructure.Identity.Models;

namespace StockTraderApi.Infrastructure.Identity
{
    public class StockTraderIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public StockTraderIdentityContext(DbContextOptions<StockTraderIdentityContext> options)
            : base(options) { }
    }
}
