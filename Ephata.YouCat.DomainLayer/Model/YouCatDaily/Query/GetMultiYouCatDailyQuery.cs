using Ephata.YouCat.DomainLayer.Model.YouCatDaily.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.DomainLayer.Model.YouCatDaily.Query
{
    public class GetMultiYouCatDailyQuery : IRequest<IEnumerable<YouCatDailyViewModel>>
    {
    }
}
