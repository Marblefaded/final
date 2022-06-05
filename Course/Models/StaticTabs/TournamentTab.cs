using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;
using System.Linq;

namespace Course.Models.StaticTabs
{
    public class TournamentTab : StaticTab
    {
        public TournamentTab(string h = "", DbSet<Tournament>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("ID");
            DataColumns.Add("Period");
            DataColumns.Add("Sponsor");
            DataColumns.Add("Location");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Tournament>? DBS { get; set; }
    }
}
