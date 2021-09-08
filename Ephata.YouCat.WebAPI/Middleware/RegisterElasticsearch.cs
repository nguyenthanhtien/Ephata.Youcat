using Elasticsearch.Net;
using Ephata.Application.Product.Data.Initiation;
using Ephata.YouCat.Data.ElasticClientHandler;
using Ephata.YouCat.WebAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ephata.YouCat.WebAPI.Middleware
{
    public static class RegisterElasticsearch
    {
        public static void AddElasticsearch(this IServiceCollection services, ApplicationSettings configuration)
        {
            //get logger instance
            var logger = services.BuildServiceProvider().GetRequiredService<ILogger<object>>();

            var client = new ElasticClient(GetConnectionSettings(configuration.ElasticUrl, logger));
            services.AddSingleton<IElasticClient>(client);
            services.AddTransient<IInitiationIndexHandler,InitiationIndexHandler>();
            //services.InitIndex(configuration);
        }
        public static void InitIndex(this IServiceCollection services, ApplicationSettings configuration)
        {

            //get elastic service instace & create index
            var initIndexHandler = services.BuildServiceProvider().GetRequiredService<InitiationIndexHandler>();
            initIndexHandler.CreateIndex(configuration.Indices).Wait();

        }
        private static ConnectionSettings GetConnectionSettings(string url, ILogger logger)
        {
            var connectionPool = new SingleNodeConnectionPool(new Uri(url));
            var settings = new ConnectionSettings(connectionPool, new HttpConnection())
                .EnableDebugMode()
                .ThrowExceptions()
                .OnRequestCompleted(apiDetail => 
                {
                    logger.LogInformation(apiDetail.DebugInformation);
                    if(apiDetail.RequestBodyInBytes != null)
                    {
                        logger.LogInformation(Encoding.UTF8.GetString(apiDetail.RequestBodyInBytes));
                    }
                });
            return settings;
        }
    }
}
