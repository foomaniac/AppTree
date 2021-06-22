using System.Threading;
using System.Threading.Tasks;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using MediatR;

namespace AppTree.Api.Application.Commands
{
    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, bool>
    {
        private readonly IApplicationRepository _applicationRepository;

        public CreateApplicationCommandHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public Task<bool> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
        {

            var newApplication = new Domain.AggregateModels.ApplicationAggregate.Application(request.Name,
                request.Summary, request.Repository, request.ApplicationTypeId);

            _applicationRepository.Add(newApplication);

            return _applicationRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
