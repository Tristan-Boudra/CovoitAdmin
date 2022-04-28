using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CovoitAdmin.Model
{
    public partial class Passenger
    {
        public int IdPassenger { get; set; }
        public int IdPath { get; set; }
        public int IdUser { get; set; }

        public virtual Paths IdPathNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
