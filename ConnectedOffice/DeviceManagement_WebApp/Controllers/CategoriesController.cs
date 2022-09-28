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
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // Create: displays the create page to fill in new category record
        public IActionResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        // this method allows to add and save data captured from the create view
        public ActionResult Create(Category category)
        {
            _categoryRepository.AddCategory(category);
            _categoryRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet] 
        // this method is the same the edit / and GetByIt. it displays a specific category record based on the id parsed onto it
        public ActionResult Update(int id)
        {
            return View(_categoryRepository.GetById(id));
        }
        [HttpPost]
        //this method adds and saves data captured from the update view and redirects to the index page
        public ActionResult Update(Category category)
        {
            _categoryRepository.UpdateCategory(category);
            _categoryRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        //deletes a record from the database based on the id parse through
        public ActionResult Delete(int id)
        {
            _categoryRepository.DeleteCategory(id);
            _categoryRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Category displayes all records in category table
        public async Task<IActionResult> Index()
        {
            var zone = _categoryRepository.GetAll();
            return View(zone);
        }
        /**
        // POST: Categories/Edit/5
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
                    categoryRepository.Update(category);
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

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
        **/
    }
}
