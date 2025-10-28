using Microsoft.Extensions.Logging;
using Radzen;
using BZ_WebMobileTemplate.Services;
using BZ_WebMobileTemplate.Shared.Services;
using BZ_WebMobileTemplate.Shared.Data;
using BZ_WebMobileTemplate.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using BZ_WebMobileTemplate.Shared.Repositories;
using Microsoft.Extensions.DependencyInjection; // Add this line
using Microsoft.Extensions.Http; // Add this line

namespace BZ_WebMobileTemplate
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the BZ_WebMobileTemplate.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddRadzenComponents();

            // Add HTTP client for API calls
            builder.Services.AddHttpClient();

            // Use HTTP-based repository instead of direct database access
            builder.Services.AddScoped<IFunctionRepository, HttpFunctionRepository>();

            // Add Radzen services
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
