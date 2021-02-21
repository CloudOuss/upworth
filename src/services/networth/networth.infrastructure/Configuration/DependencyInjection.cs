using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetworthApplication.Common.Interfaces;
using NetworthInfrastructure.Dependencies.XpathProvider;
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

            services.AddAuthentication()
                .AddIdentityServerJwt();
            
            return services;
        }
    }
}