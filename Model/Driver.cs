using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CovoitAdmin.Model
{
    public partial class Driver
    {
        public int IdDriver { get; set; }
        public int IdTrip { get; set; }
        public int IdUser { get; set; }
        public int IdVehicles { get; set; }

        public virtual Trips IdTripNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
        public virtual Vehicles IdVehiclesNavigation { get; set; }
    }
}
