using System.Collections.Generic;
using MediatR;

namespace AppTree.Api.Application.Queries
{
    public class GetAllApplicationsQuery : IRequest<IEnumerable<Domain.AggregateModels.ApplicationAggregate.Application>>
    {

    }
}
