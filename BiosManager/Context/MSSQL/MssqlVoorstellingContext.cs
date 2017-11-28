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
   try
   {
    using (SqlConnection conn = new SqlConnection(ConnectionString))
    {
	string query = "INSERT INTO dbo.voorstelling (zaal_ID, begintijd, eindtijd) VALUES (@zaal, @begintijd, @eindtijd)";
	SqlCommand cmd = new SqlCommand(query);

	cmd.Parameters.AddWithValue("@zaal", voorstelling.Zaal);
	cmd.Parameters.AddWithValue("@begintijd", voorstelling.Starttijd);
	cmd.Parameters.AddWithValue("@eindtijd", voorstelling.Eindtijd);
	Database.Database.RunNonQuery(cmd);
    }
   }
   catch (Exception e)
   {
    Console.WriteLine(e);
    throw;
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