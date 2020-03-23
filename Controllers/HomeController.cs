using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NinjaCore.Models;

namespace NinjaCore.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db;
        public HomeController(UserContext context)
        {
            db = context;
        }

        public IActionResult Logo()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View(db.Users.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {         
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {            
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }            
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //User user = db.Users.FirstOrDefault(u => u.Id == id);
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            //db.Entry(user).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");       
        }
    }
}
