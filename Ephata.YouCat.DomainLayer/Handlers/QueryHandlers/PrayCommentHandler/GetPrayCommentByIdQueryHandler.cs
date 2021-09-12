using Ephata.YouCat.DomainLayer.Model.PrayComment.Query;
using Ephata.YouCat.DomainLayer.Model.PrayComment.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ephata.YouCat.DomainLayer.Handlers.QueryHandlers.PrayHandler
{
    public class GetPrayCommentByIdQueryHandler : IRequestHandler<GetPrayCommentByIdQuery, PrayCommentViewModel>
    {
        public GetPrayCommentByIdQueryHandler()
        {

        }
        public Task<PrayCommentViewModel> Handle(GetPrayCommentByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
