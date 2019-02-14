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
    public class PartnersController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: AdminPanel/Partners
        public ActionResult Index()
        {
            return View(db.Partners.ToList());
        }

        // GET: AdminPanel/Partners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // GET: AdminPanel/Partners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Partners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Url,Logo")] Partner partner,HttpPostedFileBase Logo)
        {
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Logo.FileName;
            string path = Path.Combine(Server.MapPath("~/Upload"), filename);

            Logo.SaveAs(path);

            partner.Logo = filename;
            if (ModelState.IsValid)
            {
                db.Partners.Add(partner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partner);
        }

        // GET: AdminPanel/Partners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // POST: AdminPanel/Partners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Id,Url,Logo")]*/ Partner partner,HttpPostedFileBase Logo)
        {
            db.Entry(partner).State = System.Data.Entity.EntityState.Modified;
            //db.Abouts.Attach(about);
            //db.Entry(about).Property(m => m.Photo).IsModified = true;
            if (Logo == null)
            {
                db.Entry(partner).Property(m => m.Logo).IsModified = false;
            }
            else
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Logo.FileName;
                string path = Path.Combine(Server.MapPath("~/Upload"), filename);

                Logo.SaveAs(path);

                partner.Logo = filename;
            }
            if (ModelState.IsValid)
            {
                db.Entry(partner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partner);
        }

        // GET: AdminPanel/Partners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // POST: AdminPanel/Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partner partner = db.Partners.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Upload"), partner.Logo));
            db.Partners.Remove(partner);
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
