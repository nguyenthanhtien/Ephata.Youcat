using Ephata.YouCat.Data.ElasticClientHandler;
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
    class DeletePrayHandler : IRequestHandler<RemovePrayCommand, bool>
    {
        private readonly IElasticClient _elasticClientHandler;
        public DeletePrayHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<bool> Handle(RemovePrayCommand request, CancellationToken cancellationToken)
        {
            var result = await _elasticClientHandler.DeleteAsync(null);
            return result.Result == Result.Deleted;
        }
    }
}
