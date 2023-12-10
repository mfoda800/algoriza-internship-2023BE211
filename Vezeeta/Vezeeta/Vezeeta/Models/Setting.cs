using System;
using System.Collections.Generic;

namespace Vezeeta.Models
{
    public partial class Setting
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Price { get; set; }
        public string? DiscoundCode { get; set; }
        public decimal? FinalPrice { get; set; }
        public string? Prescription { get; set; }
        public int? Status { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual SettingStatus? StatusNavigation { get; set; }
    }
}
