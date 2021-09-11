using Ephata.YouCat.DomainLayer.Model.Pray.Command;
using Ephata.YouCat.DomainLayer.Model.Pray.Query;
using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ephata.YouCat.Service.Service
{
    public interface IPrayCommentService
    {
        Task<IEnumerable<PrayCommentViewModel>> GetPrayComments(GetPrayCommentQuery command);
        Task<PrayCommentViewModel> GetPrayCommentById(GetPrayCommentByIdQuery query);
        Task<bool> AddComment(CreatePrayCommentCommand command);
        Task<bool> UpdateComment(UpdatePrayCommentCommand command);
        Task<bool> RemoveComment(RemovePrayCommentCommand command);
    }
    public class PrayCommentService : IPrayCommentService
    {
        private readonly IMediator _mediator;
        public PrayCommentService(IMediator mediator)
        {
            this._mediator = mediator;
        }
        public Task<PrayCommentViewModel> GetPrayCommentById(GetPrayCommentByIdQuery query)
        {
            return _mediator.Send(query);
        }

        public Task<IEnumerable<PrayCommentViewModel>> GetPrayComments(GetPrayCommentQuery query)
        {
            return _mediator.Send(query);
        }

        public Task<bool> AddComment(CreatePrayCommentCommand command)
        {
            return _mediator.Send(command);
        }
        public Task<bool> RemoveComment(RemovePrayCommentCommand command)
        {
            return _mediator.Send(command);
        }
        public Task<bool> UpdateComment(UpdatePrayCommentCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
