using GetBook.DataAccess.Data.Repository.IRepository;
using GetBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GetBook.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var allProducts = _unitOfWork.Product.GetAll().ToList();
            return View(allProducts);
        }

        public IActionResult Detail(int id)
        {
            var product = _unitOfWork.Product.Get(x => x.Id == id);
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
