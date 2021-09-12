using Ephata.YouCat.Data.Models.Primary;
using Ephata.YouCat.DomainLayer.Model.Pray.Query;
using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
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
    public class GetMultiPrayQueryHandler : IRequestHandler<GetMultiPrayQuery, IEnumerable<PrayViewModel>>
    {
        private readonly IElasticClient _elasticClientHandler;
        public GetMultiPrayQueryHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<IEnumerable<PrayViewModel>> Handle(GetMultiPrayQuery request, CancellationToken cancellationToken)
        {
            var matchQuery = new MultiMatchQuery
            {
                Query = request.QueryDescription,
                Fields = Infer.Fields<Pray>(t => t.DetailPray).And<Pray>(t => t.ShortDescription)
            };
            var requestSearch = new SearchRequest
            {
                Query = matchQuery
            };
            var prayResponse = await _elasticClientHandler.SearchAsync<Pray>(requestSearch);
            var result = prayResponse.Documents.ToList();
            return result.Select(prayExisted => new PrayViewModel
                {
                    Id = prayExisted.Id,
                    DetailPray = prayExisted.DetailPray,
                    PeoplePrayTogether = prayExisted.PeoplePrayTogether,
                    Prayer = prayExisted.Prayer,
                    PrayerComments = prayExisted.PrayerComments,
                    ShortDescription = prayExisted.ShortDescription,
                    TotalPeoplePrayTogether = prayExisted.TotalPeoplePrayTogether
                });
        }
    }
}
