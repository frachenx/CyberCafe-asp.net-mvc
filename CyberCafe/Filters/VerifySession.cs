using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberCafe.Models;
using CyberCafe.Controllers;
namespace CyberCafe.Filters
{
    public class VerifySession :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (admin)HttpContext.Current.Session["Admin"];
            if (oUser == null)
            {
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Login");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Dashboard");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}