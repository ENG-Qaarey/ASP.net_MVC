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

        // GET EDIT
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            ViewBag.Users = new SelectList(_context.Users, "UserId", "Name", employee.CreatedByUserID);
            return View(employee);
        }

        // POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("Get");
            }

            ViewBag.Users = new SelectList(_context.Users, "UserId", "Name", employee.CreatedByUserID);
            return View(employee);
        }

        // POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Get");
        }
    }
}