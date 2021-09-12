using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
using Ephata.YouCat.DomainLayer.Model.PrayComment.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.DomainLayer.Model.PrayComment.Query
{
    public class GetPrayCommentByIdQuery : IRequest<PrayCommentViewModel>
    {
        public Guid Id { get; set; }
    }
}
