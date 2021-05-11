using BLL;
using BLL.DTO;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using BLL.DTO.Converters;

namespace WebApplication.Controllers
{
    public class PerformanceController : Controller
    {
        private readonly PerformanceService _perfomanceServise;
        private readonly TicketSirvice _ticketSirvice;
        private readonly UserService _userService;

        public PerformanceController(PerformanceService perfomanceServise, TicketSirvice ticketSirvice, UserService userService)
        {
            _perfomanceServise = perfomanceServise;
            _ticketSirvice = ticketSirvice;
            _userService = userService;
        }

        public IActionResult ListPerformance()
        {
            return View(_perfomanceServise.GetPerformances());
        }


        public IActionResult AddPerformance()
        {
            return View(new AddPerformanceViewModel());
        }
        public IActionResult EditPerformance(int Id)
        {
            return View(_perfomanceServise.GetPerformanceById(Id));
        }
        public IActionResult DeletePerformance(int Id)
        {
            _perfomanceServise.DeletePerformance(_perfomanceServise.GetPerformanceById(Id));
            return RedirectToAction(nameof(this.ListPerformance));
        }

        public IActionResult ViewPerformances()
        {
            return View("_PerformancesList", _perfomanceServise.GetPerformances());
        }

        public IActionResult GetSessionsById(int id)
        {
            var cntrl = new Models.GetPerfomenceDecriptionViewModel(_perfomanceServise.GetPerformanceById(id), _perfomanceServise.GetSessionsByPerformanceId(id));

            return View("GetPerformanceDescription", cntrl);
        }

        [HttpPost]
        public IActionResult BuyTicketForm(string BuyerName, string BuyerEmail, string BuyerPerformance, string Text)
        {
            //TODO: добавить обработку

            return RedirectToAction();
        }

        [HttpPost]
        public IActionResult GetPerformanceByDate(DateTime searchDate)
        {
            //TODO: добавить обработку
            var performances = _perfomanceServise
                .GetPerformances()
                .Where(e => (bool)e?.DTOSessions
                .Any(s => s?.Date >= searchDate && s?.Date <= searchDate.AddDays(1)));

            return View("_PerformancesList", performances);
        }
        [HttpPost]
        public async Task<IActionResult> AddPerformance(AddPerformanceViewModel viewModel)
        {//Логика
            await _perfomanceServise.AddPerformance(viewModel.Name, viewModel.Duration, viewModel.Genres?.Select(e => e?.ToDTOGenre()), viewModel.Actors?.Select(e => e?.ToDTOActor()), viewModel.AgeQualification?.ToDTOAgeQualification(), viewModel.Description);
            return RedirectToAction(nameof(this.ListPerformance));
        }

        [HttpPost]
        public IActionResult EditPerformance(DTOPerformance viewModel)
        {//Логика
            _perfomanceServise.UpdatePerformance(viewModel.Id, viewModel.Name, viewModel.Duration, viewModel.DTOGenres, viewModel.DTOActors, viewModel.DTOAgeQualification, viewModel.Description);
            return RedirectToAction(nameof(this.ListPerformance));
        }

        [HttpGet]
        public IActionResult GetTicketHistoryByUser()
        {
            var a = User.Identity.Name;
            if (a?.Length > 0)
            {
                var user = _userService.GetUsers().FirstOrDefault(e => e.Login == a);
                var tickets = _ticketSirvice.GetTicketsByUserId((int)user?.Id);
                return View("UserTicketList", tickets);
            }
            else
                return Redirect("/");

        }
    }
}
