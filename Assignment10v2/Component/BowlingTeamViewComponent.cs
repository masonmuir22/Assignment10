using System;
using System.Linq;
using Assignment10v2.Models;
using Microsoft.AspNetCore.Mvc;
namespace Assignment10v2.Component


{
    public class BowlingTeamViewComponent : ViewComponent 
    {
        private BowlingLeagueContext context;

        public BowlingTeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }

        //this is where we get out team name buttons built from
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamid"];

            return View(context.Teams
                .Distinct()
                .OrderBy(x => x)
                );
        }
    }
}
