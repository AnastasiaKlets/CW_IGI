using BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class BuyTicketController : Controller
    {
        public readonly PerformanceService _performanceService;

        public BuyTicketController(PerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        public IActionResult Index()
        {
            var validSessions = _performanceService
                .GetSessions()
                .Where(e => e.Date >= DateTime.Now)
                .Select(e => e?.DTOPerformance.Id)
                .Distinct();
            var perf = validSessions.Select(e => _performanceService.GetPerformanceById((int)e));
            return View(perf);
        }

        public IActionResult Buy(int performanceId)
        {
            var vm = new Models.BuyViewModel(_performanceService)
            {
                pId = performanceId
            };

            return View(vm);
        }

        public IActionResult _PlaceSelection()
        {

            return View(new BLL.Service.SeatsSchema());
        }
    }
}
