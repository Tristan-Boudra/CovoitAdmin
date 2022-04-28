using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CovoitAdmin.Model
{
    public partial class Motorization
    {
        public Motorization()
        {
            Vehicles = new HashSet<Vehicles>();
        }

        public int IdMotorization { get; set; }
        public string Libellet { get; set; }

        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
