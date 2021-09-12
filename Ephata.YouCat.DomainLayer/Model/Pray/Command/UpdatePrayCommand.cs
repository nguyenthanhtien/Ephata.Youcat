using Ephata.YouCat.Data.Models.Additional;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.DomainLayer.Model.Pray.Command
{
    public class UpdatePrayCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Prayer Prayer { get; set; }
        public string ShortDescription { get; set; }
        public string DetailPray { get; set; }
    }
}
