using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BiosManager.Models;
using BiosManager.Database;


namespace BiosManager.Context.MSSQL
{
 public class MssqlAccountContext : Database.Database, IAccountContext
 {
  public void Insert(Account account)
  {//TODO try catch
   try
   {
    using (SqlConnection conn = new SqlConnection(ConnectionString))
    {
	string query = "INSERT INTO dbo.account (email, wachtwoord, admin) VALUES (@email, @wachtwoord, @admin)";
	SqlCommand cmd = new SqlCommand(query);
	cmd.Parameters.AddWithValue("@email", account.Email);
	cmd.Parameters.AddWithValue("@wachtwoord", account.Wachtwoord);
	cmd.Parameters.AddWithValue("@admin", account.Admin);
	Database.Database.RunNonQuery(cmd);
    }
   }
   catch (SqlException e)
   {
    Console.WriteLine(e);
   }

  }

  public List<Account> Select()
  {
   try
   {
    return Database.Database.RunQuery(new Account());
   }
   catch (Exception e)
   {
    Console.WriteLine(e);
    return new List<Account>();
   }
  }

  public void Update(Account account, string nieuwWachtwoord)
  {
   try
   {
    using (SqlConnection conn = new SqlConnection(ConnectionString))
    {
	string query = "UPDATE dbo.account (wachtwoord) SET (@nieuwwachtwoord) WHERE id = (@id)";
	SqlCommand cmd = new SqlCommand(query);
	cmd.Parameters.AddWithValue("@nieuwwachtwoord", nieuwWachtwoord);
	cmd.Parameters.AddWithValue("@id", account.Id);
	Database.Database.RunNonQuery(cmd);
    }
   }
   catch (Exception e)
   {
    Console.WriteLine(e);

   }

  }

  public void Delete(Account account)
  {
   using (SqlConnection conn = new SqlConnection(ConnectionString))
   {
    conn.Open();

    string query = "DELETE FROM dbo.account WHERE id = (@id)";
    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.AddWithValue("@id", account.Id);
    cmd.ExecuteNonQuery();
    conn.Close();
   }
  }
 }
}