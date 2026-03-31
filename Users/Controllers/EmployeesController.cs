using Microsoft.AspNetCore.Mvc;
using Users.Data;
using Users.Models;

namespace Users.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UsersDBcontext _context;

        public EmployeesController(UsersDBcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Get));
            }

            return View(employee);
        }

        public IActionResult Get()
        {
            return View(_context.Employees.ToList());
        }
    }
}
