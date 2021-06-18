using System;
using System.Threading;
using System.Threading.Tasks;
using AppTree.Domain.AggregateModels.HostAggregate;
using MediatR;

namespace AppTree.Application.Commands
{
    public class UpdateHostCommandHandler : IRequestHandler<UpdateHostCommand, bool>
    {
        private readonly IHostRepository _hostRepository;

        public UpdateHostCommandHandler(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public async Task<bool> Handle(UpdateHostCommand request, CancellationToken cancellationToken)
        {
            var existingHost = await _hostRepository.GetAsync(request.Id);

            if (existingHost == null)
            {
                throw new ArgumentException($"Host not found with id {request.Id}");
            }

            existingHost.UpdateHost(request.HostName, request.Domain, request.Location, request.Summary);

            _hostRepository.Update(existingHost);

            return await _hostRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
