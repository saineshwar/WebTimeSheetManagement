using System.Web;
using System.Web.Mvc;
using WebTimeSheetManagement.Helpers;

namespace WebTimeSheetManagement
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           filters.Add(new ErrorLoggerAttribute());
        }
    }
}
