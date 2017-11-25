using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BiosManager.Context;
using BiosManager.Context.MSSQL;
using BiosManager.Managers;
using BiosManager.Models;
using BiosManager.Repositories;

namespace BiosManager.Controllers
{
 public class AccountController : Controller
 {
  private AccountRepository accountRepository = new AccountRepository(new MssqlAccountContext());

  [HttpPost]
  [ValidateAntiForgeryToken]
  public ActionResult Register(Account account)
  {
   if (!accountRepository.ValidEmail(account.Email))
   {
    ViewBag.Message = "Please enter a valid emailaddress";
    return View();
   }
   if (!accountRepository.ValidPassword(account.Wachtwoord))
   {
    ViewBag.Message2 = "Please enter a password with atleast 1 uppercase letter, 1 lowercase letter and 1 digit and has a lenght between 4 and 16 characters ";
    return View();
   }
   account.Wachtwoord = WachtwoordManager.Hash(account.Wachtwoord);
   account.Admin = false;
   accountRepository.AddAccount(account);
   return View("Login");
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public ActionResult Login(Account account)
  {
   account.Wachtwoord = WachtwoordManager.Hash(account.Wachtwoord);
   account = accountRepository.LoginAccount(account);
   if (account != null)
   {
    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, account.Id.ToString(), DateTime.Now, DateTime.Now.AddHours(1), false, "", FormsAuthentication.FormsCookiePath);
    HttpCookie c = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
    HttpContext.Response.Cookies.Add(c);
    return RedirectToAction("Films", "Film");
   }
   ViewBag.Message = "Incorrect email or password";
   return View();
  }

  [HttpGet]
  public ActionResult Login()
  {
   return View();
  }

  [HttpGet]
  public ActionResult Register()
  {
   return View();
  }
 }
}