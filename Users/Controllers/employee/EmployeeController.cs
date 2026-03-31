using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Users.Data;
using Users.Models;

namespace Users.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UsersDBcontext _context;

        public EmployeeController(UsersDBcontext context)
        {
            _context = context;
        }

        // LIST
        public IActionResult Get()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        // GET ADD
        public IActionResult Add()
        {
            ViewBag.Users = new SelectList(_context.Users, "UserId", "Name");
            return View();
        }

        // POST ADD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Get");
            }

            // reload dropdown if validation fails
            ViewBag.Users = new SelectList(_context.Users, "UserId", "Name");
            return View(employee);
        }
    }
}