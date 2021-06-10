using System.Collections.Generic;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using MediatR;

namespace AppTree.Application.Queries
{
    public class GetAllApplicationTypesQuery : IRequest<IEnumerable<ApplicationType>>
    {
        public GetAllApplicationTypesQuery()
        {
        }

    }
}
