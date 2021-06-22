using System;
using System.Threading;
using System.Threading.Tasks;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using MediatR;

namespace AppTree.Api.Application.Commands
{
    public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationCommand, bool>
    {
        private readonly IApplicationRepository _applicationRepository;

        public UpdateApplicationCommandHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<bool> Handle(UpdateApplicationCommand request, CancellationToken cancellationToken)
        {
            var existingApplication = await _applicationRepository.GetAsync(request.ApplicationId);

            if (existingApplication == null)
            {
                throw new ArgumentException($"Application not found with id {request.ApplicationId}");
            }

            existingApplication.UpdateApplication(request.Name, request.Summary, request.Repository, request.ApplicationTypeId);

            _applicationRepository.Update(existingApplication);

            return await _applicationRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
