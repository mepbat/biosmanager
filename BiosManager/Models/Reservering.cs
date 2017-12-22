using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Linq;
using System.Web;
using BiosManager.Database;

namespace BiosManager.Models
{
    public class Reservering
    {
        public int Id { get; set; }
        public List<Stoel> Stoelen { get; set; }
        public SqlMoney Prijs { get; set; }
        public bool Betaald { get; set; }
        public Account Acc { get; set; }
        public Voorstelling Voorstelling { get; set; }

        public Reservering(int id, Voorstelling v, Account acc)
        {
            this.Id = id;
            this.Voorstelling = v;
            this.Acc = acc;
        }

        public Reservering(Voorstelling v, Account acc)
        {
            this.Voorstelling = v;
            this.Acc = acc;
        }
    }
}