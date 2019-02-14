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
    public class BlogsController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: AdminPanel/Blogs
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Author).Include(b => b.Category);
            return View(blogs.ToList());
        }

        // GET: AdminPanel/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: AdminPanel/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Fullname");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: AdminPanel/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tittle,Date,Desc,Photo,Text,CategoryId,AuthorId")] Blog blog,HttpPostedFileBase Photo)
        {
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
            string path = Path.Combine(Server.MapPath("~/Upload"), filename);

            Photo.SaveAs(path);

            blog.Photo = filename;
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Fullname", blog.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", blog.CategoryId);
            return View(blog);
        }

        // GET: AdminPanel/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Fullname", blog.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", blog.CategoryId);
            return View(blog);
        }

        // POST: AdminPanel/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog,HttpPostedFileBase Photo)
        {
            db.Entry(blog).State = System.Data.Entity.EntityState.Modified;
            //db.Abouts.Attach(about);
            //db.Entry(about).Property(m => m.Photo).IsModified = true;
            if (Photo == null)
            {
                db.Entry(blog).Property(m => m.Photo).IsModified = false;
            }
            else
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Upload"), filename);

                Photo.SaveAs(path);

                blog.Photo = filename;
            }
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Fullname", blog.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", blog.CategoryId);
            return View(blog);
        }

        // GET: AdminPanel/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: AdminPanel/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Upload"), blog.Photo));
            db.Blogs.Remove(blog);
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
