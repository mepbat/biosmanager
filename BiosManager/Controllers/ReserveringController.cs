﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BiosManager.Context.MSSQL;
using BiosManager.Helpers;
using BiosManager.Models;
using BiosManager.Repositories;

namespace BiosManager.Controllers
{
    [Authorize]
    public class ReserveringController : Controller
    {
        ReserveringRepository _reserveringRepository = new ReserveringRepository(new MssqlReserveringContext());
        VoorstellingRepository _voorstellingRepository = new VoorstellingRepository(new MssqlVoorstellingContext());

        [HttpGet]
        public ActionResult Reservering(Voorstelling voor)
        {
            Voorstelling voorst = _voorstellingRepository.GetById(voor.Id);
            Account acc = new Account();
            TicketAuth auth = new TicketAuth();
            acc.Id = Convert.ToInt32(auth.Decrypt());
            Reservering res = new Reservering(voorst, acc);
            return View("Reservering", "Reservering", res);
        }

        [HttpPost]
        public ActionResult Reservering(Reservering reservering)
        {
            return View();
        }
    }
}