using AppTree.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AppTree.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Domain.AggregateModels.HostAggregate.Host>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Domain.AggregateModels.HostAggregate.Host>>> HostsAsync()
        {      
            var result = await _mediator.Send(new GetAllApplicationHostsQuery());

            return Ok(result);
        }

        [HttpGet]
        [Route("{hostId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Domain.AggregateModels.HostAggregate.Host), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Domain.AggregateModels.HostAggregate.Host>> HostAsync([FromRoute]int hostId)
        {
            if(hostId == default)
            {
                return BadRequest("Need valid host id");
            }

            var result = await _mediator.Send(new GetApplicationHostQuery(hostId));

            if (result == null)
            {
                return BadRequest($"No host found for id {hostId}");
            }

            return result;
        }

    }
}
