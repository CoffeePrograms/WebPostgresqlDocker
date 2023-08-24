using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using WebPostgresqlDemo.Models;
using WebPostgresqlDemo.Services;

namespace WebPostgresqlDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _context;
        private IUserService _userService;

        public UserController(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var list = await
                _context.Users.AsNoTracking().Select(user =>
                new UserModel()
                {
                    Id = user.Id,
                    Name = user.Name ?? "",
                    Email = user.Email ?? "",
                }).ToListAsync();
            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            UserModel user = await _context.Users.Where(p => p.Id == id)
                .SingleAsync();
            if (user == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            var user = await _context.Users
                        .Where(p => p.Id == id)
                        .SingleAsync();

            if (user == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            UserModel? user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserModel? user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<ActionResult> VerifyEmail(string email)
        {
            if (! await _userService.VerifyEmail(_context, email))
            {
                return Json($"Email {email} is already in use.");
            }

            return Json(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}