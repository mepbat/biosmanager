using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.TMDb;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls.WebParts;
using BiosManager.Context.MSSQL;
using BiosManager.Models;
using BiosManager.Models.Enums;
using BiosManager.Repositories;
using IMDb = IMDb_Scraper.IMDb;

namespace BiosManager.Controllers
{
 public class FilmController : Controller
 {
  private FilmRepository filmRepository = new FilmRepository(new MssqlFilmContext());
  [HttpGet]
  public ActionResult Films()
  {
   List<Film> filmList = Database.Database.RunQuery(new Film());
   var model = filmList;
   return View(model);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public ActionResult Films(Film film)
  {
   return View();
  }

  [HttpGet]
  public ActionResult Details(int id = 0)
  {
   try
   {
    Film film = filmRepository.SelectFilm(id);
    Details(film);
   }
   catch (Exception e)
   {
    Console.WriteLine(e);
    throw;
   }
   return View();
  }

  [HttpPost]
  public ActionResult Details(Film film)
  {
   return View("Details", film);
  }
 }
}