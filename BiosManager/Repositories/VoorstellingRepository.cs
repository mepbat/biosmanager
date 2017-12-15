using System.Collections.Generic;
using System.Linq;
using BiosManager.Context.MSSQL;
using BiosManager.Models;

namespace BiosManager.Repositories
{
    public class VoorstellingRepository
    {
        private readonly MssqlVoorstellingContext _voorstellingContext;


        public VoorstellingRepository(MssqlVoorstellingContext voorstellingContext)
        {
            this._voorstellingContext = voorstellingContext;
        }

        public List<Voorstelling> SelectVoorstellingen(int filmId)
        {
            List<Voorstelling> voorstellingen = (from f in _voorstellingContext.Select()
                                                 where f.Fl.Id.Equals(filmId)
                                                 select f).ToList();
            return voorstellingen;
        }
    }
}