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
    public class GetApplicationHostQueryHandler : IRequestHandler<GetApplicationHostQuery, Domain.AggregateModels.HostAggregate.Host>
    {
        private readonly AppTreeContext _context;

        public GetApplicationHostQueryHandler(AppTreeContext context)
        {
            _context = context;
        }

        public async Task<Domain.AggregateModels.HostAggregate.Host> Handle(GetApplicationHostQuery request, CancellationToken cancellationToken)
        {
            return await _context.Hosts.FirstOrDefaultAsync(host => host.Id == request.HostId,cancellationToken: cancellationToken);
        }
    }
}
