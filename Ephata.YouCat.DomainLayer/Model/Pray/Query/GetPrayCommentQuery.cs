using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
using MediatR;
using System.Collections.Generic;

namespace Ephata.YouCat.DomainLayer.Model.Pray.Query
{
    public class GetPrayCommentQuery : IRequest<IEnumerable<PrayCommentViewModel>>
    {
    }
}