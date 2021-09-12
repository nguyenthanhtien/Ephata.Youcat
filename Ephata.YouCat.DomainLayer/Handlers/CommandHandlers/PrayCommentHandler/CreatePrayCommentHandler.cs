using Elasticsearch.Net;
using Ephata.YouCat.Data.Models.Primary;
using Ephata.YouCat.DomainLayer.Model.PrayComment.Command;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.CommandHandlers.PrayCommentHandler
{
    public class CreatePrayCommentHandler : IRequestHandler<CreatePrayCommentCommand, bool>
    {
        private readonly IElasticClient _elasticClientHandler;
        public CreatePrayCommentHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<bool> Handle(CreatePrayCommentCommand request, CancellationToken cancellationToken)
        {
            var result = _elasticClientHandler.Index(request, i => i
                                .Index("praycomment")
                                .Id(request.Id)
                                .Refresh(Refresh.WaitFor));
            return result.Result == Result.Created;
        }
    }
}
