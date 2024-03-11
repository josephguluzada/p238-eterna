using EternaMVC.DAL;
using EternaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EternaMVC.Areas.Admin.Controllers;

[Area("admin")]
public class CategoryController : Controller
{
    private readonly EternaDbContext _context;

    public CategoryController(EternaDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Categories.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        if (!ModelState.IsValid) return View();

        if(await _context.Categories.AnyAsync(x=>x.Name.ToLower() == category.Name.ToLower()))
        {
            ModelState.AddModelError("Name", "Category is already exist!");
            return View();
        }

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var data = await _context.Categories.FindAsync(id);
        if (data is null) throw new NullReferenceException();

        return View(data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(Category category)
    {
        if (!ModelState.IsValid) return View();
        var existData = await _context.Categories.FindAsync(category.Id);
        if (existData is null) throw new NullReferenceException();

        if (await _context.Categories.AnyAsync(x => x.Name.ToLower() == category.Name.ToLower() 
            && existData.Name.ToLower() != category.Name.ToLower()))
        {
            ModelState.AddModelError("Name", "Category is already exist!");
            return View();
        }

        existData.Name = category.Name;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.Categories.FindAsync(id);
        if (data is null) return NotFound(); //404

        _context.Categories.Remove(data);
        await _context.SaveChangesAsync();

        return Ok(); //200
    }
}
