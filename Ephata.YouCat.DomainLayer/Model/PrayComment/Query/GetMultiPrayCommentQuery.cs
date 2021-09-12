using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
using Ephata.YouCat.DomainLayer.Model.PrayComment.ViewModel;
using MediatR;
using System.Collections.Generic;

namespace Ephata.YouCat.DomainLayer.Model.PrayComment.Query
{
    public class GetMultiPrayCommentQuery : IRequest<IEnumerable<PrayCommentViewModel>>
    {
        public string Detail { get;  set; }
    }
}