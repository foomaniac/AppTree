using System.Collections.Generic;
using MediatR;

namespace AppTree.Api.Application.Queries
{
    public class GetAllApplicationHostsQuery : IRequest<IEnumerable<Domain.AggregateModels.HostAggregate.Host>>
    {

    }
}
