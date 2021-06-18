using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppTree.Application.Queries;
using MediatR;
using AppTree.Models;
using AppTree.Application.Commands;

namespace AppTree.Controllers
{
    public class HostsController : Controller
    {
        private readonly IMediator _mediator;

        public HostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: HostsController
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllApplicationHostsQuery()));
        }

        // GET: HostsController/Details/5
        public async Task<IActionResult> DetailsAsync(int id)
        {
            return View(await _mediator.Send(new GetApplicationHostQuery(id)));
        }

        // GET: HostsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("HostName,Domain,Summary,Location")] CreateHostViewModel host)
        {
            if (ModelState.IsValid)
            {
                var success = await _mediator.Send(new CreateHostCommand(host.HostName, host.Domain, host.Location, host.Summary));

                if (success) {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(host);
        }

        // GET: HostsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            return View(await _mediator.Send(new GetApplicationHostQuery(id)));
        }


        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("HostName,Domain,Summary,Location")] CreateHostViewModel hostModel)
        {
            if (id == default)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _mediator.Send(new UpdateHostCommand(id, hostModel.HostName,
                    hostModel.Domain, hostModel.Location, hostModel.Summary));

                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(hostModel);
        }
    }
}
