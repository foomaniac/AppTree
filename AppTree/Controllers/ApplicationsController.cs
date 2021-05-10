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
using AppTree.Models;
using MediatR;

namespace AppTree.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly AppTreeContext _context;
        private readonly IMediator _mediator;

        public ApplicationsController(IMediator mediator, AppTreeContext context)
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
        public async Task<IActionResult> Details(int id)
        {
            var application = await _mediator.Send(new GetApplicationQuery() {ApplicationId = id});
            if (application == null)
            {
                return NotFound();
            }

            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name");

            return View(application);
        }

        // GET: Applications/Create
        public async Task<IActionResult> Create()
        {
            var applicationTypes = await _mediator.Send(new GetAllApplicationTypesQuery());

            ViewData["ApplicationTypes"] = new SelectList(applicationTypes, "Id", "Type");

            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ApplicationTypeId,Name,Summary,Repository")] CreateApplicationViewModel application)
        {
            if (ModelState.IsValid)
            {
                var newApplication = new Domain.AggregateModels.ApplicationAggregate.Application(application.Name,
                    application.Summary, application.Repository, application.ApplicationTypeId);

                _context.Add(newApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(application);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var application = await _mediator.Send(new GetApplicationQuery() {ApplicationId = id});
            if (application == null)
            {
                return NotFound();
            }

            var applicationTypes = await _mediator.Send(new GetAllApplicationTypesQuery());

            ViewData["ApplicationTypes"] = new SelectList(applicationTypes, "Id", "Type");

            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,
            [Bind("Id,Name,Summary,Repository")] Domain.AggregateModels.ApplicationAggregate.Application application)
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
        public async Task<IActionResult> CreateDependency([FromForm] int ParentApplicationId,
            [FromForm] int ApplicationId)
        {
            if (ModelState.IsValid)
            {
                var dependency = new Dependency()
                    {ApplicationId = ApplicationId, ParentApplicationId = ParentApplicationId};
                _context.Add(dependency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new {id = ParentApplicationId});
            }

            return RedirectToAction(nameof(Details), new { id = ParentApplicationId });
        }

        private bool ApplicationExists(int? id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEnvironment([FromForm] int ApplicationId, [FromForm] string EnvironmentName,
            [FromForm] string Host, [FromForm] string Url)
        {
            var appEnvironment = new ApplicationEnvironment()
                {ApplicationId = ApplicationId, EnvironmentName = EnvironmentName, Host = Host, Url = Url};

            await _context.ApplicationEnvironments.AddAsync(appEnvironment);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new {id = ApplicationId});
        }
    }
}

