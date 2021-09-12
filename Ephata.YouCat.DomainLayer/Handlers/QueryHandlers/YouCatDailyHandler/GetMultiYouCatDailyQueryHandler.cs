using Ephata.YouCat.Data.Models.Primary;
using Ephata.YouCat.DomainLayer.Model.YouCatDaily.Query;
using Ephata.YouCat.DomainLayer.Model.YouCatDaily.ViewModel;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.QueryHandlers.YouCatDailyHandler
{
    public class GetMultiYouCatDailyQueryHandler : IRequestHandler<GetMultiYouCatDailyQuery, IEnumerable<YouCatDailyViewModel>>
    {
        private readonly IElasticClient _elasticClientHandler;
        public GetMultiYouCatDailyQueryHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }

        public async Task<IEnumerable<YouCatDailyViewModel>> Handle(GetMultiYouCatDailyQuery request, CancellationToken cancellationToken)
        {
            var matchQuery = new MatchQuery
            {
                Query = request.Bible,
                Field = Infer.Field<YouCatDaily>(t => t.Bible.BibleDetail)
            };
            var requestSearch = new SearchRequest
            {
                Query = matchQuery
            };
            var prayResponse = await _elasticClientHandler.SearchAsync<YouCatDaily>(requestSearch);
            var result = prayResponse.Documents.ToList();
            return result.Select(prayExisted => new YouCatDailyViewModel
            {
                Bible = prayExisted.Bible,
                Inspiration = prayExisted.Inspiration,
                Testament = prayExisted.Testament,
                YouCat = prayExisted.YouCat
            });
        }
    }
}
