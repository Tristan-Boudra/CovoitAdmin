using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CovoitAdmin.Model
{
    public partial class Vehicles
    {
        public Vehicles()
        {
            Driver = new HashSet<Driver>();
        }

        public int IdVehicles { get; set; }
        public int IdMotorization { get; set; }
        public int IdUser { get; set; }
        public string VehicleName { get; set; }
        public int NbPlaces { get; set; }
        public string Color { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModification { get; set; }

        public virtual Motorization IdMotorizationNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<Driver> Driver { get; set; }
    }
}
