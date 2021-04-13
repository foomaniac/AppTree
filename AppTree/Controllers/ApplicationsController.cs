using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppTree.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using AppTree.Infrastructure;
using MediatR;

namespace AppTree.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly AppTreeContext _context;
        private readonly IMediator _mediator;

        public ApplicationsController(IMediator mediator,  AppTreeContext context)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        { 
            return View(await _mediator.Send(new GetAllApplicationsQuery()));
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .Include(app => app.Dependencies)
                .ThenInclude(app => app.Application)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }
            
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name");

            return View(application);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Summary,Repository")] Domain.AggregateModels.ApplicationAggregate.Application application)
        {
            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(application);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Summary,Repository")] Domain.AggregateModels.ApplicationAggregate.Application application)
        {
            if (id != application.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.Id))
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
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var application = await _context.Applications.FindAsync(id);
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Dependencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDependency([FromForm] int ParentApplicationId, [FromForm] int ApplicationId)
        {
            if (ModelState.IsValid)
            {
                var dependency = new Dependency()
                    {ApplicationId = ApplicationId, ParentApplicationId = ParentApplicationId};
                _context.Add(dependency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details),new { id = ParentApplicationId});
            }
      
            return RedirectToAction(nameof(Details), ParentApplicationId);
        }

        private bool ApplicationExists(int? id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }
    }
}
