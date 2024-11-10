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
            _db.Category.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
