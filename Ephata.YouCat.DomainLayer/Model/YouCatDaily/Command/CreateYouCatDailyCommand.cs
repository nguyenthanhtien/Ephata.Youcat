using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.DomainLayer.Model.YouCatDaily.Command
{
    public class CreateYouCatDailyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
