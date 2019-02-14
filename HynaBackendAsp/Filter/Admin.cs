using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HynaBackendAsp.Filter
{
    public class Admin: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["AdminLogin"] == null)
            {
                filterContext.Result = new RedirectResult("~/adminpanel");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}