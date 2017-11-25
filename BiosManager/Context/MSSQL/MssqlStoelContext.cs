using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Models;

namespace BiosManager.Context.MSSQL
{
 public class MssqlStoelContext : Database.Database, IStoelContext
 {
  public void Insert(Stoel stoel)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();

    string query = "INSERT INTO dbo.stoel (rij, nummer, bezet) VALUES (@rij, @nummer, @bezet)";
    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.AddWithValue("@rij", stoel.Rij);
    cmd.Parameters.AddWithValue("@nummer", stoel.Nummer);
    cmd.Parameters.AddWithValue("@bezet", stoel.Bezet);
    cmd.ExecuteNonQuery();
    conn.Close();
   }
  }

  public List<Stoel> Select()
  {
   return Database.Database.RunQuery(new Stoel());
  }

  public void Update(Stoel stoel, bool bezet)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();

    string query = "UPDATE dbo.stoel (bezet) SET (@bezet) WHERE id = (@id)";
    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.AddWithValue("@bezet", bezet);
    cmd.Parameters.AddWithValue("@id", stoel.Id);
    cmd.ExecuteNonQuery();
    conn.Close();
   }
  }

  public void Delete(Stoel stoel)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();

    string query = "DELETE FROM dbo.stoel WHERE id = (@id)";
    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.AddWithValue("@id", stoel.Id);
    cmd.ExecuteNonQuery();
    conn.Close();
   }
  }
 }
}