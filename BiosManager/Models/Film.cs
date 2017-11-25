using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BiosManager.Database;

namespace BiosManager.Models
{
 public class Film : IQuery
 {
  public int Id { get; set; }
  public string Naam { get; set; }
  public string Beschrijving { get; set; }
  public string Genres { get; set; }
  public int Lengte { get; set; }
  public decimal Rating { get; set; }
  public Image Image { get; set; }
  public string Query { get; set; }
  public int Jaar { get; set; }
  public IEnumerable<SelectListItem> ActionsList { get; set; }

  public Film()
  {
   ActionsList = new List<SelectListItem>();
   Query = "SELECT * FROM dbo.film";
  }

  public void Parse(SqlDataReader reader)
  {
   Id = reader.GetInt32(reader.GetOrdinal("ID"));
   Naam = reader.GetString(reader.GetOrdinal("naam"));
   Genres =  reader.GetString(reader.GetOrdinal("genre"));
   Beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
   Lengte = reader.GetInt32(reader.GetOrdinal("lengte"));
   Rating = reader.GetDecimal(reader.GetOrdinal("rating"));
  }
 }
}