using System.Collections.Generic;
using MediatR;

namespace AppTree.Application.Queries
{
    public class GetAllApplicationsQuery : IRequest<IEnumerable<Domain.AggregateModels.ApplicationAggregate.Application>>
    {

    }
}
