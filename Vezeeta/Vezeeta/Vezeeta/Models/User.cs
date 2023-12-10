using System;
using System.Collections.Generic;

namespace Vezeeta.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsAdmin { get; set; }
        public string? Password { get; set; }
    }
}
