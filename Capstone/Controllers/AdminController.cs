using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using ApplicationLogger;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class AdminController : Controller
    {
        public IUserLogic adminLogic = new UserLogic(new UserDAO(new LoggerIO()), new SQLDAO(), new LoggerIO(), new Hashing());
        // GET: Admin
        public ActionResult Index()
        {
            List<UserVM> users = UserVM.Map(adminLogic.GetUsers());
            return View(users);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            UserVM user = UserVM.Map(adminLogic.GetUserById(id));
            ViewBag.UserId = user.userId;
            ViewBag.UserName = user.username;
            ViewBag.Admin = user.admin;
            ViewBag.User = user.user;
            ViewBag.PowerUser = user.poweruser;
            ViewBag.Street1 = user.street1;
            ViewBag.Street2 = user.street2;
            ViewBag.City = user.city;
            ViewBag.State = user.state;
            ViewBag.Zipcode = user.zipcode;
            return View(user);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(UserVM user)
        {
            try
            {
                adminLogic.CreateUser(UserVM.Map(user));    
                return RedirectToAction("Index","Admin");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            UserVM user = UserVM.Map(adminLogic.GetUserById(id));
            return View(user);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserVM user)
        {
            try
            {
                user.userId = id;
                user.password = UserVM.Map(adminLogic.GetUserById(id)).password;
                adminLogic.UpdateUser(UserVM.Map(user));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            UserVM user = UserVM.Map(adminLogic.GetUserById(id));
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserVM user)
        {
            try
            {
                adminLogic.DeleteUserById(id);
                return RedirectToAction("Index","Ad");
            }
            catch
            {
                return View();
            }
        }
    }
}
