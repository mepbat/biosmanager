using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using BiosManager.Database;

namespace BiosManager.Models
{
 public class Stoel
 {
  public int Id { get; set; }
  public int Rij { get; set; }
  public int Nummer { get; set; }
  public bool Bezet { get; set; }
 }
}