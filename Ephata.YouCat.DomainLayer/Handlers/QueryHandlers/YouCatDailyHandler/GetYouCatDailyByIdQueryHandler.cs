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
    public class GetYouCatDailyByIdQueryHandler : IRequestHandler<GetYouCatDailyByIdQuery, YouCatDailyViewModel>
    {
        public GetYouCatDailyByIdQueryHandler()
        {

        }
        public Task<YouCatDailyViewModel> Handle(GetYouCatDailyByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
