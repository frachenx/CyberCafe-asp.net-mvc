using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberCafe.Models;
using CyberCafe.Models.ViewModels;
using CyberCafe.Models.TableViewModels;
namespace CyberCafe.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult DatesDetail(ReportViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<UsersTableViewModel> lstUsers = null;
                using (var db = new CYBERCAFEEntities())
                {
                    lstUsers = (from u in db.users
                                where u.user_in_time >= model.Start && u.user_in_time < model.End
                                select new UsersTableViewModel
                                {
                                    Id = u.user_id,
                                    Name = u.user_name,
                                    EntryID = u.user_id_proof
                                }).ToList();
                }
                model.Users = lstUsers;
                return View(model);
            }
            else
            {
                return View(model);
            }
        }
    }
}