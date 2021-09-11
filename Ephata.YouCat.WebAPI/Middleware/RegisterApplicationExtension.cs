using Ephata.YouCat.Service.Service;
using Ephata.YouCat.WebAPI.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ephata.YouCat.DomainLayer.Model.Pray.Command;
using Ephata.YouCat.DomainLayer.Handlers.CommandHandlers.PrayCommandHandler;

namespace Ephata.YouCat.WebAPI.Middleware
{
    public static class RegisterApplicationExtension
    {
        public static void SetApplicationSetting(this IServiceCollection services, IConfiguration configuration, out ApplicationSettings settings)
        {
            services.UseConfigurationValidation();
            services.ConfigureValidatableSetting<ApplicationSettings>(configuration);
            var serviceProvider = services.BuildServiceProvider();
            var environmentsettings = serviceProvider.GetService<ApplicationSettings>();
            settings = environmentsettings;
        }
        public static void RegisterServiceBusiness(this IServiceCollection services)
        {
            services.AddLogging(logBuilder => logBuilder.AddConsole());
            services.AddScoped<IPrayService, PrayService>();
            services.AddScoped<IYouCatDailyService, YouCatDailyService>();

        }
        public static void RegisterHandler(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreatePrayCommand, bool>, CreatePrayHandler>();
            services.AddScoped<IRequestHandler<UpdatePrayCommand, bool>, UpdatePrayHandler>();
            services.AddScoped<IRequestHandler<RemovePrayCommand, bool>, DeletePrayHandler>();
        }
    }
}
