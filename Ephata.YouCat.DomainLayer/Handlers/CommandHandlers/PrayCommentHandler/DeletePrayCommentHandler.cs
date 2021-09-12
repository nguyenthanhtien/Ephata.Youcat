using Ephata.YouCat.Data.Models.Primary;
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
    public class DeletePrayCommentHandler : IRequestHandler<RemovePrayCommentCommand, bool>
    {
        private readonly IElasticClient _elasticClientHandler;
        public DeletePrayCommentHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<bool> Handle(RemovePrayCommentCommand request, CancellationToken cancellationToken)
        {
            var result = await _elasticClientHandler.DeleteAsync(DocumentPath<Pray>.Id(request.Id).Index("praycomment"));
            return result.Result == Result.Deleted;
        }
    }
}
