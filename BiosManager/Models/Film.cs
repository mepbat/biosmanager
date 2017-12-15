using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BiosManager.Database;
using BiosManager.Models.Enums;

namespace BiosManager.Models
{
 public class Film
 {
  public int Id { get; set; }
  public string Naam { get; set; }
  public string Beschrijving { get; set; }
  public string Genres { get; set; }
  public List<FilmType> ListGenres { get; set; }
  public int Lengte { get; set; }
  public decimal Rating { get; set; }
  public Image Image { get; set; }
  public int Jaar { get; set; }
 }
}