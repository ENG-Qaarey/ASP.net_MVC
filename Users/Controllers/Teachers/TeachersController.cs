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

        public IActionResult Edit(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TeachersModel teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Teachers.Update(teacher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Get));
            }

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return RedirectToAction(nameof(Get));
        }
    }
}
