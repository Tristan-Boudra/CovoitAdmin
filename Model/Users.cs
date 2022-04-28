using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CovoitAdmin.Model
{
    public partial class Users
    {
        public Users()
        {
            Driver = new HashSet<Driver>();
            Passenger = new HashSet<Passenger>();
            Vehicles = new HashSet<Vehicles>();
        }

        public int IdUser { get; set; }
        public int Tel { get; set; }
        public bool? Contacts { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string ImgProfil { get; set; }
        public bool? Administrator { get; set; }
        public string Password { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModification { get; set; }

        public virtual ICollection<Driver> Driver { get; set; }
        public virtual ICollection<Passenger> Passenger { get; set; }
        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
