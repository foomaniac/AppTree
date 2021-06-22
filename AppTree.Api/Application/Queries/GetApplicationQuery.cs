using MediatR;

namespace AppTree.Api.Application.Queries
{
    public class GetApplicationQuery : IRequest<Domain.AggregateModels.ApplicationAggregate.Application>
    {
        public GetApplicationQuery(int applicationId)
        {
            ApplicationId = applicationId;
        }

        public int ApplicationId { get;  }
    }
}
