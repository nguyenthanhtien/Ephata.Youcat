using Ephata.YouCat.Data.Models.Primary;
using Ephata.YouCat.DomainLayer.Model.Pray.Command;
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
    public class DeleteYouCatDailyHandler : IRequestHandler<RemoveYouCatDailyCommand, bool>
    {
        private readonly IElasticClient _elasticClientHandler;
        public DeleteYouCatDailyHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<bool> Handle(RemoveYouCatDailyCommand request, CancellationToken cancellationToken)
        {
            var result = await _elasticClientHandler.DeleteAsync(DocumentPath<Pray>.Id(request.Id).Index("youcatdaily"));
            return result.Result == Result.Deleted;
        }
    }
}
