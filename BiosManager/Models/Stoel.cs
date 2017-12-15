using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using BiosManager.Database;

namespace BiosManager.Models
{
    public class Stoel
    {
        public int Id { get; set; }
        public int Rij { get; set; }
        public int StoelNummer { get; set; }
        public bool Bezet { get; set; }

        public Stoel(int id, int rij, int stoelNummer, bool bezet)
        {
            this.Id = id;
            this.Rij = rij;
            this.StoelNummer = stoelNummer;
            this.Bezet = bezet;
        }
    }
}