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
        public Zaal Zaal { get; set; }
        public int ZaalNummer { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public DateTime Starttijd { get; set; }
        public DateTime Eindtijd { get; set; }
    }
}