using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BLL;
using DAL;
using ApplicationLogger;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class GuestListController : Controller
    {
        private IGuestLogic guestLogic = new GuestLogic(new GuestDAO(new LoggerIO()), new SQLDAO(), new LoggerIO());
        private GuestVM guestModel = new GuestVM();
        // GET: Guest
        public ActionResult Index()
        {
            return View(guestLogic.GetAllGuests());
        }

        // GET: Guest/Details/5
        public ActionResult Details(int id)
        {
            return View(guestLogic.GetGuestById(id));
        }

        // GET: Guest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guest/Create
        [HttpPost]
        public ActionResult Create(GuestVM newGuest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    guestLogic.CreateGuest(guestModel.Map(newGuest));

                    return RedirectToAction("Index");
                }
                return View(newGuest);
            }
            catch
            {
                return View(newGuest);
            }
        }

        // GET: Guest/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestVM findGuest = guestModel.Map(guestLogic.GetGuestById(id));
            if (findGuest==null)
            {
                return HttpNotFound();
            }
            return View(findGuest);
        }

        // POST: Guest/Edit/5
        [HttpPost]
        public ActionResult Edit( GuestVM guest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    guestLogic.UpdateGuest(guestModel.Map(guest));
                    return RedirectToAction("Index");
                }
                return View(guest);
            }
            catch
            {
                return View(guest);
            }
        }

        // GET: Guest/Delete/5
        public ActionResult Delete(GuestVM guest, int id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            GuestVM findGuest = guestModel.Map(guestLogic.GetGuestById(id));
            if (findGuest==null)
            {
                return HttpNotFound();
            }
            return View(findGuest);
        }

        // POST: Guest/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                guestLogic.DeleteGuestById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
