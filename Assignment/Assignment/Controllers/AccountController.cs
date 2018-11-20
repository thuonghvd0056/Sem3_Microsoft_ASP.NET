using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using(OurDbContext db = new OurDbContext())
            {
                return View(db.userAccounts.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using(OurDbContext db = new OurDbContext())
                {
                    db.userAccounts.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using(OurDbContext db = new OurDbContext())
            {
                var usr = db.userAccounts.Single(u => u.Name == user.Name && u.Password == user.Password);
                if(usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Name"] = usr.Name.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Name or Password wrong.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}