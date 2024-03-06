using EternaMVC.DAL;
using EternaMVC.Models;
using EternaMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EternaMVC.Controllers;

public class HomeController : Controller
{
    private readonly EternaDbContext _context;

    public HomeController(EternaDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Slider> sliders = _context.Sliders.ToList();
        List<Feature> features = _context.Features.ToList();

        HomeViewModel viewModel = new HomeViewModel()
        {
            Sliders = sliders,
            Features = features
        };
        return View(viewModel);
    }
}
