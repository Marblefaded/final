using System;
using System.Collections.Generic;

namespace Course.Models.Database
{
    public partial class Tournament
    {
        public long Id { get; set; }
        public string? Period { get; set; }
        public string? Sponsor { get; set; }
        public string? Location { get; set; }
    }
}
