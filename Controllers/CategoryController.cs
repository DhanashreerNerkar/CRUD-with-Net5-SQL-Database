using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreApp2.Data;
using NetCoreApp2.Models;

namespace NetCoreApp2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDataContext db;
        public CategoryController(ApplicationDataContext _db)
        { db = _db; }
        public IActionResult Index()
        {
            IEnumerable<Category> Category = db.Category;
            return View(Category);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category c)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            { return NotFound(); }

            var obj = db.Category.Find(id);

            if (obj == null)
            { return NotFound(); }

            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category c)
        {
            if (ModelState.IsValid)
            {
                db.Category.Update(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            { return NotFound(); }

            var obj = db.Category.Find(id);

            if (obj == null)
            { return NotFound(); }

            return View(obj);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteComfirmed(int? id)
        {
            var obj = db.Category.Find(id);
            if (obj == null)
            { return NotFound(); }
            
            db.Category.Remove(obj);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
