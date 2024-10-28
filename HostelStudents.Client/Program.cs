using HostelStudents.BusinessLogic.Repositories.Admin;
using HostelStudents.BusinessLogic.Repositories.Admin.Client;
using HostelStudents.Client;
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

builder.Services.AddScoped<IHostelAdminRepository, HostelClientAdminRepository>();
builder.Services.AddScoped<IStudentAdminRepository, StudentClientAdminRepository>();
// RegisterClientServiceCodePlaceholder

await builder.Build().RunAsync();
