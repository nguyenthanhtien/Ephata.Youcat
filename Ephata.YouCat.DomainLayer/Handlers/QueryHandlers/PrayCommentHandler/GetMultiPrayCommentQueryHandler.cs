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
    public class GetMultiPrayCommentQueryHandler : IRequestHandler<GetMultiPrayCommentQuery, IEnumerable<PrayCommentViewModel>>
    {
        public GetMultiPrayCommentQueryHandler()
        {

        }
        public Task<IEnumerable<PrayCommentViewModel>> Handle(GetMultiPrayCommentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
