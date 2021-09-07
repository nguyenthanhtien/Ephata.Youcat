using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.Data.Models.Additional
{
    public class PrayerComment
    {
        public Guid PrayerId { get; set; }
        public string CommentDetail { get; set; }
    }
}
