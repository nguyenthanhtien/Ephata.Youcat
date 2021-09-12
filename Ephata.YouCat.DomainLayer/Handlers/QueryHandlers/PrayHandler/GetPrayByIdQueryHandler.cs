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
    public class GetPrayByIdQueryHandler : IRequestHandler<GetPrayByIdQuery, PrayViewModel>
    {
        public GetPrayByIdQueryHandler()
        {

        }
        public Task<PrayViewModel> Handle(GetPrayByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
