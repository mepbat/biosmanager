using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Linq;
using System.Web;
using BiosManager.Database;

namespace BiosManager.Models
{
 public class Reservering : IQuery
 {
  public int Id { get; set; }
  public List<Stoel> Stoelen { get; set; }
  public DateTime Datum { get; set; }
  public SqlMoney Prijs { get; set; }
  public bool Betaald { get; set; }
  public Film Film { get; set; }
  public int VoorstellingId { get; set; }
  public int AccountId { get; set; }
  public Voorstelling Voorstelling { get; set; }
  public string Query { get; set; }

  public Reservering()
  {
   Query = "SELECT * FROM dbo.reservering";
  }

  public void Parse(SqlDataReader reader)
  {
   Id = reader.GetInt32(reader.GetOrdinal("ID"));
   AccountId = reader.GetInt32(reader.GetOrdinal("account_ID"));
   VoorstellingId = reader.GetInt32(reader.GetOrdinal("voorstelling_ID"));
   Datum = reader.GetDateTime(reader.GetOrdinal("datum"));
   Prijs = reader.GetSqlMoney(reader.GetOrdinal("prijs"));
  }
 }
}