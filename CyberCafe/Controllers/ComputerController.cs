using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberCafe.Models.TableViewModels;
using CyberCafe.Models.ViewModels;
using CyberCafe.Models;
namespace CyberCafe.Controllers
{
    public class ComputerController : Controller
    {
        // GET: Computer
        public ActionResult Index()
        {
            List<ComputerTableViewModel> lst = null;
            using(var db = new CYBERCAFEEntities())
            {
                lst = (from c in db.computers
                       select new ComputerTableViewModel
                       {
                           Id=c.computer_id,
                           Name=c.computer_name
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            ComputerViewModel computer = null;
            using(var db =  new CYBERCAFEEntities())
            {
                computer = (from c in db.computers
                            where c.computer_id==ID
                           select new ComputerViewModel
                           {
                               Id=c.computer_id,
                               Name=c.computer_name,
                               Location=c.computer_location,
                               IP=c.computer_ip
                           }).First();
            }
            return View(computer);
        }

        [HttpPost]
        public ActionResult Edit(ComputerViewModel model)
        {
            if (ModelState.IsValid)
            {
                using(var db= new CYBERCAFEEntities())
                {
                    computers computer = db.computers.Find(model.Id);
                    computer.computer_name = model.Name;
                    computer.computer_location = model.Location;
                    computer.computer_ip = model.IP;
                    db.Entry(computer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Redirect(Url.Content("~/Computer"));
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ComputerViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                using(var db= new CYBERCAFEEntities())
                {
                    computers oComputer = new computers
                    {
                        computer_name = model.Name,
                        computer_location = model.Location,
                        computer_ip = model.IP
                    };
                    db.computers.Add(oComputer);
                    db.SaveChanges();
                    return Redirect(Url.Content("~/Computer"));
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}