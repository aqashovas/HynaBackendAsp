using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HynaBackendAsp.Models;
using HynaBackendAsp.DAL;
using System.Web.Helpers;

namespace HynaBackendAsp.Areas.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private HynaContext db = new HynaContext();

        // GET: AdminPanel/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            if (ModelState.IsValid)
            {
                Admin adm = db.Admins.FirstOrDefault(a => a.Email == admin.Email);

                if (adm != null)
                {
                    if (Crypto.VerifyHashedPassword(adm.Password, admin.Password))
                    {
                        Session["AdminLogin"] = true;
                        Session["AdminId"] = adm.Id;
                        return RedirectToAction("index", "dashboard");
                    }
                }

                ModelState.AddModelError("summary", "Email or password incorret");
            }

            return View(admin);
        }
    }
}