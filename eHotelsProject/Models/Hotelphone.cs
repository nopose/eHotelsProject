using System;
using System.Collections.Generic;

namespace eHotelsProject.Models
{
    public partial class Hotelphone
    {
        public string PhoneNumber { get; set; }
        public int Hid { get; set; }

        public virtual Hotel H { get; set; }
    }
}
