using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Dynamic;
using System.Web.ModelBinding;
using BiosManager.Database;

namespace BiosManager.Models
{
 public class Account : IQuery
 {
  public int Id { get; set; }
  public string Email { get; set; }
  public string Wachtwoord { get; set; }
  public bool Admin { get; set; }
  public string Query { get; set; }

  public Account()
  {
   Query = "SELECT * FROM dbo.account";
  }

  public void Parse(SqlDataReader reader)
  {
   Id = reader.GetInt32(reader.GetOrdinal("ID"));
   Email = reader.GetString(reader.GetOrdinal("email"));
   Wachtwoord = reader.GetString(reader.GetOrdinal("wachtwoord"));
   Admin = reader.GetBoolean(reader.GetOrdinal("admin"));
  }
 }
}