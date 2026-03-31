using Microsoft.AspNetCore.Mvc;
using Users.Data;
using Users.Models;

namespace Users.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersDBcontext _context;

        public UsersController(UsersDBcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UsersModel user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Get));
            }

            return View(user);
        }

        public IActionResult Get()
        {
            return View(_context.Users.ToList());
        }
    }
}
