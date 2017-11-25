using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Database;
using BiosManager.Models;

namespace BiosManager.Context.MSSQL
{
 public class MssqlReserveringContext : Database.Database, IReserveringContext
 {
  public void Insert(Reservering reservering)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();

    string query = "INSERT INTO dbo.reservering (Stoel_ID, datum, prijs) VALUES (@stoel, @datum, @prijs)";
    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.AddWithValue("@stoel", reservering.Stoelen);
    cmd.Parameters.AddWithValue("@datum", reservering.Datum);
    cmd.Parameters.AddWithValue("@prijs", reservering.Prijs);

    cmd.ExecuteNonQuery();
    conn.Close();
   }
  }

  public List<Reservering> Select()
  {
   return Database.Database.RunQuery(new Reservering());
  }

  public void Delete(Reservering reservering)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();

    string query = "DELETE FROM dbo.reservering WHERE id = (@id)";
    SqlCommand cmd = new SqlCommand(query, conn);
    cmd.Parameters.AddWithValue(@"id", reservering.Id);
    cmd.ExecuteNonQuery();
    conn.Close();
   }
  }
 }
}