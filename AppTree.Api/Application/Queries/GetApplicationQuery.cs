using MediatR;

namespace AppTree.Api.Application.Queries
{
    public class GetApplicationQuery : IRequest<Domain.AggregateModels.ApplicationAggregate.Application>
    {
        public int ApplicationId { get; set; }
    }
}
