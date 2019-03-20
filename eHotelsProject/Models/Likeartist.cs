using System;
using System.Collections.Generic;

namespace eHotelsProject.Models
{
    public partial class Likeartist
    {
        public int Custid { get; set; }
        public string Aname { get; set; }

        public virtual Artist AnameNavigation { get; set; }
        public virtual Customer1 Cust { get; set; }
    }
}
