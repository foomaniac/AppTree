using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppTree.Application.Queries;
using MediatR;

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
        public ActionResult Create(IFormCollection collection)
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

        // GET: HostsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            return View(await _mediator.Send(new GetApplicationHostQuery(id)));
        }

        // POST: HostsController/Edit/5
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

        // GET: HostsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HostsController/Delete/5
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
