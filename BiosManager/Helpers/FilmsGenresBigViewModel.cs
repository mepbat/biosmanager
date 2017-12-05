using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiosManager.Models;
using BiosManager.Models.Enums;

namespace BiosManager.Helpers
{
 public class FilmsGenresBigViewModel
 {
  public List<Film> ListFilms { get; set; }
  public List<FilmType> Genres { get; set; }
  public string GekozenType { get; set; }
 }
}