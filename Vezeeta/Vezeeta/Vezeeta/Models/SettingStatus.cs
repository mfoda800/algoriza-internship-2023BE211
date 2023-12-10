using System;
using System.Collections.Generic;

namespace Vezeeta.Models
{
    public partial class SettingStatus
    {
        public SettingStatus()
        {
            Settings = new HashSet<Setting>();
        }

        public int Id { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }
    }
}
