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
  public string Naam { get; set; }
  public DateTime Starttijd { get; set; }
  public DateTime Eindtijd { get; set; }
  public string Query { get; set; }


  public Voorstelling()
  {
   Query = "SELECT * FROM dbo.voorstelling";
  }

  public void Parse(SqlDataReader reader)
  {
   Id = reader.GetInt32(reader.GetOrdinal("Id"));
   Naam = reader.GetString(reader.GetOrdinal("naam"));
   Starttijd = reader.GetDateTime(reader.GetOrdinal("starttijd"));
   Eindtijd = reader.GetDateTime(reader.GetOrdinal("eindtijd"));
  }

 }
}