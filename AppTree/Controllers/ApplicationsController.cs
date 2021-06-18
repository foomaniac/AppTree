using System.Threading.Tasks;
using AppTree.Application.Commands;
using AppTree.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppTree.Models;
using MediatR;

namespace AppTree.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly IMediator _mediator;

        public ApplicationsController(IMediator mediator)
        {
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

            var applications = await _mediator.Send(new GetAllApplicationsQuery());
            var applicationHosts = await _mediator.Send(new GetAllApplicationHostsQuery());
            ViewData["Applications"] = new SelectList(applications, "Id", "Name");
            ViewData["Hosts"] = new SelectList(applicationHosts, "Id", "HostName");

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
                var newApplicationCommand = new CreateApplicationCommand(application.Name, application.Summary,
                    application.Repository, application.ApplicationTypeId);

               var success = await _mediator.Send(newApplicationCommand);
               if (success)
               {
                   return RedirectToAction(nameof(Index));
               }
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
        public async Task<IActionResult> Edit(int id,
            [Bind("ApplicationTypeId,Name,Summary,Repository")] CreateApplicationViewModel applicationModel)
        {
            if (id == default)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _mediator.Send(new UpdateApplicationCommand(id, applicationModel.Name,
                    applicationModel.Summary, applicationModel.Repository, applicationModel.ApplicationTypeId));

                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(applicationModel);
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
                var success =
                   await _mediator.Send(new CreateApplicationDependencyCommand(ParentApplicationId, ApplicationId));

                return RedirectToAction(nameof(Details), new {id = ParentApplicationId});
            }

            return RedirectToAction(nameof(Details), new { id = ParentApplicationId });
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEnvironment([FromForm] int ApplicationId, [FromForm] string EnvironmentName,
            [FromForm] int HostId, [FromForm] string Url)
        {
            var success =
                await _mediator.Send(
                    new CreateApplicationEnvironmentCommand(EnvironmentName, HostId, Url, ApplicationId));

            return RedirectToAction(nameof(Details), new { id = ApplicationId });
        }
    }
}

