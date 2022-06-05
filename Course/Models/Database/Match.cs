using System;
using System.Collections.Generic;

namespace Course.Models.Database
{
    public partial class Match
    {
        public string? Date { get; set; }
        public long? TournamentId { get; set; }
        public long? ResultId { get; set; }

        public virtual Result? Result { get; set; }
        public virtual Tournament? Tournament { get; set; }
    }
}
