using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppTree.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppTree.Application.Queries
{
    public class GetAllApplicationTypesQueryHandler : IRequestHandler<GetAllApplicationTypesQuery,IEnumerable<Domain.AggregateModels.ApplicationAggregate.ApplicationType>>
    {
        private readonly AppTreeContext _context;

        public GetAllApplicationTypesQueryHandler(AppTreeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.AggregateModels.ApplicationAggregate.ApplicationType>> Handle(GetAllApplicationTypesQuery request, CancellationToken cancellationToken)
        {
            return await _context.ApplicationTypes.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
