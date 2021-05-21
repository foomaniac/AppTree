using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppTree.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppTree.Application.Queries
{
    public class GetAllApplicationHostsQueryHandler : IRequestHandler<GetAllApplicationHostsQuery, IEnumerable<Domain.AggregateModels.HostAggregate.Host>>
    {
        private readonly AppTreeContext _context;

        public GetAllApplicationHostsQueryHandler(AppTreeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.AggregateModels.HostAggregate.Host>> Handle(GetAllApplicationHostsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Hosts.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
