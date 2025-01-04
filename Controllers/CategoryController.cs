using LabProject.Areas.Identity.Data;
using LabProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Xml.Linq;

namespace LabProject.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoryController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager) : base(userManager)
        {
            _context = dbContext;
            _userManager = userManager;
        }
        // GET: CategoryController
        public async Task<IActionResult> CategoryList()
        {
            if (CurrentUser == null)
            {
                
                
                return RedirectToAction("Login", "Account");
            }

            var categories = _context.Categories
            .Where(c => c.UserId == CurrentUser.Id)
            .ToList();



            return View(categories);
        }


        // GET: CategoryController/AddOrEdit
        public IActionResult AddOrEdit(int? id)

        // GET: CategoryController/AddOrEdit
        public IActionResult AddOrEdit(int? id)
        {
            
            if (id == null)
            {                

                return PartialView("_AddOrEditModal", new Category());
            } else
            {
                return View(_context.Categories.Find(id));

                //return PartialView("_AddOrEditModal",category);
            }
            
        }

        // POST: CategoryController/AddOrEdit
        // POST: CategoryController/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,IsDefault, UserId, Type")] Category category)
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,IsDefault, UserId, Type")] Category category)
        {
            if (CurrentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var existingCategory = await _context.Categories
        .Where(c => c.UserId == CurrentUser.Id && c.Name.ToLower() == category.Name.ToLower())
        .FirstOrDefaultAsync();

            if (existingCategory != null && existingCategory.Type == category.Type)
            {
                ModelState.AddModelError("Name", "A category with this name already exists.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    category.UserId = CurrentUser.Id.ToString();
                    if (category.Id == 0)
                    {
                        
                        _context.Categories.Add(category);
                    }
                    else
                    {
                        _context.Categories.Update(category);
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(CategoryList));
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                }
            }
            var categories = await _context.Categories
                .Where(c => c.UserId == CurrentUser.Id)
                .ToListAsync();
            return PartialView("_AddOrEditModal", category);
        }

        //GET: CategoryController/Edit/5
        //GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Categories.Find(id));
            return View(_context.Categories.Find(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            category.UserId = CurrentUser.Id.ToString();
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CategoryList));
            }
            catch
            {
                return View(category);
                return View(category);
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _context.Categories.Find(id);
            return View(result);
            var result = _context.Categories.Find(id);
            return View(result);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            var category = _context.Categories.Find(id);
            try
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(CategoryList));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "ERROR");
                return View(category);
            }
        }

        

        
    }
}
