using System;
using System.Collections.Generic;

namespace eHotelsProject.Models
{
    public partial class Customer1
    {
        public Customer1()
        {
            Likeartist = new HashSet<Likeartist>();
        }

        public int Custid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal? Amount { get; set; }
        public int? Rating { get; set; }

        public virtual ICollection<Likeartist> Likeartist { get; set; }
    }
}
