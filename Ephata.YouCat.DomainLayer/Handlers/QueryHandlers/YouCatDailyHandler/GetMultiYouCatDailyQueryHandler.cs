using Ephata.YouCat.DomainLayer.Model.YouCatDaily.Query;
using Ephata.YouCat.DomainLayer.Model.YouCatDaily.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.QueryHandlers.YouCatDailyHandler
{
    public class GetMultiYouCatDailyQueryHandler : IRequestHandler<GetMultiYouCatDailyQuery, IEnumerable<YouCatDailyViewModel>>
    {
        public GetMultiYouCatDailyQueryHandler()
        {

        }
        public Task<IEnumerable<YouCatDailyViewModel>> Handle(GetMultiYouCatDailyQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
