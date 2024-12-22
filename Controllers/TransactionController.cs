using LabProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabProject.Models;
using Microsoft.AspNetCore.Authorization;
using System.Xml.Linq;
using System.Drawing.Printing;
using System.Globalization;




namespace LabProject.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private const int PageSize = 10;

        public TransactionController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _context = dbContext;
            _userManager = userManager;
        }


        // GET: TransactionController
        public async Task<IActionResult> TransactionList(int page = 1)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {

                return RedirectToAction("Login", "Account");
            }

            var userLanguages = Request.Headers["Accept-Language"].ToString();
            var culture = userLanguages.Split(',').FirstOrDefault();
            try
            {
                var cultureInfo = CultureInfo.GetCultureInfo(culture);

                if (cultureInfo.IsNeutralCulture)
                {
                    culture = culture switch
                    {
                        "en" => "en-US",
                        "fr" => "fr-FR",
                        "pl" => "pl-PL",
                        _ => "en-US"
                    };
                }

                var regionInfo = new RegionInfo(culture);
                ViewBag.CurrencySymbol = regionInfo.CurrencySymbol;
            }
            catch (CultureNotFoundException)
            {
                // Logowanie błędu lub fallback na domyślną kulturę
                culture = "en-US";
                ViewBag.CurrencySymbol = new RegionInfo(culture).CurrencySymbol;
            }

            var totalTransactions = await _context.Transaction
                .Where(i => i.UserId == user.Id)
                .CountAsync();
            var totalPages = (int)Math.Ceiling(totalTransactions / (double)PageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            var transactionItems = await _context.Transaction
               .Where(i => i.UserId == user.Id)
               .OrderBy(t => t.AdditionDate)
               .Skip((page - 1) * PageSize) 
               .Take(PageSize)
               .ToListAsync();


            ViewBag.Categories = await _context.Categories.Where(c => c.UserId == user.Id).ToListAsync();
            ViewBag.CountedTransactions = totalTransactions;
            return View(transactionItems);

        }

        // GET: TransactionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionController/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Categories = await _context.Categories.Where(c => c.UserId == user.Id).ToListAsync();
            return View(new Transaction());
        }

        [HttpPost]
        public async Task<IActionResult> SaveMultiple([FromBody] List<Transaction> transactions)
        {
            var user = await _userManager.GetUserAsync(User);
            if (transactions == null || !transactions.Any())
            {
                return BadRequest("No transactions provided.");
            }

            
            foreach (var transaction in transactions)
            {
                if (ModelState.IsValid)
                {
                    transaction.UserId = user.Id.ToString();
                    _context.Transaction.Add(transaction);
                }
            }

             _context.SaveChangesAsync();

            return Ok(new { message = "Transactions saved successfully!" });
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction transaction)
        
        {
            var user = await _userManager.GetUserAsync(User);
            try
            {
                transaction.UserId = user.Id.ToString();
                _context.Transaction.Add(transaction);
                _context.SaveChanges();
                return RedirectToAction(nameof(TransactionList));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionController/Edit/5
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

        // GET: TransactionController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_context.Transaction.Find(id));
        }

        // POST: TransactionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            var transaction = _context.Transaction.Find(id);
            try
            {
                _context.Transaction.Remove(transaction);
                _context.SaveChanges();
                return RedirectToAction(nameof(TransactionList));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "ERROR");
                return PartialView("_TransactionDeleteModal", transaction);
            }
        }
    }
}
