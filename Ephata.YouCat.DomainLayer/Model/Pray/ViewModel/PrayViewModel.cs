using Ephata.YouCat.Data.Models.Additional;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.DomainLayer.Model.Pray.ViewModel
{
    public class PrayViewModel
    {
        public Guid Id { get; set; }
        public Prayer Prayer { get; set; }
        public string ShortDescription { get; set; }
        public string DetailPray { get; set; }
        public decimal TotalPeoplePrayTogether { get; set; }
        public IEnumerable<Prayer> PeoplePrayTogether { get; set; }
        public IEnumerable<PrayerComment> PrayerComments { get; set; }
    }
}
