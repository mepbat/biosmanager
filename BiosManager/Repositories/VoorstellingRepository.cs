using System.Collections.Generic;
using System.Linq;
using BiosManager.Context.MSSQL;
using BiosManager.Models;

namespace BiosManager.Repositories
{
 public class VoorstellingRepository
 {
  private MssqlVoorstellingContext _voorstellingContext;

  public VoorstellingRepository(MssqlVoorstellingContext voorstellingContext)
  {
   this._voorstellingContext = voorstellingContext;
  }

  public IEnumerable<Voorstelling> SelectVoorstellingen(int filmId)
  {
   IEnumerable<Voorstelling> voorstellingen = (from f in _voorstellingContext.Select()
									  where f.FilmId.Equals(filmId)
									  select f);
   return voorstellingen;
  }
 }
}