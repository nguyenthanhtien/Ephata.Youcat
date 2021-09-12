using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.DomainLayer.Model.PrayComment.Command
{
    public class UpdatePrayCommentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

    }
}
