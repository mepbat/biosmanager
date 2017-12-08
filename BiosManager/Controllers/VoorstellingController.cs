using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiosManager.Context.MSSQL;
using BiosManager.Helpers;
using BiosManager.Models;
using BiosManager.Repositories;

namespace BiosManager.Controllers
{
    [Authorize]
    public class VoorstellingController : Controller
    {
        private readonly VoorstellingRepository _voorstellingRepository = new VoorstellingRepository(new MssqlVoorstellingContext());

        [HttpGet]
        public ActionResult Voorstelling(int filmId)
        {
            IEnumerable<Voorstelling> voorstellingList = _voorstellingRepository.SelectVoorstellingen(filmId);
            return View(new BigViewModel { Voorstellings = voorstellingList });
        }

        [HttpPost]
        public ActionResult Voorstelling(Voorstelling voorstelling)
        {
            return RedirectToAction("Reservering", "Reservering", voorstelling);
        }

    }
}