using Elasticsearch.Net;
using Ephata.YouCat.DomainLayer.Model.PrayComment.Command;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.CommandHandlers.PrayCommandHandler
{
    public class UpdatePrayCommentHandler : IRequestHandler<UpdatePrayCommentCommand, bool>
    {
        private readonly IElasticClient _elasticClientHandler;
        public UpdatePrayCommentHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<bool> Handle(UpdatePrayCommentCommand request, CancellationToken cancellationToken)
        {
            var result = _elasticClientHandler.Index(request, i => i
                                .Index("pray")
                                .Id(request.Id)
                                .Refresh(Refresh.WaitFor));
            return result.Result == Result.Updated;
        }
    }
}
