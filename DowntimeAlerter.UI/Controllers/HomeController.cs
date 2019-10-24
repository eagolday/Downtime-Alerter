using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DowntimeAlerter.UI.Models;
using Microsoft.Extensions.Logging;
using DowntimeAlerter.ApplicationLayer.IServices;

namespace DowntimeAlerter.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMonitorService _monitorService;
        public HomeController(ILogger<HomeController> logger,IMonitorService monitorService)
        {

            _logger = logger;
            _monitorService = monitorService;
        }
        public IActionResult Index()
        {
          var test= _monitorService.GetAll().ToList();
            _logger.LogInformation("Index page says hello");
            return View();
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
