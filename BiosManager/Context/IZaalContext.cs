using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiosManager.Models;

namespace BiosManager.Context
{
 public interface IZaalContext
 {
  void Insert(Zaal zaal);
  List<Zaal> Select();
  void Delete(Zaal zaal);
 }
}
