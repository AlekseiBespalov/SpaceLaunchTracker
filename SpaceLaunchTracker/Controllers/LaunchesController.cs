using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceLaunchTracker.Models;
using SpaceLaunchTracker.Services;

namespace SpaceLaunchTracker.Controllers
{
    public class LaunchesController : Controller
    {
        private readonly LaunchService _launchService;

        public LaunchesController(LaunchService launchService)
        {
            _launchService = launchService;
        }

        //fix
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<LaunchViewModel> launches = await _launchService.GetUpcomingLaunches();
            return View(launches);
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
