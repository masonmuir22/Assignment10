using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment10v2.Models;
using Microsoft.EntityFrameworkCore;
using Assignment10v2.Models.ViewModels;

namespace Assignment10v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //generate the variable
        private BowlingLeagueContext context;

        //set the items per page
        public int itemsPerPage = 5;

        //add context to the constructor in the controller
        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }


        public IActionResult Index(long? team, string teamid, int pageNum = 1)
        {


            return View(new BowlerListViewModel
            {
                //this will query the database for the bowers on a particular team
                Team = teamid,
                Bowlers = (context.Bowlers
                   .Where(m => m.TeamId == team || team == null)
                   .OrderBy(m => m.BowlerLastName)
                   .Skip((pageNum - 1) * itemsPerPage)
                   .Take(itemsPerPage)
                   .ToList())
               ,
                //this gets our page numbers
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = itemsPerPage,
                    TotalNumItems = (team == null ? context.Bowlers.Count()
                       : context.Bowlers.Where(x => x.TeamId == team).Count())
                },

                //This is our list of teams
                Teams = (context.Teams
                .Where(m => m.TeamId == team)
                .ToList())

            }
            );
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
