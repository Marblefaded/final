using System;
using System.Collections.Generic;

namespace Course.Models.Database
{
    public partial class Player
    {
        public Player()
        {
            Results = new HashSet<Result>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long? Rank { get; set; }
        public string? Country { get; set; }
        public string? Titles { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
