using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Models;

namespace BiosManager.Context.MSSQL
{
 public class MssqlZaalContext : Database.Database, IZaalContext
 {
  public void Insert(Zaal zaal)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();

    string query = "INSERT INTO dbo.zaal (nummer, grootte) VALUES (@nummer, @grootte)";
    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.AddWithValue("@email", zaal.Nummer);
    cmd.Parameters.AddWithValue("@wachtwoord", zaal.Grootte);
    cmd.ExecuteNonQuery();
    conn.Close();
   }

  }

  public List<Zaal> Select()
  {
   return Database.Database.RunQuery(new Zaal());
  }

  public void Delete(Zaal zaal)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();

    string query = "DELETE FROM dbo.zaal WHERE id = (@id)";
    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.AddWithValue("@id", zaal.Id);
    cmd.ExecuteNonQuery();
    conn.Close();
   }
  }
 }
}