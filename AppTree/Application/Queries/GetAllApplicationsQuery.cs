using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace AppTree.Application.Queries
{
    public class GetAllApplicationsQuery : IRequest<IEnumerable<Domain.AggregateModels.ApplicationAggregate.Application>>
    {

    }
}
