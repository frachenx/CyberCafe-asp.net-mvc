using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberCafe.Models;
using CyberCafe.Models.ViewModels;
namespace CyberCafe.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin Profile
        public ActionResult Index()
        {
            admin oAdmin=(admin) Session["Admin"];
            AdminViewModel vmAdmin = new AdminViewModel
            {
                Id = oAdmin.admin_id,
                Name=oAdmin.admin_name,
                Username=oAdmin.admin_user_name,
                Contact=oAdmin.admin_contact_number,
                Email=oAdmin.admin_email
            };
            return View(vmAdmin);
        }

        [HttpPost] //Admin Profile
        public ActionResult Index(AdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CYBERCAFEEntities())
                {
                    admin dbAdmin = db.admin.Find(model.Id);
                    dbAdmin.admin_name = model.Name;
                    dbAdmin.admin_user_name = model.Username;
                    dbAdmin.admin_contact_number = model.Contact;
                    dbAdmin.admin_email = model.Email;
                    db.Entry(dbAdmin).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                ModelState.AddModelError("error", "Failed to update admin profile");
            }
            return View(model);
        }

        [HttpGet] //API TO CHECK CURRENT PASSWORD
        public string CheckPassword(string mPassword)
        {
            admin oAdmin = (admin)Session["Admin"];
            return (oAdmin.admin_password == mPassword).ToString();
            //return mPassword;
        }

        [HttpGet] //Change Admin Password
        public ActionResult Password()
        {
            admin oAdmin = (admin)Session["Admin"];
            AdminPasswordViewModel vmAdminPassword = new AdminPasswordViewModel
            {
                Id = oAdmin.admin_id
            };
            return View(vmAdminPassword);
        }

        [HttpPost] //Change Admin Password
        public ActionResult Password(AdminPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                using(var db= new CYBERCAFEEntities())
                {
                    admin oAdmin = db.admin.Find(model.Id);
                    if (oAdmin!=null) {
                        oAdmin.admin_password = model.NewPassword;
                        db.Entry(oAdmin).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                ModelState.AddModelError("success", "Changed password correctly");

            }
            else
            {
                ModelState.AddModelError("error", "Failed to change password");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            return Redirect("~/Access/Login");
        }


    }
}