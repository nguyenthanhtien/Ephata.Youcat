using Ephata.YouCat.Data.Models.Additional;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.DomainLayer.Model.PrayComment.ViewModel
{
    public class PrayCommentViewModel
    {
        public Guid Id { get; set; }
        public IEnumerable<PrayerComment> PrayerComments { get; set; }
    }
}
