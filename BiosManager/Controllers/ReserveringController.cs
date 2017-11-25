using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiosManager.Models;

namespace BiosManager.Controllers
{
 public class ReserveringController : Controller
 {
  [HttpGet]
  public ActionResult Reservering()
  {
   return View();
  }

  [HttpPost]
  public ActionResult Reservering(Reservering reservering)
  {
   return View();
  }
 }
}