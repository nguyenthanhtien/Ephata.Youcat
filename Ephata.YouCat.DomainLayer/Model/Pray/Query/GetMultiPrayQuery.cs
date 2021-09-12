using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
using Ephata.YouCat.DomainLayer.Model.PrayComment.ViewModel;
using MediatR;
using System.Collections.Generic;

namespace Ephata.YouCat.DomainLayer.Model.Pray.Query
{
    public class GetMultiPrayQuery : IRequest<IEnumerable<PrayViewModel>>
    {
        public string QueryDescription { get; set; }
    }
}