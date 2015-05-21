using ApplicationLogger;
using BLL;
using DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpConsciousness.Controllers
{
    public class UserController : Controller
    {
        public IUserLogic userLogic = new UserLogic(new UserDAO(new LoggerIO()), new SQLDAO(), new LoggerIO(), new Hashing());

        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserVM user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userLogic.CreateUser((UserVM.Map(user)));
                    return RedirectToAction("Login");
                }
                return View(user);
            }
            catch (Exception v)
            {
                return View();
            }
        }
        // GET: User/Login

        public ActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Login(UserVM user)
        {
            UserVM tempUser = UserVM.Map(userLogic.GetUser(UserVM.Map(user)));
            if (userLogic.Login(UserVM.Map(tempUser)))
            {
                Session["userId"] = tempUser.userId;
                Session["username"] = tempUser.username;
                Session["user"] = tempUser.user;
                Session["poweruser"] = tempUser.poweruser;
                Session["admin"] = tempUser.admin;
                ViewBag.User = tempUser.username;
                if (tempUser.user == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (tempUser.poweruser == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (tempUser.admin == true)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }

        // GET: User/Login
        public ActionResult LogOut()
        {
            Session["userId"] = null;
            return RedirectToAction("Welcome", "Home");
        }
    }
}
