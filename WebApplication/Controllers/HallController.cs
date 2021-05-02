using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class HallController : Controller
    {
        private readonly PlaceService _placeService;

        public HallController(PlaceService placeService)
        {
            _placeService = placeService;
        }

        // GET: HallController
        public ActionResult Index()
        {
            return View(_placeService.GetHalls());
        }

        // GET: HallController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _placeService.GetHallById(id));
        }

        // GET: HallController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HallController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _placeService.AddHall(collection["type"]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HallController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            
            return View(await _placeService.GetHallById(id));
        }

        // POST: HallController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                _placeService.UpdateHall(id,collection["type"]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HallController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _placeService.GetHallById(id));
        }

        // POST: HallController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _placeService.DeleteHall(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
