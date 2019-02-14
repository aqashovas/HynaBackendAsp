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
    public class SlidersController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: AdminPanel/Sliders
        public ActionResult Index()
        {
            return View(db.Sliders.ToList());
        }

        // GET: AdminPanel/Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: AdminPanel/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tittle,Slogan,More_url,More_text")] Slider slider,HttpPostedFileBase Slogan)
        {
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Slogan.FileName;
            string path = Path.Combine(Server.MapPath("~/Upload"), filename);

            Slogan.SaveAs(path);

            slider.Slogan = filename;
            if (ModelState.IsValid)
            {
                db.Sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: AdminPanel/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: AdminPanel/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Id,Tittle,Slogan,More_url,More_text")]*/ Slider slider,HttpPostedFileBase Slogan)
        {
            db.Entry(slider).State = System.Data.Entity.EntityState.Modified;
            //db.Abouts.Attach(about);
            //db.Entry(about).Property(m => m.Photo).IsModified = true;
            if (Slogan == null)
            {
                db.Entry(slider).Property(m => m.Slogan).IsModified = false;
            }
            else
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Slogan.FileName;
                string path = Path.Combine(Server.MapPath("~/Upload"), filename);

                Slogan.SaveAs(path);

                slider.Slogan = filename;
            }
            if (ModelState.IsValid)
            {
                db.Entry(slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: AdminPanel/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: AdminPanel/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Sliders.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Upload"), slider.Slogan));
            db.Sliders.Remove(slider);
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
