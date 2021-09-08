using Ephata.YouCat.Data.ElasticClientHandler;
using Microsoft.Extensions.Logging;
using Nest;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ephata.Application.Product.Data.Initiation
{
    public interface IInitiationIndexHandler
    {
        Task CreateIndex(IEnumerable<string> indices);
    }

    public class InitiationIndexHandler : IInitiationIndexHandler
    {
        private readonly IElasticClient _elasticClientHandler;
        private readonly ILogger<InitiationIndexHandler> _logger;
        public InitiationIndexHandler(
            IElasticClient elasticClientHandler,
            ILogger<InitiationIndexHandler> logger)
        {
            this._elasticClientHandler = elasticClientHandler;
            this._logger = logger;
        }

        public async Task CreateIndex(IEnumerable<string> indices)
        {
            var policyRetry = CreateRetryPolicyAsync();
            foreach (var index in indices)
            {
                await policyRetry.ExecuteAsync(async() =>
                {
                    var isExistedIndex = await _elasticClientHandler.Indices.ExistsAsync(index);
                    if(!isExistedIndex.Exists)
                    {
                        await _elasticClientHandler.Indices.CreateAsync(index,
                        t => t.Settings(BuildCustomSettings));
                        _logger.LogInformation($"Successfully created indices: {index}");
                    }
                    else
                    {
                        _logger.LogInformation($"Can not create index is existed: {index}");

                    }
                });
                

            }        
        }

        private AsyncRetryPolicy CreateRetryPolicyAsync()
        {
            return Polly.Policy
                            .Handle<Exception>()
                            .WaitAndRetryAsync(5,
                                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                                onRetry: (exception, span) => _logger.LogError(exception, $"Trying again : {span}"));
        }

        public IndexSettingsDescriptor BuildCustomSettings(IndexSettingsDescriptor settings)
        {
            return settings;
        }
    }
}
