using BLL.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class SessionController : Controller
    {
        private readonly PlaceService _sessionServise;

        public SessionController(PlaceService sessionServise)
        {
            _sessionServise = sessionServise;
        }

        //public IActionResult Index()
        //{
        //    return View(_sessionServise.GetSessions());
        //}

    }
}
