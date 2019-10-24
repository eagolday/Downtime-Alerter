using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DowntimeAlerter.Domain.Entities;
using DowntimeAlerter.ApplicationLayer.IServices;
using Microsoft.Extensions.Logging;
using DowntimeAlerter.ApplicationLayer.ViewModel;

namespace DowntimeAlerter.UI.Controllers
{
    public class MonitorsController : BaseController
    {
        private readonly IMonitorService _monitorService;
        private readonly IHealthCheckService _healthCheckService;
        private readonly ILogger<MonitorsController> _logger;

        public MonitorsController(IMonitorService monitorService, IHealthCheckService healthCheckService, ILogger<MonitorsController> logger)
        {
            _monitorService = monitorService;
            _healthCheckService = healthCheckService;
            _logger = logger;

        }

        public IActionResult Index()
        {
            var _getAllMonitorList = _monitorService.FindBy(x => x.AppUserId == UserId)
                .Select(x => new MonitorViewModel
                {
                    Id = x.Id,
                    Name = x.DisplayName,
                    Url = x.Url,
                    UserId = x.AppUserId
                }).ToList();

            return View(_getAllMonitorList);
        }
        

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<MonitorDetailViewModel> monitor = _healthCheckService.FindBy(x => x.MonitorId == id)
                .Select(x => new MonitorDetailViewModel
                {
                    Name = x.Monitor.DisplayName,
                    Url = x.Monitor.Url,
                    CheckDate = x.CheckDate,
                    IsSuccess = x.IsSuccess,
                    ResponseCode = x.ResponseCode,
                    ResponseMessage = x.ResponseMessage,
                    Status =(Status)x.Monitor.Status
                }).ToList();
            if (monitor == null)
            {
                return NotFound();
            }

            return View(monitor);
        }

        public IActionResult Create()
        {
            ViewData["AppUserId"] = UserId;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(MonitorViewModel monitor)
        {
            if (ModelState.IsValid)
            {
                Monitor entitiyMonitor = new Monitor
                {
                    Id = Guid.NewGuid(),
                    AppUserId=UserId,
                    Url=monitor.Url,
                    DisplayName=monitor.Name
                };

                _monitorService.Add(entitiyMonitor);
                _monitorService.Save();

                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = UserId;
            return View(monitor);
        }
        
        public  IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitor = _monitorService.FindBy(x => x.Id == id)
                 .Select(x => new MonitorViewModel
                 {
                     Id = x.Id,
                     Name = x.DisplayName,
                     Url = x.Url,
                     UserId = x.AppUserId
                 }).ToList();
            if (monitor == null)
            {
                return NotFound();
            }
            return View(monitor);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, MonitorViewModel monitor)
        {
            if (id != monitor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Monitor entitiyMonitor = new Monitor
                    {
                        Url = monitor.Url,
                        DisplayName = monitor.Name
                    };

                    _monitorService.Edit(entitiyMonitor);
                    _monitorService.Save();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "");
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = UserId;
            return View(monitor);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
              _monitorService.DeleteById(id);
            _monitorService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool MonitorExists(Guid id)
        {
            return _monitorService.FindBy(x=>x.Id==id).Any();
        }

    }
}
