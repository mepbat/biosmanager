using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiosManager.Models;

namespace BiosManager.Helpers
{
 public class BigViewModel
 {
  public Film film { get; set; }
  public List<Voorstelling> voorstellingen { get; set; }
 }
}