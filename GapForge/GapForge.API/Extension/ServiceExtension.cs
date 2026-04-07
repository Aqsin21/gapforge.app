using GapForge.Apllication;
using GapForge.Core.InterFaces;
using GapForge.Infrastructure.Data;
using GapForge.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
namespace GapForge.API.Extension
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<GapForgeDbContext>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection")));

            return services;
        }
        public static IServiceCollection AddSwaggerWithJwt(
    this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GapForge API",
                    Version = "v1"
                });

               
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter: Bearer {your token here}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
            });

            return services;
        }

        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<IAgencyRepository, AgencyRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICompetitorRepository, CompetitorRepository>();

            return services;
        }

        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddScoped<IAgencyService, AgencyService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICompetitorService, CompetitorService>();

            return services;
        }
    }
}
