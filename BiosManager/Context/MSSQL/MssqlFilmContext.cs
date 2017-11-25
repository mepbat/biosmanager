using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Database;
using BiosManager.Models;

namespace BiosManager.Context.MSSQL
{
 public class MssqlFilmContext : Database.Database, IFilmContext
 {
  public void Insert(Film film)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();

    string query = "INSERT INTO dbo.film (naam, beschrijving, lengte, rating) VALUES (@naam, @beschrijving, @lengte, @rating)";
    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.AddWithValue("@naam", film.Naam);
    cmd.Parameters.AddWithValue("@beschrijving", film.Beschrijving);
    cmd.Parameters.AddWithValue("@lengte", film.Lengte);
    cmd.Parameters.AddWithValue("@rating", film.Rating);

    cmd.ExecuteNonQuery();
    conn.Close();
   }
  }

  public List<Film> Select()
  {
   return Database.Database.RunQuery(new Film());
  }

  public void Delete(Film film)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();
    string query = "DELETE FROM dbo.film WHERE id = (@id)";
    SqlCommand cmd = new SqlCommand(query, conn);
    cmd.Parameters.AddWithValue(@"id", film.Id);
    cmd.ExecuteNonQuery();
    conn.Close();
   }
  }
 }
}