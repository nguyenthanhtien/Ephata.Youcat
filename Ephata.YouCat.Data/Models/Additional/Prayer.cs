using System;
using System.Collections.Generic;
using System.Text;

namespace Ephata.YouCat.Data.Models.Additional
{
    public class Prayer
    {
        public Guid PrayerId { get; set; }
        public string AvatarUrl { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
    }
}
