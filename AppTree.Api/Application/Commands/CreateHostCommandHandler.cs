using System.Threading;
using System.Threading.Tasks;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using AppTree.Domain.AggregateModels.HostAggregate;
using MediatR;

namespace AppTree.Api.Application.Commands
{
    public class CreateHostCommandHandler : IRequestHandler<CreateHostCommand, bool>
    {
        private readonly IHostRepository _hostRepository;

        public CreateHostCommandHandler(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public Task<bool> Handle(CreateHostCommand request, CancellationToken cancellationToken)
        {
            var newHost = new Host(request.HostName, request.Domain, request.Location, request.Summary);

            _hostRepository.Add(newHost);

            return _hostRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
