using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class AgeQualificationController : Controller
    {


        private readonly PerformanceService _performanceService;

        public AgeQualificationController(PerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        // GET: AgeQualificationController
        public ActionResult Index()
        {
            return View(_performanceService.GetAgeQualification());
        }

        // GET: AgeQualificationController/Details/5
        public async  Task<ActionResult> Details(int id)
        {
            return View(await _performanceService.GetAgeQualificationById(id));
        }

        // GET: AgeQualificationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgeQualificationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _performanceService.AddAgeQulification(collection["name"]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgeQualificationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _performanceService.GetAgeQualificationById(id));
        }

        // POST: AgeQualificationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                _performanceService.UpdateAgeQualification(id, collection["name"]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgeQualificationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgeQualificationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _performanceService.DeleteAgeQulification(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
