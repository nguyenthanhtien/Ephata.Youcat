using Ephata.YouCat.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ephata.YouCat.WebAPI.Middleware
{
    public static class RegisterHealthCheckElasticsearch
    {
        public static void HealthCheckElasticsearch(this IServiceCollection services, string elasticUrl)
        {
            services.AddHealthChecks()
                .AddElasticsearch(elasticUrl);
        }

        public static void UseHealthCheckElasticsearch(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
