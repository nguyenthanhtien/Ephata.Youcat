using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.DomainLayer.Model.Pray.Command
{
    public class RemovePrayCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
