using Microsoft.Extensions.DependencyInjection;
namespace NetworthApi.Configuration
{
    public static class ConfigureOpenApi
    {
        public static IServiceCollection AddOpenApiConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Upworth API";
                    document.Info.Description = "API serving networth related data";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Oussama Souayeh",
                        Email = "oussama@souayeh.me",
                        Url = "https://github.com/souayo"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            });

            return services;
        }
    }
}