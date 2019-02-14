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
    public class ProjectsController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: AdminPanel/Projects
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        // GET: AdminPanel/Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: AdminPanel/Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Text,Photo")] Project project,HttpPostedFileBase Photo)
        {
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
            string path = Path.Combine(Server.MapPath("~/Upload"), filename);

            Photo.SaveAs(path);
            project.Photo = filename;
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: AdminPanel/Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: AdminPanel/Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Id,Name,Text,Photo")]*/ Project project,HttpPostedFileBase Photo)
        {
            db.Entry(project).State = System.Data.Entity.EntityState.Modified;
            
            if (Photo == null)
            {
                db.Entry(project).Property(m => m.Photo).IsModified = false;
            }
            else
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Upload"), filename);

                Photo.SaveAs(path);

                project.Photo = filename;
            }
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: AdminPanel/Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: AdminPanel/Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Upload"), project.Photo));
            db.Projects.Remove(project);
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
