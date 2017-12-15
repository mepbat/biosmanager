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
 public class Account
 {
  public int Id { get; set; }
  public string Email { get; set; }
  public string Wachtwoord { get; set; }
  public bool Admin { get; set; }
 }
}