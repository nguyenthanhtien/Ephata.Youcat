using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
using MediatR;
using System.Collections.Generic;

namespace Ephata.YouCat.Service.Service
{
    public class GetPrayCommentQuery : IRequest<IEnumerable<PrayCommentViewModel>>
    {
    }
}