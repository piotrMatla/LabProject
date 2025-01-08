﻿using LabProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace LabProject.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LabProjectDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DashboardController(UserManager<ApplicationUser> userManager, LabProjectDbContext context, SignInManager<ApplicationUser> signInManager) : base(userManager)
        {
            _userManager = userManager;
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Dodatkowa kontrola null
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            if (_context == null)
            {
                // Obsługa błędu, jeśli _context jest null
                return BadRequest("Database context is not available.");
            }

            SetCurrencySymbol();

            // Zsumowanie wszystkich wydatków użytkownika
            var totalExpenses = await _context.Transaction
                .Where(t => t.UserId == CurrentUser.Id)  
                .Join(_context.Categories,
                      t => t.CategoryId,
                      c => c.Id,
                      (t, c) => new { t, c })  
                .Where(x => x.c.Type == "Expense")  
                .SumAsync(x => x.t.Amount);

            // Zsumowanie wszystkich przychodów użytkownika
            var totalIncome = await _context.Transaction
                .Where(t => t.UserId == CurrentUser.Id)
                .Join(_context.Categories,
                      t => t.CategoryId,
                      c => c.Id,
                      (t, c) => new { t, c })
                .Where(x => x.c.Type == "Income")
                .SumAsync(x => x.t.Amount);

            // Zsumowanie wszystkich przychodów użytkownika z ostatnich 30 dni
            var monthIncome = await _context.Transaction
                .Where(t => t.UserId == CurrentUser.Id)
                .Where(t => t.AdditionDate >= DateTime.Now.AddDays(-30)) // Dodanie warunku daty
                .Join(_context.Categories,
                      t => t.CategoryId,
                      c => c.Id,
                      (t, c) => new { t, c })
                .Where(x => x.c.Type == "Income")
                .SumAsync(x => x.t.Amount);

            // Zsumowanie wszystkich wydatków użytkownika z ostatnich 30 dni
            var monthExpenses = await _context.Transaction
                .Where(t => t.UserId == CurrentUser.Id)
                .Where(t => t.AdditionDate >= DateTime.Now.AddDays(-30)) // Dodanie warunku daty
                .Join(_context.Categories,
                      t => t.CategoryId,
                      c => c.Id,
                      (t, c) => new { t, c })
                .Where(x => x.c.Type == "Expense")
                .SumAsync(x => x.t.Amount);


            var FirstName = CurrentUser?.FirstName;
            ViewBag.Message = $"Hello, <strong class='text-primary'>{FirstName}</strong>";
            ViewBag.Layout = "_Layout_Dashboard";

            ViewBag.Expenses = monthExpenses.ToString("C", ViewBag.currencyCustomFormat);
            ViewBag.Income = monthIncome.ToString("C", ViewBag.currencyCustomFormat);
            var totalExpansesIncome = totalIncome - totalExpenses;
            ViewBag.Balance = $"{(totalExpansesIncome < 0 ? "-" : string.Empty)} {Math.Abs(totalExpansesIncome).ToString("C", ViewBag.CurrencyCustomFormat)}";


            ViewBag.Categories = await _context.Categories.Where(c => c.UserId == CurrentUser.Id).ToListAsync();

            var transactionItems = await _context.Transaction
               .Where(i => i.UserId == CurrentUser.Id)
               .OrderByDescending(t => t.AdditionDate)
               .ThenByDescending(t => t.TransactionId)
               .Take(10)
               .ToListAsync();

            return View(transactionItems);
        }


        public async Task<IActionResult> AssignPremiumRole()
        {
            

            if (CurrentUser != null)
            {
                var isInRole = await _userManager.IsInRoleAsync(CurrentUser, "UserPremium");

                if (!isInRole)
                {
                    // Dodajemy rolę UserPremium do użytkownika
                    var result = await _userManager.AddToRoleAsync(CurrentUser, "UserPremium");

                    if (result.Succeeded)
                    {
                        // Przekierowanie do widoku Premium
                        await _signInManager.RefreshSignInAsync(CurrentUser);
                        return RedirectToAction("Premium");
                    }
                    else
                    {
                        // W przypadku błędu, np. gdy rola nie została przydzielona
                        return RedirectToAction("Error");
                    }
                }
            }
                

            return RedirectToAction("Error");
        }

        // GET: DashboardController/Details/5
        public ActionResult Premium()
        {
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
