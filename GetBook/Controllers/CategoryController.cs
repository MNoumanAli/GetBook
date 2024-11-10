using GetBook.Data;
using GetBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db) 
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var categories = _db.Category.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var category = _db.Category.FirstOrDefault(x => x.Id == id);
            if(category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.Category.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var category = _db.Category.FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            if (category == null) return NotFound();
            _db.Category.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
