using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class TypeOfSeatController : Controller
    {
        private readonly PlaceService _placeService;

        public TypeOfSeatController(PlaceService placeService)
        {
            _placeService = placeService;
        }

        // GET: TypeOfSeatController
        public ActionResult Index()
        {
            return View(_placeService.GetTypeOfSeats());
        }

        // GET: TypeOfSeatController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _placeService.GetTypeOfSeatById(id));
        }

        // GET: TypeOfSeatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfSeatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeOfSeat typeOfSeat)
        {
            try
            {
                _placeService.AddTypeOfSeat(typeOfSeat.Name, typeOfSeat.Price);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeOfSeatController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _placeService.GetTypeOfSeatById(id));
        }

        // POST: TypeOfSeatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                _placeService.UpdateTypeOfSeat(id, collection["name"], double.Parse(collection["price"]));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeOfSeatController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _placeService.GetTypeOfSeatById(id));
        }

        // POST: TypeOfSeatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _placeService.DeleteTypeOfseat(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
