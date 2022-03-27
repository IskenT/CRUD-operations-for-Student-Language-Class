using LanguageClassManager.Data;
using LanguageClassManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LanguageClassManager.Controllers
{
    public class StudentСontroller : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentСontroller(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Student> student = _context.Students.Include(x => x.LanguageClass).ToList();
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Student student = new Student();
            ViewBag.LanguageClasses = _context.LanguageClasses.OrderBy(x => x.Name).ToList();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageClasses = _context.LanguageClasses.OrderBy(x => x.Name).ToList();
            return View(student);

        }
        public IActionResult Details(int id)
        {
            Student student = _context.Students.
                Include(x => x.LanguageClass).
                Where(x => x.Id == id).FirstOrDefault();
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            Student student = _context.Students.Find(id);
            if(student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();     
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.LanguageClasses = _context.LanguageClasses.OrderBy(x => x.Name).ToList();
            Student student = _context.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if(ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageClasses = _context.LanguageClasses.OrderBy(x => x.Name).ToList();
            return View(student);
        }
    }
}