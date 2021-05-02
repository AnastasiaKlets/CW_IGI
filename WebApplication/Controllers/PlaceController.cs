using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PlaceController : Controller
    {
        private readonly PlaceService _placeService;

        public PlaceController(PlaceService placeService)
        {
            _placeService = placeService;
        }

        // GET: PlaceController
        public ActionResult Index()
        {
            return View(_placeService.GetPlace());
        }

        // GET: PlaceController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _placeService.GetPlaceById(id));
        }

        // GET: PlaceController/Create
        public ActionResult Create()
        {
            return View(new CreatePlaceViewModel()
            {

                typeOfSeats = _placeService.GetTypeOfSeats(),
                halls = _placeService.GetHalls(),
            });
        }

        // POST: PlaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _placeService.AddPlace(int.Parse(collection["hallId"]),int.Parse( collection["row"]), int.Parse( collection["typeOfSeatId"]));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaceController/Edit/5
        public async Task< ActionResult> Edit(int id)
        {
            var dop = await _placeService.GetPlaceById(id);
            return View(new EditPlaceViewModel() 
            {
                typeOfSeats = _placeService.GetTypeOfSeats(),
                halls = _placeService.GetHalls(),    
                row = dop.Row,
                id = dop.Id,
                hall = dop.Hall,
                typeOfSeat =dop.TypeOfSeat,
                
            });
        }

        // POST: PlaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                _placeService.UpdatePlace(id, int.Parse(collection["hallId"]), int.Parse(collection["row"]), int.Parse(collection["typeOfSeatId"]));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_placeService.GetPlaceById(id).Result);
        }

        // POST: PlaceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _placeService.DeletePlace(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
