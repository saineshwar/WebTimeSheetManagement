using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTimeSheetManagement.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();

            HttpCookie Cookies = new HttpCookie("WebTime");
            Cookies.Value = "";
            Cookies.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(Cookies);
            HttpContext.Session.Clear();
            Session.Abandon();

            return View("Error");
        }
    }
}