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
        private readonly BigViewModel _viewModel = new BigViewModel();

        [HttpGet]
        public ActionResult Voorstelling(int filmId)
        {
            _viewModel.voorstellingen = _voorstellingRepository.SelectVoorstellingen(filmId);
            return View(_viewModel);
        }

        [HttpPost]
        public ActionResult Voorstelling(Voorstelling voorstelling)
        {
            return RedirectToAction("Reservering", "Reservering", voorstelling);
        }

    }
}