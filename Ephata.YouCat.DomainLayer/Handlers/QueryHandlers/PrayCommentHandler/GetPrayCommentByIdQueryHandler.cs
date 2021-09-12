using Ephata.YouCat.Data.Models.Additional;
using Ephata.YouCat.DomainLayer.Model.PrayComment.Query;
using Ephata.YouCat.DomainLayer.Model.PrayComment.ViewModel;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.QueryHandlers.PrayHandler
{
    public class GetPrayCommentByIdQueryHandler : IRequestHandler<GetPrayCommentByIdQuery, PrayCommentViewModel>
    {
        private readonly IElasticClient _elasticClientHandler;

        public GetPrayCommentByIdQueryHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<PrayCommentViewModel> Handle(GetPrayCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var prayResponse = _elasticClientHandler.Get(DocumentPath<PrayComment>.Id(request.Id).Index("pray"));
            var prayExisted = prayResponse.Source;
            return new PrayCommentViewModel
            {
                PrayerId = prayExisted.PrayerId,
                CommentDetail = prayExisted.CommentDetail,
            };
        }
    }
}
