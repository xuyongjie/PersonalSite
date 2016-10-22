using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XYJPersonalSite.Data;
using XYJPersonalSite.Models.BusinessModels;
using XYJPersonalSite.Repo;

namespace XYJPersonalSite.Controllers
{
    public class BlogTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BaseRepo<BlogType, string> _repo;

        public BlogTypesController(ApplicationDbContext context)
        {
            _context = context;
            _repo = new BlogTypeRepo(_context);  
        }

        // GET: BlogTypes
        public async Task<IActionResult> Index()
        {
            return PartialView(await _repo.GetAll());
        }


        // GET: BlogTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeName,ThisTypeBlogCount,TypeDesc")] BlogType blogType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(blogType);
        }



        // POST: BlogTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TypeName,ThisTypeBlogCount,TypeDesc")] BlogType blogType)
        {
            if (id != blogType.TypeName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogTypeExists(blogType.TypeName))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(blogType);
        }

        // POST: BlogTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var blogType = await _context.BlogTypes.SingleOrDefaultAsync(m => m.TypeName == id);
            _context.BlogTypes.Remove(blogType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlogTypeExists(string id)
        {
            return _context.BlogTypes.Any(e => e.TypeName == id);
        }
    }
}
