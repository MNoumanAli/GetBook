using GetBook.DataAccess.Data;
using GetBook.DataAccess.Data.Repository.IRepository;
using GetBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["Success"] = "Category Created Successfully.";
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var category = _unitOfWork.Category.Get(x => x.Id == id);
            if(category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Category.Save();
                TempData["Success"] = "Category Updated Successfully.";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var category = _unitOfWork.Category.Get(x => x.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            if (category == null) return NotFound();
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Category.Save();
            TempData["Success"] = "Category Deleted Successfully.";
            return RedirectToAction("Index");
        }
    }
}
