using EternaMVC.DAL;
using EternaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly EternaDbContext _context;

        public SliderController(EternaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();

            //if(slider.Title1.Length < 5)
            //{
            //    ModelState.AddModelError("nameof(slider.Title1)", "Title1 minimum 6 ola biler");
            //    return View();
            //}

            _context.Sliders.Add(slider);   
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x=>x.Id == id);

            if(slider == null) { throw new NullReferenceException(); };

            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            Slider existSlider = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);
            if (slider == null) { throw new NullReferenceException(); };

            existSlider.Title1 = slider.Title1;
            existSlider.Title2 = slider.Title2;
            existSlider.Desc = slider.Desc;
            existSlider.RedirectUrl = slider.RedirectUrl;
            existSlider.ImageUrl = slider.ImageUrl;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.Sliders.Find(id);
            if (data is null) return NotFound(); //404

            _context.Sliders.Remove(data);
            _context.SaveChanges();

            return Ok(); //200
        }
    }
}
