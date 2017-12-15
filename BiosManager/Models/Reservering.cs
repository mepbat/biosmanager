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
 public class Reservering
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
 }
}