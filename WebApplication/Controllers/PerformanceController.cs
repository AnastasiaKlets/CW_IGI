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

        public PerformanceController(PerformanceService perfomanceServise)
        {
            _perfomanceServise = perfomanceServise;
        }

        public IActionResult ListPerformance()
        {
            return View(_perfomanceServise.GetPerformances());
        }
       

        public IActionResult DeletePerformance(int Id)
        {
            _perfomanceServise.DeletePerformance(_perfomanceServise.GetPerformanceById(Id));
            return RedirectToAction(nameof(this.ListPerformance));
        }

        [HttpPost]
        public async Task<IActionResult> AddPerformance(AddPerformanceViewModel viewModel)
        {//Логика
            await _perfomanceServise.AddPerformance(viewModel.Name, viewModel.Duration, viewModel.Genres?.Select(e => e?.ToDTOGenre()), viewModel.Actors?.Select(e => e?.ToDTOActor()), viewModel.AgeQualification?.ToDTOAgeQualification(), viewModel.Description);
            return RedirectToAction(nameof(this.ListPerformance));
        }

        //[HttpPost]
        //public async Task<IActionResult> AddPerformance(BLL.DTO.DTOPerformance viewModel)
        //{//Логика
        //    await _perfomanceServise.AddPerformance(viewModel.Name, viewModel.Duration, viewModel.DTOGenres, viewModel.DTOActors, viewModel.DTOAgeQualification, viewModel.Description);
        //    return RedirectToAction(nameof(this.ListPerformance));
        //}
    }
}
