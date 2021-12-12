using wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClientInterceptor();
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


builder.Services.AddLoadingBar();
builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("networthApi"));


builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Identity", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.DefaultScopes.Add("profile");
    options.ProviderOptions.DefaultScopes.Add("address");
    options.ProviderOptions.DefaultScopes.Add("networth");
});

builder.UseLoadingBar();
await builder.Build().RunAsync();
