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
                // Below line execute in infinite loops as below path is not found so updated code
                //Response.Redirect("~/Errorview/Error");

                // Updated code for redirect to Error page in general 
                //need to create separate page for Well known error. e.g. 404 Error
                Response.Redirect("~/Error/Error");


            }
            finally
            {
                ex = null;
            }

        }
    }
}
