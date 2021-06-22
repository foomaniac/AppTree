using System.Threading;
using System.Threading.Tasks;
using AppTree.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppTree.Api.Application.Queries
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
                .Include(app => app.ApplicationType)
                .Include(app => app.Dependencies)
                .Include(app => app.Environments)
                .ThenInclude(env => env.Host)
                .FirstOrDefaultAsync(m => m.Id == request.ApplicationId, cancellationToken: cancellationToken);
        }
    }
}
