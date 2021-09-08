using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.DomainLayer.Model.Pray.Query
{
    public class GetPrayCommentByIdQuery : IRequest<PrayCommentViewModel>
    {
    }
}
