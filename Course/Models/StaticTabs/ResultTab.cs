using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;


namespace Course.Models.StaticTabs
{
    public class ResultTab : StaticTab
    {
        public ResultTab(string h = "", DbSet<Result>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("ID");
            DataColumns.Add("Player_id");
            DataColumns.Add("Round");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Result>? DBS { get; set; }
    }
}
