﻿using HostelStudents.BusinessLogic.Data;
using HostelStudents.BusinessLogic.Entities;
using HostelStudents.BusinessLogic.Grid;
using HostelStudents.BusinessLogic.Grid.Admin.ApplicationRoleGrid;
using HostelStudents.BusinessLogic.Grid.Admin.ApplicationUserGrid;

using HostelStudents.BusinessLogic.Grid.Admin.HostelGrid;
using HostelStudents.BusinessLogic.Grid.Admin.StudentGrid;
// GridNamespaceCodePlaceholder

using HostelStudents.Components;
using HostelStudents.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

if (builder.Environment.EnvironmentName == "Test")
{
    builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
        options.UseSqlite(connectionString));
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!),
});

builder.Services.AddScoped<IPageHelper, PageHelper>();
builder.Services.AddScoped<EditSuccess>();

builder.Services.AddScoped<IApplicationRoleFilters, ApplicationRoleGridControls>();
builder.Services.AddScoped<ApplicationRoleGridQueryAdapter>();

builder.Services.AddScoped<IApplicationUserFilters, ApplicationUserGridControls>();
builder.Services.AddScoped<ApplicationUserGridQueryAdapter>();

builder.Services.AddScoped<IHostelFilters, HostelGridControls>();
builder.Services.AddScoped<HostelGridQueryAdapter>();

builder.Services.AddScoped<IStudentFilters, StudentGridControls>();
builder.Services.AddScoped<StudentGridQueryAdapter>();

// RegisterServerServiceCodePlaceholder

var app = builder.Build();

if (app.Environment.EnvironmentName == "Test")
{
    app.UseWebAssemblyDebugging();
    await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
    var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();
    await DatabaseUtility.EnsureDbCreatedAndSeedAsync(options, scope.ServiceProvider);
}

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(HostelStudents.Client._Imports).Assembly);

app.MapAdditionalIdentityEndpoints();

app.Run();
