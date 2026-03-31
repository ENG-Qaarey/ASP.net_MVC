using Microsoft.AspNetCore.Mvc;
using Users.Data;
using Users.Models;

namespace Users.Controllers
{
    public class TeachersController : Controller
    {
        private readonly UsersDBcontext _context;

        public TeachersController(UsersDBcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Teachers.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TeachersModel teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Get));
            }

            return View(teacher);
        }

        public IActionResult Get()
        {
            return View(_context.Teachers.ToList());
        }
    }
}
