using ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin;
using ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin.Client;
using ApplicationNamePlaceholder.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});
builder.Services.AddScoped<IApplicationRoleAdminRepository, ApplicationRoleClientAdminRepository>();
builder.Services.AddScoped<IApplicationUserAdminRepository, ApplicationUserClientAdminRepository>();

// RegisterClientServiceCodePlaceholder

await builder.Build().RunAsync();
