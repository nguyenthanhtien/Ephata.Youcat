using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.Service.Service
{
    public interface IYouCatDailyService
    {

    }
    public class YouCatDailyService : IYouCatDailyService
    {
        private readonly IMediator _mediator;
        public YouCatDailyService(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }
}
