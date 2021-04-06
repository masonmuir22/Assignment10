using System;
using System.Collections.Generic;

namespace Assignment10v2.Models.ViewModels
{
    //this is the data that we will pull from in our index page
    public class BowlerListViewModel
    {
        public List<Bowler> Bowlers { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string Team { get; set; }

        public List<Team> Teams { get; set; }

    }
}
