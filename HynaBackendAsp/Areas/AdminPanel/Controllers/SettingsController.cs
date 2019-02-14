using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HynaBackendAsp.DAL;
using HynaBackendAsp.Models;

namespace HynaBackendAsp.Areas.AdminPanel.Controllers
{
    public class SettingsController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: AdminPanel/Settings
        public ActionResult Index()
        {
            return View(db.Settings.ToList());
        }

        // GET: AdminPanel/Settings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // GET: AdminPanel/Settings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Settings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Logo,Phone,Email,Address,Facebook,Youtube,Instagram,Lat,Lng")] Setting setting,HttpPostedFileBase Logo)
        {
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Logo.FileName;
            string path = Path.Combine(Server.MapPath("~/Upload"), filename);

            Logo.SaveAs(path);

            setting.Logo = filename;
            if (ModelState.IsValid)
            {
                db.Settings.Add(setting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setting);
        }

        // GET: AdminPanel/Settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: AdminPanel/Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Id,Logo,Phone,Email,Address,Facebook,Youtube,Instagram,Lat,Lng")] */Setting setting,HttpPostedFileBase Logo)
        {
            db.Entry(setting).State = System.Data.Entity.EntityState.Modified;
            //db.Abouts.Attach(about);
            //db.Entry(about).Property(m => m.Photo).IsModified = true;
            if (Logo == null)
            {
                db.Entry(setting).Property(m => m.Logo).IsModified = false;
            }
            else
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Logo.FileName;
                string path = Path.Combine(Server.MapPath("~/Upload"), filename);

                Logo.SaveAs(path);

                setting.Logo = filename;
            }
            if (ModelState.IsValid)
            {
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setting);
        }

        // GET: AdminPanel/Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: AdminPanel/Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Setting setting = db.Settings.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Upload"), setting.Logo));
            db.Settings.Remove(setting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
