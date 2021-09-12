using Ephata.YouCat.Service.Service;
using Ephata.YouCat.WebAPI.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ephata.YouCat.DomainLayer.Model.Pray.Command;
using Ephata.YouCat.DomainLayer.Handlers.CommandHandlers.PrayCommandHandler;
using Ephata.YouCat.DomainLayer.Handlers.CommandHandlers.PrayCommentHandler;
using Ephata.YouCat.DomainLayer.Handlers.CommandHandlers.PrayHandler;
using Ephata.YouCat.DomainLayer.Handlers.CommandHandlers.YouCatDailyHandler;
using Ephata.YouCat.DomainLayer.Handlers.QueryHandlers.PrayHandler;
using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
using Ephata.YouCat.DomainLayer.Model.Pray.Query;
using System.Collections.Generic;
using Ephata.YouCat.DomainLayer.Handlers.QueryHandlers.YouCatDailyHandler;
using Ephata.YouCat.DomainLayer.Model.PrayComment.Command;
using Ephata.YouCat.DomainLayer.Model.PrayComment.Query;
using Ephata.YouCat.DomainLayer.Model.PrayComment.ViewModel;
using Ephata.YouCat.DomainLayer.Model.YouCatDaily.Command;
using Ephata.YouCat.DomainLayer.Model.YouCatDaily.Query;
using Ephata.YouCat.DomainLayer.Model.YouCatDaily.ViewModel;

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
            //Pray
            services.AddScoped<IRequestHandler<CreatePrayCommand, bool>, CreatePrayHandler>();
            services.AddScoped<IRequestHandler<UpdatePrayCommand, bool>, UpdatePrayHandler>();
            services.AddScoped<IRequestHandler<RemovePrayCommand, bool>, DeletePrayHandler>();
            services.AddScoped<IRequestHandler<GetPrayByIdQuery, PrayViewModel>, GetPrayByIdQueryHandler >();
            services.AddScoped<IRequestHandler<GetMultiPrayQuery, IEnumerable<PrayViewModel>>, GetMultiPrayQueryHandler>();
            
            //Pray Comment
            services.AddScoped<IRequestHandler<CreatePrayCommentCommand, bool>, CreatePrayCommentHandler>();
            services.AddScoped<IRequestHandler<UpdatePrayCommentCommand, bool>, UpdatePrayCommentHandler>();
            services.AddScoped<IRequestHandler<RemovePrayCommentCommand, bool>, DeletePrayCommentHandler>();
            services.AddScoped<IRequestHandler<GetPrayCommentByIdQuery, PrayCommentViewModel>, GetPrayCommentByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetMultiPrayCommentQuery, IEnumerable<PrayCommentViewModel>>, GetMultiPrayCommentQueryHandler>();

            //YouCat Daily
            services.AddScoped<IRequestHandler<CreateYouCatDailyCommand, bool>, CreateYouCatDailyHandler>();
            services.AddScoped<IRequestHandler<UpdateYouCatDailyCommand, bool>, UpdateYouCatDailyHandler>();
            services.AddScoped<IRequestHandler<RemoveYouCatDailyCommand, bool>, DeleteYouCatDailyHandler>();
            services.AddScoped<IRequestHandler<GetYouCatDailyByIdQuery, YouCatDailyViewModel>, GetYouCatDailyByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetMultiYouCatDailyQuery, IEnumerable<YouCatDailyViewModel>>, GetMultiYouCatDailyQueryHandler>();

        }
    }
}
