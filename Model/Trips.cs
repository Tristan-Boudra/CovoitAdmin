using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CovoitAdmin.Model
{
    public partial class Trips
    {
        public Trips()
        {
            Driver = new HashSet<Driver>();
            Paths = new HashSet<Paths>();
        }

        public int IdTrip { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime StartingDate { get; set; }

        public virtual ICollection<Driver> Driver { get; set; }
        public virtual ICollection<Paths> Paths { get; set; }
    }
}
