using EternaMVC.DAL;
using EternaMVC.Models;
using EternaMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EternaMVC.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly EternaDbContext _context;
        public PortfolioController(EternaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            PortfolioViewModel model = new PortfolioViewModel()
            {
                Categories = _context.Categories.ToList(),
                Products = _context.Products
                        .Include(x => x.Category)
                        .Include(x => x.ProductImages).ToList()
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            Product? product = _context.Products
                        .Include(x=>x.Category)
                        .Include(x=>x.ProductImages)
                        .FirstOrDefault(x => x.Id == id);

            if (product is null) return View("Error");

            return View(product);
        }
    }
}
