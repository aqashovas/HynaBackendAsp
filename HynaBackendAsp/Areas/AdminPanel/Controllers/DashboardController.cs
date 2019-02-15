using HynaBackendAsp.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HynaBackendAsp.Areas.AdminPanel.Controllers
{
    //[Admin]
    public class DashboardController : Controller
    {
        // GET: AdminPanel/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}