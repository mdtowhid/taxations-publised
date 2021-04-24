using System.Web;
using System.Web.Mvc;
using Taxations.BusinessLogic;

namespace Taxations
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ActionInterceptor());
        }
    }
}
