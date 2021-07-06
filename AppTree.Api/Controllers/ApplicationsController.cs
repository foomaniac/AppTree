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
        [ProducesResponseType(typeof(IEnumerable<Models.ApplicationModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Models.ApplicationModel>>> ApplicationsAsync()
        {      
            var result = await _mediator.Send(new GetAllApplicationsQuery());

            var mappedResults = result.Select(app => new Models.ApplicationModel()
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
        [ProducesResponseType(typeof(Models.ApplicationModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Models.ApplicationModel>> ApplicationAsync([FromRoute]int id)
        {
            if(id == default)
            {
                return BadRequest("Need valid application id");
            }

            var result = await _mediator.Send(new GetApplicationDetailsQuery(id));

            if (result == null)
            {
                return BadRequest($"No application found for id {id}");
            }

            return Ok(result);
        }

    }
}
