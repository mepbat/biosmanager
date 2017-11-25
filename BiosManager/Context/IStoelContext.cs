using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiosManager.Models;

namespace BiosManager.Context
{
 public interface IStoelContext
 {
  void Insert(Stoel stoel);
  List<Stoel> Select();
  void Update(Stoel stoel, bool bezet);
  void Delete(Stoel stoel);
 }
}
