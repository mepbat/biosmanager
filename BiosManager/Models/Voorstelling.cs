using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Database;

namespace BiosManager.Models
{
 public class Voorstelling : IQuery
 {
  public int Id { get; set; }
  public int Zaal { get; set; }
  public int FilmId { get; set; }
  public Film Film { get; set; }
  public DateTime Starttijd { get; set; }
  public DateTime Eindtijd { get; set; }
  public string Query { get; set; }


  public Voorstelling()
  {
   Query = "SELECT * FROM dbo.voorstelling";
  }

  public void Parse(SqlDataReader reader)
  {
   Id = reader.GetInt32(reader.GetOrdinal("ID"));
   Zaal = reader.GetInt32(reader.GetOrdinal("zaal_ID"));
   FilmId = reader.GetInt32(reader.GetOrdinal("film_ID"));
   Starttijd = reader.GetDateTime(reader.GetOrdinal("begintijd"));
   Eindtijd = reader.GetDateTime(reader.GetOrdinal("eindtijd"));
  }
 }
}