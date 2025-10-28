using BZ_WebMobileTemplate.Shared.Services;
using BZ_WebMobileTemplate.Web.Components;
using BZ_WebMobileTemplate.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;
using BZ_WebMobileTemplate.Repositories.IRepository;
using BZ_WebMobileTemplate.Shared.Data;
using BZ_WebMobileTemplate.Shared.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the BZ_WebMobileTemplate.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddRadzenComponents();

builder.Services.AddScoped<IFunctionRepository, FunctionRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
// Use a standard scoped DbContext. Removed AddPooledDbContextFactory to avoid mixing pooled singleton pool with scoped consumers.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(connectionString), ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(BZ_WebMobileTemplate.Shared._Imports).Assembly);

app.Run();
