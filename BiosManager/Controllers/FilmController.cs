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
using BiosManager.Database;
using BiosManager.Helpers;
using BiosManager.Models;
using BiosManager.Models.Enums;
using BiosManager.Repositories;
using IMDb = IMDb_Scraper.IMDb;

namespace BiosManager.Controllers
{
    [Authorize]
    public class FilmController : Controller
    {
        private readonly FilmRepository _filmRepository = new FilmRepository(new MssqlFilmContext());
        private readonly FilmsGenresBigViewModel _model = new FilmsGenresBigViewModel();

        [HttpGet]
        public ActionResult Films()
        {
            _model.ListFilms =_filmRepository.GetAllFilms();
            _model.Genres = _filmRepository.GetAllGenres();
            return View(_model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Films(string gekozentype)
        {
            _model.Genres = _filmRepository.GetAllGenres();
            _model.ListFilms = _filmRepository.SelectFilmsMetGenre(gekozentype); ;
            return View(_model);
        }

        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            try
            {
                Film film = _filmRepository.SelectFilm(id);
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