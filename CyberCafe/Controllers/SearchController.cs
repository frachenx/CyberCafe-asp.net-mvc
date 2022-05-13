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
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<UsersTableViewModel> lstUsers = null;
                using(var db=new CYBERCAFEEntities())
                {
                    lstUsers = (from u in db.users
                                where u.user_name.StartsWith(model.Search)
                                select new UsersTableViewModel { 
                                    Id=u.user_id,
                                    Name=u.user_name,
                                    EntryID=u.user_id_proof
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