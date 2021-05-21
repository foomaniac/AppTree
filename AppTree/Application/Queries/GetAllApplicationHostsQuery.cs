using System.Collections.Generic;
using MediatR;

namespace AppTree.Application.Queries
{
    public class GetAllApplicationHostsQuery : IRequest<IEnumerable<Domain.AggregateModels.HostAggregate.Host>>
    {

    }
}
