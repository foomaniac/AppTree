using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using AppTree.Infrastructure;

namespace AppTree.Controllers
{
    public class DependenciesController : Controller
    {
        private readonly AppTreeContext _context;

        public DependenciesController(AppTreeContext context)
        {
            _context = context;
        }

        // GET: Dependencies
        public async Task<IActionResult> Index()
        {
            var appTreeContext = _context.Dependencies.Include(d => d.Application).Include(d => d.ParentApplication);
            return View(await appTreeContext.ToListAsync());
        }

        // GET: Dependencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependency = await _context.Dependencies
                .Include(d => d.Application)
                .Include(d => d.ParentApplication)
                .FirstOrDefaultAsync(m => m.ParentApplicationId == id);
            if (dependency == null)
            {
                return NotFound();
            }

            return View(dependency);
        }

        // GET: Dependencies/Create
        public IActionResult Create()
        {
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name");
            ViewData["ParentApplicationId"] = new SelectList(_context.Applications, "Id", "Name");
            return View();
        }

        // POST: Dependencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentApplicationId,ApplicationId")] Dependency dependency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name", dependency.ApplicationId);
            ViewData["ParentApplicationId"] = new SelectList(_context.Applications, "Id", "Name", dependency.ParentApplicationId);
            return View(dependency);
        }

        // GET: Dependencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependency = await _context.Dependencies.FindAsync(id);
            if (dependency == null)
            {
                return NotFound();
            }
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name", dependency.ApplicationId);
            ViewData["ParentApplicationId"] = new SelectList(_context.Applications, "Id", "Name", dependency.ParentApplicationId);
            return View(dependency);
        }

        // POST: Dependencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParentApplicationId,ApplicationId")] Dependency dependency)
        {
            if (id != dependency.ParentApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependencyExists(dependency.ParentApplicationId))
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
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name", dependency.ApplicationId);
            ViewData["ParentApplicationId"] = new SelectList(_context.Applications, "Id", "Name", dependency.ParentApplicationId);
            return View(dependency);
        }

        // GET: Dependencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependency = await _context.Dependencies
                .Include(d => d.Application)
                .Include(d => d.ParentApplication)
                .FirstOrDefaultAsync(m => m.ParentApplicationId == id);
            if (dependency == null)
            {
                return NotFound();
            }

            return View(dependency);
        }

        // POST: Dependencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dependency = await _context.Dependencies.FindAsync(id);
            _context.Dependencies.Remove(dependency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DependencyExists(int id)
        {
            return _context.Dependencies.Any(e => e.ParentApplicationId == id);
        }
    }
}
