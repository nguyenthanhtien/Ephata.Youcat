﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ephata.YouCat.DomainLayer.Model.Pray.Command;
using Ephata.YouCat.DomainLayer.Model.Pray.Query;
using Ephata.YouCat.DomainLayer.Model.Pray.ViewModel;
using MediatR;

namespace Ephata.YouCat.Service.Service
{
    public interface IPrayService
    {
        Task<IEnumerable<PrayViewModel>> GetPrayers(GetPrayQuery command);
        Task<PrayViewModel> GetPrayById(GetPrayByIdQuery query);
        Task<bool> CreatePray(CreatePrayCommand command);
        Task<bool> UpdatePray(UpdatePrayCommand command);
        Task<bool> RemovePray(RemovePrayCommand command);
        Task<IEnumerable<PrayCommentViewModel>> GetPrayComments(GetPrayCommentQuery command);
        Task<PrayCommentViewModel> GetPrayCommentById(GetPrayCommentByIdQuery query);
        Task<bool> AddComment(CreatePrayCommentCommand command);
        Task<bool> UpdateComment(UpdatePrayCommentCommand command);
        Task<bool> RemoveComment(RemovePrayCommentCommand command);

    }

    public class PrayService : IPrayService
    {
        private readonly IMediator _mediator;
        public PrayService(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public Task<bool> AddComment(CreatePrayCommentCommand command)
        {
            return _mediator.Send(command);
        }

        public Task<bool> CreatePray(CreatePrayCommand command)
        {
            return _mediator.Send(command);
        }

        public Task<PrayViewModel> GetPrayById(GetPrayByIdQuery query)
        {
            return _mediator.Send(query);
        }

        public Task<PrayCommentViewModel> GetPrayCommentById(GetPrayCommentByIdQuery query)
        {
            return _mediator.Send(query);
        }

        public Task<IEnumerable<PrayCommentViewModel>> GetPrayComments(GetPrayCommentQuery query)
        {
            return _mediator.Send(query);
        }

        public Task<IEnumerable<PrayViewModel>> GetPrayers(GetPrayQuery command)
        {
            return _mediator.Send(command);
        }

        public Task<bool> RemoveComment(RemovePrayCommentCommand command)
        {
            return _mediator.Send(command);
        }

        public Task<bool> RemovePray(RemovePrayCommand command)
        {
            return _mediator.Send(command);
        }

        public Task<bool> UpdateComment(UpdatePrayCommentCommand command)
        {
            return _mediator.Send(command);
        }

        public Task<bool> UpdatePray(UpdatePrayCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
