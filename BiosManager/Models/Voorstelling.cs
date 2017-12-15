using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Database;

namespace BiosManager.Models
{
    public class Voorstelling
    {
        public int Id { get; set; }
        public Zaal Zl { get; set; }
        public Film Fl { get; set; }
        public DateTime Starttijd { get; set; }
        public DateTime Eindtijd { get; set; }

        public Voorstelling(int id, Zaal z, Film f, DateTime starttijd, DateTime eindtijd)
        {
            this.Id = id;
            this.Fl = f;
            this.Zl = z;
            this.Starttijd = starttijd;
            this.Eindtijd = eindtijd;
        }
    }
}