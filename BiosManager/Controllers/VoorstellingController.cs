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
 public class VoorstellingController : Controller
 {
  private VoorstellingRepository voorstellingRepository = new VoorstellingRepository(new MssqlVoorstellingContext());

  [HttpGet]
  public ActionResult Voorstelling(int filmId)
  {
   try
   {
    IEnumerable<Voorstelling> voorstellingList = voorstellingRepository.SelectVoorstellingen(filmId);
    return View(new BigViewModel { Voorstellings = voorstellingList });
   }
   catch (Exception e)
   {
    Console.WriteLine(e);
    throw;
   }
   return View();
  }

  [HttpPost]
  public ActionResult Voorstelling(Voorstelling voorstelling)
  {
   return RedirectToAction("Reservering", "Reservering", voorstelling);
  }

 }
}