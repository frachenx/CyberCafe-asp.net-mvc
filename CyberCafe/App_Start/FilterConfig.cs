using System.Web;
using System.Web.Mvc;
using CyberCafe.Filters;
namespace CyberCafe
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerifySession());
        }
    }
}
