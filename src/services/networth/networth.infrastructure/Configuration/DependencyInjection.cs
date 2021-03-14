using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetworthApplication.Common.Interfaces;
using NetworthInfrastructure.Dependencies.XpathProvider;
using NetworthInfrastructure.Persistence;
using NetworthInfrastructure.Services;

namespace NetworthInfrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDomainEventService, DomainEventService>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<ISecuritiesService, SecuritiesService>();
            services.AddTransient<IXpathProvider, XpathProvider>();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration
                    .GetConnectionString("UpworthConnection")));
            
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<IDomainEventService, DomainEventService>();
            
            return services;
        }
    }
}