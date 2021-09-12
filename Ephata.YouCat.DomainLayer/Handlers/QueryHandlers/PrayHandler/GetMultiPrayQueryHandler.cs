using Ephata.YouCat.DomainLayer.Model.Pray.Query;
using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.QueryHandlers.PrayHandler
{
    public class GetMultiPrayQueryHandler : IRequestHandler<GetMultiPrayQuery, IEnumerable<PrayViewModel>>
    {
        public GetMultiPrayQueryHandler()
        {

        }
        public Task<IEnumerable<PrayViewModel>> Handle(GetMultiPrayQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
