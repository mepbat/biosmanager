using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Models;

namespace BiosManager.Context.MSSQL
{
 public class MssqlVoorstellingContext : Database.Database, IVoorstellingContext
 {
  public void Insert(Voorstelling voorstelling)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();
    string query = "INSERT INTO dbo.voorstelling (naam, starttijd, eindtijd) VALUES (@naam, @starttijd, @eindtijd)";
    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.AddWithValue("@naam", voorstelling.Naam);
    cmd.Parameters.AddWithValue("@starttijd", voorstelling.Starttijd);
    cmd.Parameters.AddWithValue("@eindtijd", voorstelling.Eindtijd);
    cmd.ExecuteNonQuery();
    conn.Close();
   }
  }

  public List<Voorstelling> Select()
  {
   return Database.Database.RunQuery(new Voorstelling());
  }

  public void Delete(Voorstelling voorstelling)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();

    string query = "DELETE FROM dbo.voorstelling WHERE id = (@id)";
    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.AddWithValue("@id", voorstelling.Id);
    cmd.ExecuteNonQuery();
    conn.Close();
   }
  }
 }
}