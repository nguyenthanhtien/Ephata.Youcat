using Ephata.YouCat.Data.Models.Primary;
using Ephata.YouCat.DomainLayer.Model.Pray.Query;
using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.QueryHandlers.PrayHandler
{
    public class GetPrayByIdQueryHandler : IRequestHandler<GetPrayByIdQuery, PrayViewModel>
    {
        private readonly IElasticClient _elasticClientHandler;
        public GetPrayByIdQueryHandler(IElasticClient elasticClientHandler)
        {
            _elasticClientHandler = elasticClientHandler;
        }
        public async Task<PrayViewModel> Handle(GetPrayByIdQuery request, CancellationToken cancellationToken)
        {
            var prayResponse = _elasticClientHandler.Get(DocumentPath<Pray>.Id(request.Id).Index("pray"));
            var prayExisted = prayResponse.Source;
            return new PrayViewModel
            {
                Id = prayExisted.Id,
                DetailPray = prayExisted.DetailPray,
                PeoplePrayTogether = prayExisted.PeoplePrayTogether,
                Prayer = prayExisted.Prayer,
                PrayerComments = prayExisted.PrayerComments,
                ShortDescription = prayExisted.ShortDescription,
                TotalPeoplePrayTogether = prayExisted.TotalPeoplePrayTogether
            };
        }
    }
}
