using System;
using System.Collections.Generic;

namespace Course.Models.Database
{
    public partial class Result
    {
        public long Id { get; set; }
        public long? PlayerId { get; set; }
        public string? Round { get; set; }

        public virtual Player? Player { get; set; }
    }
}
