using Ephata.YouCat.Data.Models.Additional;
using Ephata.YouCat.Data.Models.Primary;
using Ephata.YouCat.DomainLayer.Model.PrayComment.Query;
using Ephata.YouCat.DomainLayer.Model.PrayComment.ViewModel;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.QueryHandlers.PrayHandler
{
    public class GetMultiPrayCommentQueryHandler : IRequestHandler<GetMultiPrayCommentQuery, IEnumerable<PrayCommentViewModel>>
    {
        private readonly IElasticClient _elasticClientHandler;
        public GetMultiPrayCommentQueryHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<IEnumerable<PrayCommentViewModel>> Handle(GetMultiPrayCommentQuery request, CancellationToken cancellationToken)
        {
            var matchQuery = new MatchQuery
            {
                Query = request.Detail,
                Field = Infer.Field<Pray>(t => t.PrayerComments.Select(x => x.CommentDetail))
            };
            var requestSearch = new SearchRequest
            {
                Query = matchQuery
            };
            var prayResponse = await _elasticClientHandler.SearchAsync<Pray>(requestSearch);
            var result = prayResponse.Documents.ToList();
            return result.Select(prayExisted => new PrayCommentViewModel
            {
                Id = prayExisted.Id,
                PrayerComments = prayExisted.PrayerComments,
            });
        }
    }
}
