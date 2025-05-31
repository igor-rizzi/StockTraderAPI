using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace StockTraderApi.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "StockTrader API",
                    Version = "v1",
                    Description = "API para gerenciamento de operações de trade de ações.",
                    TermsOfService = new Uri("https://exemplo.com/termos"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Igor Henrique Rizzi",
                        Email = "igor.rizzi2@gmail.com",
                        Url = new Uri("https://github.com/igor-rizzi"),
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                // Se quiser incluir comentários XML para documentação automática:
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                var jwtSecurityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Description = "Digite apenas o token JWT no campo abaixo",

                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });

            return services;
        }
    }
}
