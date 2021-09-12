using Ephata.YouCat.Data.Models.Additional;
using System;
using System.Collections.Generic;
using System.Text;
using YouCatholic = Ephata.YouCat.Data.Models.Additional.YouCat;

namespace Ephata.YouCat.DomainLayer.Model.YouCatDaily.ViewModel
{
    public class YouCatDailyViewModel
    {
        public Bible Bible { get; set; }
        public YouCatholic YouCat { get; set; }
        public Inspiration Inspiration { get; set; }
        public TESTAMENT_ENUM Testament { get; set; }
    }
}
