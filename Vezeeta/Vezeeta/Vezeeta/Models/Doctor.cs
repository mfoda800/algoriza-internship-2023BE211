using System;
using System.Collections.Generic;

namespace Vezeeta.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Settings = new HashSet<Setting>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? SpecializeId { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Image { get; set; }

        public virtual Specialization? Specialize { get; set; }
        public virtual ICollection<Setting> Settings { get; set; }
    }
}
