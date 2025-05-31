using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StockTraderApi.Infrastructure.Identity.Models;

namespace StockTraderApi.Infrastructure.Identity.Seed
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = new[] { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var defaultUser = new ApplicationUser
            {
                UserName = "admin@stocktrader.com",
                Email = "admin@stocktrader.com",
                EmailConfirmed = true
            };

            if (await userManager.FindByEmailAsync(defaultUser.Email) == null)
            {
                var result = await userManager.CreateAsync(defaultUser, "Admin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                }
            }
        }
    }
}
