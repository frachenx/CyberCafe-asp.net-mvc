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
    public class UserController : Controller
    {
        // GET: view all active users
        public ActionResult Index()
        {
            List<UsersTableViewModel> userList = null;
            using (var db = new CYBERCAFEEntities()) {
                userList = (from u in db.users
                            where u.user_status==null
                            select new UsersTableViewModel
                            {
                                Id=u.user_id,
                                EntryID=u.user_id_proof,
                                Name=u.user_name
                            }).ToList();
            }
                return View(userList);
        }

        public ActionResult Archive()
        {
            List<UsersTableViewModel> lst = null;
            using(var db = new CYBERCAFEEntities())
            {
                lst = (from u in db.users
                       where u.user_status != null
                       select new UsersTableViewModel
                       {
                           Id=u.user_id,
                           EntryID=u.user_id_proof,
                           Name=u.user_name
                       }).ToList();
            }
            return View(lst);
        }
        [HttpGet]
        public ActionResult Add()
        {
            using (CYBERCAFEEntities db = new CYBERCAFEEntities())
            {
                SelectList computerList = null;
                computerList = new SelectList(db.computers,"computer_id","computer_name");
                ViewBag.ComputerList = computerList.ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                using(var db = new CYBERCAFEEntities())
                {
                    var oUser = new users
                    {
                        user_name = model.Name,
                        user_address = model.Address,
                        user_number = model.Contact,
                        user_email = model.Email,
                        computer_id = model.Computer.ToString(),
                        user_id_proof = model.IdProof,
                        user_in_time = DateTime.Now
                    };
                    db.users.Add(oUser);
                    db.SaveChanges();
                    return Redirect("~/User");
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult ViewUser(int id)
        {
            
            UserViewModel oUser = null;
            using(var db = new CYBERCAFEEntities())
            {
                oUser = (from u in db.users
                        where u.user_id == id
                        select new UserViewModel
                        {
                            Id=u.user_id,
                            EntryID=u.user_id_proof,
                            Name=u.user_name,
                            Address=u.user_address,
                            Contact=u.user_number,
                            Email=u.user_email,
                            ComputerID= u.computer_id,
                            IdProof=u.user_id_proof,
                            InTime=u.user_in_time,
                            Status=u.user_status
                        }).First(); 
            }
            string computerName = "";
            int computerID = Int32.Parse(oUser.ComputerID);
            using(var db = new CYBERCAFEEntities())
            {
                computerName = (from c in db.computers
                                where c.computer_id==computerID
                                select c.computer_name).First();
            }
            oUser.ComputerName = computerName;
            return View(oUser);
        }

        [HttpPost]
        public ActionResult ViewUser(UserViewModel model)
        {
            if (ModelState.IsValid && model.Remark!=null && model.Status!=null)
            {
                using(var db = new CYBERCAFEEntities())
                {
                    var oUser = db.users.Find(model.Id);
                    oUser.user_remark = model.Remark;
                    oUser.user_fee = model.Fee;
                    oUser.user_status = model.Status;
                    oUser.user_out_time = DateTime.Now;
                    db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Redirect(Url.Content("~/User"));
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}