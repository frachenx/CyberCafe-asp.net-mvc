using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberCafe.Models;
using CyberCafe.Models.ViewModels;
namespace CyberCafe.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            using(var db= new CYBERCAFEEntities())
            {
                int numActiveUsers = (from u in db.users
                                      where u.user_status == null
                                      select u).Count();
                int numComputers = (from c in db.computers
                                      select c).Count();
                return View(new DashboardViewModel { ActiveUsers = numActiveUsers, Computers = numComputers });
            }
        }
    }
}