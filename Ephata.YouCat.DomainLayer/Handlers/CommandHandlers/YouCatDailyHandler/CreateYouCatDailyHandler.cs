using Elasticsearch.Net;
using Ephata.YouCat.Data.Models.Primary;
using Ephata.YouCat.DomainLayer.Model.YouCatDaily.Command;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.CommandHandlers.YouCatDailyHandler
{
    public class CreateYouCatDailyHandler : IRequestHandler<CreateYouCatDailyCommand, bool>
    {
        private readonly IElasticClient _elasticClientHandler;
        public CreateYouCatDailyHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<bool> Handle(CreateYouCatDailyCommand request, CancellationToken cancellationToken)
        {
            var result = _elasticClientHandler.Index(request, i => i
                                .Index("youcatdaily")
                                .Id(request.Id)
                                .Refresh(Refresh.WaitFor));
            return result.Result == Result.Created;
        }
    }
}
