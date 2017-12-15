using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BiosManager.Context.MSSQL;
using BiosManager.Models;
using BiosManager.Repositories;

namespace BiosManager.Controllers
{
    [Authorize]
    public class ReserveringController : Controller
    {
        ReserveringRepository _reserveringRepository = new ReserveringRepository(new MssqlReserveringContext());

        [HttpGet]
        public ActionResult Reservering(Voorstelling voorstelling)
        {
            Account acc = new Account {Id = Convert.ToInt32(Request.Cookies[FormsAuthentication.FormsCookieName])};
            Reservering res = new Reservering(voorstelling, acc);
            return View("Reservering", "Reservering",res);
        }

        [HttpPost]
        public ActionResult Reservering(Reservering reservering)
        {
            return View();
        }
    }
}