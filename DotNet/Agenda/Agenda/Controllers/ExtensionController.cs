using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class ExtensionController : Controller
    {
        private smolEntities db = new smolEntities();

        //
        // GET: /Extension/

        public ActionResult Index()
        {
            var phoneexts = db.PhoneExts.Include(p => p.Deparment);
            return View(phoneexts.ToList());
        }

        //
        // GET: /Extension/Details/5

        public ActionResult Details(int id = 0)
        {
            PhoneExt phoneext = db.PhoneExts.Find(id);
            if (phoneext == null)
            {
                return HttpNotFound();
            }
            return View(phoneext);
        }

        //
        // GET: /Extension/Create

        public ActionResult Create()
        {
            ViewBag.Department = new SelectList(db.Deparments, "Id", "Name");
            return View();
        }

        //
        // POST: /Extension/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhoneExt phoneext)
        {
            if (ModelState.IsValid)
            {
                db.PhoneExts.Add(phoneext);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Department = new SelectList(db.Deparments, "Id", "Name", phoneext.Department);
            return View(phoneext);
        }

        //
        // GET: /Extension/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PhoneExt phoneext = db.PhoneExts.Find(id);
            if (phoneext == null)
            {
                return HttpNotFound();
            }
            ViewBag.Department = new SelectList(db.Deparments, "Id", "Name", phoneext.Department);
            return View(phoneext);
        }

        //
        // POST: /Extension/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhoneExt phoneext)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneext).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = new SelectList(db.Deparments, "Id", "Name", phoneext.Department);
            return View(phoneext);
        }

        //
        // GET: /Extension/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PhoneExt phoneext = db.PhoneExts.Find(id);
            if (phoneext == null)
            {
                return HttpNotFound();
            }
            return View(phoneext);
        }

        //
        // POST: /Extension/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneExt phoneext = db.PhoneExts.Find(id);
            db.PhoneExts.Remove(phoneext);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}