using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
