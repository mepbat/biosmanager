using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiosManager.Models;

namespace BiosManager.Context
{
 public interface IReserveringContext
 {
	 void Insert(Reservering reservering);
	 List<Reservering> Select();
	 void Delete(Reservering reservering);
 }
}
