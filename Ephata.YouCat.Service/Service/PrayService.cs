using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace Ephata.YouCat.Service.Service
{
    public interface IPrayService
    {

    }

    public class PrayService : IPrayService
    {
        private readonly IMediator _mediator;
        public PrayService(IMediator mediator)
        {
            this._mediator = mediator;
        }

    }
}
