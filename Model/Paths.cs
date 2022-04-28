using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CovoitAdmin.Model
{
    public partial class Paths
    {
        public Paths()
        {
            EndPoint = new HashSet<EndPoint>();
            Passenger = new HashSet<Passenger>();
            StartingPoint = new HashSet<StartingPoint>();
        }

        public int IdPath { get; set; }
        public int IdTrip { get; set; }
        public TimeSpan DepartureTime { get; set; }

        public virtual Trips IdTripNavigation { get; set; }
        public virtual ICollection<EndPoint> EndPoint { get; set; }
        public virtual ICollection<Passenger> Passenger { get; set; }
        public virtual ICollection<StartingPoint> StartingPoint { get; set; }
    }
}
