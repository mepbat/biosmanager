﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BiosManager.Context;
using BiosManager.Models;
using Microsoft.Ajax.Utilities;

namespace BiosManager.Repositories
{
 public class AccountRepository
 {
  IAccountContext context;

  public AccountRepository(IAccountContext context)
  {
   this.context = context;
  }

  public bool ValidEmail(string email)
  {
   string mailregex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
   if (Regex.IsMatch(email, mailregex))
   {
    return true;
   }
   return false;
  }

  public bool ValidPassword(string password)
  {
   string passregex = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,16}$";
   if (Regex.IsMatch(password, passregex))
   {
    return true;
   }
   return false;
  }

  public List<Account> SelectAccounts()
  {
   List<Account> accounts = new List<Account>();
   this.context.Select();
   return accounts;
  }

  public void AddAccount(Account account)
  {
   this.context.Insert(account);
  }

  public void UpdateAccount(Account account, string nieuwWachtwoord)
  {
   context.Update(account, nieuwWachtwoord);
  }

  public Account LoginAccount(Account account)
  {
   try
   {
    Account accounts = (from acc in context.Select()
				    where acc.Email.Equals(account.Email)
						&& acc.Wachtwoord.Equals(account.Wachtwoord)
				    select acc).Single();
    return accounts;
   }
   catch (InvalidOperationException)
   {
    return null;

   }
  }

  public bool CheckAdminAccount(Account account)
  {
   try
   {
    Account accounts = (from acc in context.Select()
				    where acc.Email.Equals(account.Email)
						&& acc.Wachtwoord.Equals(account.Wachtwoord)
				    select acc).Single();
    return accounts.Admin;
   }
   catch (Exception ex)
   {
    if (ex is ArgumentNullException || ex is NullReferenceException)
    {
	return false;
    }
   }
   return false;
  }

  public int LoginId(Account account)
  {
   try
   {
    Account accountId = (from acc in context.Select()
					where acc.Email.Equals(account.Email)
						 && acc.Wachtwoord.Equals(account.Wachtwoord)
					select acc).Single();
    return accountId.Id;
   }
   catch (Exception e)
   {
    Console.WriteLine(e);
    throw;
   }
  }
 }
}