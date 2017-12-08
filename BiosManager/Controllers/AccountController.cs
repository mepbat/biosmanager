using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BiosManager.Context;
using BiosManager.Context.MSSQL;
using BiosManager.Helpers;
using BiosManager.Managers;
using BiosManager.Models;
using BiosManager.Repositories;

namespace BiosManager.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private AccountRepository accountRepository = new AccountRepository(new MssqlAccountContext());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account account)
        {
            if (account == null)
            {
                return View();
            }
            if (!accountRepository.ValidEmail(account.Email) || !accountRepository.ValidPassword(account.Wachtwoord))
            {
                ViewBag.Message = "Please enter a valid emailaddress and a password with atleast 1 uppercase letter, 1 lowercase letter and 1 digit and has a lenght between 4 and 16 characters";
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
            TicketAuth ticket = new TicketAuth();
            if (account.Email == null || account.Wachtwoord == null)
            {
                ViewBag.Message = "Please fill in an email and password.";
                return View();
            }
            account.Wachtwoord = WachtwoordManager.Hash(account.Wachtwoord);
            account = accountRepository.LoginAccount(account);
            if (account != null)
            {
                int accId = accountRepository.LoginId(account);
                account.Id = accId;
                HttpCookie c = ticket.Encrypt(accId.ToString());
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