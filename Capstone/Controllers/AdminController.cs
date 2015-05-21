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
    public class AdminController : Controller
    {
        public IUserLogic adminLogic = new UserLogic(new UserDAO(new LoggerIO()), new SQLDAO(), new LoggerIO(), new Hashing());

        // GET: User
        public ActionResult Index()
        {
            List<UserVM> users = UserVM.Map(adminLogic.GetUsers());
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            UserVM user = UserVM.Map(adminLogic.GetUserById(id));
            ViewBag.userId = user.UserId;
            ViewBag.username = user.Username;
            ViewBag.password = user.Password;
            ViewBag.secLvl = user.SecLvl;
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserVM user) //Creates a user
        {
            try
            {
                adminLogic.CreateUser((UserVM.Map(user)));
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception s)
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            UserVM user = UserVM.Map(adminLogic.GetUserById(id));
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
                user.Password = UserVM.Map(adminLogic.GetUserById(id)).Password;
                adminLogic.UpdateUser(UserVM.Map(user));
                return RedirectToAction("Index");
            }
            catch (Exception r)
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            UserVM user = UserVM.Map(adminLogic.GetUserById(id));
            //Session["DeleteId"] = user.UserId;
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(UserVM user, int id) //Deletes User
        {
            try
            {
                // TODO: Add delete logic here
                adminLogic.DeleteUserById(id);
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception z)
            {
                return View();
            }
        }
    }
}
