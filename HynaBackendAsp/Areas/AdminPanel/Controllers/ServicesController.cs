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
    public class ServicesController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: AdminPanel/Services
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        // GET: AdminPanel/Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: AdminPanel/Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Orderby,Name,Icon,Photo,Desc,Pdf,Doc,Text")] Service service,HttpPostedFileBase Photo,HttpPostedFileBase Icon)
        {
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
            string filename1 = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Icon.FileName;

            string path = Path.Combine(Server.MapPath("~/Upload"), filename);
            string path1 = Path.Combine(Server.MapPath("~/Upload"), filename1);


            Photo.SaveAs(path);
            Icon.SaveAs(path1);


            service.Photo = filename;
            service.Icon = filename1;

            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }

        // GET: AdminPanel/Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: AdminPanel/Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Id,Orderby,Name,Icon,Photo,Desc,Pdf,Doc,Text")]*/ Service service,HttpPostedFileBase Photo,HttpPostedFileBase Icon)
        {

            db.Entry(service).State = System.Data.Entity.EntityState.Modified;
            //db.Abouts.Attach(about);
            //db.Entry(about).Property(m => m.Photo).IsModified = true;
            if (Photo == null && Icon==null)
            {
                db.Entry(service).Property(m => m.Photo).IsModified = false;
                db.Entry(service).Property(m => m.Icon).IsModified = false;

            }
            else
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                string filename1 = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Icon.FileName;

                string path = Path.Combine(Server.MapPath("~/Upload"), filename);
                string path1 = Path.Combine(Server.MapPath("~/Upload"), filename1);


                Photo.SaveAs(path);
                Icon.SaveAs(path1);


                service.Photo = filename;
                service.Icon = filename1;
            }
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // GET: AdminPanel/Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: AdminPanel/Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Upload"), service.Photo));
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Upload"), service.Icon));
            db.Services.Remove(service);
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
