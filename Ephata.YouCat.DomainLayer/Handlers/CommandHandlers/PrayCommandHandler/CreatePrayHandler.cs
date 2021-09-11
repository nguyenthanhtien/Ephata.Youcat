using Elasticsearch.Net;
using Ephata.YouCat.Data.ElasticClientHandler;
using Ephata.YouCat.Data.Models.Primary;
using Ephata.YouCat.DomainLayer.Model.Pray.Command;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.CommandHandlers.PrayCommandHandler
{
    public class CreatePrayHandler : IRequestHandler<CreatePrayCommand, bool>
    {
        private readonly IElasticClient _elasticClientHandler;
        public CreatePrayHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<bool> Handle(CreatePrayCommand request, CancellationToken cancellationToken)
        {
            var result = _elasticClientHandler.Index(request, i =>i
                                .Index("pray")
                                .Id(request.Id)
                                .Refresh(Refresh.WaitFor));
            return result.Result == Result.Created;
        }
    }
}
