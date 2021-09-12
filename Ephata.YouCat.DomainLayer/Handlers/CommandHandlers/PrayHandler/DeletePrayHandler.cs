using Ephata.YouCat.Data.Models.Primary;
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
    public class DeletePrayHandler : IRequestHandler<RemovePrayCommand, bool>
    {
        private readonly IElasticClient _elasticClientHandler;
        public DeletePrayHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<bool> Handle(RemovePrayCommand request, CancellationToken cancellationToken)
        {
            var result = await _elasticClientHandler.DeleteAsync(DocumentPath<Pray>.Id(request.Id).Index("pray"));
            return result.Result == Result.Deleted;
        }
    }
}
