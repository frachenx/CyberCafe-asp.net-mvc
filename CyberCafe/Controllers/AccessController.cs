using CyberCafe.Models;
using CyberCafe.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberCafe.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "Admin Login";
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLoginViewModel model)
        {
            ViewBag.Title = "Admin Login";
            if (ModelState.IsValid)
            {
                using (CYBERCAFEEntities db = new CYBERCAFEEntities())
                {
                    var lst = (from d in db.admin
                               where d.admin_user_name == model.Username && d.admin_password == model.Password
                               select d);
                    if (lst.Count() > 0)
                    {
                        Session["Admin"] = lst.First();
                        return Redirect(Url.Content("~/Dashboard/"));
                    }
                    else
                    {
                        ModelState.AddModelError("error", "Invalid Login");
                        return View(model);
                    }
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}