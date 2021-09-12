using Elasticsearch.Net;
using Ephata.YouCat.DomainLayer.Model.Pray.Command;
using Ephata.YouCat.DomainLayer.Model.YouCatDaily.Command;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.CommandHandlers.PrayHandler
{
    public class UpdateYouCatDailyHandler : IRequestHandler<UpdateYouCatDailyCommand, bool>
    {
        private readonly IElasticClient _elasticClientHandler;
        public UpdateYouCatDailyHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<bool> Handle(UpdateYouCatDailyCommand request, CancellationToken cancellationToken)
        {
            var result = _elasticClientHandler.Index(request, i => i
                                .Index("youcatdaily")
                                .Id(request.Id)
                                .Refresh(Refresh.WaitFor));
            return result.Result == Result.Updated;
        }
    }
}
