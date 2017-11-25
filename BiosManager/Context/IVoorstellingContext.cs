using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiosManager.Models;

namespace BiosManager.Context
{
 public interface IVoorstellingContext
 {
  void Insert(Voorstelling voorstelling);
  List<Voorstelling> Select();
  void Delete(Voorstelling voorstelling);
 }
}
