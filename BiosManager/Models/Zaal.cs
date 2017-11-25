using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Database;

namespace BiosManager.Models
{
 public class Zaal : IQuery
 {
  public int Id { get; set; }
  public List<Stoel> Stoelen { get; set; }
  public int Nummer { get; set; }
  public int Grootte { get; set; }
  public bool Bezig { get; set; }
  public string Query { get; set; }

  public Zaal()
  {
   Query = "SELECT * FROM dbo.zaal";
  }

  public void Parse(SqlDataReader reader)
  {
   Id = reader.GetInt32(reader.GetOrdinal("ID"));
   Nummer = reader.GetInt32(reader.GetOrdinal("nummer"));
   Grootte = reader.GetInt32(reader.GetOrdinal("grootte"));
   Bezig = reader.GetBoolean(reader.GetOrdinal("bezig"));
  }

 }
}