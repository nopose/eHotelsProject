using System;
using System.Collections.Generic;

namespace eHotelsProject.Models
{
    public partial class Artwork
    {
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Type { get; set; }
        public decimal? Price { get; set; }
        public string Aname { get; set; }

        public virtual Artist AnameNavigation { get; set; }
    }
}
