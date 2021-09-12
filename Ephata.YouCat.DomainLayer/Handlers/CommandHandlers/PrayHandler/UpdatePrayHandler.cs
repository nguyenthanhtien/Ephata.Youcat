using Elasticsearch.Net;
using Ephata.YouCat.DomainLayer.Model.Pray.Command;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.CommandHandlers.PrayHandler
{
    public class UpdatePrayHandler : IRequestHandler<UpdatePrayCommand, bool>
    {
        private readonly IElasticClient _elasticClientHandler;
        public UpdatePrayHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<bool> Handle(UpdatePrayCommand request, CancellationToken cancellationToken)
        {
            var result = _elasticClientHandler.Index(request, i => i
                                .Index("pray")
                                .Id(request.Id)
                                .Refresh(Refresh.WaitFor));
            return result.Result == Result.Updated;
        }
    }
}
