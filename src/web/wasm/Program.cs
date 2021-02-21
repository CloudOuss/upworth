using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("networthApi", cl =>
            {
                cl.BaseAddress = new Uri("https://localhost:5002/api/");
            })
            .AddHttpMessageHandler(sp =>
            {
                var handler = sp.GetService<AuthorizationMessageHandler>()
                .ConfigureHandler(
                    authorizedUrls: new[] { "https://localhost:5002" },
                    scopes: new[] { "networth" }
                );
                return handler;
            });
        
            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("networthApi"));


            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Identity", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.DefaultScopes.Add("profile");
                options.ProviderOptions.DefaultScopes.Add("address");
                options.ProviderOptions.DefaultScopes.Add("networth");
            });

            await builder.Build().RunAsync();
        }
    }
}
