using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SpaceLaunchTracker.Models;
using SpaceLaunchTracker.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SpaceLaunchTracker.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class LaunchesController : Controller
    {
        private readonly LaunchService _launchService;

        public LaunchesController(LaunchService launchService)
        {
            _launchService = launchService;
        }

        // GET api/launches
        [HttpGet]
        public async Task<IEnumerable<LaunchViewModel>> Get()
        {
            List<LaunchViewModel> launches = await _launchService.GetUpcomingLaunches();

            return launches;
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
