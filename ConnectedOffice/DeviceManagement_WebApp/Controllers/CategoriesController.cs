using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using System.Data;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Repository;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ConnectedOfficeContext _context;
        private CategoryRepository categoryRepository = new CategoryRepository();


        public CategoriesController(ConnectedOfficeContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {

            var results = categoryRepository.GetAll();

            return View(results);
        }
        //Get: Products/Details/1
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();
            var fetchProduct = categoryRepository.GetById(id);
            if (fetchProduct == null) return NotFound();
            return View(fetchProduct);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = categoryRepository.GetById(id);
            return View(category);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    categoryRepository.UpdateCategory(category);
                    categoryRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Category category = categoryRepository.GetById(id);
                categoryRepository.DeleteCategory(id);
                categoryRepository.Save();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Category category = categoryRepository.GetById(id);
            return View(category);
        }
        //[HttpGet]
        public async Task<IActionResult> Exists(string Find)
        {
            var find = from x in _context.Category select x;
            if (Find != null)
            {
                find = find.Where(x => x.CategoryName.Contains(Find) || x.CategoryDescription.Contains(Find));


            }
            return View(await find.ToListAsync());


        }

        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
