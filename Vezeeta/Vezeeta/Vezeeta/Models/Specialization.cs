using System;
using System.Collections.Generic;

namespace Vezeeta.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string? Specialize { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
