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
    public class TransactionController : BaseController 
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private const int PageSize = 10;

        public TransactionController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager) : base(userManager)
        {
            _context = dbContext;
            _userManager = userManager;
        }


        // GET: TransactionController
        public async Task<IActionResult> TransactionList(int page = 1)
        {
            if (CurrentUser == null)
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
                culture = "en-US";
                ViewBag.CurrencySymbol = new RegionInfo(culture).CurrencySymbol;
            }

            var totalTransactions = await _context.Transaction
                .Where(i => i.UserId == CurrentUser.Id)
                .CountAsync();
            var totalPages = (int)Math.Ceiling(totalTransactions / (double)PageSize);

            ViewBag.CurrentCulture = culture;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            var transactionItems = await _context.Transaction
               .Where(i => i.UserId == CurrentUser.Id)
               .OrderByDescending(t => t.TransactionId)
               .Skip((page - 1) * PageSize) 
               .Take(PageSize)
               .ToListAsync();


            ViewBag.Categories = await _context.Categories.Where(c => c.UserId == CurrentUser.Id).ToListAsync();
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
            if (CurrentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Categories = await _context.Categories.Where(c => c.UserId == CurrentUser.Id).ToListAsync();
            return View(new Transaction());
        }

        [HttpPost]
        public IActionResult SaveMultiple([FromBody] List<Transaction> transactions)
        {
            
            if (transactions == null || !transactions.Any())
            {
                return BadRequest("No transactions provided.");
            }

            var totalTransactions = _context.Transaction
                .Where(i => i.UserId == CurrentUser.Id)
                .Count();

            foreach (var transaction in transactions)
            {
                
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { success = false, message = "Validation failed for one or more transactions." });
                }

                if (totalTransactions >= 50)
                {
                    return BadRequest(new { success = false, message = "Transaction limit reached." });
                }

                
                transaction.UserId = CurrentUser.Id;
                _context.Transaction.Add(transaction);
                totalTransactions++;
                _context.SaveChanges();

            }

            
            return Ok(new { success = true, message = "Transactions saved successfully." });
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction transaction)
        
        {
            try
            {
                transaction.UserId = CurrentUser.Id.ToString();
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
