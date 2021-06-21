using AppTree.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace AppTree.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{applicationId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Domain.AggregateModels.ApplicationAggregate.Application), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Domain.AggregateModels.ApplicationAggregate.Application>> ApplicationsAsync([FromRoute]int applicationId)
        {
            if(applicationId == default)
            {
                return BadRequest("Need valid application id");
            }

            var result = await _mediator.Send(new GetApplicationQuery() { ApplicationId = applicationId });

            if (result == null)
            {
                return BadRequest($"No application found for id {applicationId}");
            }

            return result;
        }

    }
}
