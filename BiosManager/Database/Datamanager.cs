using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiosManager.Models;

namespace BiosManager.Database
{
 public static class Datamanager
 {
  public static List<Account> AccList;
  public static List<Film> FilmList;
  public static List<Reservering> ResList;
  public static List<Stoel> StoelList;
  public static List<Voorstelling> VoorstellingList;
  public static List<Zaal> ZaalList;

  public static void Initialize()
  {
   AccList = Database.RunQuery(new Account());
   FilmList = Database.RunQuery(new Film());
   ResList = Database.RunQuery(new Reservering());
   StoelList = Database.RunQuery(new Stoel());
   VoorstellingList = Database.RunQuery(new Voorstelling());
   ZaalList = Database.RunQuery(new Zaal());
  }
 }
}