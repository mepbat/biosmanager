using System.Linq;
using BiosManager.Context.MSSQL;
using BiosManager.Models;

namespace BiosManager.Repositories
{
 public class ReserveringRepository
 {
  private MssqlReserveringContext _reserveringContext;
  public ReserveringRepository(MssqlReserveringContext reserveringContext)
  {
   this._reserveringContext = reserveringContext;
  }
  public void AddTickets()
  {

  }
 }
}