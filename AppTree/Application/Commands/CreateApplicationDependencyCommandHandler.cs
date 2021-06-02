using System.Threading;
using System.Threading.Tasks;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using MediatR;

namespace AppTree.Application.Commands
{
    public class CreateApplicationDependencyCommandHandler : IRequestHandler<CreateApplicationDependencyCommand, bool>
    {
        private readonly IApplicationDependencyRepository _applicationDependencyRepository;

        public CreateApplicationDependencyCommandHandler(IApplicationDependencyRepository applicationDependencyRepository)
        {
            _applicationDependencyRepository = applicationDependencyRepository;
        }

        public Task<bool> Handle(CreateApplicationDependencyCommand request, CancellationToken cancellationToken)
        {

            var newApplicationDependency = new Domain.AggregateModels.ApplicationAggregate.Dependency(request.ParentApplicationId, request.ApplicationId);

            _applicationDependencyRepository.Add(newApplicationDependency);

            return _applicationDependencyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
