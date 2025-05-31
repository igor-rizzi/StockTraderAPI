using Microsoft.EntityFrameworkCore;
using StockTraderApi.API.Configuration;
using StockTraderApi.Infrastructure.Context;
using StockTraderApi.Infrastructure.Identity.Seed;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.ConfigureDependencyInjection();

builder.Services.AddDbContext<StockTraderDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("StockTraderDbContext")));

builder.Services.AddAuthenticationConfig(builder.Configuration);

builder.Services.AddSwaggerConfiguration(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StockTraderDbContext>();
    db.Database.Migrate();

    var services = scope.ServiceProvider;
    await IdentitySeeder.SeedAsync(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StockTrader API v1");
        c.DocumentTitle = "Documentação StockTrader API";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();