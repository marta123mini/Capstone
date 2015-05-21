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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            UserVM user = UserVM.Map(userLogic.GetUserById(id));
            //Session["EditId"] = user.UserId;
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserVM user, int id) //Edits a User
        {
            try
            {
                //user.UserId = (int)Session["EditId"];
                user.UserId = id;
                user.Password = UserVM.Map(userLogic.GetUserById(id)).Password;
                userLogic.UpdateUser(UserVM.Map(user));
                return RedirectToAction("Index");
            }
            catch (Exception r)
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
        [HttpPost] //data annotation
        public ActionResult Login(UserVM user)
        {
            UserVM tempUser = UserVM.Map(userLogic.GetUser(UserVM.Map(user)));
            if (userLogic.Login(UserVM.Map(tempUser)))
            {
                Session["UserId"] = tempUser.UserId;
                Session["Role"] = tempUser.SecLvl;
                //ViewBag.user = tempUser.username; <- what do ?
                if(tempUser.SecLvl == null)
                {
                    return RedirectToAction("Index", "Welcome");
                }
                else if (tempUser.SecLvl == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (tempUser.SecLvl == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (tempUser.SecLvl == 3)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }

        // GET: User/Login
        public ActionResult LogOut()
        {
            Session["UserId"] = null;
            return RedirectToAction("Welcome", "Home");
        }
    }
}
