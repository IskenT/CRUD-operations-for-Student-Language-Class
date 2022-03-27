using LanguageClassManager.Data;
using LanguageClassManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageClassManager.Controllers
{
    public class LanguageClassController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguageClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<LanguageClass> language = _context.LanguageClasses.ToList();
            return View(language);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LanguageClass language = new LanguageClass();
            return View(language);
        }

        [HttpPost]
        public IActionResult Create(LanguageClass language)
        {
            _context.Add(language);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            LanguageClass language = _context.LanguageClasses.Find(id);
            if (id!=0)
            {
                _context.LanguageClasses.Remove(language);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            LanguageClass language = _context.LanguageClasses.Where(x => x.Id == id).FirstOrDefault();
            return View(language);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            LanguageClass language = _context.LanguageClasses.Find(id);
            return View(language);
        }

        [HttpPost]
        public IActionResult Edit(LanguageClass language)
        {
            if(ModelState.IsValid)
            {
                _context.LanguageClasses.Update(language);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(language);
        }
            

    }
}
