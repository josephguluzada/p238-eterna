using EternaMVC.DAL;
using EternaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EternaMVC.Areas.Admin.Controllers;

[Area("admin")]
public class ProductController : Controller
{
    private readonly EternaDbContext _context;

    public ProductController(EternaDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Products.Include(x=>x.Category).Include(x=>x.ProductImages).ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = await _context.Categories.ToListAsync();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        ViewBag.Categories = await _context.Categories.ToListAsync();
        if (!ModelState.IsValid)
        {
            return View();
        }

        await _context.AddAsync(product);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
