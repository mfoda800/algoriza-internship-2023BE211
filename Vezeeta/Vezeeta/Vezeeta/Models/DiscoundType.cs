using System;
using System.Collections.Generic;

namespace Vezeeta.Models
{
    public partial class DiscoundType
    {
        public int Id { get; set; }
        public string? DiscoundCode { get; set; }
        public string? DiscoundType1 { get; set; }
        public decimal? DiscoundPercent { get; set; }
        public bool? IsActive { get; set; }
    }
}
