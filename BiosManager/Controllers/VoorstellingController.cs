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
            List<Voorstelling> voorstellingList = new List<Voorstelling>();
            voorstellingList = _voorstellingRepository.SelectVoorstellingen(filmId);
            return View(voorstellingList);
        }

        [HttpGet]
        public ActionResult MaakRes(int voorstellingId)
        {
            Voorstelling voor = _voorstellingRepository.GetById(voorstellingId);
            return RedirectToAction("Reservering", "Reservering", voor);
        }

    }
}