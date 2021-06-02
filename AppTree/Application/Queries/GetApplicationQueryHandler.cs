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
    public class GetApplicationQueryHandler : IRequestHandler<GetApplicationQuery, Domain.AggregateModels.ApplicationAggregate.Application>
    {
        private readonly AppTreeContext _context;

        public GetApplicationQueryHandler(AppTreeContext context)
        {
            _context = context;
        }

        public async Task<Domain.AggregateModels.ApplicationAggregate.Application> Handle(GetApplicationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Applications
                .Include(app => app.Dependencies)
                .Include(app => app.Environments)
                .FirstOrDefaultAsync(m => m.Id == request.ApplicationId, cancellationToken: cancellationToken);
        }
    }
}
