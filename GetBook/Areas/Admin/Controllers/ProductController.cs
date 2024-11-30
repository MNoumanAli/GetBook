using GetBook.DataAccess.Data.Repository;
using GetBook.DataAccess.Data.Repository.IRepository;
using GetBook.Models;
using GetBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GetBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var products = _unitOfWork.Product.GetAll().ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> categoryList = _unitOfWork.Category.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                });
            ProductVM productVM = new ProductVM()
            {
                CategoryList = categoryList,
                Product = new Product(),
            };

            return View(productVM);
        }

        [HttpPost]
        public IActionResult Create(ProductVM productvm)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productvm.Product);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            productvm.CategoryList = _unitOfWork.Category.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                });
            return View(productvm);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var product = _unitOfWork.Product.Get(option => option.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            var product = _unitOfWork.Product.Get(option => option.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            if(product == null) return NotFound();
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["Success"] = "Product Deleted Successfully.";
            return RedirectToAction("Index");
        }
    }
}
