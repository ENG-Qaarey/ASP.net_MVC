using Microsoft.AspNetCore.Mvc;
using Users.Data;
using Users.Models;

namespace Users.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UsersDBcontext _context;

        public StudentsController(UsersDBcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(StudentsModel student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Get));
            }

            return View(student);
        }

        public IActionResult Get()
        {
            return View(_context.Students.ToList());
        }
    }
}
