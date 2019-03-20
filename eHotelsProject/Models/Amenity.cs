using System;
using System.Collections.Generic;

namespace eHotelsProject.Models
{
    public partial class Amenity
    {
        public int Aid { get; set; }
        public string Amenity1 { get; set; }
        public int Rid { get; set; }

        public virtual Room R { get; set; }
    }
}
