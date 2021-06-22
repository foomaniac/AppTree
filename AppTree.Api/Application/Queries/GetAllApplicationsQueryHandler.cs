using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppTree.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppTree.Api.Application.Queries
{
    public class GetAllApplicationsQueryHandler : IRequestHandler<GetAllApplicationsQuery, IEnumerable<Domain.AggregateModels.ApplicationAggregate.Application>>
    {
        private readonly AppTreeContext _context;

        public GetAllApplicationsQueryHandler(AppTreeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.AggregateModels.ApplicationAggregate.Application>> Handle(GetAllApplicationsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Applications.Include(app => app.ApplicationType).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
