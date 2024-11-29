using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LabProject.Models;
using LabProject.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace LabProject.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly AppDbContext _context;

        public UserAuthController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserAuthController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserAuthController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserAuthController/Create
        public ActionResult RegistrationForm()
        {
            return View();
        }

        // POST: UserAuthController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationForm(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return View("RegistrationSuccessful", user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while saving data.");
            }
            return View();
        }

        // GET: UserAuthController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserAuthController/Edit/5
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

        // GET: UserAuthController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserAuthController/Delete/5
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
