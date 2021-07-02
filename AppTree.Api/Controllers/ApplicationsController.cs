using AppTree.Api.Application.Queries;
using AppTree.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppTree.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApplicationData>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ApplicationData>>> ApplicationsAsync()
        {      
            var result = await _mediator.Send(new GetAllApplicationsQuery());

            var mappedResults = result.Select(app => new ApplicationData()
            {
                Id = app.Id.Value,
                Name = app.Name,
                Repository = app.Repository,
                Summary = app.Summary,
                Type = app.ApplicationType?.Type
            });

            return Ok(mappedResults);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApplicationData), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApplicationData>> ApplicationAsync([FromRoute]int id)
        {
            if(id == default)
            {
                return BadRequest("Need valid application id");
            }

            var result = await _mediator.Send(new GetApplicationQuery(id));

            if (result == null)
            {
                return BadRequest($"No application found for id {id}");
            }

            return new ApplicationData()
            {
                Id = result.Id.Value,
                Name = result.Name,
                Repository = result.Repository,
                Summary = result.Summary,
                Type = result.ApplicationType?.Type
            };
        }

    }
}
