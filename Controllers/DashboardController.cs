using LabProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace LabProject.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LabProjectDbContext _context;

        public DashboardController(UserManager<ApplicationUser> userManager, LabProjectDbContext context)
        {
            _userManager = userManager;
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Dodatkowa kontrola null
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (_context == null)
            {
                // Obsługa błędu, jeśli _context jest null
                return BadRequest("Database context is not available.");
            }

            // Zsumowanie wszystkich wydatków użytkownika
            var totalExpenses = await _context.Transaction
                .Where(t => t.UserId == currentUser.Id)  
                .Join(_context.Categories,
                      t => t.CategoryId,
                      c => c.Id,
                      (t, c) => new { t, c })  
                .Where(x => x.c.Type == "Expense")  
                .SumAsync(x => x.t.Amount);  


            var FirstName = currentUser?.FirstName;
            ViewBag.Message = $"Hello, <strong class='text-primary'>{FirstName}</strong>";
            ViewBag.Layout = "_Layout_Dashboard";
            ViewBag.Expenses = totalExpenses;
            return View();
        }

        

        // GET: DashboardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashboardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
