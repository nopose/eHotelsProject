using System;
using System.Collections.Generic;

namespace eHotelsProject.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Artwork = new HashSet<Artwork>();
            Likeartist = new HashSet<Likeartist>();
        }

        public string Aname { get; set; }
        public string Birthplace { get; set; }
        public string Style { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Artwork> Artwork { get; set; }
        public virtual ICollection<Likeartist> Likeartist { get; set; }
    }
}
