using Ephata.YouCat.DomainLayer.Model.YouCatDaily.Command;
using Ephata.YouCat.DomainLayer.Model.YouCatDaily.Query;
using Ephata.YouCat.DomainLayer.Model.YouCatDaily.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ephata.YouCat.Service.Service
{
    public interface IYouCatDailyService
    {
        Task<IEnumerable<YouCatDailyViewModel>> GetYouCatDailies(GetYouCatDailyQuery command);
        Task<YouCatDailyViewModel> GetYouCatDailyById(GetYouCatDailyByIdQuery query);
        Task<bool> AddYouCatDaily(CreateYouCatDailyCommand command);
        Task<bool> UpdateYouCatDaily(UpdateYouCatDailyCommand command);
        Task<bool> RemoveYouCatDaily(RemoveYouCatDailyCommand command);
    }
    public class YouCatDailyService : IYouCatDailyService
    {
        private readonly IMediator _mediator;
        public YouCatDailyService(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public Task<bool> AddYouCatDaily(CreateYouCatDailyCommand command)
        {
            return _mediator.Send(command);
        }

        public Task<IEnumerable<YouCatDailyViewModel>> GetYouCatDailies(GetYouCatDailyQuery command)
        {
            return _mediator.Send(command);
        }

        public Task<YouCatDailyViewModel> GetYouCatDailyById(GetYouCatDailyByIdQuery query)
        {
            return _mediator.Send(query);
        }

        public Task<bool> RemoveYouCatDaily(RemoveYouCatDailyCommand command)
        {
            return _mediator.Send(command);
        }

        public Task<bool> UpdateYouCatDaily(UpdateYouCatDailyCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
