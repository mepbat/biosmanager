using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Database;

namespace BiosManager.Models
{
 public class Zaal
 {
  public int Id { get; set; }
  public List<Stoel> Stoelen { get; set; }
  public int Nummer { get; set; }
  public int Grootte { get; set; }
  public bool Bezig { get; set; }
 }
}