using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebTimeSheetManagement.Filters;

namespace WebTimeSheetManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new UserAuditFilter());
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["TimesheetDBEntities"].ToString());
        }


        void Application_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();
            if (ex == null || ex.Message.StartsWith("File"))
            {
                return;
            }
            try
            {
                Server.ClearError();
                Response.Redirect("~/Errorview/Error");
            }
            finally
            {
                ex = null;
            }

        }
    }
}
