﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.TMDb;
using System.Security.Policy;
using System.Web.Mvc;
using BiosManager.Context;
using BiosManager.Context.MSSQL;
using BiosManager.Models;
using BiosManager.Models.Enums;

namespace BiosManager.Repositories
{
 public class FilmRepository
 {
  private IFilmContext filmContext = new MssqlFilmContext();
  List<Film> films = new List<Film>();

  public FilmRepository(MssqlFilmContext context)
  {
   this.filmContext = context;
  }


  public List<Film> GetAllFilms()
  {
   filmContext.Select();
   return films;
  }


  public Film SelectFilm(int id)
  {
   Film film = (from f in filmContext.Select()
			 where f.Id.Equals(id)
			 select f).Single();
   return film;
  }
 }
}