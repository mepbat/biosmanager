using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiosManager.Context.MSSQL;
using BiosManager.Models;
using BiosManager.Repositories;

namespace BiosManager.Controllers
{
 public class ReserveringController : Controller
 {
  ReserveringRepository reserveringRepository = new ReserveringRepository(new MssqlReserveringContext());

  [HttpGet]
  public ActionResult Reservering(Film film, Voorstelling voorstelling)
  {
    Reservering reservering = new Reservering { Film = film, Voorstelling = voorstelling };
    return View("Reservering", "Reservering", reservering);
  }

  [HttpPost]
  public ActionResult Reservering(Reservering reservering)
  {
   return View();
  }
 }
}