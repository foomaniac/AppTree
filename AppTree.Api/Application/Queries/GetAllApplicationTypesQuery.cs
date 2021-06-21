using System.Collections.Generic;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using MediatR;

namespace AppTree.Api.Application.Queries
{
    public class GetAllApplicationTypesQuery : IRequest<IEnumerable<ApplicationType>>
    {
        public GetAllApplicationTypesQuery()
        {
        }

    }
}
