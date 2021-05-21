using System.Threading;
using System.Threading.Tasks;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using MediatR;

namespace AppTree.Application.Commands
{
    public class CreateApplicationEnvironmentCommandHandler : IRequestHandler<CreateApplicationEnvironmentCommand, bool>
    {
        private readonly IApplicationEnvironmentRepository _applicationEnvironmentRepository;

        public CreateApplicationEnvironmentCommandHandler(IApplicationEnvironmentRepository applicationEnvironmentRepository)
        {
            _applicationEnvironmentRepository = applicationEnvironmentRepository;
        }

        public Task<bool> Handle(CreateApplicationEnvironmentCommand request, CancellationToken cancellationToken)
        {
            var newApplicationEnv = new ApplicationEnvironment(request.EnvironmentName,request.HostId, request.Url, request.ApplicationId);

            _applicationEnvironmentRepository.Add(newApplicationEnv);

            return _applicationEnvironmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
