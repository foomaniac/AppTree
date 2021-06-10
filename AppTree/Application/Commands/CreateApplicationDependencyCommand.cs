using MediatR;

namespace AppTree.Application.Commands
{
    public class CreateApplicationDependencyCommand : IRequest<bool>
    {
        public int ParentApplicationId { get; set; }
        public int ApplicationId { get; }

        public CreateApplicationDependencyCommand(int parentApplicationId, int applicationId)
        {
            ParentApplicationId = parentApplicationId;
            ApplicationId = applicationId;
        }
    }
}
