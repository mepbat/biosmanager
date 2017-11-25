using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using BiosManager.Database;

namespace BiosManager.Models
{
 public class Stoel : IQuery
 {
  public int Id { get; set; }
  public int Rij { get; set; }
  public int Nummer { get; set; }
  public bool Bezet { get; set; }
  public string Query { get; set; }

  public Stoel()
  {
   Query = "SELECT * FROM dbo.stoel";
  }

  public void Parse(SqlDataReader reader)
  {
   Id = reader.GetInt32(reader.GetOrdinal("ID"));
   Rij = reader.GetInt32(reader.GetOrdinal("rij"));
   Nummer = reader.GetInt32(reader.GetOrdinal("nummer"));
   Bezet = reader.GetBoolean(reader.GetOrdinal("bezet"));
  }
 }
}